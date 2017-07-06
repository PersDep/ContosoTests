using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class DepartmentTests : ContosoTest
    {
        [TestMethod]
        public void Can_Navigate_To_Departments()
        {
            DepartmentsPage.GoTo();

            Assert.AreEqual(DepartmentsPage.Name, "Departments");
        }

        [TestMethod]
        public void Can_Create_Departmemt(string name = "")
        {
            string format = @"yyyy-MM-dd";

            var departmentName = "Dep0";
            if (name.Length > 0)
                departmentName = name;
            var budget = 14;
            var date = DateTime.Now;
            var admin = "Admin";

            NewDepartmentPage.GoTo();
            NewDepartmentPage.CreateDepartment(departmentName)
                .WithBudget(budget)
                .WithStartDate(date)
                .WithAdministrator(admin)
                .Create();

            Assert.IsTrue(DepartmentsPage.DoesDepartmentExistWithData(departmentName + ' ' + budget + ",00 ₽ " + date.ToString(format)));
        }

        [TestMethod]
        public void Can_Create_Departments()
        {
            var DepsToCreate = 5;

            for (int i = 0; i < DepsToCreate; i++)
                Can_Create_Departmemt("Dep" + i);
        }

        [TestMethod]
        public void Can_Delete_Departments()
        {
            DeleteDepartmentsPage.GoTo();
            DeleteDepartmentsPage.DeleteDepartmentsCommand();

            Assert.IsFalse(DeleteDepartmentsPage.DoDepartmentsExist());
        }

        [TestMethod]
        public void Can_Edit_Department()
        {
            string format = @"yyyy-MM-dd";

            var name = "EditedDep";
            var budget = 14;
            var date = DateTime.Now;
            var admin = "Admin";

            EditDepartmentPage.GoTo();
            EditDepartmentPage.EditDepartment(name)
                .WithBudget(budget)
                .WithStartDate(date)
                .WithAdministrator(admin)
                .Create();

            Assert.IsTrue(DepartmentsPage.DoesDepartmentExistWithData(name + ' ' + budget + ",00 ₽ " + date.ToString(format)));
        }
    }
}
