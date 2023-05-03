using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class SerializeDeserialize
    {
        string path = @"C:\Users\USER\source\BL\Practice\Serialization\Serialization\Binary.txt";
        List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Meghana" },  
            new Student { Id = 2, Name = "Rushitha" },
            new Student { Id = 3, Name = "Shruthi" }
        };
        public void Serialization()
        {
           
            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, students);
            stream.Close();
            Console.WriteLine("Convert Object to Binary Format");
            string binarytext = File.ReadAllText(path);
            Console.WriteLine(binarytext);
        }

        public void Deserialization()
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Student> students = (List<Student>)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine("Convert List of Binart data to Object(Human readable)");
            foreach (var students in Student)
            {
                Console.WriteLine(students.Id);
                Console.WriteLine(" " + students.Name);
                Console.WriteLine();
            }
        }
    }
}
