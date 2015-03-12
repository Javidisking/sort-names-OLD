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
            string filepath = Environment.CurrentDirectory + "\\Inputfiles\\" + "Write-test1.txt";
            cs.WriteToFile(SampleContact, filepath);

            //using (var streamreader = new StreamReader(filepath))
            //{
            //    string line;
            //    while ((line = streamreader.ReadLine()) != null)
            //    {
            //        var contact = new Contact(line.Split(',').ToList()[0], line.Split(',').ToList()[1]);
            //        contacts.Add(contact);
            //    }
            //}



            //Assert.IsNotNull(actualcontacts);
            //for (int i = 0; i < expectedcontacts.Count; i++)
            //{
            //    Assert.AreEqual(expectedcontacts[i].FirstName, actualcontacts[i].FirstName);
            //    Assert.AreEqual(expectedcontacts[i].LastName, actualcontacts[i].LastName);
            //}


            //var targetFilename = Path.GetFileNameWithoutExtension(args[0]) + "-sorted.txt";
            //var targetFilePath = Path.GetDirectoryName(args[0]) + targetFilename;
            //cs.WriteToFile(sortedcontacts, targetFilePath);
        }
    }
}
