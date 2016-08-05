using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trupanion.Mascots.Configuration;

namespace Trupanion.Mascots.Configuration.Tests
{
    [TestClass]
    public class MascotConfigurationTests
    {
        [TestMethod]
        public void Configuration_Section_Not_Null_Test()
        {
            var section = ConfigurationManager.GetSection("trupanion.mascots");

            Assert.IsNotNull(section);
            Assert.IsInstanceOfType(section, typeof(TrupanionMascotsSection));
        }

        [TestMethod]
        public void Mascots_Collection_Not_Empty_Test()
        {
            var section = (TrupanionMascotsSection)ConfigurationManager.GetSection("trupanion.mascots");

            Assert.IsNotNull(section.Mascots);
            Assert.AreEqual(5, section.Mascots.Count);
        }

        [TestMethod]
        public void Mascot_Element_Null_Test()
        {
            var section = (TrupanionMascotsSection)ConfigurationManager.GetSection("trupanion.mascots");
            string mascot = section.Mascots.GetMascot("test");

            Assert.IsNull(mascot);
        }

        [TestMethod]
        public void Mascot_Element_Not_Null_Test()
        {
            var section = (TrupanionMascotsSection)ConfigurationManager.GetSection("trupanion.mascots");
            string mascot = section.Mascots.GetMascot("t2");

            Assert.AreEqual("m2", mascot);
        }

        [TestMethod]
        public void Mascot_Element_Not_Null_Case_Insensitive_Test()
        {
            var section = (TrupanionMascotsSection)ConfigurationManager.GetSection("trupanion.mascots");
            string mascot = section.Mascots.GetMascot("T4");

            Assert.AreEqual("m4", mascot);
        }
    }
}
