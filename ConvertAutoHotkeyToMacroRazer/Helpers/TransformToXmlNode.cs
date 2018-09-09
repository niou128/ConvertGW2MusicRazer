using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ConvertAutoHotkeyToMacroRazer.Helpers
{
    public static class TransformToXmlNode
    {
        public static XmlDocument CreateNodeDelay(string entry)
        {
            string NodeDelay = String.Empty;
            int delay = ParseHelper.GetTimeSleep(entry);

            NodeDelay = $@"<Event id=""DELAY"">{Environment.NewLine}<Delay>{delay}</Delay>{Environment.NewLine}</Event>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(NodeDelay);

            return doc;
        }

        public static XmlDocument CreateNodeKeyboard(string entry)
        {
            string NodeKeyboard = String.Empty;

            var key = ParseHelper.GetKeyPressed(entry);
            var state = ParseHelper.GetState(entry);
            NodeKeyboard = $@"<Event id =""KEYBOARD""><HID>{key}</HID><State>{state}</State></Event>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(NodeKeyboard);

            return doc;
        }
    }
}
