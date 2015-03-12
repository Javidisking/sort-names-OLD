using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactHelper;
using System.IO;

namespace ContactAppUnitTestProject
{
    [TestClass]
    public class ReadFileUnitTests
    {
        #region ValidateInputUnitTests
        [TestMethod]
        public void RunApplicationWithoutProvingAnything_Validate_ThrowsInvalidPathException()
        {
            try
            {
                string TestArray = string.Empty;

                Validation.ValidateFilePath(TestArray);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
            }
        }

        [TestMethod]
        public void ProvidingInvalidInputFileType_Validate_ThrowsInvalidFileTypeException()
        {
            try
            {
                string Teststr = Environment.CurrentDirectory + "\\Inputfiles\\" + "names.xlsx";

                Validation.ValidateFilePath(Teststr);

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(InvalidFileTypeException));
            }
        }

        [TestMethod]
        public void ProvidingInvalidPath_Validate_ThrowsInvalidPathException()
        {
            try
            {
                string Teststr = "c>\\Inputfiles\\name.txt";

                Validation.ValidateFilePath(Teststr);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(InvalidPathException));
            }
        }

        [TestMethod]
        public void ProvidingFileDoesNotExist_Validate_ThrowsFileNotFoundException()
        {
            try
            {
                string Teststr = Environment.CurrentDirectory + "\\Inputfiles\\" + "javidcontacts2015.txt";

                Validation.ValidateFilePath(Teststr);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(FileNotFoundException));
            }
        }

        //TODO: Success condition

        #endregion

        #region ValidateInputFileFormatUnitTest
        [TestMethod]
        public void ContactsAreNotSplittedByComma_Validate_ThrowsInvalidFileFormatException()
        {
            try
            {
                string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "filewithoutcomma.txt";
                Validation.ValidateFileFormat(filepath);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(InvalidFileFormatException));
            }
        }

        [TestMethod]
        public void ContactsAreSplittedByExtraComma_Validate_ThrowsInvalidFileFormatException()
        {
            try
            {
                string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "FileWithTwoCommas.txt";
                Validation.ValidateFileFormat(filepath);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(InvalidFileFormatException));
            }
        }
        #endregion

        #region ReadFile Tests
        [TestMethod]
        public void ElevenContactsAreInInputFile_ReadFile_TotalContactInsertedToContactList()
        {
            var cs = new ContactService();
            string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "names.txt";

            var contacts = cs.ReadFile(filepath);
            int actual = contacts.Count;
            int expected = 11;

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        #endregion
        [TestMethod]
        public void ContactsAreInExcelFile_ReadFile_TotalContactInsertedToContactList()
        {
            try
            {
                var cs = new ContactService();
                string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "names.xlsx";

                var contacts = cs.ReadFile(filepath);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(InvalidFileTypeException));
            }
        }
    }
}
