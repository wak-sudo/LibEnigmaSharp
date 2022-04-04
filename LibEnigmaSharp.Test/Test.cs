using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LibEnigmaSharp.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void EncryptionTest()
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string testFilePath = projectDirectory + @"\EnigmaTestingFiles\TestFile.txt";
            string goodResultFilePath = projectDirectory + @"\EnigmaTestingFiles\TestFileGoodResult.txt";

            UserRotor[] rotors =
                {
                new UserRotor("I", "C", "F"),
                new UserRotor("II", "B", "G"),
                new UserRotor("III", "D", "D")
                };
            string[] plugboard = { "AZ", "BC" };
            UserSettings settings = new UserSettings("B", rotors, plugboard);

            if (File.Exists(testFilePath) && File.Exists(goodResultFilePath))
            {
                Encoder EncodingTest = new Encoder(settings);

                string properResult = File.ReadAllText(goodResultFilePath);
                string encryptedText = EncodingTest.EncryptText(File.ReadAllText(testFilePath));

                Assert.AreEqual(properResult, encryptedText);
            }
            else Assert.Fail();
        }
    }
}
