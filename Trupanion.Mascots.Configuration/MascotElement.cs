using System.Configuration;

namespace Trupanion.Mascots.Configuration
{
    public class MascotElement : ConfigurationElement
    {
        [ConfigurationProperty("teamName", IsKey = true, IsRequired = true)]
        public string TeamName
        {
            get
            {
                return (string)base["teamName"];
            }

            set
            {
                base["teamName"] = value;
            }
        }

        [ConfigurationProperty("mascot", IsRequired = true)]
        public string Mascot
        {
            get
            {
                return (string)base["mascot"];
            }

            set
            {
                base["mascot"] = value;
            }
        }
    }
}
