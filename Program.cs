// See https://aka.ms/new-console-template for more information
using Docnet.Core;
using Docnet.Core.Models;
using Docnet.Core.Readers;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Create a reader from the file bytes.
        try
        {
            using (var docReader = DocLib.Instance.GetDocReader(@"..\..\..\test.pdf", new PageDimensions()))
            {
                ReadFile(docReader);
            }
        } catch(FileNotFoundException ex) 
        {
            Console.WriteLine("File not found!");
            Console.WriteLine(ex);
        }
    }

    private static void ReadFile(IDocReader docReader)
    {
        for (var i = 0; i < docReader.GetPageCount(); i++)
        {
            using (var pageReader = docReader.GetPageReader(i))
            {
                var text = pageReader.GetText();
                Console.WriteLine(text);
            }
        }
    }
}

