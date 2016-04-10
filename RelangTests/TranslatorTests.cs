using System.Collections.Generic;
using Relang;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RelangTests
{
    [TestClass]
    public class TranslatorTests
    {
        [TestMethod]
        [DeploymentItem("TestJsonFiles", "TestJsonFiles")]
        public void DeleteKey_KeyExist_RemoveKeyFromTranslator()
        {
            //arrange
            string relangTestsPath = "TestJsonFiles";
            Lang targetRu = new Lang() { Name = "targetRU" };
            Lang targetEn = new Lang() { Name = "targetEN" };
            targetRu.Load(relangTestsPath);
            targetEn.Load(relangTestsPath);
            Translator targetTranslator = new Translator();
            targetTranslator.Langs.AddRange(new List<Lang>() { targetRu, targetEn });

            //act
            targetTranslator.RemoveKey("NEW_SCHEDULE");

            //assert
            CollectionAssert.DoesNotContain(targetTranslator.GetCaptions(), "NEW_SCHEDULE", "Key not deleted correctly.");
                
        }
    }
}
