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

        public Worker RequestWorker(int id)
        {

            List<Worker> contentWorkers = LoadWorkers();

            for(int i = 0; i < contentWorkers.Count; i++)
            {
                if (contentWorkers[i].idNumber == id)
                {
                    return contentWorkers[i];
                }

            }

            return null;

        }


        public bool SaveWorker(Worker worker)
        {
            string fullPath = path + "workers.json";

            List<Worker> contentWorkers = LoadWorkers();

            for (int i = 0; i < contentWorkers.Count; i++)
            {
                if(contentWorkers[i].idNumber == worker.idNumber)
                {
                    return false;
                }
            }

            contentWorkers.Add(worker);

            string output = JsonConvert.SerializeObject(contentWorkers.ToArray(), Formatting.Indented);

            File.WriteAllText(fullPath, output);

            return true;

        }

        public List<Worker> LoadWorkers()
        {

            string contentWorkes = LoadJson("workers.json");

            var workers = JsonConvert.DeserializeObject<List<Worker>>(contentWorkes);

            return workers;

        }

        public bool SaveClient(Client client)
        {
            string fullpath = path + "clients.json";

            List<Client> clientList = LoadClients();

            for (int i = 0; i < clientList.Count ; i++)
            {
                if (clientList[i].Id == client.Id)
                {
                    return false;
                }
            }

            clientList.Add(client);

            string output = JsonConvert.SerializeObject(clientList.ToArray(), Formatting.Indented);

            File.WriteAllText(fullpath, output);

            return true;

        }

        public Client RequestClient(string Id)
        {
            List<Client> clientList = LoadClients();
            for (int i = 0; i < clientList.Count ; i++)
            {
                if (clientList[i].Id == Id)
                {
                    return clientList[i];
                }
            }
            return null;
        }

        public List<Client> LoadClients()
        {
            string clientList = LoadJson("clients.json");

            var clients = JsonConvert.DeserializeObject<List<Client>>(clientList);

            return clients;
        }

        public string LoadJson(String pathFile)
        {
            string fullPath = path + pathFile;

            string content;

            using(var reader = new StreamReader(fullPath))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }
        
    }
}
