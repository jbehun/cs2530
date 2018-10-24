/* Project: PigLatin
 * File:    MainWindow.xaml.cs
 * Name:    Justin Behunin
 * Date:    3/27/2015
 * 
 * Description: This program converts text from english 
 *              to PigLatin using RegEx to complete the convertion.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignmentPigLatin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //example text to test transalation to piglatin.
            OriginalTb.Text = "There cannot be a crisis next week.";
            OriginalTb.Text += "\nMy schedule is already full.\nHenry A. Kissinger\n";
            OriginalTb.Text += "\ncrystal ...    yellow,    RPM.\n    help! strong  eating?\n";
        }

        #region translate to PigLatin
        private void translateButton_Click(object sender, RoutedEventArgs e)
        {
            PigLatinTb.Text = Regex.Replace(OriginalTb.Text, @"\w+", new MatchEvaluator(PigLatinTranslator));
        }

        private string PigLatinTranslator(Match match)
        {
            string currentWord = match.ToString();
            Regex beginsWithVowel = new Regex(@"^[aeiouAEIOU]");
            Regex hasVowel = new Regex(@"[aeiouyAEIOUY]");

            //adds "way" to words that begin with vowels
            if (beginsWithVowel.IsMatch(currentWord))
            {
                return currentWord + "way";
            }
            //moves letters before first vowel to end of word and adds "ay"
            else if (hasVowel.IsMatch(currentWord))
            {
                char[] vowels = hasVowel.ToString().ToArray();
                int i = currentWord.IndexOfAny(vowels, 1);
                int length = currentWord.Length;
                StringBuilder sb = new StringBuilder();
                sb.Append(currentWord.Substring(i, length - i));
                sb.Append(currentWord.Substring(0, i));
                sb.Append("ay");

                //preserves capitol letters at the begining of the word
                if (char.IsUpper(currentWord[0]))
                {
                    sb[0] = Char.ToUpper(sb[0]);
                    sb[length - i] = Char.ToLower(sb[length - i]);
                }
                return sb.ToString();
            }
            //add "ay" to the end of words with no vowels
            return currentWord + "ay";
        }
        #endregion

        #region clear text boxes
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            OriginalTb.Clear();
            PigLatinTb.Clear();
        }
        #endregion
    }
}
