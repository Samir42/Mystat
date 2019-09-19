using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mystat.AdditionalClasses
{
    public class ResourceHelper
    {
        public static Style FindNameFromResource(ResourceDictionary dictionary, object resourceItem)
        {
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key] == resourceItem)
                {
                    return (Style)key;
                }
            }

            return null;
        }
    }
}
