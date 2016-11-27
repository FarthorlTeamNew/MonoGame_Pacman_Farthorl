using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Pacman.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Password : ValidationAttribute
    {
        private  int minLenght;
        private  int maxLenght;
        public Password(int minLenght, int maxLenght)
        {
            this.MinLenght = minLenght;
            this.MaxLenght = maxLenght;
        }

        public Password(int minLenght, int maxLenght, bool containLowwrCase)
        {
            this.MinLenght = minLenght;
            this.MaxLenght = maxLenght;
            ContainsLowwerCase = containLowwrCase;
        }

        public Password(int minLenght, int maxLenght, bool containLowwrCase, bool containUpperCase)
        {
            this.MinLenght = minLenght;
            this.MaxLenght = maxLenght;
            ContainsLowwerCase = containLowwrCase;
            ContainsUpperCase = containUpperCase;
        }

        public Password(int minLenght, int maxLenght, bool containLowwrCase, bool containUpperCase, bool containDigit)
        {
            this.MinLenght = minLenght;
            this.MaxLenght = maxLenght;
            ContainsLowwerCase = containLowwrCase;
            ContainsUpperCase = containUpperCase;
            ContainsDigit = containDigit;
        }

        public Password(int minLenght, int maxLenght, bool containLowwrCase, bool containUpperCase, bool containDigit, bool containSpecialSymbol)
        {
            this.MinLenght = minLenght;
            this.MaxLenght = maxLenght;
            ContainsLowwerCase = containLowwrCase;
            ContainsUpperCase = containUpperCase;
            ContainsDigit = containDigit;
            ContainsSpecialSymbol = containSpecialSymbol;
        }

        private int MinLenght
        {
            get { return minLenght; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("the input value connot be negative");
                }

                this.minLenght = value;
            }
        }
        private int MaxLenght {
            get { return this.maxLenght; }
            set { this.maxLenght = value; }
        }
        private static bool ContainsLowwerCase { get; set; }
        private static bool ContainsUpperCase { get; set; }
        private static bool ContainsDigit { get; set; }
        private static bool ContainsSpecialSymbol { get; set; }
        private static bool ErrorMessage { get; set; }

        private static void ThrowError()
        {
            throw new ArgumentOutOfRangeException(ErrorMessage.ToString());
        }

        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            if (string.IsNullOrEmpty(stringValue))
            {
                if (ErrorMessage)
                {
                    ThrowError();
                }

                return false;
            }

            if (stringValue.Length < minLenght || stringValue.Length > maxLenght)
            {
                if (ErrorMessage)
                {
                    ThrowError();
                }

                return false;
            }

            if (ContainsDigit && !Regex.Match(stringValue, "[\\d+]", RegexOptions.ECMAScript).Success)
            {
                if (ErrorMessage)
                {
                    ThrowError();
                }

                return false;
            }
            if (ContainsLowwerCase && !Regex.Match(stringValue, "[a-z]", RegexOptions.ECMAScript).Success)
            {
                if (ErrorMessage)
                {
                    ThrowError();
                }

                return false;
            }
            if (ContainsUpperCase && !Regex.Match(stringValue, "[A-Z]", RegexOptions.ECMAScript).Success)
            {
                if (ErrorMessage)
                {
                    ThrowError();
                }

                return false;
            }
            if (ContainsSpecialSymbol &&
                !Regex.Match(stringValue, "[!, @, #, $, %, ^, &, *, (, ), _, +, <, >, ?]", RegexOptions.ECMAScript).Success)
            {
                if (ErrorMessage)
                {
                    ThrowError();
                }

                return false;
            }

            return true;
        }
    }
}