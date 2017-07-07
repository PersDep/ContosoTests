using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class AboutTest : ContosoTests
    {
        [TestMethod]
        public void Can_Navigate_To_About()
        {
            Page.GoTo("/Home/About");

            Assert.AreEqual(Page.Name, "Student Body Statistics");
        }
    }
}
