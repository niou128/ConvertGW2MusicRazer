using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConvertAutoHotkeyToMacroRazer.Helpers
{
   public static class TransformToXmlNode
    {
        public static InsertType GetType(string entry)
        {
            if (entry.StartsWith("SendInput", true, null))
            {
                return InsertType.SendInput;
            }
            if (entry.StartsWith("Sleep", true, null))
            {
                return InsertType.Sleep;
            }

            return InsertType.Undefined;
        }

        public static string GetKeyPressed(string entry)
        {
            string result = String.Empty;
            string key = String.Empty;
            string pattern = @"{Numpad([\d]+)[\w ]*}";
            Match match = Regex.Match(entry, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                key = match.Groups[1].Value;
            }
            switch(key)
            {
                case "1":
                    result = EnumKey.Key1.GetDescription();
                    break;
                case "2":
                    result = EnumKey.Key2.GetDescription();
                    break;
                case "3":
                    result = EnumKey.Key3.GetDescription();
                    break;
                case "4":
                    result = EnumKey.Key4.GetDescription();
                    break;
                case "5":
                    result = EnumKey.Key5.GetDescription();
                    break;
                case "6":
                    result = EnumKey.Key6.GetDescription();
                    break;
                case "7":
                    result = EnumKey.Key7.GetDescription();
                    break;
                case "8":
                    result = EnumKey.Key8.GetDescription();
                    break;
                case "9":
                    result = EnumKey.Key9.GetDescription();
                    break;
                case "0":
                    result = EnumKey.Key0.GetDescription();
                    break;
            }


            return result;
        }
    }
}
