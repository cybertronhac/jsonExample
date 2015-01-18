using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Json;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace useJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
           // webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            try
            {
                string er, cr;
                string s = webClient.DownloadString("https://www.kyubdevelopers.com/api/comments.php");
                comm reslt = new comm();
                //reslt.posts = new JObject();
                reslt = JsonConvert.DeserializeObject<comm>(s);
                Console.WriteLine(reslt.message);
                JArray ob = reslt.posts;
                foreach (JObject d in ob)
                {
                    Console.WriteLine(d["assignNo"].ToString());
                    Console.WriteLine(d["subject"].ToString());
                    Console.WriteLine(d["teacher"].ToString());
                    Console.WriteLine(d["submitDate"].ToString());
                    er = d["questions"].ToString();
                    cr = er.Replace("#", "\n");
                    Console.WriteLine(cr);
                    Console.WriteLine(d["altDate"].ToString());
                }
                
                //Console.WriteLine(s);
            }
            catch (Exception es)
            { Console.WriteLine(es.Message); }
            Console.Read();
        }

    //    public static void dit(string e)
    //    {
    //        root reslt = new root();
    //        reslt = JsonConvert.DeserializeObject<root>(e);
    //        JObject ob = reslt.som.posts;
    //        foreach(KeyValuePair<string, JToken> kp in ob)
    //        {
    //            string key = kp.Key;
    //            foreach(JObject d in kp.Value as JArray)
    //            {
    //                Console.WriteLine(d["assignNo"].ToString());
    //                Console.WriteLine(d["subject"].ToString());
    //                Console.WriteLine(d["teacher"].ToString());
    //                Console.WriteLine(d["submitDate"].ToString());
    //                Console.WriteLine(d["questions"].ToString());
    //                Console.WriteLine(d["altDate"].ToString());
    //            }
    //        }
    //    }
    }

    public class root
    {
        public comm som { get; set; }
        public root()
        {
            som = new comm();
        }
    }

    public class comm
    {
        public int success { get; set; }
        public string message { get; set; }
        [JsonProperty("posts")]
        public JArray posts { get; set; }
    }
}
