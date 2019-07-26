using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.IO;

namespace Serialize
{
    public class TypeSerialize
    {
        public static void Binary(List<Student> list, string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
                Console.WriteLine("A list of objects is serialized!");
            }

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                List<Student> new_list = (List<Student>)formatter.Deserialize(fs);
                 
                Console.WriteLine("A list of objects is deserialized!");
                foreach (Student p in new_list)
                {
                    Console.WriteLine("Name: {0}  \tRating: {1}  \tGroup: {2}", p.Name, p.Rating, p.group.name);
                }
            }
        }

        public static void Soap(List<Student> list, string file)
        {
            SoapFormatter formatt = new SoapFormatter();
           
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatt.Serialize(fs, list.ToArray());
                Console.WriteLine("A list of objects is serialized!");
            }
            
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                Student[] new_list = (Student[])formatt.Deserialize(fs);

                Console.WriteLine("A list of objects is deserialized!");
                foreach (Student p in new_list)
                {
                    Console.WriteLine("Name: {0}  \tRating: {1}  \tGroup: {2}", p.Name, p.Rating, p.group.name);
                }
            }
        }

        public static void Xml(List<Student> list, string file)
        {
            XmlSerializer format = new XmlSerializer(typeof(Student[]));

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                format.Serialize(fs, list.ToArray());
                Console.WriteLine("A list of objects is serialized!");
            }

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                Student[] new_list = (Student[])format.Deserialize(fs);

                Console.WriteLine("A list of objects is deserialized!");
                foreach (Student p in new_list)
                {
                    Console.WriteLine("Name: {0}  \tRating: {1}  \tGroup: {2}", p.Name, p.Rating, p.group.name);
                }
            }
        }

        public static void Json(List<Student> list, string file)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, list.ToArray());
                Console.WriteLine("A list of objects is serialized!");
            }

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                Student[] new_list = (Student[])jsonFormatter.ReadObject(fs);

                Console.WriteLine("A list of objects is deserialized!");
                foreach (Student p in new_list)
                {
                    Console.WriteLine("Name: {0}  \tRating: {1}  \tGroup: {2}", p.Name, p.Rating, p.group.name);
                }
            }
        }
    }
}
