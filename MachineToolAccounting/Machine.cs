using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class Machine
    {
        public int Id = 0;
        public int TypeOfMachine = 0;
        public string Name = "";
        public int NumberOfRepaird = 0;

        public Machine(int maxId, int type, string name = "")
        {
            this.Id = ++maxId;
            this.TypeOfMachine = type;
            this.Name = name;
        }

        public static List<Machine> DownloadMachines(Stream stream)
        {
            //создаем временный массив
            List<Machine> items = new List<Machine>();
            //с использованием StreamReader мы читаем содержимое, переданное через Stream
            //с дефолтным кодированием русских и латинских символов
            using (StreamReader r = new StreamReader(stream, Encoding.Default))
            {
                //читаем весь файл до конца как строку
                string json = r.ReadToEnd();

                //с помощью класса JsonConvert из внешней библиотеки Newtonsoft мы читаем 
                //нашу полученную строку данных из файла как список определенных объектов переданного класса
                items = JsonConvert.DeserializeObject<List<Machine>>(json);
                //явление выше называется десериализация Json в объект или в список объектов

                //сортируем полученный список с помощью дополнительного условия CompareTo с переданным
                //полем, по которому надо сортировать
                items.Sort((x, y) => x.Id.CompareTo(y.Id));
            }

            //возвращаем временный массив с данными
            return items;
        }
    }
}
