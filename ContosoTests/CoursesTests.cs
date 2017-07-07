using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class CoursesTests : ContosoTests
    {
        [TestMethod]
        public void Can_Navigate_To_Courses()
        {
            Page.GoTo("/Course");

            Assert.AreEqual(Page.Name, "Courses");
        }

        [TestMethod]
        public void Can_Create_Courses()
        {
            var DepartmentsTests = new DepartmentsTests();
            DepartmentsTests.Can_Create_Departments();

            var cred = 3;

            var CoursesToCreate = 5;

            for (int i = 0; i < CoursesToCreate; i++)
            {
                var n = i;
                var title = "Course" + i;
                var dep = "Dep" + i;
                NewCoursePage.CreateCourse(n, title, cred, dep);
                Assert.IsTrue(Page.DoesElementExistWithData(n.ToString() + ' ' + title + ' ' + cred + ' ' + dep));
            }
        }

        [TestMethod]
        public void Can_Delete_Courses()
        {
            DeleteElementsPage.GoTo("/Course");
            DeleteElementsPage.DeleteElementsCommand();

            Assert.IsFalse(DeleteElementsPage.DoElementsExist());
        }

        [TestMethod]
        public void Can_Edit_Course()
        {
            var DepartmentsTests = new DepartmentsTests();
            DepartmentsTests.Can_Create_Departments();

            var title = "EditedCourse";
            var cred = 4;
            var dep = "Dep4";

            NewCoursePage.GoTo();
            NewCoursePage.CreateCourse(111, "TestCourse", 3, "Dep0");
            EditCoursePage.GoTo();
            EditCoursePage.EditCourse(0)
                .WithTitle(title)
                .WithCredits(cred)
                .WithDepartment(dep)
                .Create();

            Assert.IsTrue(Page.DoesElementExistWithData(title + ' ' + cred + ' ' + dep));
        }

        [TestMethod]
        public void Can_Filter_Courses()
        {
            var name = '4';
            char DiffName = (char)((name - '0' + 1) % 5 + '0');

            FIlterCoursesPage.GoTo("Dep" + name);

            Assert.IsTrue(Page.DoesElementExistWithData(name + " Course" + name + " 3 Dep" + name));
            Assert.IsFalse(Page.DoesElementExistWithData(DiffName + " Course" + DiffName + " 3 Dep" + DiffName));
        }
    }
}
