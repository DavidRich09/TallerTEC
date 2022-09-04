using Newtonsoft.Json;
using WebApi.Models;
using System;
using System.IO;
using System.Text;

namespace WebApi.Data_base
{
    public class JsonManager
    {
        private static string path = @"..\\WebApi\\Data base\\";
        private JsonSerializer serializer = new JsonSerializer();


        public void SaveWorker(Worker worker)
        {
            string fullPath = path + "workers.json";

            string output = JsonConvert.SerializeObject(worker);

            File.WriteAllText(fullPath, output);

        }
        
    }
}
