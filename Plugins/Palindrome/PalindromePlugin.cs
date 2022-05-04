using BasePlugin.Interfaces;
using BasePlugin.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palindrome
{
    public class PalindromePlugin : IPlugin
    {
        public static string _Id = "Palindrome";
        public string Id => _Id;
        public bool IsNumPal;
        public bool IsStrPal;
        public PluginOutput Execute(PluginInput input)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (input.Message == "")
            {
                input.Callbacks.StartSession();
                return new PluginOutput("Palindrome started. Enter a number or string to check if it is a palindrome. Enter 'Exit' to stop.", input.PersistentData);
            }
            else if (input.Message == "exit")
            {
                input.Callbacks.EndSession();
                return new PluginOutput("Palindrome stopped.", input.PersistentData);
            }

            else if (regex.IsMatch(input.Message))
            {
                IsNumPal = IsNumberPalindrome(int.Parse(input.Message));
                if (IsNumPal) return new PluginOutput("The number is a Palindrome!");
                else  return new PluginOutput("The number is NOT a Palindrome!");

            }

            else
            {
                IsStrPal = IsStringPalindrome(input.Message);
                if (IsStrPal) return new PluginOutput("The string is a Palindrome!");
                else return new PluginOutput("The string is NOT a Palindrome!");
            }
        }
        public static bool IsNumberPalindrome(int n)
        {
            int tmp = n;
            int n2 = 0;
            int dig = 0;
            while (n > 0)
            {
                dig = n % 10;
                n2 = n2 * 10 + dig;
                n /= 10;
            }
            if (tmp == n2)
                return true;
            return false;
        }
        public static bool IsStringPalindrome(String s)
        {
            int a = 0;
            int b = s.Length - 1;

            while (a < b)
            {
                if (s[a] != s[b])
                    return false;
                a++;
                b--;
            }
            return true;
        }
         

    }
}
