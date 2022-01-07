using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineToolAccounting
{
    class TypeOfMachine
    {
        public int Id { get; } = 0;
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
    }
}
