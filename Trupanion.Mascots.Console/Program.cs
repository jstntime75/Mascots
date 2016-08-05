using System.Collections.Generic;
using System.Configuration;
using Trupanion.Mascots.Configuration;

namespace Trupanion.Mascots.Console
{
    public class Program
    {
        private static Dictionary<string, string> _data;

        private static IDictionary<string, string> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new Dictionary<string, string>();

                    var section = (TrupanionMascotsSection)ConfigurationManager.GetSection("trupanion.mascots");
                    foreach (MascotElement mascot in section.Mascots)
                    {
                        _data[mascot.TeamName] = mascot.Mascot;
                    }
                }

                return _data;
            }
        }

        public static void Main(string[] args)
        {
            var names = new List<string>(Data.Keys);
            names.Sort();

            bool pickAgain = false;
            do
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Choose a Team:");
                System.Console.WriteLine("");

                for (int i = 0; i < names.Count; i++)
                {
                    System.Console.WriteLine(string.Format("{0}: {1}", i + 1, names[i]));
                }

                int key;
                bool valid = false;

                do
                {
                    string inputKey = System.Console.ReadLine();
                    if (int.TryParse(inputKey, out key) && key <= names.Count)
                    {
                        valid = true;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid entry. Try again.");
                    }
                } while (!valid);

                string selectedTeam = names[key - 1];
                string selectedMascot = Data[selectedTeam];
                System.Console.WriteLine("");
                System.Console.WriteLine(string.Format("The mascot for {0} is: {1}", selectedTeam, selectedMascot));

                System.Console.WriteLine("");
                System.Console.WriteLine("Would you like to pick again? (Y: for yes, N: for no)");
                string inputPickAgain = System.Console.ReadLine();
                pickAgain = string.Equals(inputPickAgain, "Y", System.StringComparison.OrdinalIgnoreCase);
            } while (pickAgain);
        }
    }
}
