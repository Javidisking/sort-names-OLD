using System;
using System.IO;
using System.Linq;

namespace ContactHelper
{
    public static class Validation
    {
        public static void ValidateFilePath(string[] args)
        {
            //check if given filepath is null or empty
            if (args == null || args.Length == 0)
                throw new Exception("File was missing. please provide the file. e.g. sort-names c:\names.txt");

            //check if given filepath has an invalid character
            if (args[0].IndexOfAny(Path.GetInvalidPathChars()) > -1)
                throw new InvalidPathException(args[0]);

            //check if given file exist in given path
            if (!File.Exists(args[0]))
                throw new FileNotFoundException("The file was not found in given path.", args[0]);

            //check if given file is a text file or not
            if (Path.GetExtension(args[0]) != ".txt")
                throw new InvalidFileTypeException(args[0], ".txt");
        }

        public static void ValidateFileFormat(string filepath)
        {
            using (var streamreader = new StreamReader(filepath))
            {
                string line;
                while ((line = streamreader.ReadLine()) != null)
                {
                    //File without comma  or File with more than one comma 
                    if (line.Split(',').ToList().Count != 2)
                        throw new InvalidFileFormatException(filepath);
                }
            }
        }
    }
}
