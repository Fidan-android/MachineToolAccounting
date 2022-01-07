using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class TypeOfRepair
    {
        public int Id { get; } = 0;
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
    }
}
