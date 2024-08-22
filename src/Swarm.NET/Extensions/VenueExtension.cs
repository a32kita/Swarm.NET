using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

using SwarmDotNET.Entities;

namespace SwarmDotNET.Extensions
{
    public static class VenueExtension
    {
        private static string _processString(string input)
        {
            // 全角文字のみの場合はそのまま返す
            if (Regex.IsMatch(input, @"^[^\x00-\x7F]+$"))
            {
                return input;
            }

            // () の外が半角英数およびスペースのみ、() の中が全角文字の場合
            var match = Regex.Match(input, @"^([a-zA-Z0-9 ]*)\(([^)]*)\)([a-zA-Z0-9 ]*)$");
            if (match.Success)
            {
                string outside = match.Groups[1].Value + match.Groups[3].Value;
                string inside = match.Groups[2].Value;

                if (Regex.IsMatch(outside, @"^[a-zA-Z0-9 ]*$") && Regex.IsMatch(inside, @"^[^\x00-\x7F]+$"))
                {
                    return inside;
                }
            }

            // その他の場合はそのまま返す
            return input;
        }


        public static string GetLocalName(this Venue venue)
        {
            if (string.IsNullOrEmpty(venue.Name))
                return null;

            var procResult = _processString(venue.Name);

            return procResult; //String.IsNullOrEmpty(procResult) ? procResult : venue.Name;
        }
    }
}
