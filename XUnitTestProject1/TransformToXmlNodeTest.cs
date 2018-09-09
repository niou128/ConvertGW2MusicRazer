using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConvertAutoHotkeyToMacroRazer.Helpers;
using ConvertAutoHotkeyToMacroRazer;
using System.Xml;

namespace XUnitTestProject1
{
    public class TransformToXmlNodeTest
    {
        [Fact]
        public void If_Event_Is_Sleep_Return_Node_delay()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml($@"<Event id=""DELAY""><Delay>300</Delay></Event>");

            var expected = doc;

            string entry = @"Sleep, 300";

            var result = TransformToXmlNode.CreateNodeDelay(entry);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void If_Event__is_input_key_1_down_return_Node_Keyboard_state_0()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml($@"<Event id =""KEYBOARD""><HID>07001E</HID><State>0</State></Event>");

            string entry = "SendInput {Numpad1 down}";

            var result = TransformToXmlNode.CreateNodeKeyboard(entry);

            Assert.Equal(doc.OuterXml, result.OuterXml);
        }

        [Fact]
        public void If_Event__is_input_key_1_up_return_Node_Keyboard_state_1()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml($@"<Event id =""KEYBOARD""><HID>07001E</HID><State>1</State></Event>");

            string entry = "SendInput {Numpad1 up}";

            var result = TransformToXmlNode.CreateNodeKeyboard(entry);

            Assert.Equal(doc.OuterXml, result.OuterXml);
        }

        [Fact]
        public void Init_xml_return_skeleton_with_MacroName_And_UUID()
        {
            var xmlSkeleton = @"<Macro>
	                    <MacroName>etalon</MacroName>
	                    <UUID>845185D6-926C-4B78-A9B8-90B23BA72CEE</UUID>
	                    <EventList>
	                    </EventList>
                    </Macro>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlSkeleton);

            var result = TransformToXmlNode.InitXml("etalon", "845185D6-926C-4B78-A9B8-90B23BA72CEE");

            Assert.Equal(doc.OuterXml, result.OuterXml);
        }
    }
}
