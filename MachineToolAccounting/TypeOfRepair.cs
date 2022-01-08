using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class TypeOfRepair
    {
        public int Id = 1;
        public string Name = "";
        public int DurationInHours = 0;
        public float Amount = 0F;
        public string Note = "";

        public TypeOfRepair(int maxId, string name, int duration, float amount, string note = "")
        {
            this.Id = ++maxId;
            this.Name = name;
            this.DurationInHours = duration;
            this.Amount = amount;
            this.Note = note;
        }

        public static List<TypeOfRepair> DownloadTypesOfRepair(Stream stream)
        {
            List<TypeOfRepair> items = new List<TypeOfRepair>();
            using (StreamReader r = new StreamReader(stream, Encoding.Default))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<TypeOfRepair>>(json);
                items.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
            return items;
        }
    }
}
