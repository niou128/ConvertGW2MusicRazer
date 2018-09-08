using ConvertAutoHotkeyToMacroRazer.Helpers;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void If_1_element_return_List_1_Element()
        {
            string entry = "{numpad 3 up}";

            var result = ParseHelper.ParseElt(entry);

            Assert.Single(result);

        }

        [Fact]
        public void IF_3_Elements_Return_List_With_3_Elements()
        {
            string entry = "{numpad 3 up}{sleep 100} {numpad3 down}";

            var result = ParseHelper.ParseElt(entry);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void If_n_element_Return_List_With_n_Element()
        {
            string entry = @"{numpad 3 up}{sleep 100} {numpad3 down}{numpad 3 up}{sleep 100} {numpad3 down}
{numpad 3 up}{sleep 100} {numpad3 down}{numpad 3 up}{sleep 100} {numpad3 down}";

            var result = ParseHelper.ParseElt(entry);
            Assert.Equal(12, result.Count);
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
