namespace Pacman.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property)]
    public class Email : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;

            if (!Regex.Match(stringValue, "^([^\\.\\-\\/_][\\w\\.\\-\\/_]*[^\\.\\-\\/_]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", RegexOptions.ECMAScript).Success)
            {
                return false;
            }

            return true;
        }
    }
}