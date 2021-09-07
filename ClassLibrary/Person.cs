using System;
using System.Reflection;

namespace ClassLibrary
{
    public class Person
    {
        [RegexValidation(@"^[a-zA-Z]*$")]
        private string FirstName { get; }
        [RegexValidation(@"^[a-zA-Z]*$")]
        private string SurName { get; }
        public Person(string firstName, string surName)
        {
            FirstName = firstName;
            SurName = surName;
        }         
        public override string ToString()
        {
            return $"Имя:{FirstName}, Фамилия:{SurName}";
        }
        public bool IsValid()
        {
            var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var property in properties)
            {
                foreach (var attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is RegexValidationAttribute)
                    {
                        var temp = attribute as RegexValidationAttribute;

                        if (!temp.IsValueValid(property.GetValue(this).ToString()))
                        {
                            Console.WriteLine("{0} is failed", property.Name);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
