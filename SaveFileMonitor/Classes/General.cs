using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveFileMonitor.Classes
{
    public class General
    {
        public enum TimeFormat
        {
            [Description("yyyyMMdd-HHmmss")]
            DateTimeFormatUTC = 0,

            [Description("MMddyyyy-hhmmsstt")]
            DateTimeFormatUS = 1,

            //add more formats here
        }

        public string GetEnumDescription(Enum value)
        {
            System.Reflection.FieldInfo oField = value.GetType().GetField(value.ToString());
            DescriptionAttribute oAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(oField, typeof(DescriptionAttribute));
            return oAttribute != null ? oAttribute.Description : oAttribute.ToString();
        }

        public string RemoveInvalidFileNameChars(string input)
        {
            var invalidChars = new HashSet<char>(Path.GetInvalidFileNameChars());
            var result = new StringBuilder(input.Length);

            foreach (var c in input)
            {
                if (!invalidChars.Contains(c) && !char.IsWhiteSpace(c))
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
