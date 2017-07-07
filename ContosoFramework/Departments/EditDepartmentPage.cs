using System;

using OpenQA.Selenium;

namespace ContosoFramework
{
    public class EditDepartmentPage
    {
        public static void GoTo()
        {
            Page.GoTo("/Department");

            Driver.Instance.FindElement(By.LinkText("Edit")).Click();
        }

        public static EditDepartmentCommand EditDepartment(string name)
        {
            return new EditDepartmentCommand(name);
        }

        public class EditDepartmentCommand
        {
            private readonly string _name;
            private decimal _budget;
            private DateTime _startDate;
            private string _administrator;

            public EditDepartmentCommand(string name)
            {
                _name = name;
            }

            public EditDepartmentCommand WithBudget(decimal budget)
            {
                _budget = budget;
                return this;
            }

            public EditDepartmentCommand WithStartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public EditDepartmentCommand WithAdministrator(string administrator)
            {
                _administrator = administrator;
                return this;
            }

            public void Create()
            {
                string format = @"dd\/MM\/yyyy";

                Driver.Instance.FindElement(By.Id("Name")).Clear();
                Driver.Instance.FindElement(By.Id("Name")).SendKeys(_name);
                Driver.Instance.FindElement(By.Id("Budget")).Clear();
                Driver.Instance.FindElement(By.Id("Budget")).SendKeys(_budget.ToString());
                Driver.Instance.FindElement(By.Id("StartDate")).Clear();
                Driver.Instance.FindElement(By.Id("StartDate")).SendKeys(_startDate.ToString(format));
                Driver.Instance.FindElement(By.Id("InstructorID")).SendKeys(_administrator);

                Driver.Instance.FindElement(By.XPath("//input[@value='Save']")).Click();
            }
        }
    }
}
