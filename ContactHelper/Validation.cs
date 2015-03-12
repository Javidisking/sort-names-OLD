using System;
using System.IO;
using System.Linq;

namespace ContactHelper
{
    public static class Validation
    {
        public static void ValidateFilePath(string filepath)
        {
            //check if given filepath is null or empty
            if (filepath == null || filepath.Length == 0)
                throw new Exception("File was missing. please provide the file. e.g. sort-names c:\names.txt");

            //check if given filepath has an invalid character
            if (filepath.IndexOfAny(Path.GetInvalidPathChars()) > -1)
                throw new InvalidPathException(filepath);

            //check if given file exist in given path
            if (!File.Exists(filepath))
                throw new FileNotFoundException("The file was not found in given path.", filepath);

            //check if given file is a text file or not
            if (Path.GetExtension(filepath) != ".txt")
                throw new InvalidFileTypeException(filepath, ".txt");
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
