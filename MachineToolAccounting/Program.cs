using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MachineToolAccounting
{
    class Program
    {
        //здесь мы с помощью встроенного класса Reflection прочитываем все сведения о проекте и его ресурсах
        private static Assembly assembly = typeof(Program).GetTypeInfo().Assembly;
        //далее после чтения проекта, мы вытягиваем нужные нам файлы json и создаем Stream для чтения каждого файлика
        private readonly static Stream machineStream = assembly.GetManifestResourceStream("MachineToolAccounting.machine.json");
        private readonly static Stream typeOfMachineStream = assembly.GetManifestResourceStream("MachineToolAccounting.typeOfMachine.json");
        private readonly static Stream repairStream = assembly.GetManifestResourceStream("MachineToolAccounting.repair.json");
        private readonly static Stream typeOfRepairStream = assembly.GetManifestResourceStream("MachineToolAccounting.typeOfRepair.json");

        static void Main(string[] args)
        {
            //с помощью статичных методов из каждого класс(распределили методы по классам соответственно)
            //передавая наши имеющиеся Stream, нам возвращаются списки объектов, созданные из файлов.
            //пояснения к методам описано в классе Machine
            List<Machine> machines = Machine.DownloadMachines(machineStream);
            List<TypeOfMachine> typesOfMachine = TypeOfMachine.DownloadTypesOfMachine(typeOfMachineStream);
            List<Repair> repairs = Repair.DownloadRepairs(repairStream);
            List<TypeOfRepair> typesOfRepair = TypeOfRepair.DownloadTypesOfRepair(typeOfRepairStream);
            
            //выводим все имеющиеся данные в табуляционном виде
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
