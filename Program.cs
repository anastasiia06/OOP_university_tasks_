using System.Xml.Serialization;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; } 

    public Student() { } 
    public Student(string name, int age)
    {
        Name = name; Age = age; 
    }

    public override string ToString() => $"{Name}, {Age} років";
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<Student> students = new List<Student>
        {
            new Student("Student1", 20),
            new Student("student2", 19),
            new Student("student3", 18)
        };
        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
        using (FileStream fs = new FileStream("student.xml", FileMode.Create))
        {
            serializer.Serialize(fs, students);
        }
        Console.WriteLine("Об’єкт серіалізовано у файл student.xml");
        using (FileStream fs = new FileStream("student.xml", FileMode.Open))
        {
            List<Student> newStudents = (List<Student>)serializer.Deserialize(fs);
            Console.WriteLine("Об’єкт десеріалізовано:");
            foreach (var s in newStudents)
                Console.WriteLine(s);
        }

       
    }
}
