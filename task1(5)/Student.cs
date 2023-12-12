using System;
using System.Collections.Generic;
using PersonNS;
using TeacherNS;

namespace StudentNS
{
    public class Student : Person
    {
        public int Course { get; set; }
      //  public Teacher Advisor { get; set; }

        public Student(string name, int age, int course) : base(name, age)
        {
            Course = course;
           // Advisor = advisor;
        }

        public Student(Student other):base(other)
        {
            Course = other.Course;
        }

        public override void Print()
        {
            Console.WriteLine($"{GetType().Name}: {Name}, {Age} лет, курс {Course}");
        }

        public static Student RandomStudents()
        {
            List<Student> onlyStudents = People.OfType<Student>().ToList();

            if (onlyStudents.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, onlyStudents.Count);

            return onlyStudents[randomIndex];
            // var random = new Random();
            // var students = new List<Student>();
            // for (int i = 0; i < count; i++)
            // {
            //     students.Add(new Student(
            //         $"Student_{i}",
            //         random.Next(18, 23),
            //         random.Next(1, 5),
            //         Teacher.RandomTeachers(1)[0]
            //     ));
            // }
            // return students;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, {Age} лет, курс {Course}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Student other = (Student)obj;
            return base.Equals(obj) && Course == other.Course;
        }

        public override int GetHashCode()
        {
            return (Name + Age + Course).GetHashCode();
        }

        public override object Clone()
        {
            return new Student(Name, Age, Course);
        }
    }
}