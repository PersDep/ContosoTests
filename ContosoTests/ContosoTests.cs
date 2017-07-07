using Microsoft.VisualStudio.TestTools.UnitTesting;

using ContosoFramework;

namespace ContosoTests
{
    [TestClass]
    public class ContosoTests
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
