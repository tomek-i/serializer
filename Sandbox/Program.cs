using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Serializer.Logic.Serializers;

namespace Sandbox
{



    public class TestClassB
    {
        public string Message { get; set; } = "Class B";
        public object Parent { get; set; }

        public List<int> Numbers { get; set; } = new List<int>() { 1, 2, 3, 4, 5 };
    }

    public class MainTestClass
    {
        public int Number { get; set; } = 99;
        public bool Bool { get; set; } = true;
        public string Text { get; set; } = "Main Test Class";

        public object Object { get; set; } = new TestClassB();

      
    }

    class Program
    {
        static void Main(string[] args)
        {

            var test = new MainTestClass();
            ((TestClassB)test.Object).Parent = test;


            var result = new JsonSerializer().Serialize(test,Newtonsoft.Json.Formatting.Indented,new Newtonsoft.Json.JsonSerializerSettings()
            {
                PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
            });

            Console.WriteLine("JSON");
            Console.WriteLine("========");
            Console.WriteLine(result);
            Console.WriteLine();


        

        }
    }
}
