using ClassStudentWithAdvisor;
using PersonNS;
using TeacherNS;

namespace TestProject1;

 [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestRandom()
        {
            Person p1 = new Person("Artyom", 21);
            Teacher t1 = new Teacher("Misha", 32);
            Teacher t2 = new Teacher("Masha", 27);
            StudentWithAdvisor s1 = new StudentWithAdvisor("Vovan", 20, 3);
            StudentWithAdvisor s2 = new StudentWithAdvisor("Andrew", 22, 4);
            Person.People = new List<Person> { s1, p1, t1, s2, t2 };
            s1.AppointTeacher(Teacher.RandomTeacher());
            s2.AppointTeacher(Teacher.RandomTeacher());
            Assert.IsNotNull(s1.Teacher);
            Assert.IsNotNull(s2.Teacher);
        }

        [Test]
        public void TestEquals()
        {
            Person p1 = new Person("Artyom", 21);
            Assert.IsTrue(p1.Equals(new Person("Artyom", 21)));
            Assert.IsFalse(p1.Equals(new Person("Artyom", 20)));
            Assert.IsFalse(p1.Equals(new Teacher("Artyom", 21)));
        }

        [Test]
        public void TestClone()
        {
            Teacher t1 = new Teacher("Dimon", 38);
            Teacher t2 = (Teacher)t1.Clone();
            Assert.AreEqual(t1, t2);
        }

        [Test]
        public void TestToString()
        {
           var person = new Person("TestPerson", 30);
            Assert.AreEqual( "Person: TestPerson, 30 лет", person.ToString());
        }
    }