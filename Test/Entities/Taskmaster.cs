using System;
using System.Collections.Generic;

namespace FirmProject
{
    public class Taskmaster : Employee
    {
       
        public Taskmaster(string _fistName, string _lastName, string _middleName, double _expirience, Position _position, string _task) :
          base(_fistName, _lastName, _middleName, _expirience, _position, _task)
        {}

        public static void CheckWorker(List<Worker> workers)
        {
            foreach (var worker in workers)
            {
                Console.WriteLine($"Name : {worker.Name}  - task: {worker.Task}");
            }

            Console.WriteLine("Tasks checked");
        }

        public static void Work(string task)
        {
            Console.WriteLine(task);
        }
    }
}
