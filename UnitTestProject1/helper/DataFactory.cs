using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.helper
{
    public class DataFactory
    {
        public static JToken GetData(string filename, string token)
        {
            string jsonpath = Directory.GetCurrentDirectory() + @"\Data\" + filename;
            string filecontent = File.ReadAllText(jsonpath);
            JObject jsoncontent = JObject.Parse(filecontent);
            return jsoncontent[token];
        }
    }
}
