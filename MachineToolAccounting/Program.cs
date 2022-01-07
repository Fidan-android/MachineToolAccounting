using System;
using System.Collections.Generic;
using System.IO;

namespace MachineToolAccounting
{
    class Program
    {
        private static int MAX_ID { get; set; } = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("ID\tНазвание\tТип станка\tКоличество починок");
            TypeOfMachine typeOfMachine1 = new TypeOfMachine(MAX_ID, "Russia", 2009, "Anything");
            Machine machine1 = new Machine(MAX_ID, typeOfMachine1.Id, "Little machine");
            List<Repair> repairsOfMachine1 = new List<Repair>
            {
                //2 Machine repairs
                machine1.MachineForRepair(),
                machine1.MachineForRepair()
            };

            Console.WriteLine(machine1.Id + "\t" + machine1.Name + "\t" + typeOfMachine1.Mark + "\t" + machine1.NumberOfRepaird);
            Console.ReadLine();
        }
    }
}
