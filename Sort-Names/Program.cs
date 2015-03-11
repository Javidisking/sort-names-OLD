using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ContactHelper;

namespace SortNames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //TODO: Delete this before you hand it over
                //var temp = new string[] { "D:\\development\\Sandpit\\ContactApp\\ContactApp\\InputFiles\\names.txt" };
                var temp = new string[] { "C:\\nds.txt" };
                args = temp;

                //Validating File Path
                Validation.ValidateFilePath(args);

                //Validating File Format
                Validation.ValidateFileFormat(args[0]);

                var cs = new ContactService();

                //Reading Source                
                var contacts = cs.ReadFile(args[0]);

                //Displaying
                cs.DisplayContacts(contacts);

                //Sorting
                var sortedcontacts = cs.Sort(contacts, x => x.LastName, x => x.FirstName);

                //Wrting To Target
                var targetFilename = Path.GetFileNameWithoutExtension(args[0]) + "-sorted.txt";
                var targetFilePath = Path.GetDirectoryName(args[0]) + targetFilename;
                cs.WriteToFile(sortedcontacts, targetFilePath);

                Console.WriteLine("Finished: created {0}", targetFilename);
            }
            catch (InvalidFileTypeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }


    }
}
