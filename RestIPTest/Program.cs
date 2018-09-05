using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestIPTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string html = string.Empty;
			string url = @"API-PROXY";
			while (true)
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.AutomaticDecompression = DecompressionMethods.GZip;

				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				using (Stream stream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					html = reader.ReadToEnd();
				}

				ProxyIp p = JsonConvert.DeserializeObject<ProxyIp>(html);

				Console.WriteLine(string.Format("{0}:{1}", p.Ip, p.Port));
				Thread.Sleep(2000);
				
			}
			
		}
	}
}
