using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConvertAutoHotkeyToMacroRazer.Helpers
{
    public static class ParseHelper
    {
        public static List<string> ParseElt(string entry)
        {
            List<string> listElt = new List<string>();
            if (!String.IsNullOrEmpty(entry))
            {
                string pattern = @"{[\w\d ]+}";
                Match match = Regex.Match(entry, pattern, RegexOptions.IgnoreCase);
                while (match.Success)
                {
                    string v = match.Groups[1].Value;
                    listElt.Add(v);
                    match = match.NextMatch();
                }
            }

            return listElt;
        }
    }
}
