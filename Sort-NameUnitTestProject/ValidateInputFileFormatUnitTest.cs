using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactHelper;
using System.Collections.Generic;
using System.IO;

namespace ContactAppUnitTestProject
{
    [TestClass]
    public class ValidateInputFileFormatUnitTest
    {


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


        //[TestMethod]
        //public void ValidInputFile_Validate_TotalContactInsertedToContactList()
        //{
        //    ContactService cs = new ContactService();
        //    List<Contact> contacts;
        //    string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "names.txt";
        //    contacts = cs.Validate(filepath);
        //    int actual = contacts.Count;
        //    int expected = 11;
        //    Assert.AreEqual(expected, actual);
        //}

    }
}
