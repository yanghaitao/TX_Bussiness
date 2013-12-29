using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bussiness.Common
{
    public static class Validation
    {
        // Methods
        public static string CleanCreditCardNumber(string creditCard)
        {
            Regex regex = new Regex(@"(\-|\s|\D)*", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return regex.Replace(creditCard, string.Empty);
        }

        private static bool CreditPassesFormatCheck(string creditCardNumber)
        {
            creditCardNumber = CleanCreditCardNumber(creditCardNumber);
            if (!Numbers.IsInteger(creditCardNumber))
            {
                return false;
            }
            int[] digits = new int[creditCardNumber.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = Convert.ToInt16(creditCardNumber[i].ToString());
            }
            return IsValidLuhn(digits);
        }

        public static bool IsAlpha(string evalString)
        {
            return !Regex.IsMatch(evalString, "[^a-zA-Z]");
        }

        public static bool IsAlphaNumeric(string evalString)
        {
            return !Regex.IsMatch(evalString, "[^a-zA-Z0-9]");
        }

        public static bool IsAlphaNumeric(string evalString, bool allowSpaces)
        {
            if (allowSpaces)
            {
                return !Regex.IsMatch(evalString, @"[^a-zA-Z0-9\s]");
            }
            return IsAlphaNumeric(evalString);
        }

        public static bool IsCreditCardAmericanExpress(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:[3][4|7])(?:\d{13}))$");
            }
            return false;
        }

        public static bool IsCreditCardAny(string creditCard)
        {
            if (!CreditPassesFormatCheck(creditCard))
            {
                return false;
            }
            creditCard = CleanCreditCardNumber(creditCard);
            if (((!Regex.IsMatch(creditCard, @"^(?:(?:[3][4|7])(?:\d{13}))$") && !Regex.IsMatch(creditCard, @"^(?:(?:[3](?:[0][0-5]|[6|8]))(?:\d{11,12}))$")) && (!Regex.IsMatch(creditCard, @"^(?:(?:[3](?:[0][0-5]|[6|8]))(?:\d{11,12}))$") && !Regex.IsMatch(creditCard, @"^(?:(?:6011)(?:\d{12}))$"))) && ((!Regex.IsMatch(creditCard, @"^(?:(?:[2](?:014|149))(?:\d{11}))$") && !Regex.IsMatch(creditCard, @"^(?:(?:(?:2131|1800)(?:\d{11}))$|^(?:(?:3)(?:\d{15})))$")) && !Regex.IsMatch(creditCard, @"^(?:(?:[5][1-5])(?:\d{14}))$")))
            {
                return Regex.IsMatch(creditCard, @"^(?:(?:[4])(?:\d{12}|\d{15}))$");
            }
            return true;
        }

        public static bool IsCreditCardBigFour(string creditCard)
        {
            if (!CreditPassesFormatCheck(creditCard))
            {
                return false;
            }
            creditCard = CleanCreditCardNumber(creditCard);
            if ((!Regex.IsMatch(creditCard, @"^(?:(?:[3][4|7])(?:\d{13}))$") && !Regex.IsMatch(creditCard, @"^(?:(?:6011)(?:\d{12}))$")) && !Regex.IsMatch(creditCard, @"^(?:(?:[5][1-5])(?:\d{14}))$"))
            {
                return Regex.IsMatch(creditCard, @"^(?:(?:[4])(?:\d{12}|\d{15}))$");
            }
            return true;
        }

        public static bool IsCreditCardCarteBlanche(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:[3](?:[0][0-5]|[6|8]))(?:\d{11,12}))$");
            }
            return false;
        }

        public static bool IsCreditCardDinersClub(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:[3](?:[0][0-5]|[6|8]))(?:\d{11,12}))$");
            }
            return false;
        }

        public static bool IsCreditCardDiscover(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:6011)(?:\d{12}))$");
            }
            return false;
        }

        public static bool IsCreditCardEnRoute(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:[2](?:014|149))(?:\d{11}))$");
            }
            return false;
        }

        public static bool IsCreditCardJCB(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:(?:2131|1800)(?:\d{11}))$|^(?:(?:3)(?:\d{15})))$");
            }
            return false;
        }

        public static bool IsCreditCardMasterCard(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:[5][1-5])(?:\d{14}))$");
            }
            return false;
        }

        public static bool IsCreditCardVisa(string creditCard)
        {
            if (CreditPassesFormatCheck(creditCard))
            {
                creditCard = CleanCreditCardNumber(creditCard);
                return Regex.IsMatch(creditCard, @"^(?:(?:[4])(?:\d{12}|\d{15}))$");
            }
            return false;
        }

        public static bool IsEmail(string emailAddressString)
        {
            return Regex.IsMatch(emailAddressString, "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$");
        }

        public static bool IsGuid(string guid)
        {
            return Regex.IsMatch(guid, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");
        }

        public static bool IsIPAddress(string ipAddress)
        {
            return Regex.IsMatch(ipAddress, @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        }

        public static bool IsLowerCase(string inputString)
        {
            return Regex.IsMatch(inputString, "^[a-z]+$");
        }

        public static bool IsNumeric(string evalString)
        {
            return !Regex.IsMatch(evalString, "[^0-9]");
        }

        public static bool IsSocialSecurityNumber(string socialSecurityNumber)
        {
            return Regex.IsMatch(socialSecurityNumber, @"^\d{3}[-]?\d{2}[-]?\d{4}$");
        }

        public static bool IsStrongPassword(string password)
        {
            return Regex.IsMatch(password, @"(?=^.{8,255}$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*");
        }

        public static bool IsUpperCase(string inputString)
        {
            return Regex.IsMatch(inputString, "^[A-Z]+$");
        }

        public static bool IsURL(string url)
        {
            return Regex.IsMatch(url, @"^^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$");
        }

        public static bool IsUSCurrency(string currency)
        {
            return Regex.IsMatch(currency, @"^\$(([1-9]\d*|([1-9]\d{0,2}(\,\d{3})*))(\.\d{1,2})?|(\.\d{1,2}))$|^\$[0](.00)?$");
        }

        public static bool IsUSState(string stateName)
        {
            stateName = stateName.ToUpper();
            if (stateName.Length > 2)
            {
                return !string.IsNullOrEmpty(Strings.USStateNameToAbbrev(stateName));
            }
            return !string.IsNullOrEmpty(Strings.USStateAbbrevToName(stateName));
        }

        public static bool IsUSTelephoneNumber(string telephoneNumber)
        {
            return Regex.IsMatch(telephoneNumber, @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
        }

        public static bool IsValidLuhn(int[] digits)
        {
            int num = 0;
            bool flag = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (flag)
                {
                    digits[i] *= 2;
                    if (digits[i] > 9)
                    {
                        digits[i] -= 9;
                    }
                }
                num += digits[i];
                flag = !flag;
            }
            return ((num % 10) == 0);
        }

        public static bool IsZIPCodeAny(string zipCode)
        {
            return Regex.IsMatch(zipCode, @"^\d{5}((-|\s)?\d{4})?$");
        }

        public static bool IsZIPCodeFive(string zipCode)
        {
            return Regex.IsMatch(zipCode, @"^\d{5}$");
        }

        public static bool IsZIPCodeFivePlusFour(string zipCode)
        {
            return Regex.IsMatch(zipCode, @"^\d{5}((-|\s)?\d{4})$");
        }
    }
}
