using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    internal class Student
    {
        public event Action<string> LectureMissed;
        public event Action<int, string> AutomatReceived;
        public event Action<double, string> ScholarshipAwarded;

        private string firstName;

        public string Firstname
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStudentDataException("The name can't be empty", "FirstName");
                }
                firstName = value;
            }
        }

        private string surname;

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStudentDataException("Surname can't be empty", "Surname");
                }
                surname = value;
            }
        }

        public string FullName => $"{Surname} {Firstname}";

        private int studentNumber;

        public int StudentNumber
        {
            get
            {
                return studentNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidStudentDataException("Student's number must be a positive number", "StudentNumber");
                }
                studentNumber = value;
            }
        }

        private List<int> grades;

        public List<int> Grades
        {
            get
            {
                return grades;
            }
            set
            {
                grades = value;
                CheckScholarship();
            }
        }

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 16 || value > 100)
                    throw new InvalidStudentDataException("Age must be in a range from 16 to 100", "Age");
                age = value;
            }
        }

        public void CheckTime()
        {
            DateTime currentTime = DateTime.Now;
            DateTime lectureStart = DateTime.Today.AddHours(16).AddMinutes(45);

            if (currentTime > lectureStart)
                LectureMissed?.Invoke("Quickly turn on online-translation!");
        }

        public void CheckScholarship()
        {
            if (AverageGrade >= 10)
            {
                ScholarshipAwarded?.Invoke(AverageGrade, "Congrats! You receive scholarship!");
            }
        }

        public double AverageGrade
        {
            get
            {
                if (grades.Count == 0)
                    return 0;
                return grades.Average();
            }
        }

        public Student()
        {
            try
            {
                Firstname = "Karina";
                Surname = "Zinovieva";
                grades = new List<int>();
                Age = 16;
            }
            catch (StudentManagmentException ex)
            {
                Console.WriteLine($"Invalid creation of a student: {ex.Message}");
                throw;
            }

        }

        public Student(string firstName, string surname, int studentNumber, int age)
        {
            Firstname = firstName;
            Surname = surname;
            grades = new List<int>();
            Age = age;
        }

        public bool Passed()
        {
            if (grades.Count == 0)
            {
                return false;
            }

            return grades.All(grade => grade > 7);
        }

        public void AddGrade(int grade)
        {
            try
            {
                if (grade < 0 || grade > 12)
                {
                    throw new InvalidGradeException("\nA grade must be in a range from 0 to 12", grade);
                }
                grades.Add(grade);

                if (grade == 12)
                {
                    ScholarshipAwarded?.Invoke(grade, "avtomatom");
                }
                CheckScholarship();
                //Console.WriteLine($"A grade {grade} was added to {this}");
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine($"Invalid adding of a grade {ex.Message}\nDetails: {ex.ErrorDetails}");
                throw;
            }
            finally
            {
                //Console.WriteLine($"Done with loading grades for {this}");
            }


        }

        public double GetAverageGrade()
        {
            if (grades.Count == 0)
                return 0;
            return grades.Average();
        }

        public override string ToString()
        {
            return $"{Surname} {Firstname}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Student other)
            {
                Console.WriteLine("this is not a student or a pointer is null");
                return false;
            }

            return other.GetAverageGrade() == GetAverageGrade();
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (student1 is null)
                return student2 is null;

            if (student2 is null)
                return false;

            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        public static bool operator true(Student student)
        {
            return student is not null && student.GetAverageGrade() >= 7;
        }

        public static bool operator false(Student student)
        {
            return student is null || student.GetAverageGrade() < 7;
        }

        public override int GetHashCode()
        {
            return GetAverageGrade().GetHashCode();
        }

        public class AverageGradeComparer : IComparer<Student>
        {
            public int Compare(Student? a, Student? b)
            {
                if (a == null && b == null)
                    return 0;

                if (a == null)
                    throw new ArgumentNullException(nameof (a));

                if (b == null)
                    throw new ArgumentNullException(nameof (b));

                int Comparison = a.GetAverageGrade().CompareTo(b.GetAverageGrade());

                if (Comparison == 0)
                {
                    return string.Compare(a?.FullName, b?.FullName);
                }

                return Comparison;
            }
        }

        public class FullNameComparer : IComparer<Student>
        {
            public int Compare(Student? a, Student? b)
            {
                if (a == null && b == null)
                    return 0;

                int nameCompare = string.Compare(a?.FullName, b?.FullName);

                if (nameCompare != 0)
                    return nameCompare;

                return b.AverageGrade.CompareTo(a?.AverageGrade);
            }
        }
    }
}
