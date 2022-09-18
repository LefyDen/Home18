using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Home18
{
    class Program
    {
        static void Main(string[] args)
        {

            Type myType = typeof(Class1);
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                // если метод статический
                if (method.IsStatic) modificator += "static ";
                // если метод виртуальный
                if (method.IsVirtual) modificator += "virtual ";
                Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
            }
            ///////////////////////////////////
           
         
            Console.WriteLine("Конструктор:");
            foreach (ConstructorInfo ctor in myType.GetConstructors(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                string modificator = "";
                // получаем модификатор доступа
                if (ctor.IsPublic)
                    modificator += "public";
                else if (ctor.IsPrivate)
                    modificator += "private";
                else if (ctor.IsAssembly)
                    modificator += "internal";
                else if (ctor.IsFamily)
                    modificator += "protected";
                else if (ctor.IsFamilyAndAssembly)
                    modificator += "private protected";
                else if (ctor.IsFamilyOrAssembly)
                    modificator += "protected internal";
                Console.Write($"{modificator} {myType.Name}(");
                // получаем параметры конструктора
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            ///////////////////////
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
            ///////////////////////
            foreach (PropertyInfo prop in myType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                Console.WriteLine("Проперті");
                Console.Write($"{prop.PropertyType} {prop.Name} {{");
              
                if (prop.CanRead) Console.Write("get;");               
                if (prop.CanWrite) Console.Write("set;");
                Console.WriteLine("}");
            }
        }
    }

}


