using Xunit;
using EncrypterDecrypter.Services;
using System.IO;

namespace EncDecTest
{
    public class AlgorythmsTests
    {
        [Theory]
        [InlineData("� �� ����� 6������ GRIBS", "����", "� �� ����� 6����� GRIBS")]
        [InlineData("���� � ����� ����� �������", "�������", "���� � ����� ����� �������")]
        [InlineData("�������� ���� �� ��������, ����������!!1!!!11!", "�������", "�������� ���� �� ��������, ����������!!1!!!11!")]
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
        [InlineData("� �� ����� 6����� GRIBS", "����","� �� ����� 6������ GRIBS" )]
        [InlineData("���� � ����� ����� �������", "�������", "���� � ����� ����� �������")]
        [InlineData("�������� ���� �� ��������, ����������!!1!!!11!", "�������", "�������� ���� �� ��������, ����������!!1!!!11!")]
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
        [InlineData("TestLoadDOCS.docx", "I�m in docx!\r")]
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