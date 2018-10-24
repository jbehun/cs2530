using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file should not be changed
namespace _2530_Final
{
    public enum SpecialOccasion { birthday, anniversary, holiday, valentine}

    public class Greetings
    {
        public static string FormalWelcome(string title, string name)
        {
            return string.Format("Welcome {0} {1}", title, name);
        }

        public static String SpecialOccasionGreeting(SpecialOccasion occasion, string title, string name)
        {
            return string.Format("Happy {0} {1} {2}", occasion, title, name);
        }

        public static String FriendGreeting()
        {
            return string.Format("Hi, buddy!  :)");
        }  
    }
}
