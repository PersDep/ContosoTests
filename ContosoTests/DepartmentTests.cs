using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
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

            var bodyTag = Driver.Instance.FindElement(By.TagName("body"));
            Console.WriteLine(bodyTag.Text);

            Assert.AreEqual(DepartmentsPage.Name, "Departments");
        }

        [TestMethod]
        public void Can_Create_Departmemt(string name = "")
        {
            var departmentName = "Dep0";
            if (name.Length > 0)
                departmentName = name;

            NewDepartmentPage.GoTo();
            NewDepartmentPage.CreateDepartment(departmentName)
                .WithBudget(14)
                .WithStartDate(DateTime.Now)
                .WithAdministrator("Admin")
                .Create();

            Assert.IsTrue(DepartmentsPage.DoesDepartmentExistWithName(departmentName));
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
    }
}
