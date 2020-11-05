using System;

namespace FirmProject
{
    public class Worker : Employee
    {
        public Worker(string _fistName, string _lastName, string _middleName, double _expirience, Position _position, string _task) :
            base(_fistName, _lastName,_middleName, _expirience,_position,_task)
        {}

        public void Work(string task )
        {
            Console.WriteLine(task);
        }
    }
}
