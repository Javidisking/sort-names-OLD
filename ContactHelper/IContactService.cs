using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactHelper
{
    public interface IContactService
    {
        List<Contact> ReadFile(string filepath);
        //List<Contact> SortByLastnameThenFirstname(List<Contact> contacts);
        List<Contact> Sort(List<Contact> contacts, Func<Contact, string> orderBySelector, Func<Contact, string> thenSelector);
        void DisplayContacts(List<Contact> contacts);
        void WriteToFile(List<Contact> contacts, string filepath);
    }
}
