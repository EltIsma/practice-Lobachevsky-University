using System;
using System.Collections.Generic;
using PersonNS;
using StudentNS;

namespace TeacherNS
{
    public class Teacher : Person
    {
        public List<Student> Students { get; set; }

        public Teacher(string name, int age) : base(name, age)
        {
            Students = new List<Student>();;
        }

        public Teacher(Teacher other) : base(other)
        {
            Students = other.Students;
        }

        public override void Print()
        {
            Console.WriteLine($"{GetType().Name}: {Name}, {Age} лет, количество студентов: {Students.Count}");
        }

        public static Teacher RandomTeacher()
        {
            List<Teacher> ts = People.OfType<Teacher>().ToList();

            if (ts.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, ts.Count);

            return ts[randomIndex];
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, {Age} лет, количество студентов: {Students.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Teacher other = (Teacher)obj;
             for (int i = 0; i < Students.Count; i++)
            {
                if (!Students[i].Equals(other.Students[i]))
                    return false;
            }
            return base.Equals(obj) && Students.Count == other.Students.Count && Students.SequenceEqual(other.Students);
        }

        public override int GetHashCode()
        {
            return (Name + Age + Students.Count).GetHashCode();
        }

        public override object Clone()
        {
            var clonedStudents = new List<Student>();
            foreach (var student in Students)
            {
                clonedStudents.Add((Student)student.Clone());
            }
            return new Teacher(Name, Age);
        }
    }
}