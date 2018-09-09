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
    }
}
