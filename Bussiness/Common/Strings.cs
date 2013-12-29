using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace Bussiness.Common
{
    /// <summary>
    /// 字符串加密
    /// </summary>
    public static class Strings
    {
        public static void ToLower(ref string[] values)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = values[i].ToLower();
        }

        #region 字符串加密SHA1 MD5
        /// <summary>
        /// 字符串加密 SHA1
        /// </summary>
        /// <param name="chars">待加密字符串</param>
        /// <returns></returns>
        public static string EncryptSHA1(string chars)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(chars.ToLower(), "SHA1").ToLower();
        }
        /// <summary>
        /// 字符串加密 MD5
        /// </summary>
        /// <param name="chars">待加密字符串</param>
        /// <returns></returns>
        public static string EncryptMD5(string chars)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(chars.ToLower(), "MD5").ToLower();
        }
        #endregion

        #region base64加密及解密
        /// <summary>
        /// 将字符串使用base64算法加密
        /// </summary>
        /// <param name="sourceString">待加密的字符串</param>
        /// <param name="ens">System.Text.Encoding 对象，如创建中文编码集对象：System.Text.Encoding.GetEncoding(54936)</param>
        /// <returns>加码后的文本字符串</returns>
        public static string BaseEncoding(string sourceString, System.Text.Encoding ens)
        {
            return Convert.ToBase64String(ens.GetBytes(sourceString));
        }
        /// <summary>
        /// 将字符串使用base64算法加密
        /// </summary>
        /// <param name="sourceString">待加密的字符串</param>
        /// <returns>加码后的文本字符串</returns>
        public static string BaseEncoding(string sourceString)
        {
            return BaseEncoding(sourceString, System.Text.Encoding.GetEncoding(65001));
        }
        /// <summary>
        /// 从base64编码的字符串中还原字符串，支持中文
        /// </summary>
        /// <param name="base64String">base64加密后的字符串</param>
        /// <param name="ens">System.Text.Encoding 对象，如创建中文编码集对象：System.Text.Encoding.GetEncoding(54936)</param>
        /// <returns>还原后的文本字符串</returns>
        public static string BaseDecoding(string base64String, System.Text.Encoding ens)
        {
            /**
            * ***********************************************************
            *
            * 从base64String中取得的字节值为字符的机内码（ansi字符编码）
            * 一般的，用机内码转换为汉字是公式：
            * (char)(第一字节的二进制值*256+第二字节值)
            * 而在c#中的char或string由于采用了unicode编码，就不能按照上面的公式计算了
            * ansi的字节编和unicode编码不兼容
            * 故利用.net类库提供的编码类实现从ansi编码到unicode代码的转换
            *
            * GetEncoding 方法依赖于基础平台支持大部分代码页。但是，对于下列情况提供系统支持：默认编码，即在执行此方法的计算机的区域设置中指定的编码；Little- Endian Unicode (UTF-16LE)；Big-Endian Unicode (UTF-16BE)；Windows 操作系统 (windows-1252)；UTF-7；UTF-8；ASCII 以及 GB18030（简体中文）。
            *
            *指定下表中列出的其中一个名称以获取具有对应代码页的系统支持的编码。
            *
            * 代码页 名称
            * 1200 “UTF-16LE”、“utf-16”、“ucs-2”、“unicode”或“ISO-10646-UCS-2”
            * 1201 “UTF-16BE”或“unicodeFFFE”
            * 1252 “windows-1252”
            * 65000 “utf-7”、“csUnicode11UTF7”、“unicode-1-1-utf-7”、“unicode-2-0-utf-7”、“x-unicode-1-1-utf-7”或“x-unicode-2-0-utf-7”
            * 65001 “utf-8”、“unicode-1-1-utf-8”、“unicode-2-0-utf-8”、“x-unicode-1-1-utf-8”或“x-unicode-2-0-utf-8”
            * 20127 “us-ascii”、“us”、“ascii”、“ANSI_X3.4-1968”、“ANSI_X3.4-1986”、“cp367”、 “csASCII”、“IBM367”、“iso-ir-6”、“ISO646-US”或“ISO_646.irv:1991”
            * 54936 “GB18030”
            *
            * 某些平台可能不支持特定的代码页。例如，Windows 98 的美国版本可能不支持日语 Shift-jis 代码页（代码页 932）。这种情况下，GetEncoding 方法将在执行下面的 C# 代码时引发 NotSupportedException：
            *
            * Encoding enc = Encoding.GetEncoding("shift-jis");
            *
            * **************************************************************/
            //从base64String中得到原始字符
            return ens.GetString(Convert.FromBase64String(base64String));
        }

        /// <summary>
        /// 从base64编码的字符串中还原字符串，支持中文
        /// </summary>
        /// <param name="base64String">base64加密后的字符串</param>
        /// <returns>还原后的文本字符串</returns>
        public static string BaseDecoding(string base64String)
        {
            return BaseDecoding(base64String, System.Text.Encoding.GetEncoding(65001));
        }
        #endregion

        #region 字符串编码
        public static string En(string TextStr)
        {
            TextStr = TextStr.Replace("&", "&amp;");
            TextStr = TextStr.Replace("'", "&#39;");
            TextStr = TextStr.Replace("\"", "&quot;");
            TextStr = TextStr.Replace("<", "&lt;");
            TextStr = TextStr.Replace(">", "&gt;");
            TextStr = TextStr.Replace(" ", "&nbsp;");
            TextStr = TextStr.Replace(System.Environment.NewLine, "<br />");

            return TextStr;
        }
        public static string De(string TextStr)
        {
            TextStr = TextStr.Replace("<br />", System.Environment.NewLine);
            TextStr = TextStr.Replace("&nbsp;", " ");
            TextStr = TextStr.Replace("&gt;", ">");
            TextStr = TextStr.Replace("&lt;", "<");
            TextStr = TextStr.Replace("&quot;", "\"");
            TextStr = TextStr.Replace("&#39;", "'");
            TextStr = TextStr.Replace("&amp;", "&");

            return TextStr;
        }
        #endregion

        private static readonly Dictionary<int, string> _entityTable = new Dictionary<int, string>();
        private static readonly Dictionary<string, string> _USStateTable = new Dictionary<string, string>();

        // Methods
        static Strings()
        {
            FillEntities();
            FillUSStates();
        }

        public static string AsciiToUnicode(int asciiCode)
        {
            Encoding encoding = Encoding.UTF32;
            byte[] bytes = encoding.GetBytes(((char)asciiCode).ToString());
            return encoding.GetString(bytes);
        }

        public static string CamelToProper(string sourceString)
        {
            return Utility.ParseCamelToProper(sourceString);
        }

        public static string Chop(string sourceString)
        {
            return Chop(sourceString, 1);
        }

        public static string Chop(string sourceString, int removeFromEnd)
        {
            string str = sourceString;
            if ((removeFromEnd > 0) && (sourceString.Length > (removeFromEnd - 1)))
            {
                str = str.Remove(sourceString.Length - removeFromEnd, removeFromEnd);
            }
            return str;
        }

        public static string Chop(string sourceString, string backDownTo)
        {
            int startIndex = sourceString.LastIndexOf(backDownTo);
            int count = 0;
            if (startIndex > 0)
            {
                count = sourceString.Length - startIndex;
            }
            string str = sourceString;
            if (sourceString.Length > (count - 1))
            {
                str = str.Remove(startIndex, count);
            }
            return str;
        }

        public static string Clip(string sourceString)
        {
            return Clip(sourceString, 1);
        }

        public static string Clip(string sourceString, int removeFromBeginning)
        {
            string str = sourceString;
            if (sourceString.Length > removeFromBeginning)
            {
                str = str.Remove(0, removeFromBeginning);
            }
            return str;
        }

        public static string Clip(string sourceString, string removeUpTo)
        {
            int index = sourceString.IndexOf(removeUpTo);
            string str = sourceString;
            if ((sourceString.Length > index) && (index > 0))
            {
                str = str.Remove(0, index);
            }
            return str;
        }

        public static string Crop(string sourceString, string startText, string endText)
        {
            int index = sourceString.IndexOf(startText, StringComparison.CurrentCultureIgnoreCase);
            if (index == -1)
            {
                return string.Empty;
            }
            index += startText.Length;
            int num2 = sourceString.IndexOf(endText, index, StringComparison.CurrentCultureIgnoreCase);
            if (num2 == -1)
            {
                return string.Empty;
            }
            return sourceString.Substring(index, num2 - index);
        }

        public static string EntityToText(string entityText)
        {
            entityText = entityText.Replace("&amp;", "&");
            foreach (KeyValuePair<int, string> pair in _entityTable)
            {
                entityText = entityText.Replace(pair.Value, AsciiToUnicode(pair.Key));
            }
            return entityText;
        }

        private static void FillEntities()
        {
            _entityTable.Add(160, "&nbsp;");
            _entityTable.Add(0xa1, "&iexcl;");
            _entityTable.Add(0xa2, "&cent;");
            _entityTable.Add(0xa3, "&pound;");
            _entityTable.Add(0xa4, "&curren;");
            _entityTable.Add(0xa5, "&yen;");
            _entityTable.Add(0xa6, "&brvbar;");
            _entityTable.Add(0xa7, "&sect;");
            _entityTable.Add(0xa8, "&uml;");
            _entityTable.Add(0xa9, "&copy;");
            _entityTable.Add(170, "&ordf;");
            _entityTable.Add(0xab, "&laquo;");
            _entityTable.Add(0xac, "&not;");
            _entityTable.Add(0xad, "&shy;");
            _entityTable.Add(0xae, "&reg;");
            _entityTable.Add(0xaf, "&macr;");
            _entityTable.Add(0xb0, "&deg;");
            _entityTable.Add(0xb1, "&plusmn;");
            _entityTable.Add(0xb2, "&sup2;");
            _entityTable.Add(0xb3, "&sup3;");
            _entityTable.Add(180, "&acute;");
            _entityTable.Add(0xb5, "&micro;");
            _entityTable.Add(0xb6, "&para;");
            _entityTable.Add(0xb7, "&middot;");
            _entityTable.Add(0xb8, "&cedil;");
            _entityTable.Add(0xb9, "&sup1;");
            _entityTable.Add(0xba, "&ordm;");
            _entityTable.Add(0xbb, "&raquo;");
            _entityTable.Add(0xbc, "&frac14;");
            _entityTable.Add(0xbd, "&frac12;");
            _entityTable.Add(190, "&frac34;");
            _entityTable.Add(0xbf, "&iquest;");
            _entityTable.Add(0xc0, "&Agrave;");
            _entityTable.Add(0xc1, "&Aacute;");
            _entityTable.Add(0xc2, "&Acirc;");
            _entityTable.Add(0xc3, "&Atilde;");
            _entityTable.Add(0xc4, "&Auml;");
            _entityTable.Add(0xc5, "&Aring;");
            _entityTable.Add(0xc6, "&AElig;");
            _entityTable.Add(0xc7, "&Ccedil;");
            _entityTable.Add(200, "&Egrave;");
            _entityTable.Add(0xc9, "&Eacute;");
            _entityTable.Add(0xca, "&Ecirc;");
            _entityTable.Add(0xcb, "&Euml;");
            _entityTable.Add(0xcc, "&Igrave;");
            _entityTable.Add(0xcd, "&Iacute;");
            _entityTable.Add(0xce, "&Icirc;");
            _entityTable.Add(0xcf, "&Iuml;");
            _entityTable.Add(0xd0, "&ETH;");
            _entityTable.Add(0xd1, "&Ntilde;");
            _entityTable.Add(210, "&Ograve;");
            _entityTable.Add(0xd3, "&Oacute;");
            _entityTable.Add(0xd4, "&Ocirc;");
            _entityTable.Add(0xd5, "&Otilde;");
            _entityTable.Add(0xd6, "&Ouml;");
            _entityTable.Add(0xd7, "&times;");
            _entityTable.Add(0xd8, "&Oslash;");
            _entityTable.Add(0xd9, "&Ugrave;");
            _entityTable.Add(0xda, "&Uacute;");
            _entityTable.Add(0xdb, "&Ucirc;");
            _entityTable.Add(220, "&Uuml;");
            _entityTable.Add(0xdd, "&Yacute;");
            _entityTable.Add(0xde, "&THORN;");
            _entityTable.Add(0xdf, "&szlig;");
            _entityTable.Add(0xe0, "&agrave;");
            _entityTable.Add(0xe1, "&aacute;");
            _entityTable.Add(0xe2, "&acirc;");
            _entityTable.Add(0xe3, "&atilde;");
            _entityTable.Add(0xe4, "&auml;");
            _entityTable.Add(0xe5, "&aring;");
            _entityTable.Add(230, "&aelig;");
            _entityTable.Add(0xe7, "&ccedil;");
            _entityTable.Add(0xe8, "&egrave;");
            _entityTable.Add(0xe9, "&eacute;");
            _entityTable.Add(0xea, "&ecirc;");
            _entityTable.Add(0xeb, "&euml;");
            _entityTable.Add(0xec, "&igrave;");
            _entityTable.Add(0xed, "&iacute;");
            _entityTable.Add(0xee, "&icirc;");
            _entityTable.Add(0xef, "&iuml;");
            _entityTable.Add(240, "&eth;");
            _entityTable.Add(0xf1, "&ntilde;");
            _entityTable.Add(0xf2, "&ograve;");
            _entityTable.Add(0xf3, "&oacute;");
            _entityTable.Add(0xf4, "&ocirc;");
            _entityTable.Add(0xf5, "&otilde;");
            _entityTable.Add(0xf6, "&ouml;");
            _entityTable.Add(0xf7, "&divide;");
            _entityTable.Add(0xf8, "&oslash;");
            _entityTable.Add(0xf9, "&ugrave;");
            _entityTable.Add(250, "&uacute;");
            _entityTable.Add(0xfb, "&ucirc;");
            _entityTable.Add(0xfc, "&uuml;");
            _entityTable.Add(0xfd, "&yacute;");
            _entityTable.Add(0xfe, "&thorn;");
            _entityTable.Add(0xff, "&yuml;");
            _entityTable.Add(0x192, "&fnof;");
            _entityTable.Add(0x391, "&Alpha;");
            _entityTable.Add(0x392, "&Beta;");
            _entityTable.Add(0x393, "&Gamma;");
            _entityTable.Add(0x394, "&Delta;");
            _entityTable.Add(0x395, "&Epsilon;");
            _entityTable.Add(0x396, "&Zeta;");
            _entityTable.Add(0x397, "&Eta;");
            _entityTable.Add(920, "&Theta;");
            _entityTable.Add(0x399, "&Iota;");
            _entityTable.Add(0x39a, "&Kappa;");
            _entityTable.Add(0x39b, "&Lambda;");
            _entityTable.Add(0x39c, "&Mu;");
            _entityTable.Add(0x39d, "&Nu;");
            _entityTable.Add(0x39e, "&Xi;");
            _entityTable.Add(0x39f, "&Omicron;");
            _entityTable.Add(0x3a0, "&Pi;");
            _entityTable.Add(0x3a1, "&Rho;");
            _entityTable.Add(0x3a3, "&Sigma;");
            _entityTable.Add(0x3a4, "&Tau;");
            _entityTable.Add(0x3a5, "&Upsilon;");
            _entityTable.Add(0x3a6, "&Phi;");
            _entityTable.Add(0x3a7, "&Chi;");
            _entityTable.Add(0x3a8, "&Psi;");
            _entityTable.Add(0x3a9, "&Omega;");
            _entityTable.Add(0x3b1, "&alpha;");
            _entityTable.Add(0x3b2, "&beta;");
            _entityTable.Add(0x3b3, "&gamma;");
            _entityTable.Add(0x3b4, "&delta;");
            _entityTable.Add(0x3b5, "&epsilon;");
            _entityTable.Add(950, "&zeta;");
            _entityTable.Add(0x3b7, "&eta;");
            _entityTable.Add(0x3b8, "&theta;");
            _entityTable.Add(0x3b9, "&iota;");
            _entityTable.Add(0x3ba, "&kappa;");
            _entityTable.Add(0x3bb, "&lambda;");
            _entityTable.Add(0x3bc, "&mu;");
            _entityTable.Add(0x3bd, "&nu;");
            _entityTable.Add(0x3be, "&xi;");
            _entityTable.Add(0x3bf, "&omicron;");
            _entityTable.Add(960, "&pi;");
            _entityTable.Add(0x3c1, "&rho;");
            _entityTable.Add(0x3c2, "&sigmaf;");
            _entityTable.Add(0x3c3, "&sigma;");
            _entityTable.Add(0x3c4, "&tau;");
            _entityTable.Add(0x3c5, "&upsilon;");
            _entityTable.Add(0x3c6, "&phi;");
            _entityTable.Add(0x3c7, "&chi;");
            _entityTable.Add(0x3c8, "&psi;");
            _entityTable.Add(0x3c9, "&omega;");
            _entityTable.Add(0x3d1, "&thetasym;");
            _entityTable.Add(0x3d2, "&upsih;");
            _entityTable.Add(0x3d6, "&piv;");
            _entityTable.Add(0x2022, "&bull;");
            _entityTable.Add(0x2026, "&hellip;");
            _entityTable.Add(0x2032, "&prime;");
            _entityTable.Add(0x2033, "&Prime;");
            _entityTable.Add(0x203e, "&oline;");
            _entityTable.Add(0x2044, "&frasl;");
            _entityTable.Add(0x2118, "&weierp;");
            _entityTable.Add(0x2111, "&image;");
            _entityTable.Add(0x211c, "&real;");
            _entityTable.Add(0x2122, "&trade;");
            _entityTable.Add(0x2135, "&alefsym;");
            _entityTable.Add(0x2190, "&larr;");
            _entityTable.Add(0x2191, "&uarr;");
            _entityTable.Add(0x2192, "&rarr;");
            _entityTable.Add(0x2193, "&darr;");
            _entityTable.Add(0x2194, "&harr;");
            _entityTable.Add(0x21b5, "&crarr;");
            _entityTable.Add(0x21d0, "&lArr;");
            _entityTable.Add(0x21d1, "&uArr;");
            _entityTable.Add(0x21d2, "&rArr;");
            _entityTable.Add(0x21d3, "&dArr;");
            _entityTable.Add(0x21d4, "&hArr;");
            _entityTable.Add(0x2200, "&forall;");
            _entityTable.Add(0x2202, "&part;");
            _entityTable.Add(0x2203, "&exist;");
            _entityTable.Add(0x2205, "&empty;");
            _entityTable.Add(0x2207, "&nabla;");
            _entityTable.Add(0x2208, "&isin;");
            _entityTable.Add(0x2209, "&notin;");
            _entityTable.Add(0x220b, "&ni;");
            _entityTable.Add(0x220f, "&prod;");
            _entityTable.Add(0x2211, "&sum;");
            _entityTable.Add(0x2212, "&minus;");
            _entityTable.Add(0x2217, "&lowast;");
            _entityTable.Add(0x221a, "&radic;");
            _entityTable.Add(0x221d, "&prop;");
            _entityTable.Add(0x221e, "&infin;");
            _entityTable.Add(0x2220, "&ang;");
            _entityTable.Add(0x2227, "&and;");
            _entityTable.Add(0x2228, "&or;");
            _entityTable.Add(0x2229, "&cap;");
            _entityTable.Add(0x222a, "&cup;");
            _entityTable.Add(0x222b, "&int;");
            _entityTable.Add(0x2234, "&there4;");
            _entityTable.Add(0x223c, "&sim;");
            _entityTable.Add(0x2245, "&cong;");
            _entityTable.Add(0x2248, "&asymp;");
            _entityTable.Add(0x2260, "&ne;");
            _entityTable.Add(0x2261, "&equiv;");
            _entityTable.Add(0x2264, "&le;");
            _entityTable.Add(0x2265, "&ge;");
            _entityTable.Add(0x2282, "&sub;");
            _entityTable.Add(0x2283, "&sup;");
            _entityTable.Add(0x2284, "&nsub;");
            _entityTable.Add(0x2286, "&sube;");
            _entityTable.Add(0x2287, "&supe;");
            _entityTable.Add(0x2295, "&oplus;");
            _entityTable.Add(0x2297, "&otimes;");
            _entityTable.Add(0x22a5, "&perp;");
            _entityTable.Add(0x22c5, "&sdot;");
            _entityTable.Add(0x2308, "&lceil;");
            _entityTable.Add(0x2309, "&rceil;");
            _entityTable.Add(0x230a, "&lfloor;");
            _entityTable.Add(0x230b, "&rfloor;");
            _entityTable.Add(0x2329, "&lang;");
            _entityTable.Add(0x232a, "&rang;");
            _entityTable.Add(0x25ca, "&loz;");
            _entityTable.Add(0x2660, "&spades;");
            _entityTable.Add(0x2663, "&clubs;");
            _entityTable.Add(0x2665, "&hearts;");
            _entityTable.Add(0x2666, "&diams;");
            _entityTable.Add(0x22, "&quot;");
            _entityTable.Add(60, "&lt;");
            _entityTable.Add(0x3e, "&gt;");
            _entityTable.Add(0x152, "&OElig;");
            _entityTable.Add(0x153, "&oelig;");
            _entityTable.Add(0x160, "&Scaron;");
            _entityTable.Add(0x161, "&scaron;");
            _entityTable.Add(0x178, "&Yuml;");
            _entityTable.Add(710, "&circ;");
            _entityTable.Add(0x2dc, "&tilde;");
            _entityTable.Add(0x2002, "&ensp;");
            _entityTable.Add(0x2003, "&emsp;");
            _entityTable.Add(0x2009, "&thinsp;");
            _entityTable.Add(0x200c, "&zwnj;");
            _entityTable.Add(0x200d, "&zwj;");
            _entityTable.Add(0x200e, "&lrm;");
            _entityTable.Add(0x200f, "&rlm;");
            _entityTable.Add(0x2013, "&ndash;");
            _entityTable.Add(0x2014, "&mdash;");
            _entityTable.Add(0x2018, "&lsquo;");
            _entityTable.Add(0x2019, "&rsquo;");
            _entityTable.Add(0x201a, "&sbquo;");
            _entityTable.Add(0x201c, "&ldquo;");
            _entityTable.Add(0x201d, "&rdquo;");
            _entityTable.Add(0x201e, "&bdquo;");
            _entityTable.Add(0x2020, "&dagger;");
            _entityTable.Add(0x2021, "&Dagger;");
            _entityTable.Add(0x2030, "&permil;");
            _entityTable.Add(0x2039, "&lsaquo;");
            _entityTable.Add(0x203a, "&rsaquo;");
            _entityTable.Add(0x20ac, "&euro;");
        }

        private static void FillUSStates()
        {
            _USStateTable.Add("ALABAMA", "AL");
            _USStateTable.Add("ALASKA", "AK");
            _USStateTable.Add("AMERICAN SAMOA", "AS");
            _USStateTable.Add("ARIZONA ", "AZ");
            _USStateTable.Add("ARKANSAS", "AR");
            _USStateTable.Add("CALIFORNIA ", "CA");
            _USStateTable.Add("COLORADO ", "CO");
            _USStateTable.Add("CONNECTICUT", "CT");
            _USStateTable.Add("DELAWARE", "DE");
            _USStateTable.Add("DISTRICT OF COLUMBIA", "DC");
            _USStateTable.Add("FEDERATED STATES OF MICRONESIA", "FM");
            _USStateTable.Add("FLORIDA", "FL");
            _USStateTable.Add("GEORGIA", "GA");
            _USStateTable.Add("GUAM ", "GU");
            _USStateTable.Add("HAWAII", "HI");
            _USStateTable.Add("IDAHO", "ID");
            _USStateTable.Add("ILLINOIS", "IL");
            _USStateTable.Add("INDIANA", "IN");
            _USStateTable.Add("IOWA", "IA");
            _USStateTable.Add("KANSAS", "KS");
            _USStateTable.Add("KENTUCKY", "KY");
            _USStateTable.Add("LOUISIANA", "LA");
            _USStateTable.Add("MAINE", "ME");
            _USStateTable.Add("MARSHALL ISLANDS", "MH");
            _USStateTable.Add("MARYLAND", "MD");
            _USStateTable.Add("MASSACHUSETTS", "MA");
            _USStateTable.Add("MICHIGAN", "MI");
            _USStateTable.Add("MINNESOTA", "MN");
            _USStateTable.Add("MISSISSIPPI", "MS");
            _USStateTable.Add("MISSOURI", "MO");
            _USStateTable.Add("MONTANA", "MT");
            _USStateTable.Add("NEBRASKA", "NE");
            _USStateTable.Add("NEVADA", "NV");
            _USStateTable.Add("NEW HAMPSHIRE", "NH");
            _USStateTable.Add("NEW JERSEY", "NJ");
            _USStateTable.Add("NEW MEXICO", "NM");
            _USStateTable.Add("NEW YORK", "NY");
            _USStateTable.Add("NORTH CAROLINA", "NC");
            _USStateTable.Add("NORTH DAKOTA", "ND");
            _USStateTable.Add("NORTHERN MARIANA ISLANDS", "MP");
            _USStateTable.Add("OHIO", "OH");
            _USStateTable.Add("OKLAHOMA", "OK");
            _USStateTable.Add("OREGON", "OR");
            _USStateTable.Add("PALAU", "PW");
            _USStateTable.Add("PENNSYLVANIA", "PA");
            _USStateTable.Add("PUERTO RICO", "PR");
            _USStateTable.Add("RHODE ISLAND", "RI");
            _USStateTable.Add("SOUTH CAROLINA", "SC");
            _USStateTable.Add("SOUTH DAKOTA", "SD");
            _USStateTable.Add("TENNESSEE", "TN");
            _USStateTable.Add("TEXAS", "TX");
            _USStateTable.Add("UTAH", "UT");
            _USStateTable.Add("VERMONT", "VT");
            _USStateTable.Add("VIRGIN ISLANDS", "VI");
            _USStateTable.Add("VIRGINIA ", "VA");
            _USStateTable.Add("WASHINGTON", "WA");
            _USStateTable.Add("WEST VIRGINIA", "WV");
            _USStateTable.Add("WISCONSIN", "WI");
            _USStateTable.Add("WYOMING", "WY");
        }

        [Obsolete("Will be removed in future versions. Use Validation.IsAlpha instead")]
        public static bool IsAlpha(string s)
        {
            return Validation.IsAlpha(s);
        }

        [Obsolete("Will be removed in future versions. Use Validation.IsAlphaNumeric instead")]
        public static bool IsAlphaNumeric(string s)
        {
            return Validation.IsAlphaNumeric(s);
        }

        [Obsolete("Will be removed in future versions. Use Validation.IsEmail instead")]
        public static bool IsValidEmail(string emailAddressString)
        {
            return Validation.IsEmail(emailAddressString);
        }


        public static string Squeeze(string sourceString)
        {
            char[] separator = new char[] { ' ' };
            string[] strArray = sourceString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach (string str in strArray)
            {
                if (!string.IsNullOrEmpty(str.Trim()))
                {
                    builder.Append(str + " ");
                }
            }
            return Chop(builder.ToString()).Trim();
        }

        public static string Strip(string sourceString, string stripValue)
        {
            if (!string.IsNullOrEmpty(stripValue))
            {
                string[] strArray = stripValue.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!string.IsNullOrEmpty(sourceString))
                    {
                        sourceString = Regex.Replace(sourceString, strArray[i], string.Empty);
                    }
                }
            }
            return sourceString;
        }

        public static string StripHTML(string htmlString)
        {
            return StripHTML(htmlString, string.Empty);
        }

        public static string StripHTML(string htmlString, string htmlPlaceHolder)
        {
            return Regex.Replace(htmlString, @"<(.|\n)*?>", htmlPlaceHolder).Replace("&nbsp;", string.Empty).Replace("&amp;", "&").Replace("&gt;", ">").Replace("&lt;", "<");
        }

        public static string StripNonAlphaNumeric(string sourceString)
        {
            return Utility.StripNonAlphaNumeric(sourceString);
        }

        public static string StripNonAlphaNumeric(string sourceString, char cReplace)
        {
            return Utility.StripNonAlphaNumeric(sourceString, cReplace);
        }

        public static string TextToEntity(string textString)
        {
            foreach (KeyValuePair<int, string> pair in _entityTable)
            {
                textString = textString.Replace(AsciiToUnicode(pair.Key), pair.Value);
            }
            return textString.Replace(AsciiToUnicode(0x26), "&amp;");
        }

        public static string ToDelimitedList(List<string> list)
        {
            return ToDelimitedList(list, ",");
        }

        public static string ToDelimitedList(List<string> list, string delimiter)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in list)
            {
                builder.Append(str + delimiter);
            }
            return Chop(builder.ToString());
        }

        public static string ToDelimitedList(string[] list, string delimiter)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in list)
            {
                builder.Append(str + delimiter);
            }
            return Chop(builder.ToString());
        }

        public static string[] ToWords(string sourceString)
        {
            return sourceString.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string USStateAbbrevToName(string stateAbbrev)
        {
            stateAbbrev = stateAbbrev.ToUpper();
            foreach (KeyValuePair<string, string> pair in _USStateTable)
            {
                if (stateAbbrev == pair.Value)
                {
                    return pair.Key;
                }
            }
            return null;
        }

        public static string USStateNameToAbbrev(string stateName)
        {
            stateName = stateName.ToUpper();
            foreach (KeyValuePair<string, string> pair in _USStateTable)
            {
                if (stateName == pair.Key)
                {
                    return pair.Value;
                }
            }
            return null;
        }

    }
}
