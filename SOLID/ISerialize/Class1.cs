using ClassLibrary1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ISerialize1
{
    public interface ISerialize
    {
        void Save(List<Storage> storages);
        List<Storage> Load();
    }
    public class xmlserialize : ISerialize
    {
        public List<Storage> Load()
        {
            XmlSerializer serialize = new XmlSerializer(typeof(List<Storage>));
            try
            {
                using (FileStream stream = new FileStream("Storage.xml", FileMode.Open))
                {
                    List<Storage> list = (List<Storage>)serialize.Deserialize(stream);
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Нет файла скорее всего - {ex.Message}");
                return null;
            }
        }

        public void Save(List<Storage> storages)
        {
            XmlSerializer serialize = new XmlSerializer(typeof(List<Storage>));
            using (FileStream stream = new FileStream("Storage.xml", FileMode.Create))
            {
                serialize.Serialize(stream, storages);
            }
        }
    }

    public class jsonserialize : ISerialize
    {
        public List<Storage> Load()
        {
            List<Storage> list;

            //using (FileStream fs = new FileStream("Storage.json", FileMode.OpenOrCreate))
            //{
            //    list = System.Text.Json.JsonSerializer.Deserialize<List<Storage>>(fs);

            //}
            string json =File.ReadAllText("Storage.json");
            list = JsonConvert.DeserializeObject<List<Storage>>(json);
            Console.WriteLine("Список десириализован");
            return list;
        }

        public void Save(List<Storage> storages)
        {
            //using (FileStream fs = new FileStream("Storage.json", FileMode.OpenOrCreate))
            //{

            //    System.Text.Json.JsonSerializer.Serialize(fs, storages);
            //    Console.WriteLine("Данные записаны в файл");
            //}
            string fileName = "Storage.json";
            string jsonString = JsonConvert.SerializeObject(storages);
            File.WriteAllText(fileName, jsonString);
        }
    }

    public class soapserialize : ISerialize
    {
        SoapFormatter formatter = new SoapFormatter();
        public List<Storage> Load()
        {
            List<Storage> list;
            using (FileStream fs = new FileStream("Storage.soap", FileMode.OpenOrCreate))
            {
                list = (List<Storage>)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Storage p in list)
                {
                    Console.WriteLine("Name: {0}\nCapacity: {1}" +
                        "\nModel: {2}\nCount: {3}\nCampany: {4}", p.Name, p.Capacity,p.Model,p.Count,p.Campany);
                }

            }
            return list;
        }

        public void Save(List<Storage> storages)
        {

            using (FileStream fs = new FileStream("Storage.soap", FileMode.OpenOrCreate))
            {
                foreach (Storage p in storages)
                { formatter.Serialize(fs, p); }

                Console.WriteLine("Объект сериализован");
            }
        }
    }
}
