using System;
using System.Linq;

namespace SimplePasswordGenerator.Library
{
    public class Generator
    {
        private readonly Random _random;
        private readonly string _letters;
        private readonly string _numerics;
        private string _specials;

        /// <summary>
        /// Get or set the special characters to be used in generating the password
        /// </summary>
        public string Specials
        {
            get { return _specials; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new GeneratorException("The \"specials\" field cannot be null or empty");
                }
                else if (value.Contains(" "))
                {
                    throw new GeneratorException("The \"specials\" field cannot contain a \"space\" as a character");
                }

                _specials = new string(value.Distinct().ToArray()); 
            }
        }

        /// <summary>
        /// Will initialize the Generator with default values for letters, numerics and special characters
        /// </summary>
        public Generator() : this(letters: "ABCDEFGHIJKLMNOPQRSTUVWXYZ", numerics: "1234567890", specials: "!@#$%&[]()=?+*-_") { }

        /// <summary>
        /// Will initialite the generator with the handed values for letters, numerics and special characters
        /// </summary>
        /// <param name="letters">the letters to use when generating password</param>
        /// <param name="numerics">the numerics to use when generating password</param>
        /// <param name="specials">the special characters to use when generating password</param>
        public Generator(string letters, string numerics, string specials)
        {
            _random = new Random();
            _letters = letters;
            _numerics = numerics;
            Specials = specials;
        }

        /// <summary>
        /// Will generate the actual password with help from the given options
        /// </summary>
        /// <param name="passwordLength">the length of the password</param>
        /// <param name="casing">what casing to be used (default is "Mixed")</param>
        /// <param name="useSpecials">whether to use specials characters or not (default is "false")</param>
        /// <param name="useNumerics">whether to use numerics or not (default is "false")</param>
        /// <param name="filter">this will prevent any of the characters in this filter from appearing in the password</param>
        /// <returns></returns>
        public string Generate(uint passwordLength, 
                               PasswordCasing casing, 
                               bool useSpecials = false, 
                               bool useNumerics = false, 
                               string filter = null)
        {
            ValidateOptions(passwordLength);

            var result = "";
            result = GetLetters(casing, result);
            result = GetSpecials(useSpecials, result);
            result = GetNumerics(useNumerics, result);
            result = ApplyFilter(filter, result);

            return ActuallyGeneratePassword(passwordLength, result);
        }

        private void ValidateOptions(uint passwordLength)
        {
            if (passwordLength > 1024)
            {
                throw new GeneratorException("The length of the password cannot be greater than 1024");
            }
        }

        private string GetLetters(PasswordCasing casing, string result)
        {
            switch (casing)
            {
                case PasswordCasing.Uppercase:
                    result += _letters;
                    break;
                case PasswordCasing.Lowercase:
                    result += _letters.ToLower();
                    break;
                case PasswordCasing.Mixed:
                    result += _letters + _letters.ToLower();
                    break;
            }

            return result;
        }
        
        private string GetSpecials(bool useSpecials, string result)
        {
            if (useSpecials)
                result += Specials;
            return result;
        }

        private string GetNumerics(bool useNumerics, string result)
        {
            if (useNumerics)
                result += _numerics;
            return result;
        }

        private string ApplyFilter(string filter, string result)
        {
            if (!string.IsNullOrEmpty(filter))
                foreach (var c in filter)
                    result = result.Replace(c.ToString(), "");

            return result;
        }

        private string ActuallyGeneratePassword(uint passwordLength, string result)
        {
            return new string(Enumerable.Repeat(result, (int)passwordLength)
                            .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
