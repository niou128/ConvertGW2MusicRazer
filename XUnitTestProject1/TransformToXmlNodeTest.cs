using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConvertAutoHotkeyToMacroRazer.Helpers;
using ConvertAutoHotkeyToMacroRazer;

namespace XUnitTestProject1
{
    public class TransformToXmlNodeTest
    {
        [Fact]
        public void If_SendIput_return_type_Sendinput()
        {
            string entry = "SendInput {Numpad2 down}";

            var result = TransformToXmlNode.GetType(entry);

            Assert.Equal(InsertType.SendInput, result);
        }

        [Fact]
        public void If_sleep_return_type_Sleep()
        {
            string entry = "Sleep, 75";

            var result = TransformToXmlNode.GetType(entry);

            Assert.Equal(InsertType.Sleep, result);
        }

        [Fact]
        public void If_Key_press_is_1_return_07001E()
        {
            string entry = "SendInput {Numpad1 down}";

            var result = TransformToXmlNode.GetKeyPressed(entry);

            Assert.Equal("07001E", result);
        }

        [Theory]
        [InlineData("SendInput {Numpad1 down}", "07001E")]
        [InlineData("SendInput {Numpad2 down}", "07001F")]
        [InlineData("SendInput {Numpad3 down}", "070020")]
        [InlineData("SendInput {Numpad4 down}", "070021")]
        [InlineData("SendInput {Numpad5 down}", "070022")]
        [InlineData("SendInput {Numpad6 down}", "070023")]
        [InlineData("SendInput {Numpad7 down}", "070024")]
        [InlineData("SendInput {Numpad8 down}", "070025")]
        [InlineData("SendInput {Numpad9 down}", "070026")]
        [InlineData("SendInput {Numpad0 down}", "070027")]
        public void Return_Correct_Razer_Key_Code(string input, string expected)
        {
            var result = TransformToXmlNode.GetKeyPressed(input);

            Assert.Equal(expected, result);
        }
    }
}
