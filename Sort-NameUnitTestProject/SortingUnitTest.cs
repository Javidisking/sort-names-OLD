using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactHelper;
using System.Collections.Generic;
using System.IO;

namespace ContactAppUnitTestProject
{
    [TestClass]
    public class SortingUnitTest
    {

        [TestMethod]
        public void ProvideUnsortedContactList_SortByLastNameThenFirstName_SortedContactList()
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
            var actualcontacts = cs.Sort(SampleContact, x => x.LastName, x => x.FirstName);

            var expectedcontacts = new List<Contact>(){
                new Contact("ABEGGNALE","FRANK"),
                new Contact("NAJAFI", "FRANK"), 
                new Contact("NAJAFI", "JAVID"), 
                new Contact("SMITH", "AMY") ,
                new Contact("SMITH", "JOHN"),
                 new Contact("SMITH", "NANCY"),           
                new Contact("ZIGLAR", "JOHN"),
                new Contact("ZIGLAR","ZIG")              
            };

            Assert.IsNotNull(actualcontacts);
            for (int i = 0; i < expectedcontacts.Count; i++)
            {
                Assert.AreEqual(expectedcontacts[i].FirstName, actualcontacts[i].FirstName);
                Assert.AreEqual(expectedcontacts[i].LastName, actualcontacts[i].LastName);
            }
        }

        [TestMethod]
        public void ProvideUnsortedContactListHavingOneContactOnly_SortByLastNameThenFirstName_SortedContactList()
        {
            // Create Sample Contact List with One Contact 
            var SampleContact = new List<Contact>() { new Contact("NAJAFI", "JAVID") };

            var cs = new ContactService();
            var actualcontacts = cs.Sort(SampleContact, x => x.LastName, x => x.FirstName);

            var expectedcontacts = new List<Contact>() { new Contact("NAJAFI", "JAVID") };

            Assert.IsNotNull(actualcontacts);
            for (int i = 0; i < expectedcontacts.Count; i++)
            {
                Assert.AreEqual(expectedcontacts[i].FirstName, actualcontacts[i].FirstName);
                Assert.AreEqual(expectedcontacts[i].LastName, actualcontacts[i].LastName);
            }
        }

        [TestMethod]
        public void ProvideEmptyContactList_SortByLastNameThenFirstName_EmptyList()
        {
            // Create Sample Contact List with One Contact 
            var SampleContact = new List<Contact>() { };

            var cs = new ContactService();
            var actualcontacts = cs.Sort(SampleContact, x => x.LastName, x => x.FirstName);

            var expectedcontacts = new List<Contact>() { };

            Assert.IsNotNull(actualcontacts);
            for (int i = 0; i < expectedcontacts.Count; i++)
            {
                Assert.AreEqual(expectedcontacts[i].FirstName, actualcontacts[i].FirstName);
                Assert.AreEqual(expectedcontacts[i].LastName, actualcontacts[i].LastName);
            }
        }

        [TestMethod]
        public void PassNull_SortByLastNameThenFirstName_EmptyList()
        {
            var cs = new ContactService();
            var actualcontacts = cs.Sort(null, x => x.LastName, x => x.FirstName);

            Assert.IsNull(actualcontacts);
        }
    }
}
