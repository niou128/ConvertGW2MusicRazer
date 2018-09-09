using ConvertAutoHotkeyToMacroRazer.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConvertAutoHotkeyToMacroRazer
{
    class Program
    {
        static void Main(string[] args)
        {
            string macroName = String.Empty;
            string uuid = String.Empty;
            string source = String.Empty;
            string sourcePath = String.Empty;
            Console.WriteLine("Macro Name?");
            macroName = Console.ReadLine();

            Console.WriteLine("uuid?");
            uuid = Console.ReadLine();

            Console.WriteLine("Path to source file:");
            sourcePath = Console.ReadLine();
            source = File.ReadAllText(sourcePath);


            List<string> inputList = ParseHelper.ParseElt(source);

            var macro = TransformToXmlNode.InitXml(macroName, uuid);



        }
    }
}
