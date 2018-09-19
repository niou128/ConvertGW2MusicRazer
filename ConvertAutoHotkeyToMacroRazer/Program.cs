using ConvertAutoHotkeyToMacroRazer.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

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
            string destPath = String.Empty;
            Console.WriteLine("Macro Name?");
            macroName = Console.ReadLine();

            Console.WriteLine("uuid?");
            uuid = Console.ReadLine();

            Console.WriteLine("Path to source file:");
            sourcePath = Console.ReadLine();
            source = File.ReadAllText(sourcePath);

            Console.WriteLine("Path to final xml?");
            destPath = Console.ReadLine();


            List<string> inputList = ParseHelper.ParseElt(source);

            var macro = TransformToXmlNode.InitXml(macroName, uuid);

            foreach (var item in inputList)
            {
                XmlDocument newNode = new XmlDocument();
                switch (ParseHelper.GetType(item))
                {
                   
                    case InsertType.SendInput:
                        newNode = TransformToXmlNode.CreateNodeKeyboard(item);                       
                        break;
                    case InsertType.Sleep:
                        newNode = TransformToXmlNode.CreateNodeDelay(item);
                        break;
                }
                macro = TransformToXmlNode.AddNode(macro, newNode);
            }

            macro.Save(destPath);

        }
    }
}
