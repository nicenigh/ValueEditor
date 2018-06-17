using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace valueEditor
{
    public static class Converts
    {
        /// <summary>
        /// 字符串编码转换
        /// </summary>
        /// <param name="srcEncoding">原编码</param>
        /// <param name="dstEncoding">目标编码</param>
        /// <param name="srcBytes">原字符串</param>
        /// <returns>字符串</returns>
        public static string TransferEncoding(Encoding srcEncoding, Encoding dstEncoding, string srcStr)
        {
            byte[] srcBytes = srcEncoding.GetBytes(srcStr);
            byte[] bytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
            return dstEncoding.GetString(bytes);
        }
        ///// <summary>
        ///// html转码
        ///// </summary>
        ///// <param name="html"></param>
        ///// <returns></returns>
        //public static string HtmlEncode(string html)
        //{
        //    return HttpUtility.HtmlEncode(html);//System.Net.WebUtility.HtmlEncode(html);            
        //}
        ///// <summary>
        ///// html解码
        ///// </summary>
        ///// <param name="html"></param>
        ///// <returns></returns>
        //public static string HtmlDecode(string html)
        //{
        //    return HttpUtility.HtmlDecode(html);//System.Net.WebUtility.HtmlDecode(html);  
        //}
        ///// <summary>
        ///// Url转码
        ///// </summary>
        ///// <param name="url"></param>
        ///// <returns></returns>
        //public static string UrlEncode(string url)
        //{
        //    return HttpUtility.UrlEncode(url);
        //}
        ///// <summary>
        ///// Url解码
        ///// </summary>
        ///// <param name="url"></param>
        ///// <returns></returns>
        //public static string UrlDecode(string url)
        //{
        //    return HttpUtility.UrlDecode(url);
        //}
        /// <summary>
        /// Base64转码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToBase64(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Base64字符串解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FromBase64(string input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 字节数组转为字符串
        /// 将指定的字节数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BitToString(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            //将指定的字节数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
            return BitConverter.ToString(bytes);
        }
        /// <summary>
        /// 将十六进制字符串转为字节数组
        /// </summary>
        /// <param name="bitStr"></param>
        /// <returns></returns>
        public static byte[] FromBitString(string bitStr)
        {
            if (bitStr == null)
            {
                return null;
            }

            string[] sInput = bitStr.Split("-".ToCharArray());
            byte[] data = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
            }

            return data;
        }

    }
}
