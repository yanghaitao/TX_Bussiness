using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace Bussiness.Common
{
    public class Utility
    {
        // Fields
        private static bool? _isRunningInMediumTrust;

        // Methods
        public static string ByteArrayToString(byte[] arrInput)
        {
            StringBuilder builder = new StringBuilder(arrInput.Length * 2);
            for (int i = 0; i < arrInput.Length; i++)
            {
                builder.Append(arrInput[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static object ChangeType(object value, Type conversionType)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }
                NullableConverter converter = new NullableConverter(conversionType);
                conversionType = converter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }

        public static string CheckStringLength(string stringToCheck, int maxLength)
        {
            if (stringToCheck.Length > maxLength)
            {
                if ((stringToCheck.Length > maxLength) && (stringToCheck.IndexOf(" ") == -1))
                {
                    return (stringToCheck.Substring(0, maxLength) + "...");
                }
                if (stringToCheck.Length > 0)
                {
                    return (stringToCheck.Substring(0, maxLength) + "...");
                }
            }
            return stringToCheck;
        }

        [Obsolete("Deprecated: Use DataTableToHtmlTable() instead")]
        public static string DataTableToHTML(DataTable tbl, string tableWidth)
        {
            return DataTableToHtmlTable(tbl, tableWidth);
        }

        public static string DataTableToHtmlTable(DataTable tbl, string tableWidth)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(tableWidth))
            {
                tableWidth = "70%";
            }
            if (tbl != null)
            {
                builder.AppendFormat("<table style=\"width: {0}\" cellpadding=\"4\" cellspacing=\"0\"><thead style=\"background-color: #dcdcdc\">", tableWidth);
                foreach (DataColumn column in tbl.Columns)
                {
                    builder.AppendFormat("<th><span style=\"font-weight: bold\">{0}</span></th>", column.ColumnName);
                }
                builder.Append("</thead>");
                bool flag = false;
                foreach (DataRow row in tbl.Rows)
                {
                    if (flag)
                    {
                        builder.Append("<tr>");
                    }
                    else
                    {
                        builder.Append("<tr style=\"background-color: #f5f5f5\">");
                    }
                    foreach (DataColumn column2 in tbl.Columns)
                    {
                        builder.AppendFormat("<td>{0}</td>", row[column2]);
                    }
                    builder.Append("</tr>");
                    flag = !flag;
                }
                builder.Append("</table>");
            }
            return builder.ToString();
        }

        public static string FastReplace(string original, string pattern, string replacement)
        {
            return FastReplace(original, pattern, replacement, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string FastReplace(string original, string pattern, string replacement, StringComparison comparisonType)
        {
            if (original == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(pattern))
            {
                return original;
            }
            int length = pattern.Length;
            int num2 = -1;
            int startIndex = 0;
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                num2 = original.IndexOf(pattern, num2 + 1, comparisonType);
                if (num2 < 0)
                {
                    builder.Append(original, startIndex, original.Length - startIndex);
                    return builder.ToString();
                }
                builder.Append(original, startIndex, num2 - startIndex);
                builder.Append(replacement);
                startIndex = num2 + length;
            }
        }

        [Obsolete("Obsolete and marked for removal.")]
        public static string FormatDate(DateTime theDate)
        {
            return FormatDate(theDate, false, null);
        }

        [Obsolete("Obsolete and marked for removal.")]
        public static string FormatDate(DateTime theDate, bool showTime)
        {
            return FormatDate(theDate, showTime, null);
        }

        [Obsolete("Obsolete and marked for removal.")]
        public static string FormatDate(DateTime theDate, bool showTime, string pattern)
        {
            if (pattern == null)
            {
                if (showTime)
                {
                    pattern = "MMMM d, yyyy hh:mm tt";
                }
                else
                {
                    pattern = "MMMM d, yyyy";
                }
            }
            return theDate.ToString(pattern);
        }
        public static Guid GetGuidParameter(string sParam)
        {
            Guid empty = Guid.Empty;
            if (HttpContext.Current.Request.QueryString[sParam] != null)
            {
                string guid = HttpContext.Current.Request[sParam];
                if (Validation.IsGuid(guid))
                {
                    empty = new Guid(guid);
                }
            }
            return empty;
        }

        public static int GetIntParameter(string sParam)
        {
            int result = 0;
            if (HttpContext.Current.Request[sParam] != null)
            {
                string str = HttpContext.Current.Request[sParam];
                if (!string.IsNullOrEmpty(str))
                {
                    int.TryParse(str, out result);
                }
            }
            return result;
        }

        public static string GetParameter(string sParam)
        {
            if (HttpContext.Current.Request[sParam] != null)
            {
                return HttpContext.Current.Request[sParam];
            }
            return string.Empty;
        }

        public static string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, false));
            builder.Append(RandomInt(0x3e8, 0x270f));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        public static string GetSiteRoot()
        {
            string str = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            switch (str)
            {
                case null:
                case "80":
                case "443":
                    str = string.Empty;
                    break;

                default:
                    str = ":" + str;
                    break;
            }
            string str2 = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            switch (str2)
            {
                case null:
                case "0":
                    str2 = "http://";
                    break;

                default:
                    str2 = "https://";
                    break;
            }
            string applicationPath = HttpContext.Current.Request.ApplicationPath;
            if (applicationPath == "/")
            {
                applicationPath = string.Empty;
            }
            return (str2 + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + str + applicationPath);
        }

        public static SqlDbType GetSqlDBType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                    return SqlDbType.VarChar;

                case DbType.Binary:
                    return SqlDbType.VarBinary;

                case DbType.Byte:
                    return SqlDbType.TinyInt;

                case DbType.Boolean:
                    return SqlDbType.Bit;

                case DbType.Currency:
                    return SqlDbType.Money;

                case DbType.Date:
                    return SqlDbType.DateTime;

                case DbType.DateTime:
                    return SqlDbType.DateTime;

                case DbType.Decimal:
                    return SqlDbType.Decimal;

                case DbType.Double:
                    return SqlDbType.Float;

                case DbType.Guid:
                    return SqlDbType.UniqueIdentifier;

                case DbType.Int16:
                    return SqlDbType.Int;

                case DbType.Int32:
                    return SqlDbType.Int;

                case DbType.Int64:
                    return SqlDbType.BigInt;

                case DbType.Object:
                    return SqlDbType.Variant;

                case DbType.SByte:
                    return SqlDbType.TinyInt;

                case DbType.Single:
                    return SqlDbType.Real;

                case DbType.String:
                    return SqlDbType.NVarChar;

                case DbType.Time:
                    return SqlDbType.DateTime;

                case DbType.UInt16:
                    return SqlDbType.Int;

                case DbType.UInt32:
                    return SqlDbType.Int;

                case DbType.UInt64:
                    return SqlDbType.BigInt;

                case DbType.VarNumeric:
                    return SqlDbType.Decimal;

                case DbType.AnsiStringFixedLength:
                    return SqlDbType.Char;

                case DbType.StringFixedLength:
                    return SqlDbType.NChar;
            }
            return SqlDbType.VarChar;
        }

        public static string GetSystemType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                    return "System.String";

                case DbType.Binary:
                    return "System.Byte[]";

                case DbType.Byte:
                    return "System.Byte";

                case DbType.Boolean:
                    return "System.Boolean";

                case DbType.Currency:
                    return "System.Decimal";

                case DbType.Date:
                    return "System.DateTime";

                case DbType.DateTime:
                    return "System.DateTime";

                case DbType.Decimal:
                    return "System.Decimal";

                case DbType.Double:
                    return "System.Double";

                case DbType.Guid:
                    return "System.Guid";

                case DbType.Int16:
                    return "System.Int16";

                case DbType.Int32:
                    return "System.Int32";

                case DbType.Int64:
                    return "System.Int64";

                case DbType.Object:
                    return "System.Object";

                case DbType.SByte:
                    return "System.SByte";

                case DbType.Single:
                    return "System.Single";

                case DbType.String:
                    return "System.String";

                case DbType.Time:
                    return "System.TimeSpan";

                case DbType.UInt16:
                    return "System.UInt16";

                case DbType.UInt32:
                    return "System.UInt32";

                case DbType.UInt64:
                    return "System.UInt64";

                case DbType.VarNumeric:
                    return "System.Decimal";

                case DbType.AnsiStringFixedLength:
                    return "System.String";

                case DbType.StringFixedLength:
                    return "System.String";
            }
            return "System.String";
        }


        public static bool IsAuditField(string colName)
        {
            if ((!IsMatch(colName, "CreatedBy") && !IsMatch(colName, "CreatedOn")) && !IsMatch(colName, "ModifiedBy"))
            {
                return IsMatch(colName, "ModifiedOn");
            }
            return true;
        }

        public static bool IsLogicalDeleteColumn(string columnName)
        {
            if (!IsMatch(columnName, "Deleted"))
            {
                return IsMatch(columnName, "IsDeleted");
            }
            return true;
        }


        public static bool IsMatch(string stringA, string stringB)
        {
            return string.Equals(stringA, stringB, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsMatch(string stringA, string stringB, bool trimStrings)
        {
            if (trimStrings)
            {
                return string.Equals(stringA.Trim(), stringB.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }
            return string.Equals(stringA, stringB, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsNullableDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                case DbType.String:
                case DbType.AnsiString:
                case DbType.Binary:
                case DbType.Object:
                    return false;
            }
            return true;
        }


        public static bool IsParsable(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                case DbType.Object:
                case DbType.String:
                case DbType.AnsiString:
                case DbType.Binary:
                case DbType.Guid:
                    return false;
            }
            return true;
        }

        public static bool IsRegexMatch(string inputString, string matchPattern)
        {
            return Regex.IsMatch(inputString, matchPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
        }


        public static string KeyWordCheck(string word, string table, string appendWith)
        {
            string str = word + appendWith;
            if (word == table)
            {
                return str;
            }
            switch (word.ToLower())
            {
                case "abstract":
                case "as":
                case "base":
                case "bool":
                case "break":
                case "byte":
                case "case":
                case "catch":
                case "char":
                case "checked":
                case "class":
                case "const":
                case "continue":
                case "date":
                case "datetime":
                case "decimal":
                case "default":
                case "delegate":
                case "do":
                case "double":
                case "else":
                case "enum":
                case "event":
                case "explicit":
                case "extern":
                case "false":
                case "finally":
                case "fixed":
                case "float":
                case "for":
                case "foreach":
                case "goto":
                case "if":
                case "implicit":
                case "in":
                case "int":
                case "interface":
                case "internal":
                case "is":
                case "lock":
                case "long":
                case "namespace":
                case "new":
                case "null":
                case "object":
                case "operator":
                case "out":
                case "override":
                case "params":
                case "private":
                case "protected":
                case "public":
                case "readonly":
                case "ref":
                case "return":
                case "sbyte":
                case "sealed":
                case "short":
                case "sizeof":
                case "stackalloc":
                case "static":
                case "string":
                case "struct":
                case "switch":
                case "this":
                case "throw":
                case "true":
                case "try":
                case "typecode":
                case "typeof":
                case "uint":
                case "ulong":
                case "unchecked":
                case "unsafe":
                case "ushort":
                case "using":
                case "virtual":
                case "volatile":
                case "void":
                case "while":
                case "get":
                case "partial":
                case "set":
                case "value":
                case "where":
                case "yield":
                case "alias":
                case "addHandler":
                case "ansi":
                case "assembly":
                case "auto":
                case "binary":
                case "byref":
                case "byval":
                case "custom":
                case "directcast":
                case "each":
                case "elseif":
                case "end":
                case "error":
                case "friend":
                case "global":
                case "handles":
                case "implements":
                case "lib":
                case "loop":
                case "me":
                case "module":
                case "mustinherit":
                case "mustoverride":
                case "mybase":
                case "myclass":
                case "narrowing":
                case "next":
                case "nothing":
                case "notinheritable":
                case "notoverridable":
                case "of":
                case "off":
                case "on":
                case "option":
                case "optional":
                case "overloads":
                case "overridable":
                case "overrides":
                case "paramarray":
                case "preserve":
                case "property":
                case "raiseevent":
                case "resume":
                case "shadows":
                case "shared":
                case "step":
                case "structure":
                case "text":
                case "then":
                case "to":
                case "trycast":
                case "unicode":
                case "until":
                case "when":
                case "widening":
                case "withevents":
                case "writeonly":
                case "compare":
                case "isfalse":
                case "istrue":
                case "mid":
                case "strict":
                case "schema":
                    return str;
            }
            return word;
        }


        public static void LoadDropDown(ListControl listControl, IDataReader dataReader, bool closeReader)
        {
            string str3;
            listControl.Items.Clear();
            if (!closeReader)
            {
                goto Label_0087;
            }
            using (dataReader)
            {
                while (dataReader.Read())
                {
                    string text = dataReader[1].ToString();
                    string str2 = dataReader[0].ToString();
                    listControl.Items.Add(new ListItem(text, str2));
                }
                dataReader.Close();
                return;
            }
        Label_005B:
            str3 = dataReader[1].ToString();
            string str4 = dataReader[0].ToString();
            listControl.Items.Add(new ListItem(str3, str4));
        Label_0087:
            if (dataReader.Read())
            {
                goto Label_005B;
            }
        }

        public static void LoadDropDown(ListControl ddl, ICollection collection, string textField, string valueField, string initialSelection)
        {
            ddl.DataSource = collection;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.SelectedValue = initialSelection;
        }

        public static void LoadListItems(ListItemCollection list, DataTable tblBind, DataTable tblVals, string textField, string valField)
        {
            for (int i = 0; i < tblBind.Rows.Count; i++)
            {
                ListItem item = new ListItem(tblBind.Rows[i][textField].ToString(), tblBind.Rows[i][valField].ToString());
                for (int j = 0; j < tblVals.Rows.Count; j++)
                {
                    DataRow row = tblVals.Rows[j];
                    if (IsMatch(row[valField].ToString(), item.Value))
                    {
                        item.Selected = true;
                    }
                }
                list.Add(item);
            }
        }

        public static void LoadListItems(ListItemCollection listCollection, IDataReader dataReader, string textField, string valueField, string selectedValue, bool closeReader)
        {
            string str3;
            listCollection.Clear();
            if (!closeReader)
            {
                goto Label_00B4;
            }
            using (dataReader)
            {
                while (dataReader.Read())
                {
                    string text = dataReader[textField].ToString();
                    string str2 = dataReader[valueField].ToString();
                    ListItem item = new ListItem(text, str2);
                    if (!string.IsNullOrEmpty(selectedValue))
                    {
                        item.Selected = IsMatch(selectedValue, str2);
                    }
                    listCollection.Add(item);
                }
                dataReader.Close();
                return;
            }
        Label_006E:
            str3 = dataReader[textField].ToString();
            string str4 = dataReader[valueField].ToString();
            ListItem item2 = new ListItem(str3, str4);
            if (!string.IsNullOrEmpty(selectedValue))
            {
                item2.Selected = IsMatch(selectedValue, str4);
            }
            listCollection.Add(item2);
        Label_00B4:
            if (dataReader.Read())
            {
                goto Label_006E;
            }
        }

        public static bool MatchesOne(string stringA, params string[] matchStrings)
        {
            for (int i = 0; i < matchStrings.Length; i++)
            {
                if (IsMatch(stringA, matchStrings[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ParseCamelToProper(string sIn)
        {
            if (Validation.IsUpperCase(sIn))
            {
                return sIn;
            }
            char[] chArray = sIn.ToCharArray();
            StringBuilder builder = new StringBuilder();
            int num = 0;
            if (sIn.Contains("ID"))
            {
                builder.Append(chArray[0]);
                builder.Append(sIn.Substring(1, sIn.Length - 1));
            }
            else
            {
                foreach (char ch in chArray)
                {
                    if (num == 0)
                    {
                        builder.Append(" ");
                        builder.Append(ch.ToString().ToUpper());
                    }
                    else if (char.IsUpper(ch))
                    {
                        builder.Append(" ");
                        builder.Append(ch);
                    }
                    else
                    {
                        builder.Append(ch);
                    }
                    num++;
                }
            }
            return Regex.Replace(builder.ToString().Trim(), "(?<=[A-Z]) (?=[A-Z])", string.Empty);
        }

        private static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32((double)((26.0 * random.NextDouble()) + 65.0)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }


        public static string Replace(string word, string find, string replaceWith, bool removeUnderscores)
        {
            string[] strArray = Split(find);
            string str = word;
            foreach (string str2 in strArray)
            {
                if (str2.Length > 0)
                {
                    str = str.Replace(str2, replaceWith);
                }
            }
            if (removeUnderscores)
            {
                return str.Replace(" ", string.Empty).Replace("_", string.Empty).Trim();
            }
            return str.Replace(" ", string.Empty).Trim();
        }

        public static void SetListSelection(ListItemCollection lc, string Selection)
        {
            for (int i = 0; i < lc.Count; i++)
            {
                if (lc[i].Value == Selection)
                {
                    lc[i].Selected = true;
                    return;
                }
            }
        }

        public static string ShortenText(object sIn, int length)
        {
            string str = sIn.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length) + " ...";
            }
            return str;
        }


        public static string[] Split(string list)
        {
            try
            {
                return list.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return new string[] { string.Empty };
            }
        }

        public static bool StartsWith(string word, string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                return true;
            }
            foreach (string str in Split(list))
            {
                if (word.StartsWith(str, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static byte[] StringToByteArray(string str)
        {
            Encoding aSCII = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = unicode.GetBytes(str);
            return Encoding.Convert(unicode, aSCII, bytes);
        }

        [Obsolete("Obsolete and marked for removal. Update references to use Sugar.Strings.StripHTML()")]
        public static string StripHTML(string htmlString)
        {
            return Strings.StripHTML(htmlString);
        }

        [Obsolete("Obsolete and marked for removal. Update references to use Sugar.Strings.StripHTML()")]
        public static string StripHTML(string htmlString, string htmlPlaceHolder)
        {
            return Strings.StripHTML(htmlString, htmlPlaceHolder);
        }

        [Obsolete("Obsolete and marked for removal.")]
        public static string StripHTML(string htmlString, string htmlPlaceHolder, bool stripExcessSpaces)
        {
            string str = Regex.Replace(htmlString, @"<(.|\n)*?>", htmlPlaceHolder).Replace("&nbsp;", string.Empty).Replace("&amp;", "&");
            if (!stripExcessSpaces)
            {
                return str;
            }
            char[] separator = new char[] { ' ' };
            string[] strArray = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach (string str2 in strArray)
            {
                builder.Append(str2);
                builder.Append(" ");
            }
            return builder.ToString().Trim();
        }

        public static string StripNonAlphaNumeric(string sIn)
        {
            return StripNonAlphaNumeric(sIn, " ".ToCharArray()[0]);
        }

        public static string StripNonAlphaNumeric(string sIn, char cReplace)
        {
            StringBuilder builder = new StringBuilder(sIn);
            for (int i = 0; i < ".'?\\/><$!@%^*&+,;:\"(){}[]|-#".Length; i++)
            {
                builder.Replace(".'?\\/><$!@%^*&+,;:\"(){}[]|-#"[i], cReplace);
            }
            builder.Replace(cReplace.ToString(), string.Empty);
            return builder.ToString();
        }

        public static string StripText(string inputString, string stripString)
        {
            if (!string.IsNullOrEmpty(stripString))
            {
                string[] strArray = stripString.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!string.IsNullOrEmpty(inputString))
                    {
                        inputString = Regex.Replace(inputString, strArray[i], string.Empty);
                    }
                }
            }
            return inputString;
        }

        public static string StripWhitespace(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, @"\s", string.Empty);
            }
            return inputString;
        }

        [Obsolete("Obsolete and marked for removal.")]
        public static string ToggleHtmlBR(string text, bool isOn)
        {
            if (isOn)
            {
                return text.Replace(Environment.NewLine, "<br />");
            }
            return text.Replace("<br />", Environment.NewLine).Replace("<br>", Environment.NewLine).Replace("<br >", Environment.NewLine);
        }

        public static bool UserIsAuthenticated()
        {
            HttpContext current = HttpContext.Current;
            return (((current.User != null) && (current.User.Identity != null)) && !string.IsNullOrEmpty(current.User.Identity.Name));
        }

        /// <summary>
        /// List<T>转Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Obj2Json<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Json转List<T>
        /// </summary>
        /// <param name="json"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Object Json2Obj(String json, Type t)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {

                    return serializer.ReadObject(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// DataTable 转Json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTable2Json(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return "";
            }

            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{"); 
            //jsonBuilder.Append(dt.TableName.ToString());  
            jsonBuilder.Append("[");//转换成多个model的形式
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            //  jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 单个对象转JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Json2Obj<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }


        #region 读取或写入cookie
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());

            return "";
        }
        #endregion

        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }
       
        #region 检查是否为IP地址
        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        #endregion
        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;
            if (string.IsNullOrEmpty(result) || !IsIP(result))
                return "127.0.0.1";
            return result;
        }
        /// <summary>
        /// 将XML字符串转换成DATASET
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static DataSet ConvertToDateSetByXmlString(string xmlStr)
        {
            if (xmlStr.Length > 0)
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据  
                    //ds.ReadXmlSchema(Xmlrdr);
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                    }
                }
            }
            else
            {
                return null;
            }
        }
        #region[ 导出Excel ]

        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="FileName">输出文件名</param>
        /// <param name="dt">需要输出的Datatable</param>
        public static void ExportToExcel(string FileName, DataTable dt)
        {
            HttpContext.Current. Response.Clear();
            HttpContext.Current.Response.Buffer = false;
            //以下语句导出出现乱码情况(注释：鲁伟兴)  
            if (dt.Rows.Count > 1)
            {
                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//System.Text.Encoding.GetEncoding("GB2312");
                HttpContext.Current.Response.ContentType = "application/ms-excel";
            }
            else
            {
                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//System.Text.Encoding.GetEncoding("GB2312");
                HttpContext.Current.Response.ContentType = "application/ms-excel";
            }

            //Response.Charset = "big5";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
            //Response.ContentEncoding = System.Text.Encoding.UTF8;//System.Text.Encoding.GetEncoding("GB2312");
            //Response.ContentType = "application/ms-excel";

            
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            string newLine = "";
            newLine = "<table cellspacing=\"1\" border=\"1\">";
            oHtmlTextWriter.WriteLine(newLine);
            newLine = "<tr><td colspan=\"" + dt.Columns.Count + "\" align=\"center\">" + dt.TableName + "</td></tr>";
            oHtmlTextWriter.WriteLine(newLine);
            newLine = "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                newLine += "<td>" + dt.Columns[i].Caption + "</td>";
            }
            newLine += "</tr>";
            oHtmlTextWriter.WriteLine(newLine);
            for (int j = 0; j < dt.Rows.Count; j++)
            {

                newLine = "<tr>";

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newLine += "<td>" + dt.Rows[j][i].ToString() + "</td>";
                }
                newLine += "</tr>";
                oHtmlTextWriter.WriteLine(newLine);
            }
            oHtmlTextWriter.WriteLine("</table>");
            HttpContext.Current.Response.Write(oStringWriter.ToString());
            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="FileName">输出文件名</param>
        /// <param name="ControlID">要输出控件id</param>
        public void ExportToExcel(string FileName, string ControlID)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/ms-excel";
           
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            HttpContext.Current.Response.Write(oStringWriter.ToString());
            HttpContext.Current.Response.End();
        }
        #endregion
    }

}
