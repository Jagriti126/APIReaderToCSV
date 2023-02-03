using System;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;



namespace ApIReader
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://api.publicapis.org/entries").Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;

            var lines = responseContent.Split('\n');
            String file = @".//output.csv";

            using (var writer = new StreamWriter(file))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }


   
}

