using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class Repair
    {
        public int Id { get; } = 0;
        public int Machhine { get; } = 0;
        public int TypeOfRepair { get; } = 0;
        public DateTime StartDateTime { get; }
        public string Note = "";

        public Repair(int maxId, int machine, int type, DateTime startDate, string note = "")
        {
            this.Id = ++maxId;
            this.Machhine = machine;
            this.TypeOfRepair = type;
            this.StartDateTime = startDate;
            this.Note = note;
        }
    }
}
