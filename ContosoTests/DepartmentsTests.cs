using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class DepartmentsTests : ContosoTests
    {
        [TestMethod]
        public void Can_Navigate_To_Departments()
        {
            Page.GoTo("/Department");

            Assert.AreEqual(Page.Name, "Departments");
        }

        [TestMethod]
        public void Can_Create_Departments()
        {
            string format = @"yyyy-MM-dd";

            var budget = 14;
            var date = DateTime.Now;
            var admin = "Admin";

            var DepsToCreate = 5;

            for (int i = 0; i < DepsToCreate; i++)
            {
                var name = "Dep" + i;
                NewDepartmentPage.CreateDepartmemt(name, budget, date, admin);
                Assert.IsTrue(Page.DoesElementExistWithData(name + ' ' + budget + ",00 ₽ " + date.ToString(format)));
            }
        }

        [TestMethod]
        public void Can_Delete_Departments()
        {
            DeleteElementsPage.GoTo("/Department");
            DeleteElementsPage.DeleteElementsCommand();
            
            Assert.IsFalse(DeleteElementsPage.DoElementsExist());
        }

        [TestMethod]
        public void Can_Edit_Department()
        {
            string format = @"yyyy-MM-dd";

            var name = "EditedDep";
            var budget = 14;
            var date = DateTime.Now;
            var admin = "Admin";

            NewDepartmentPage.GoTo();
            NewDepartmentPage.CreateDepartmemt("TestDep", 16, date, "Ivan");
            EditDepartmentPage.GoTo();
            EditDepartmentPage.EditDepartment(name)
                .WithBudget(budget)
                .WithStartDate(date)
                .WithAdministrator(admin)
                .Create();

            Assert.IsTrue(Page.DoesElementExistWithData(name + ' ' + budget + ",00 ₽ " + date.ToString(format)));
        }
    }
}
