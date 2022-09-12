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

        public bool SaveOffice(Office office)
        {
            string fullpath = path + "office.json";

            List<Office> OfficeList = LoadOffices();

            for (int i = 0; i < OfficeList.Count ; i++)
            {
                if (OfficeList[i].Name == office.Name)
                {
                    return false;
                }
            }

            OfficeList.Add(office);

            string output = JsonConvert.SerializeObject(clientList.ToArray(), Formatting.Indented);

            File.WriteAllText(fullpath, output);

            return true;

        }

        public Office RequestOffice(string Name)
        {
            List<Office> OfficeList = LoadOffices();
            for (int i = 0; i < OfficeList.Count ; i++)
            {
                if (OfficeList[i].Name == Name)
                {
                    return OfficeList[i];
                }
            }
            return null;
        }

        public List<Offices> LoadOffices()
        {
            string OfficeList = LoadJson("clients.json");

            var offices = JsonConvert.DeserializeObject<List<Office>>(OfficeList);

            return offices;
        }

         public bool SaveQuote(Quote quote)
        {
            string fullpath = path + "quote.json";

            List<Quote> QuoteList = LoadQuotes();

            for (int i = 0; i < QuoteList.Count ; i++)
            {
                if (QuoteList[i].LicensePlate == quote.LicensePlate)
                {
                    return false;
                }
            }

            QuoteList.Add(quote);

            string output = JsonConvert.SerializeObject(QuoteList.ToArray(), Formatting.Indented);

            File.WriteAllText(fullpath, output);

            return true;

        }

        public Quote RequestQuote(string licensePlate)
        {
            List<Quote> QuoteList = LoadQuotes();
            for (int i = 0; i < QuoteList.Count ; i++)
            {
                if (QuoteList[i].LicensePlate == licensePlate)
                {
                    return QuoteList[i];
                }
            }
            return null;
        }

        public List<Quote> LoadQuotes()
        {
            string QuoteList = LoadJson("quote.json");

            var quotes = JsonConvert.DeserializeObject<List<Quote>>(QuoteList);

            return quotes;
        }
        
        public bool SaveService(Service service)
        {
            string fullpath = path + "service.json";

            List<Service> ServiceList = LoadServices();

            for (int i = 0; i < ServiceList.Count ; i++)
            {
                if (ServiceList[i].Name == service.Name)
                {
                    return false;
                }
            }

            ServiceList.Add(service);

            string output = JsonConvert.SerializeObject(ServiceList.ToArray(), Formatting.Indented);

            File.WriteAllText(fullpath, output);

            return true;

        }

        public Service RequestService(string Name)
        {
            List<Service> ServiceList = LoadServices();
            for (int i = 0; i < ServiceList.Count ; i++)
            {
                if (ServiceList[i].Name == Name)
                {
                    return ServiceList[i];
                }
            }
            return null;
        }

        public List<Service> LoadServices()
        {
            string ServiceList = LoadJson("service.json");

            var services = JsonConvert.DeserializeObject<List<Service>>(ServiceList);

            return services;
        }
    }
}
