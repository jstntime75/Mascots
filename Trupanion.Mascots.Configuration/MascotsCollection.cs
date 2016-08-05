using System.Configuration;

namespace Trupanion.Mascots.Configuration
{
    [ConfigurationCollection(typeof(MascotElement))]
    public class MascotsCollection : ConfigurationElementCollection
    {
        protected override string ElementName
        {
            get
            {
                return "mascot";
            }
        }

        public string GetMascot(string teamName)
        {
            foreach (MascotElement element in this)
            {
                if (string.Equals(element.TeamName, teamName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return element.Mascot;
                }
            }

            return null;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MascotElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MascotElement)element).TeamName;
        }
    }
}
