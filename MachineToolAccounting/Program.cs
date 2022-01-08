using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MachineToolAccounting
{
    class Program
    {
        private static Assembly assembly = typeof(Program).GetTypeInfo().Assembly;
        private readonly static Stream machineStream = assembly.GetManifestResourceStream("MachineToolAccounting.machine.json");
        private readonly static Stream typeOfMachineStream = assembly.GetManifestResourceStream("MachineToolAccounting.typeOfMachine.json");
        private readonly static Stream repairStream = assembly.GetManifestResourceStream("MachineToolAccounting.repair.json");
        private readonly static Stream typeOfRepairStream = assembly.GetManifestResourceStream("MachineToolAccounting.typeOfRepair.json");

        static void Main(string[] args)
        {
            var machines = Machine.DownloadMachines(machineStream);
            var typesOfMachine = TypeOfMachine.DownloadTypesOfMachine(typeOfMachineStream);
            var repairs = Repair.DownloadRepairs(repairStream);
            var typesOfRepair = TypeOfRepair.DownloadTypesOfRepair(typeOfRepairStream);

            Console.WriteLine();
            Console.WriteLine("Типы станков: ");
            Console.WriteLine("ID \t Страна \t Год производства \t Марка");
            foreach (var types in typesOfMachine)
            {
                Console.WriteLine($"{types.Id} \t {types.Country} \t {types.YearsOfRelease} \t \t \t {types.Mark}");
            }

            Console.WriteLine();
            Console.WriteLine("Имеющиеся станки: ");
            Console.WriteLine("ID \t Название \t Тип станка \t Количество починок");
            foreach (var machine in machines)
            {
                Console.WriteLine($"{machine.Id} \t {machine.Name} \t \t {machine.TypeOfMachine} \t \t { machine.NumberOfRepaird }");
            }

            Console.WriteLine();
            Console.WriteLine("Типы ремонта: ");
            Console.WriteLine("ID \t Название \t Время ремонта \t Цена \t Примечание");
            foreach (var types in typesOfRepair)
            {
                Console.WriteLine($"{types.Id} \t {types.Name} \t \t {types.DurationInHours} \t {types.Amount} \t \t {types.Note}");
            }

            Console.WriteLine();
            Console.WriteLine("Список ремонтов: ");
            Console.WriteLine("ID \t Станок \t Тип ремонта \t Начало ремонта \t Примечание");
            foreach (var repair in repairs)
            {
                Console.WriteLine($"{repair.Id} \t {repair.Machhine} \t \t {repair.TypeOfRepair} \t \t {repair.StartDateTime} \t \t {repair.Note}");
            }

            Console.ReadLine();
        }
    }
}
