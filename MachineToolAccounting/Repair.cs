using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class Repair
    {
        public int Id = 0;
        public int Machhine = 0;
        public int TypeOfRepair = 0;
        public DateTime StartDateTime = DateTime.Now;
        public string Note = "";

        public Repair(int maxId, int machine, int type, DateTime startDate, string note = "")
        {
            this.Id = ++maxId;
            this.Machhine = machine;
            this.TypeOfRepair = type;
            this.StartDateTime = startDate;
            this.Note = note;
        }

        public static List<Repair> DownloadRepairs(Stream stream)
        {
            List<Repair> items = new List<Repair>();
            using (StreamReader r = new StreamReader(stream, Encoding.Default))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Repair>>(json);
                items.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
            return items;
        }
    }
}
