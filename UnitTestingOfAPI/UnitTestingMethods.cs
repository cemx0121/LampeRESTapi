using LampeRESTapi.Managers;
using LampLib.Models;

namespace UnitTestingOfAPI
{
    [TestClass]
    public class UnitTestingMethods
    {
        private ILamp lampMgr = new LampManager();

        [TestMethod]
        [DataRow("ETDEVICENAVNDERIKKEFINDES")]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void TestGetByDevicenameMethodInValid(string deviceName)
        {

            Assert.ThrowsException<ArgumentException>(() => lampMgr.GetAllByDeviceName(deviceName));
        }

        [TestMethod]
        [DataRow("P�re 1")]
        [DataRow("P�re 2")]
        [DataRow("Phillips Hue")]
        public void TestGetByDevicenameMethodValid(string deviceName)
        {
            List<Lamp> testLamp = new List<Lamp>();
            testLamp = lampMgr.GetAllByDeviceName(deviceName);

            Assert.AreEqual(deviceName, testLamp[0].DeviceName);

        }
    }
}