using MyILog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [DataContract]
    [Serializable]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]
    abstract public class Storage
    {
        [XmlElement]
        [DataMember]
        public string Campany { get; set; }="";
        [XmlElement]
        [DataMember]
        public string Model { get; set; }="";
        [XmlElement]
        [DataMember]
        public string Name { get; set; }="";
        [XmlElement]
        [DataMember]
        public int Capacity { get; set; } 
        [XmlElement]
        [DataMember]
        public string Count { get; set; }="";
        public Storage() { }
        virtual public void Print(ILog log)
        {
            string message = $"Campany - {Campany}\nModel - {Model}\nName - {Name}\nCapacity - {Capacity}\nCount - {Count}";
            log.Print(message);
        }
    }
    [DataContract]
    [Serializable]
    public class Flash : Storage
    {
        [DataMember]
        public int Speed { get; set; }
        public Flash() { }
        public override void Print(ILog log)
        {
            base.Print(log);
            string mess = $"Speed Flash - {Speed}\n";
            log.Print(mess);
        }
    }
    [DataContract]
    [Serializable]
    public class DVD : Storage
    {
        [DataMember]
        public int Speed { get; set; }
        public DVD() { }
        public override void Print(ILog log)
        {
            base.Print(log);
            string mess = $"Speed DVD-head - {Speed}\n";
            log.Print(mess);
        }
    }
    [DataContract]
    [Serializable]
    public class HDD : Storage
    {
        [DataMember]
        public int Speed { get; set; }
        public HDD() { }
        public override void Print(ILog log)
        {
            base.Print(log);
            string mess=$"Speed HDD-head - {Speed} \n";
            log.Print(mess);
        }
    }
}
