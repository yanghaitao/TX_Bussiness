using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;
using System.Security.Cryptography;
using System.Net;

namespace Bussiness.Common
{
    public static class Web
    {
        // Methods
        public static t Cookie<t>(string param)
        {
            t local = default(t);
            HttpCookie cookie = HttpContext.Current.Request.Cookies[param];
            if (cookie != null)
            {
                local = (t)Utility.ChangeType(cookie.Value, typeof(t));
            }
            return local;
        }

        public static string CreateSpamFreeEmailLink(string emailText)
        {
            if (!string.IsNullOrEmpty(emailText))
            {
                string[] strArray = emailText.Split(new char[] { '@' });
                if (strArray.Length == 2)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<script type='text/javascript'>");
                    builder.Append("var m = '" + strArray[0] + "';");
                    builder.Append("var a = '" + strArray[1] + "';");
                    builder.Append("var l = '" + emailText + "';");
                    builder.Append("document.write('<a href=\"mailto:' + m + '@' + a + '\">' + l + '</a>');");
                    builder.Append("</script>");
                    return builder.ToString();
                }
            }
            return string.Empty;
        }

        public static string[] DNSLookup(string url)
        {
            ArrayList list = new ArrayList();
            IPHostEntry hostEntry = Dns.GetHostEntry(url);
            list.Add("HostName," + hostEntry.HostName);
            foreach (string str in hostEntry.Aliases)
            {
                list.Add("Aliases," + str);
            }
            foreach (IPAddress address in hostEntry.AddressList)
            {
                list.Add("Address," + address);
            }
            return (string[])list.ToArray(typeof(string));
        }

        public static string GenerateLoremIpsum(int count, string method)
        {
            Random random = new Random();
            if ((method.ToLower() == "p") && (count > 0x3e8))
            {
                throw new ArgumentOutOfRangeException("count", "Sorry, lorem ipsum control only allows 1000 or less paragraphs.");
            }
            string sIn = LoadTextFromManifest("loremIpsum.txt");
            if (sIn == null)
            {
                throw new Exception("Could not load loremipsum.txt");
            }
            StringBuilder builder = new StringBuilder();
            if ((string.IsNullOrEmpty(method) || (method.ToLower() == "p")) || (((method.ToLower() != "p") && (method.ToLower() != "c")) && (method.ToLower() != "w")))
            {
                char[] separator = new char[] { '|' };
                string[] strArray = sIn.Split(separator);
                ArrayList list = new ArrayList();
                foreach (string str2 in strArray)
                {
                    list.Add(str2);
                }
                int length = strArray.Length;
                if (count > length)
                {
                    int num2 = count - length;
                    for (int j = 0; j < num2; j++)
                    {
                        int index = random.Next(0, length - 1);
                        list.Add(strArray[index]);
                    }
                }
                for (int i = 0; i < count; i++)
                {
                    builder.Append("<p>");
                    builder.Append(list[i]);
                    builder.Append("</p>");
                }
            }
            if (method.ToLower() == "c")
            {
                int num6 = sIn.Length;
                if (count > num6)
                {
                    int num7 = count / num6;
                    for (int k = 0; k < num7; k++)
                    {
                        string str3 = sIn;
                        sIn = sIn + " " + str3;
                    }
                }
                builder.Append(Utility.ShortenText(sIn, count));
            }
            if (method.ToLower() == "w")
            {
                string[] strArray2 = sIn.Split(new char[] { ' ' });
                ArrayList list2 = new ArrayList();
                foreach (string str4 in strArray2)
                {
                    list2.Add(str4);
                }
                int num9 = strArray2.Length;
                if (count > num9)
                {
                    int num10 = count - num9;
                    for (int n = 0; n < num10; n++)
                    {
                        int num12 = random.Next(0, num9 - 1);
                        list2.Add(strArray2[num12]);
                    }
                }
                for (int m = 0; m < count; m++)
                {
                    builder.Append(list2[m]);
                    builder.Append(" ");
                }
            }
            return builder.ToString();
        }

