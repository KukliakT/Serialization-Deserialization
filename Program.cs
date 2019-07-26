using System;
using System.Collections.Generic;

namespace Serialize
{
    [Serializable]
    public class Student
    {
        public string Name;
        private int rating;
        public  Group group;

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public Student(string Name, int rating, string group)
        {
            this.Name = Name;
            this.rating = rating;
            this.group = new Group(group); ;
        }
        
        public Student()
        { }
    }

    [Serializable]
    public class Group
    {
        public string name;
        public Group(string name)
        {
            this.name = name;
        }
        
        public Group()
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            list.Add(new Student("Taras", 78, "KI-37"));
            list.Add(new Student("Ferid", 51, "KI-31"));
            list.Add(new Student("Ivan", 68, "KI-37"));
            list.Add(new Student("Seroga", 45, "KI-32"));


            char repeated;

            do
            {
                string title = "Choose serialization type: \n 1)Binary \n 2)Soap \n 3)XML \n 4)Json"; // title - condition for input data
                string[] range = new string[] { "1", "2", "3", "4" };


                //Returns only array 'range' element (in this example "1", "2", "3" or "4")
                string Menu_point = Verify.CorrectSwitch(range, title);

                switch (Menu_point)
                {
                    case "1":
                        TypeSerialize.Binary(list, "student.dat");
                        break;

                    case "2":
                        TypeSerialize.Soap(list, "student.soap");
                        break;

                    case "3":
                        TypeSerialize.Xml(list, "student.xml");
                        break;

                    case "4":
                        TypeSerialize.Json(list, "student.json");
                        break;
                } 

                title = "Enter any symbol for quit or 'c' for - continue: "; // title - condition for input data

                //Returns char for checking if we want to quit or continue to use 
                repeated = Verify.Repeated(title); 

            } while (repeated == 'c');  //c - continue

        }
    }
}
