using ConvertAutoHotkeyToMacroRazer;
using ConvertAutoHotkeyToMacroRazer.Helpers;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class ParseHelperTest
    {
        [Fact]
        public void If_1_element_return_List_1_Element()
        {
            string entry = "SendInput {Numpad2 down}";

            var result = ParseHelper.ParseElt(entry);

            Assert.Single(result);

        }

        [Fact]
        public void IF_3_Elements_Return_List_With_3_Elements()
        {
            string entry = @"SendInput {Numpad2 up}
SendInput {Numpad6 up}
Sleep, 75";

            var result = ParseHelper.ParseElt(entry);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void If_n_element_Return_List_With_n_Element()
        {
            string entry = @"SendInput {Numpad2 down}
SendInput {Numpad6 down}
SendInput {Numpad2 up}
SendInput {Numpad6 up}
Sleep, 75
SendInput {Numpad9}
SendInput {Numpad2 down}
Sleep, 300
SendInput {Numpad2 up}
SendInput {Numpad3 down}";

            var result = ParseHelper.ParseElt(entry);
            Assert.Equal(10, result.Count);
        }

        [Fact]
        public void If_entry_Is_Null_Return_Empty_List()
        {
            string entry = null;

            var result = ParseHelper.ParseElt(entry);

            Assert.Empty(result);
        }

        [Fact]
        public void If_SendIput_return_type_Sendinput()
        {
            string entry = "SendInput {Numpad2 down}";

            var result = ParseHelper.GetType(entry);

            Assert.Equal(InsertType.SendInput, result);
        }

        [Fact]
        public void If_sleep_return_type_Sleep()
        {
            string entry = "Sleep, 75";

            var result = ParseHelper.GetType(entry);

            Assert.Equal(InsertType.Sleep, result);
        }

        [Fact]
        public void If_Key_press_is_1_return_07001E()
        {
            string entry = "SendInput {Numpad1 down}";

            var result = ParseHelper.GetKeyPressed(entry);

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
            var result = ParseHelper.GetKeyPressed(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void If_key_down_return_state_0()
        {
            string entry = "SendInput {Numpad1 down}";

            var result = ParseHelper.GetState(entry);

            Assert.Equal(0, result);
        }

        [Fact]
        public void If_Key_up_return_state_1()
        {
            string entry = "SendInput {Numpad1 Up}";

            var result = ParseHelper.GetState(entry);

            Assert.Equal(1, result);
        }

        [Fact]
        public void If_Sleep_300_return_300()
        {
            string entry = "Sleep, 300";

            var result = ParseHelper.GetTimeSleep(entry);

            Assert.Equal(300, result);
        }
    }
}
