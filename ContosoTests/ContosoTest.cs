using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class ContosoTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
