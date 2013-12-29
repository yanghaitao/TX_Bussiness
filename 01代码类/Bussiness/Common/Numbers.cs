using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Bussiness.Common
{
    public static class Numbers
    {
        // Methods
        public static bool IsEven(int value)
        {
            return ((value & 1) == 0);
        }

        public static bool IsInteger(string sItem)
        {
            Regex regex = new Regex("[^0-9-]");
            Regex regex2 = new Regex("^-[0-9]+$|^[0-9]+$");
            return (!regex.IsMatch(sItem) && regex2.IsMatch(sItem));
        }

        public static bool IsNaturalNumber(string sItem)
        {
            Regex regex = new Regex("[^0-9]");
            Regex regex2 = new Regex("0*[1-9][0-9]*");
            return (!regex.IsMatch(sItem) && regex2.IsMatch(sItem));
        }

        public static bool IsNumber(string sItem)
        {
            double num;
            return double.TryParse(sItem, NumberStyles.Float, (IFormatProvider)NumberFormatInfo.CurrentInfo, out num);
        }

        public static bool IsOdd(int value)
        {
            return ((value & 1) == 1);
        }

        public static bool IsWholeNumber(string sItem)
        {
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(sItem);
        }

        public static double Random()
        {
            return new Random().NextDouble();
        }

        public static int Random(bool noZeros)
        {
            byte[] data = new byte[1];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            if (noZeros)
            {
                provider.GetNonZeroBytes(data);
            }
            else
            {
                provider.GetBytes(data);
            }
            return data[0];
        }

        public static int Random(int high)
        {
            byte[] data = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(data);
            return Math.Abs((int)(BitConverter.ToInt32(data, 0) % high));
        }

        public static int Random(int low, int high)
        {
            return new Random().Next(low, high);
        }
    }

}
