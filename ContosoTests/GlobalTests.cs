using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContosoTests
{
    [TestClass]
    public class GlobalTests : ContosoTests
    {
        [TestMethod]
        public void Can_Create_Courses_When_No_Departments()
        {
            var DepartmentsTests = new DepartmentsTests();
            var CoursesTests = new CoursesTests();

            DepartmentsTests.Can_Delete_Departments();
            CoursesTests.Can_Create_Courses();
        }

        [TestMethod]
        public void Can_Create_Course_With_Existing_Number()
        {
            var DepartmentsTests = new DepartmentsTests();
            var CoursesTests = new CoursesTests();

            DepartmentsTests.Can_Create_Departments();

            CoursesTests.Can_Create_Courses();
            CoursesTests.Can_Create_Courses();
        }
    }
}
