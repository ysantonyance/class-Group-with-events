using System;
using System.Runtime.CompilerServices;

namespace C__basics__classes__exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student1 = new Student("John", "Doe", 1, 19);
                student1.AddGrade(12);
                student1.AddGrade(12);
                student1.AddGrade(12);

                Student student2 = new Student("Jane", "Doe", 2, 30);
                student2.AddGrade(2);
                student2.AddGrade(2);
                student2.AddGrade(2);

                List<Student> students = new List<Student> { student1, student2 };

                Group group1 = new Group(students, "P45", "C#", 1);
                group1.Print();

                Group group2 = new Group(group1);
                group2.Print();

                List<Student> randomStudents = new List<Student>();

                Group group3 = new Group(randomStudents, "AB12", "JavaScript", 4);

                Student student3 = new Student("Bob", "Bobovich", 3, 42);
                student3.AddGrade(3);
                student3.AddGrade(3);
                student3.AddGrade(3);

                Student student4 = new Student("Bob", "Smith", 5, 23);
                student4.AddGrade(5);
                student4.AddGrade(5);
                student4.AddGrade(5);
                group1.AddStudent(student4);

                group1.AddStudent(student3);
                group1.Print();

                group1.TransferStudent(student3, group1, group2);
                group1.TransferStudent(student4, group1, group2);
                group2.Print();

                group1.WorstStudent();
                group1.FailedStudents();

                group2.WorstStudent();
                group2.FailedStudents();

                /*student1.AddGrade(50);*/

                /*Student BadStudent = new Student("", "Bad", -1);*/

                /////////////////////////////////////////////////////////////

                Student copycat1 = new Student("Yes", "No", 15, 16);
                copycat1.AddGrade(10);
                copycat1.AddGrade(11);
                randomStudents.Add(copycat1);

                Student copycat2 = new Student("No", "Yes", 16, 18);
                copycat2.AddGrade(10);
                copycat2.AddGrade(11);
                randomStudents.Add(copycat2);
                
                //group3.AddStudent(copycat1);
                //group3.AddStudent(copycat2);

                if (copycat1 == copycat2)
                {
                    Console.WriteLine("Students have the same average grade");
                }

                Student goodStudent = new Student("Good", "Student", 10, 17);
                goodStudent.AddGrade(8);
                goodStudent.AddGrade(9);

                Student averageStudent = new Student("Average", "Student", 11, 16);
                averageStudent.AddGrade(6);
                averageStudent.AddGrade(7);

                if (goodStudent)
                    Console.WriteLine($"{goodStudent} is a good student \navg: {goodStudent.GetAverageGrade()}");

                if (averageStudent)
                    Console.WriteLine($"{averageStudent} needs improvement \navg: {averageStudent.GetAverageGrade()}");

                Student anotherGood = new Student("Another", "Good", 12, 67);
                anotherGood.AddGrade(8);
                anotherGood.AddGrade(9);

                if (goodStudent == anotherGood)
                    Console.WriteLine($"Students have same average grade: {goodStudent.GetAverageGrade()}");

                Group smallGroup = new Group(new List<Student> { student1 }, "Small", "YesNo", 1);
                if (group1 != smallGroup)
                    Console.WriteLine("Groups have different amount of students");
                else
                    Console.WriteLine("Groups have the same amount of students");






                Random random = new Random();

                Student student10 = new Student("Ivan", "Ivanov", 11, 18);
                student10.AddGrade(random.Next(3, 13));
                student10.AddGrade(random.Next(3, 13));
                student10.AddGrade(random.Next(3, 13));
                randomStudents.Add(student10);

                Student student11 = new Student("Petro", "Petrov", 12, 19);
                student11.AddGrade(random.Next(3, 13));
                student11.AddGrade(random.Next(3, 13));
                student11.AddGrade(random.Next(3, 13));
                randomStudents.Add(student11);

                Student student12 = new Student("Maria", "Mariivna", 13, 20);
                student12.AddGrade(random.Next(3, 13));
                student12.AddGrade(random.Next(3, 13));
                student12.AddGrade(random.Next(3, 13));
                randomStudents.Add(student12);

                Student student13 = new Student("Oleg", "Olegovich", 14, 21);
                student13.AddGrade(random.Next(3, 13));
                student13.AddGrade(random.Next(3, 13));
                student13.AddGrade(random.Next(3, 13));
                randomStudents.Add(student13);

                Student student14 = new Student("Anna", "Anna", 15, 22);
                student14.AddGrade(random.Next(3, 13));
                student14.AddGrade(random.Next(3, 13));
                student14.AddGrade(random.Next(3, 13));
                randomStudents.Add(student14);

                Group group = new Group(students, "P45", "C#", 2);

                foreach (Student student in group)
                {
                    Console.WriteLine($"{student.FullName}: average grade = {student.GetAverageGrade():F2}");
                }

                group.Sort(new Student.AverageGradeComparer());
                foreach (Student student in group)
                {
                    Console.WriteLine($"{student.FullName}: average grade = {student.GetAverageGrade():F2}");
                }

                group.Sort(new Student.FullNameComparer());
                foreach (Student student in group)
                {
                    Console.WriteLine($"{student.FullName}: average grade = {student.GetAverageGrade():F2}");
                }























                Student niceStudent = new Student("Bohdan", "Good", 50, 19);
                niceStudent.AddGrade(12);
                niceStudent.AddGrade(11);
                niceStudent.AddGrade(10);

                Student Grade2 = new Student("Victor", "Twos", 51, 21);
                Grade2.AddGrade(2);
                Grade2.AddGrade(8);
                Grade2.AddGrade(9);

                Student noHW = new Student("Oleg", "NoGrades", 52, 23);

                Student longName = new Student("Christopher", "Longname", 53, 24);
                longName.AddGrade(7);
                longName.AddGrade(8);

                Student sameGrades1 = new Student("Ivan", "Samegrades", 54, 25);
                sameGrades1.AddGrade(8);
                sameGrades1.AddGrade(9);
                sameGrades1.AddGrade(10);

                Student sameGrades2 = new Student("Petro", "Twingrades", 55, 26);
                sameGrades2.AddGrade(10);
                sameGrades2.AddGrade(9);
                sameGrades2.AddGrade(8);

                Student evenGrades = new Student("Mykola", "Evencount", 56, 27);
                evenGrades.AddGrade(7);
                evenGrades.AddGrade(8);
                evenGrades.AddGrade(9);
                evenGrades.AddGrade(10);

                Student sumAbove50 = new Student("Dmytro", "Highsum", 57, 28);
                sumAbove50.AddGrade(12);
                sumAbove50.AddGrade(12);
                sumAbove50.AddGrade(12);
                sumAbove50.AddGrade(12);
                sumAbove50.AddGrade(12);

                List<Student> allCategoryStudents = new List<Student>
                {
                niceStudent,
                Grade2,
                noHW,
                longName,
                sameGrades1,
                sameGrades2,
                evenGrades,
                sumAbove50

                };

                Group fullHouseGroup = new Group(allCategoryStudents, "Full House", "Assembly", 6);

                Console.WriteLine();
                fullHouseGroup.Print();

                Console.WriteLine();
                var goodStudents = fullHouseGroup.FilterStudents(s => s.GetAverageGrade() >= 10);
                Console.WriteLine("Good Students: ");
                foreach (Student student in goodStudents)
                {
                    Console.WriteLine($"{student.FullName}: {student.GetAverageGrade()}");
                }

                Console.WriteLine();

                var nameStartsWithB = fullHouseGroup.FilterStudents(s => s.Firstname.StartsWith("B"));
                Console.WriteLine("Students which names star with a B: ");
                foreach (Student student in nameStartsWithB)
                {
                    Console.WriteLine($"{student.FullName}");
                }

                Console.WriteLine();

                var hasGrade2 = fullHouseGroup.FilterStudents(s => s.Grades.Contains(2));
                Console.WriteLine("Students who has 2s:");
                foreach(Student student in hasGrade2)
                {
                    Console.WriteLine($"{student.FullName}: {string.Join(", ", student.Grades)}");
                }

                Console.WriteLine();

                var noHWGrade = fullHouseGroup.FilterStudents(s => s.Grades.Count == 0);
                Console.WriteLine("Students who don't have grades for hws: ");
                foreach(Student student in noHWGrade)
                {
                    Console.WriteLine($"{student.FullName}");
                }

                Console.WriteLine();

                //double groupAverage 

                Console.WriteLine();

                var longNames = fullHouseGroup.FilterStudents(s => s.Firstname.Length > 5);
                Console.WriteLine($"Student's names longer than 5 symbols: ");
                foreach(Student student in longNames)
                {
                    Console.WriteLine($"{student.Firstname} ({student.Firstname.Length})");
                }

                Console.WriteLine();

                bool HasSameGrades(Student student)
                {
                    var mySortedGrades = student.Grades.OrderBy(g => g).ToList();

                    foreach(var other in students)
                    {
                        var otherSortedGrades = other.Grades.OrderBy(g => g).ToList();
                        if (mySortedGrades.Equals(otherSortedGrades))
                            return true;
                    }
                    return false;
                }

                var sameHWGrades = fullHouseGroup.FilterStudents(HasSameGrades);
                Console.WriteLine("Students with the same grades: ");
                foreach (Student student in sameHWGrades)
                {
                    Console.WriteLine($"{student.FullName}: {string.Join(", ", student.Grades)}");
                }

                Console.WriteLine();

                var evenGradesCount = fullHouseGroup.FilterStudents(s => s.Grades.Count % 2 == 0);
                Console.WriteLine("Students with even amount of grades:");
                foreach(Student student in evenGradesCount)
                {
                    Console.WriteLine($"{student.FullName}: {student.Grades.Count} grades");
                }

                Console.WriteLine();

                var SumAbove50 = fullHouseGroup.FilterStudents(s => s.Grades.Sum() > 50);
                Console.WriteLine("Students whose sum grades are over 50:");
                foreach (var student in SumAbove50)
                {
                    Console.WriteLine($"{student.FullName}: {student.Grades.Count} grades");
                }











                Student thatWeNeed = new Student("Alex", "Alexxxxxx", 90, 30);
                thatWeNeed.AddGrade(8);
                thatWeNeed.AddGrade(8);
                thatWeNeed.AddGrade(8);
                thatWeNeed.AddGrade(8);
                thatWeNeed.AddGrade(8);
                thatWeNeed.AddGrade(8);
                students.Add(thatWeNeed);

                Console.WriteLine();
                IEnumerable<string> AvgGrade7GadesCount5NameA = from student in students
                                                    where student.GetAverageGrade() > 7 
                                                    && student.Grades.Count() > 5 
                                                    && student.Firstname.StartsWith("A")
                                                    select student.FullName;

                Console.WriteLine("Stuednts whose average grade is higher than 7, amount of grades is more than 5 and whose name starts with an A:");
                foreach(var student in AvgGrade7GadesCount5NameA)
                {
                    Console.WriteLine($"{student}");
                }













                Console.WriteLine();
                Student NPC = new Student("Karina", "Zinovieva", 67, 17);
                NPC.LectureMissed += message => Console.WriteLine($"Reminder: {message}");
                NPC.AutomatReceived += (grade, subject) => Console.WriteLine($"congrats with {subject} ({grade} grade)!" +
                    $" I suggest you coffee(or tea)" +
                    $" to celebrate");
                NPC.ScholarshipAwarded += (average, message) => Console.WriteLine($"{message} Average grade: {average:F2}");
                NPC.CheckTime();
                NPC.AddGrade(12);
                NPC.AddGrade(11);
                NPC.AddGrade(12);

                List<Student> NPCstudents = new List<Student>() { NPC };
                Group NPCgroup = new Group(NPCstudents, "P67", "C#", 3);

                NPCgroup.GroupPartyPlanned += (idea) => Console.WriteLine($"Idea for a party - {idea}");
                NPCgroup.SessionSurvived += (message) => Console.WriteLine($"Message for a group: {message}");
                NPCgroup.CheckSessionResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program error: {ex.Message}");
            }
            
        }
    }
}
