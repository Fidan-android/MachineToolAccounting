using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class TypeOfMachine
    {
        public int Id = 1;
        public string Country = "";
        public int YearsOfRelease = 1970;
        public string Mark = "";

        public TypeOfMachine(int maxId, string country, int yearsOfRelease, string mark)
        {
            this.Id = ++maxId;
            this.Country = country;
            this.YearsOfRelease = yearsOfRelease;
            this.Mark = mark;
        }

        public static List<TypeOfMachine> DownloadTypesOfMachine(Stream stream)
        {
            List<TypeOfMachine> items = new List<TypeOfMachine>();
            using (StreamReader r = new StreamReader(stream, Encoding.Default))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<TypeOfMachine>>(json);
                items.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
            return items;
        }
    }
}
