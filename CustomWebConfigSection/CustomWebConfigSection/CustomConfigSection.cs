using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomWebConfigSection
{

    public class CustomSection
    {
        private static readonly Lazy<CustomConfigSection> _config = 
            new Lazy<CustomConfigSection>(() => ConfigurationManager.GetSection("myCustomSection") as CustomConfigSection);
        public static CustomConfigSection CustomConfigSection => _config.Value;
    }
    public class CustomConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("collection")]
        public CustomConfigCollection Collection => (CustomConfigCollection) this["collection"];
    }


    [ConfigurationCollection(typeof(CustomConfigElement))]
    public class CustomConfigCollection : ConfigurationElementCollection
    {
        public CustomConfigElement this[int index] => (CustomConfigElement)BaseGet(index);

        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CustomConfigElement)element).Name;
        }
    }


    public class CustomConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string)this["name"];

        [ConfigurationProperty("email", IsRequired = false)]
        public string Email => (string)this["email"];
    }
}