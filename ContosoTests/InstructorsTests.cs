using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class InstructorsTests : ContosoTests
    {
        [TestMethod]
        public void Can_Navigate_To_Instructors()
        {
            Page.GoTo("/Instructor");

            Assert.AreEqual(Page.Name, "Instructors");
        }

        [TestMethod]
        public void Can_Create_Instructors()
        {
            string format = @"yyyy-MM-dd";

            var FirstName = "John";
            var date = DateTime.Now;
            var location = "Place";

            var InstsToCreate = 5;

            for (int i = 0; i < InstsToCreate; i++)
            {
                var LastName = "Inst" + i;
                NewInstructorPage.CreateInstructor(LastName, FirstName, date, location);
                Assert.IsTrue(Page.DoesElementExistWithData(LastName + ' ' + FirstName + ' ' + date.ToString(format) + ' ' + location));
            }
        }

        [TestMethod]
        public void Can_Delete_Instructors()
        {
            DeleteElementsPage.GoTo("/Instructor");
            DeleteElementsPage.DeleteElementsCommand();

            Assert.IsFalse(DeleteElementsPage.DoElementsExist());
        }

        [TestMethod]
        public void Can_Edit_Instructor()
        {
            string format = @"yyyy-MM-dd";

            var name = "EditedInst";
            var FirstName = "Ivan";
            var date = DateTime.Now;
            var location = "New Place";

            NewInstructorPage.GoTo();
            NewInstructorPage.CreateInstructor("TestInst", "John", date, "Place");
            EditInstructorPage.GoTo();
            EditInstructorPage.EditInstructor(name)
                    .WithName(FirstName)
                    .WithStartDate(date)
                    .WithLocation(location)
                    .Create();

            Assert.IsTrue(Page.DoesElementExistWithData(name + ' ' + FirstName + ' ' + date.ToString(format) + ' ' + location));
        }
    }
}