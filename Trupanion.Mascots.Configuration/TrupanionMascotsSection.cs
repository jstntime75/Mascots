using System.Configuration;

namespace Trupanion.Mascots.Configuration
{
    public class TrupanionMascotsSection : ConfigurationSection
    {
        [ConfigurationProperty("mascots", IsDefaultCollection = true)]
        public MascotsCollection Mascots
        {
            get
            {
                return (MascotsCollection)base["mascots"];
            }
        }
    }
}
