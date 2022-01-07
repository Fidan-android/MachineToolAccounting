using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class Machine
    {
        private int MAX_ID = 0;
        public int Id { get; } = 0;
        public int TypeOfMachine = 0;
        public string Name { get; } = "";
        public int NumberOfRepaird { get; private set; } = 0;

        public Machine(int maxId, int type, string name = "")
        {
            this.Id = ++maxId;
            this.TypeOfMachine = type;
            this.Name = name;
        }

        public Repair MachineForRepair()
        {
            Repair newRepair = new Repair(MAX_ID, this.Id, this.TypeOfMachine, DateTime.Now, "Hurry up, please!");
            this.NumberOfRepaird++;
            MAX_ID++;

            return newRepair;
        }
    }
}
