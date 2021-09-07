using System;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RegexValidationAttribute: Attribute
    {
        public string _personVal;
        public RegexValidationAttribute(string personVal)
        {
            _personVal = personVal;
        }
        public bool IsValueValid(string value)
        {
            return Regex.IsMatch(value, _personVal);
        }
        
        
    }
}
