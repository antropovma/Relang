using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Relang;

namespace RelangTests
{
    [TestClass]
    [DeploymentItem("TestJsonFiles", "TestJsonFiles")]
    public class LangTests
    {
        [TestMethod]
        public void Load_FromTestJson()
        {
            //arrange
            string relangTestsPath = "TestJsonFiles";
            Dictionary<string, string> expectedCollection = new Dictionary<string, string> { { "key1", "value1" }, { "key2.key1", "value2" } };
            Lang lang = new Lang { Name = "test", Caption = "Tets Lang object", Visible = true };

            //act
            lang.Load(relangTestsPath);

            //assert
            CollectionAssert.AreEquivalent(expectedCollection, lang.Items, "Actual collection is not valid.");
        }

        [TestMethod]
        public void GetValue_FromTestJson_Value2()
        {
            //arrange
            string relangTestsPath = "TestJsonFiles";
            string expected = "value2";
            Lang lang = new Lang { Name = "test", Caption = "Tets Lang object", Visible = true };

            //act
            lang.Load(relangTestsPath);
            var actual = lang.GetValue("key2.key1");

            //assert
            Assert.AreEqual(expected, actual, "Actual value is invalid (Actual: {0}, correct: {1}).", actual, expected);
        }

        [TestMethod]
        public void ChangeValue_ChangeValueForExistingKey()
        {
            //arrange
            string relangTestsPath = "TestJsonFiles";
            Lang lang = new Lang { Name = "test", Caption = "Tets Lang object", Visible = true };
            lang.Load(relangTestsPath);

            string expectedKey = "key2.key1";
            string expectedValue = "value3";

            Dictionary<string, string> expected = new Dictionary<string, string> { { "key1", "value1" }, { "key2.key1", "value3" } };

            //act
            lang.ChangeValue(expectedKey, expectedValue);
 
            //assert
            CollectionAssert.AreEquivalent(expected, lang.Items, "Actual collection after change is not correct.");
        }

        [TestMethod]
        public void ChangeValue_ChangeValueForNotExistingKey()
        {
            //arrange
            string relangTestsPath = "TestJsonFiles";
            Lang lang = new Lang { Name = "test", Caption = "Tets Lang object", Visible = true };
            lang.Load(relangTestsPath);

            string expectedKey = "key2.key2";
            string expectedValue = "value3";

            Dictionary<string, string> expected = new Dictionary<string, string> { { "key1", "value1" }, { "key2.key1", "value2" }, { "key2.key2", "value3" } };

            //act
            lang.ChangeValue(expectedKey, expectedValue);
            //assert
            CollectionAssert.AreEquivalent(expected, lang.Items, "Actual collection after change is not correct.");
        }
    }
}
