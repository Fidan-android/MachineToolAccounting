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
        private int MAX_ID = 0;
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

        public Repair MachineForRepair()
        {
            Repair repair = new Repair(MAX_ID, this.Id, this.TypeOfMachine, DateTime.Now, "Hurry up, please!");
            this.NumberOfRepaird++;
            MAX_ID++;

            return repair;
        }

        public static List<Machine> DownloadMachines(Stream stream)
        {
            List<Machine> items = new List<Machine>();
            using (StreamReader r = new StreamReader(stream, Encoding.Default))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Machine>>(json);
                items.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
            return items;
        }

        public static void UploadMachines(List<Machine> machines, Stream stream)
        {
            
        }
    }
}
