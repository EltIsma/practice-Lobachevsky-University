using System;
using System.Collections.Generic;
using ClassStudentWithAdvisor;
using PersonNS;
using StudentNS;
using TeacherNS;

class Program
{
       public static void Main()
    {
        TestPersonConstructor();
        TestPersonEquals();
        TestPersonToString();
        TestPersonClone();

        TestStudentConstructor();
        TestStudentEquals();
        TestStudentToString();
        TestStudentClone();

        TestTeacherConstructor();
        TestTeacherEquals();
        TestTeacherToString();
        TestTeacherClone();
         var people = new List<Person>
        {
            new Person("John", 25),
            new Student("TestStudent", 22, 3),
            new Teacher("TestTeacher", 45)
        };

        Console.WriteLine("Original people list:");
        Console.WriteLine(string.Join("\n", people));

        var peopleCopy = people.Select(p => (Person)p.Clone()).ToList();

        foreach (var person in peopleCopy)
        {
            if (person is Student)
            {
                Console.WriteLine("Type: Student");
                (person as Student).Course++;
                person.Print();
            }
            else if (person is Teacher)
            {
                Console.WriteLine("Type: Teacher");
                person.Print();
            }
            else
            {
                Console.WriteLine("Type: Person");
                person.Print();
            }
        }
       
    }

    public static void TestPersonConstructor()
    {
        var person = new Person("TestPerson", 30);
        Console.WriteLine("Person Constructor Test: " + (person.Name == "TestPerson" && person.Age == 30));
    }

    public static void TestPersonEquals()
    {
        var person1 = new Person("TestPerson", 30);
        var person2 = new Person("TestPerson", 30);
        Console.WriteLine("Person Equals Test: " + person1.Equals(person2));
    }

    public static void TestPersonToString()
    {
        var person = new Person("TestPerson", 30);
        Console.WriteLine("Person ToString Test: " + (person.ToString() == "Person: TestPerson, 30 лет"));
    }

    public static void TestPersonClone()
    {
        var person1 = new Person("TestPerson", 30);
        var person2 = (Person)person1.Clone();
        Console.WriteLine("Person Clone Test: " + person1.Equals(person2));
    }

     public static void TestStudentConstructor()
    {
        var student = new Student("TestStudent", 22, 3);
        Console.WriteLine("Student Constructor Test: " + (student.Name == "TestStudent" && student.Age == 22 && student.Course == 3));
    }

    public static void TestStudentEquals()
    {
        var student1 = new Student("TestStudent", 22, 3);
        var student2 = new Student("TestStudent", 22, 3);
        Console.WriteLine("Student Equals Test: " + student1.Equals(student2));
    }

    public static void TestStudentToString()
    {
        var student = new Student("TestStudent", 22, 3);
        Console.WriteLine("Student ToString Test: " + (student.ToString() == "Student: TestStudent, 22 лет, курс 3"));
    }

    public static void TestStudentClone()
    {
        var student1 = new Student("TestStudent", 22, 3);
        var student2 = (Student)student1.Clone();
        Console.WriteLine("Student Clone Test: " + student1.Equals(student2));
    }

     public static void TestTeacherConstructor()
    {
        var teacher = new Teacher("TestTeacher", 45);
        Console.WriteLine("Teacher Constructor Test: " + (teacher.Name == "TestTeacher" && teacher.Age == 45 && teacher.Students.Count == 0));
    }

    public static void TestTeacherEquals()
    {
        var teacher1 = new Teacher("TestTeacher", 45);
        var teacher2 = new Teacher("TestTeacher", 45);
        Console.WriteLine("Teacher Equals Test: " + teacher1.Equals(teacher2));
    }

    public static void TestTeacherToString()
    {
        var teacher = new Teacher("TestTeacher", 45);
        Console.WriteLine("Teacher ToString Test: " + (teacher.ToString() == "Teacher: TestTeacher, 45 лет, количество студентов: 0"));
    }

    public static void TestTeacherClone()
    {
        var teacher1 = new Teacher("TestTeacher", 45);
        var teacher2 = (Teacher)teacher1.Clone();
        Console.WriteLine("Teacher Clone Test: " + teacher1.Equals(teacher2));
    }
    // public static void PrintTeachersForStudents(List<Person> people)
    // {
    //     foreach (var person in people)
    //     {
    //         if (person is Student)
    //         {
    //             var student = (StudentWithAdvisor)person;
    //             student.Print();
    //             // Console.WriteLine($"Student: {student.Name}");
    //             // Console.WriteLine("Teachers:");
    //             // // foreach (var teacher in  student.Teacher)
    //             // // {
    //             //     Console.WriteLine($"- {student.Teacher.Print()}");
    //             }
    //         }
    //     }
}

