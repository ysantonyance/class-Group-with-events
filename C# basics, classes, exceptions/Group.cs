using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace C__basics__classes__exceptions
{
    class Group
    {
        private List<Student> students;
        private string groupName;
        private const int maxCapacity = 25;

        public event Action<string> GroupPartyPlanned;
        public event Action<string> SessionSurvived;
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidGroupDataException("Group name can't be empty", "GroupName");
                }
                groupName = value;
            }
        }

        private string spec; //specialization

        public string Spec
        {
            get
            {
                return spec;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidGroupDataException("Specialization name can't be empty", "Spec");
                }
                spec = value;
            }
        }

        private int courseNumber;

        public int CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                if (value < 1 || value > 6)
                {
                    throw new InvalidGroupDataException("Course number must be in a range from 1 to 6", "CourseNumber");
                }
                courseNumber = value;
            }
        }

        public int Count
        {
            get
            {
                return students.Count;
            }
        }

        public Group()
        {
            students = new List<Student>();
            students.Add(new Student());
            groupName = "P45";
            spec = "C#";
            courseNumber = 1;
        }

        public Group(List<Student> students, string groupName, string spec, int courseNumber)
        {
            try
            {
                this.students = new List<Student>(students);
                GroupName = groupName;
                Spec = spec;
                CourseNumber = courseNumber;
                if (this.students.Count > maxCapacity)
                {
                    throw new GroupFullException("There's too many students in the group", this.students.Count);
                }
            }
            catch (GroupManagmentException ex)
            {
                Console.WriteLine($"Invalid creation of a group: {ex.Message}");
                throw;
            }
            
        }

        public Group(Group other)
        {
            students = new List<Student>(other.students);
            GroupName = other.groupName;
            Spec = other.spec;
            CourseNumber = other.courseNumber;
        }

        public void CheckSessionResult()
        {
            if (students.Count == 0)
                return;

            bool AllGreat = students.All(s => s.Passed() && s.GetAverageGrade() > 10);
            if (AllGreat)
            {
                GroupPartyPlanned?.Invoke("Pizza for everybody!");
            }

            bool AllPassed = students.All(s => s.Passed());
            if (AllPassed)
            {
                SessionSurvived?.Invoke("Yay, session iss over! Time to relax in the park.");
            }
        }

        public void Print()
        {
            Console.WriteLine($"Group name: {GroupName}");
            Console.WriteLine($"Specialization: {Spec}");
            Console.WriteLine($"Course number: {CourseNumber}");
            Console.WriteLine($"Student:");
            var sortedStudents = students.OrderBy(x => x.Surname).ToList();
            for (int i = 0; i < sortedStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedStudents[i].Surname} {sortedStudents[i].Firstname}");
            }
            Console.WriteLine();
        }

        public void AddStudent(Student student)
        {
            try
            {
                if (students.Count > maxCapacity)
                {
                    throw new GroupFullException("The group is full", students.Count);
                }

                if (student == null)
                {
                    throw new InvalidStudentDataException("Student can't be null", "Student");
                }
                students.Add(student);
                Console.WriteLine($"Student {student} was added to {groupName}");
            }
            catch (GroupFullException ex)
            {
                Console.WriteLine($"Invalid adding a student {ex.Message} \nPlaces: {ex.Full}");
                throw;
            }
            finally
            {
                //Console.WriteLine($"Done with trying to add a student to {groupName}");
            }
            
        }

        public void TransferStudent(Student student, Group fromGroup, Group toGroup)
        {
            try
            {
                if (student == null)
                {
                    throw new InvalidStudentDataException("Student can't be empty", "Student");
                }
                if (toGroup.students.Count > maxCapacity)
                {
                    throw new TransferFailedException("The group you wanted to move to is full", student.ToString());
                }
                if (!fromGroup.students.Contains(student))
                {
                    throw new StudentNotFoundException("We couldn't find the student in the group", student.ToString());
                }
                fromGroup.students.Remove(student);
                toGroup.students.Add(student);
                Console.WriteLine($"Student {student} was transfered from {fromGroup.GroupName} to {toGroup.GroupName}");
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Invalid transfer of {ex.Message}\nStudent: {ex.StudentName}");
                throw;
            }
            catch (GroupManagmentException ex)
            {
                Console.WriteLine($"Invalid transfer of {ex.Message}\nDetails: {ex.ErrorDetails}");
                throw;
            }
            finally
            {
                Console.WriteLine("Done with transfering a student");
            }
        }

        public void FailedStudents()
        {
            var failedStudents = students.Where(s => !s.Passed()).ToList();

            if (failedStudents.Count == 0)
            {
                Console.WriteLine("No failed students!");
                CheckSessionResult();
            }

            foreach (var student in failedStudents)
            {
                Console.WriteLine($"Student {student} failed");
            }

            int removedCount = students.RemoveAll(s => !s.Passed());
            Console.WriteLine($"{removedCount} student\\s was\\were removed from the group {groupName}");
            Console.WriteLine();
        }

        public void WorstStudent()
        {
            if (students.Count == 0)
            {
                return;
            }

            var worstStudent = students.OrderBy(s => s.GetAverageGrade()).First();

            Console.WriteLine("Worst student:");
            Console.WriteLine($"Name: {worstStudent.Surname} {worstStudent.Firstname}");
            Console.WriteLine($"Average grade: {worstStudent.GetAverageGrade():F2}");
            Console.WriteLine();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Group other)
            {
                Console.WriteLine("this is not a group or a pointer is null");
                return false;
            }

            return other.students.Count() == students.Count();
        }

        public static bool operator ==(Group group1, Group group2)
        {
            if (group1 is null)
                return group2 is null;

            if (group2 is null)
                return false;

            return group1.Equals(group2);
        }

        public static bool operator !=(Group group1, Group group2)
        {
            return !(group1 == group2);
        }

        public override int GetHashCode()
        {
            return students.Count.GetHashCode();
        }

        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= students.Count)
                    throw new IndexOutOfRangeException("Index is out of range");
                return students[index];
            }
        }

        public GroupEnumerator GetEnumerator()
        {
            return new GroupEnumerator(students);
        }


        public class GroupEnumerator
        {
            private List<Student> students;
            private int currentIndex;

            public GroupEnumerator(List<Student> students)
            {
                this.students = students;
                currentIndex = -1;
            }

            public Student Current
            {
                get
                {
                    return students[currentIndex];
                }
            }
            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < students.Count;
            }
            public void Reset()
            {
                currentIndex = -1;
            }
            public void Dispose() { }
        }
        public void Sort(IComparer<Student> comparer)
        {
            students.Sort(comparer);
        }

        public double GetAverageGrade()
        {
            return students.Average(s => s.GetAverageGrade());
        }

        public delegate bool StudentFilter(Student student);

        public List<Student> FilterStudents(StudentFilter filter)
        {
            return students.Where(s => filter(s)).ToList();
        }
    }
}