        public static string GetGravatar(string email, int size)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(email));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            StringBuilder builder2 = new StringBuilder();
            builder2.Append("<img src=\"");
            builder2.Append("http://www.gravatar.com/avatar.php?");
            builder2.Append("gravatar_id=" + builder);
            builder2.Append("&amp;rating=G");
            builder2.Append("&amp;size=" + size);
            builder2.Append("&amp;default=");
            builder2.Append(HttpContext.Current.Server.UrlEncode("http://example.com/noavatar.gif"));
            builder2.Append("\" alt=\"\" />");
            return builder2.ToString();
        }

        private static string LoadTextFromManifest(string templateFileName)
        {
            string str = null;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SubSonic.Sugar." + templateFileName))
            {
                if (stream != null)
                {
                    StreamReader reader = new StreamReader(stream);
                    str = reader.ReadToEnd();
                    reader.Close();
                }
            }
            return str;
        }

        public static t QueryString<t>(string param)
        {
            t local = default(t);
            if (HttpContext.Current.Request.QueryString[param] != null)
            {
                object obj2 = HttpContext.Current.Request[param];
                local = (t)Utility.ChangeType(obj2, typeof(t));
            }
            return local;
        }

        public static string ReadWebPage(string url)
        {
            string str;
            using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                str = reader.ReadToEnd();
                reader.Close();
            }
            return str;
        }

        public static string[] ScrapeImages(string url)
        {
            return ScrapeImages(url, true);
        }

        public static string[] ScrapeImages(string url, bool returnWithTag)
        {
            string input = ReadWebPage(url);
            StringBuilder builder = new StringBuilder();
            builder.Append("<img[^>]+");
            builder.Append(@"src\s*=\s*");
            builder.Append("(?:\"(?<src>[^\"]*)\"|'(?<src>[^']*)'|(?<src>[^\"'>\\s]+))");
            builder.Append("[^>]*>");
            Match match = new Regex(builder.ToString(), RegexOptions.IgnoreCase).Match(input);
            ArrayList list = new ArrayList();
            list.Add("<BASE href=\"" + url + "\">" + url);
            while (match.Success)
            {
                string str2 = match.Groups["src"].Value;
                string str3 = returnWithTag ? ("<img src=\"" + str2 + "\" alt=\"\" />") : str2;
                list.Add(str3);
                match = match.NextMatch();
            }
            string[] array = new string[list.Count];
            list.CopyTo(array);
            return array;
        }

        public static string[] ScrapeLinks(string url, bool makeLinkable)
        {
            string input = ReadWebPage(url);
            StringBuilder builder = new StringBuilder();
            builder.Append("<a[^>]+");
            builder.Append(@"href\s*=\s*");
            builder.Append("(?:\"(?<href>[^\"]*)\"|'(?<href>[^']*)'|(?<href>[^\"'>\\s]+))");
            builder.Append("[^>]*>.*?</a>");
            Match match = new Regex(builder.ToString(), RegexOptions.IgnoreCase).Match(input);
            ArrayList list = new ArrayList();
            list.Add("<BASE href=\"" + url + "\">" + url);
            while (match.Success)
            {
                string str2 = match.Groups["href"].Value;
                string str3 = makeLinkable ? ("<a href=\"" + str2 + "\" target=\"_blank\">" + str2 + "</a>") : str2;
                list.Add(str3);
                match = match.NextMatch();
            }
            string[] array = new string[list.Count];
            list.CopyTo(array);
            return array;
        }

        public static t SessionValue<t>(string param)
        {
            t local = default(t);
            if (HttpContext.Current.Session[param] != null)
            {
                object obj2 = HttpContext.Current.Session[param];
                local = (t)Utility.ChangeType(obj2, typeof(t));
            }
            return local;
        }

        // Properties
        public static bool IsLocalNetworkRequest
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return false;
                }
                if (HttpContext.Current.Request.IsLocal)
                {
                    return true;
                }
                string[] strArray = HttpContext.Current.Request.UserHostAddress.Split(new char[] { '.' });
                int num = Convert.ToInt16(strArray[0]);
                int num2 = Convert.ToInt16(strArray[1]);
                switch (num)
                {
                    case 10:
                    case 0x7f:
                        return true;
                }
                if ((num == 0xc0) && (num2 == 0xa8))
                {
                    return true;
                }
                if (num != 0xac)
                {
                    return false;
                }
                return ((num2 > 15) && (num2 < 0x21));
            }
        }
    }
}
