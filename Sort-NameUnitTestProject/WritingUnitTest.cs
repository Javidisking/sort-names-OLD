using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactHelper;
using System.IO;
using System.Collections.Generic;

namespace ContactAppUnitTestProject
{
    [TestClass]
    public class WritingUnitTest
    {
        [TestMethod]
        public void ProvideContactList_WriteToFile_NotEmptyFile()
        {
            #region Create Sample Contact List

            var SampleContact = new List<Contact>(){
                new Contact("ZIGLAR","ZIG"),
                new Contact("SMITH", "JOHN"), 
                new Contact("NAJAFI", "JAVID"),                 
                new Contact("ZIGLAR", "JOHN"),
                new Contact("SMITH", "NANCY") ,
                new Contact("NAJAFI", "FRANK"),
                new Contact("SMITH", "AMY") ,                
                new Contact("ABEGGNALE","FRANK")
            };
            #endregion

            var cs = new ContactService();
            string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "NotEmptyFile-test.txt";
            cs.WriteToFile(SampleContact, filepath);

            using (var streamreader = new StreamReader(filepath))
            {
                Assert.AreNotEqual(streamreader.ReadLine(), null);
            }
        }

        [TestMethod]
        public void ProvideContactList_WriteToFile_TotalContactSaveToFileMatch()
        {
            #region Create Sample Contact List

            var SampleContact = new List<Contact>(){
                new Contact("ZIGLAR","ZIG"),
                new Contact("SMITH", "JOHN"), 
                new Contact("NAJAFI", "JAVID"),                 
                new Contact("ZIGLAR", "JOHN")
            };

            #endregion

            var cs = new ContactService();
            string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "TotalContact-test.txt";
            cs.WriteToFile(SampleContact, filepath);

            var actualcontacts = cs.ReadFile(filepath);
            Assert.AreEqual(actualcontacts.Count, SampleContact.Count);
        }

        public void ProvideContactList_WriteToFile_AllContactSaveToFileMatchOriginlList()
        {
            #region Create Sample Contact List

            var SampleContact = new List<Contact>(){
                new Contact("ZIGLAR","ZIG"),
                new Contact("SMITH", "JOHN"), 
                new Contact("NAJAFI", "JAVID"),                 
                new Contact("ZIGLAR", "JOHN")
            };

            #endregion

            var cs = new ContactService();
            string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "AllContactSaveToFileMatchOriginlList-test.txt";
            cs.WriteToFile(SampleContact, filepath);

            var actualcontacts = cs.ReadFile(filepath);

            Assert.IsNotNull(actualcontacts);
            for (int i = 0; i < SampleContact.Count; i++)
            {
                Assert.AreEqual(SampleContact[i].FirstName, actualcontacts[i].FirstName);
                Assert.AreEqual(SampleContact[i].LastName, actualcontacts[i].LastName);
            }
        }
    }
}
