using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactHelper;
using System.IO;

namespace ContactAppUnitTestProject
{
    [TestClass]
    public class ValidateInputUnitTests
    {
        [TestMethod]
        public void RunApplicationWithoutProvingAnything_Validate_ThrowsInvalidPathException()
        {
            try
            {
                string[] TestArray = new string[] { };

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
                string[] TestArray = new string[] { Environment.CurrentDirectory + "\\Inputfiles\\" + "names.xlsx" };

                Validation.ValidateFilePath(TestArray);

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
                string[] TestArray = new string[] { "c>\\Inputfiles\\name.txt" };

                Validation.ValidateFilePath(TestArray);
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
                string[] TestArray = new string[] { Environment.CurrentDirectory + "\\Inputfiles\\" + "javidcontacts2015.txt" };

                Validation.ValidateFilePath(TestArray);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(FileNotFoundException));
            }
        }
    }
}
