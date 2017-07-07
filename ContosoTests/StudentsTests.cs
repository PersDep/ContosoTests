using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class StudentsTests : ContosoTests
    {
        [TestMethod]
        public void Can_Navigate_To_Students()
        {
            Page.GoTo("/Student");

            Assert.AreEqual(Page.Name, "Students");
        }

        [TestMethod]
        public void Can_Create_Students()
        {
            string format = @"yyyy-MM-dd";

            var FirstName = "John";
            var date = DateTime.Now;

            var StudsToCreate = 5;

            for (int i = 0; i < StudsToCreate; i++)
            {
                var name = "Stud" + i;
                NewStudentPage.CreateStudent(name, FirstName, date);
                Assert.IsTrue(NewStudentPage.DoesElementExistWithData(name + ' ' + FirstName + ' ' + date.ToString(format)));
            }
        }

        [TestMethod]
        public void Can_Delete_Students()
        {
            DeleteElementsPage.GoTo("/Student");
            DeleteElementsPage.DeleteElementsCommand();

            Assert.IsFalse(DeleteElementsPage.DoElementsExist());
        }

        [TestMethod]
        public void Can_Edit_Student()
        {
            string format = @"yyyy-MM-dd";

            var name = "EditedStud";
            var FirstName = "Ivan";
            var date = DateTime.Now;

            NewStudentPage.GoTo();
            NewStudentPage.CreateStudent("TestStud", "John", date);
            EditStudentPage.GoTo();
            EditStudentPage.EditStudent(name)
                .WithFirstName(FirstName)
                .WithStartDate(date)
                .Create();

            Assert.IsTrue(NewStudentPage.DoesElementExistWithData(name + ' ' + FirstName + ' ' + date.ToString(format)));
        }

        [TestMethod]
        public void Can_Search_Students()
        {
            var name = '2';
            char DiffName = (char)((name - '0' + 1) % 5 + '0');

            SearchStudentsPage.GoTo("Stud" + name);

            Assert.IsTrue(NewStudentPage.DoesElementExistWithData("Stud" + name));
            Assert.IsFalse(NewStudentPage.DoesElementExistWithData("Stud" + DiffName));
        }
    }
}
