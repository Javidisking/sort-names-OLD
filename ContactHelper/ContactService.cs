using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ContactHelper
{
    public class ContactService : IContactService
    {
        public List<Contact> ReadFile(string filepath)
        {
            //Validating File Path
            Validation.ValidateFilePath(filepath);

            //Validating File Format
            Validation.ValidateFileFormat(filepath);

            var contacts = new List<Contact>();

            using (var streamreader = new StreamReader(filepath))
            {
                string line;
                while ((line = streamreader.ReadLine()) != null)
                {
                    var contact = new Contact(line.Split(',').ToList()[0], line.Split(',').ToList()[1]);
                    contacts.Add(contact);
                }
            }
            return contacts;
        }

        public void DisplayContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        //I made this method flexible enough to sort it by anything e.g email, date of birth and etc
        public List<Contact> Sort(List<Contact> contacts, Func<Contact, string> orderBySelector, Func<Contact, string> thenSelector)
        {
            return contacts != null ? contacts.OrderBy(orderBySelector).ThenBy(thenSelector).ToList() : null;
        }

        public void WriteToFile(List<Contact> contacts, string filepath)
        {
            using (var streamwriter = new StreamWriter(filepath))
            {
                foreach (var contact in contacts)
                {
                    streamwriter.WriteLine(contact);
                }
            }
        }
    }
}
