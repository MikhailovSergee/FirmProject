using System;

namespace FirmProject
{
   public class Manager : Employee
    {
       
        public Manager(string _fistName, string _lastName, string _middleName, double _expirience, Position _position, string _task) :
           base(_fistName, _lastName, _middleName, _expirience, _position, _task)
        {}

        public static void SetTask(Worker worker)
        {
            Console.WriteLine("Enter task for worker");
            if(worker.Task != null)
            {
                worker.Task = Console.ReadLine();
            }
        }
    public static void Work(string task)
        {
            Console.WriteLine(task);
        }
    }
}
