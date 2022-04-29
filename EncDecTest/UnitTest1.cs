using Xunit;
using EncrypterDecrypter.Services;
using System.IO;

namespace EncDecTest
{
    public class AlgorythmsTests
    {
        [Theory]
        [InlineData("Я ем много 6ольших GRIBS", "гриб", "в хх нрялп 6сьещлё GRIBS")]
        [InlineData("Карл у Клары украл кораллы", "кларнет", "хлрь б пюкьы дшхтц цобнрюё")]
        [InlineData("Возьмите меня на практику, пожалуйста!!1!!!11!", "Практос", "сязжячдф эешс ьс ябахечьг, аостъещвтк!!1!!!11!")]
        public void DataEncryption_Test(string value, string key, string expected)
        {
            //Arrange
            var testclass = new EncrypterDecrypterService();

            //Act
            string actual = testclass.EncryptData(value,key);

            //Assert
            Assert.Equal(expected.ToUpper(), actual);
        }

        [Theory]
        [InlineData("в хх нрялп 6сьещлё GRIBS", "гриб","Я ем много 6ольших GRIBS" )]
        [InlineData("хлрь б пюкьы дшхтц цобнрюё", "кларнет", "Карл у Клары украл кораллы")]
        [InlineData("сязжячдф эешс ьс ябахечьг, аостъещвтк!!1!!!11!", "Практос", "Возьмите меня на практику, пожалуйста!!1!!!11!")]
        public void DataDecryption_Test(string value, string key, string expected)
        {
            //Arrange
            var testclass = new EncrypterDecrypterService();

            //Act
            string actual = testclass.DecryptData(value, key);

            //Assert
            Assert.Equal(expected.ToUpper(), actual);
        }
    }

    public class SaveLoadTests
    {
        [Theory]
        [InlineData("TestLoadTXT.txt", "I'm in txt!")]
        [InlineData("TestLoadDOCS.docx", "I’m in docx!\r")]
        public void LoadData_TxtAndDocxTest(string nameOfFile, string expected)
        {
            //Arrange
            var testclass = new FileIOService();
            string fileName = $@"{Directory.GetCurrentDirectory()}\TestFiles\{nameOfFile}";

            //Act
            string actual = testclass.LoadData(fileName);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("TestSaveTXT.txt", "I'm gonna be in txt!")]
        [InlineData("TestSaveDOCS.docx", "I'm gonna be in docx!")]
        public void SaveData_TxtAndDocxTest(string nameOfFile, string data)
        {
            //Arrange
            var testclass = new FileIOService();
            string fileName = $@"{Directory.GetCurrentDirectory()}\TestFiles\{nameOfFile}";

            //Act
            testclass.SaveData(data,fileName);

            //Assert
            Assert.True(File.Exists(fileName));
        }
    }
}