using System;
using System.Collections.Generic;
using System.Linq;

namespace FirmProject
{
    public class Firm
    {
        public List<Employee> Employees { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Taskmaster> Taskmasters { get; set; }
        public Firm()
        {
            Employees = new List<Employee>();
            Workers = new List<Worker>();
            Managers = new List<Manager>();
            Taskmasters = new List<Taskmaster>();
        }

        public void Start()
        {
            for (; ; )
            {
                Console.WriteLine("Select act\n");

                Console.WriteLine("0 - Create Employee");
                Console.WriteLine("1 - Delete Employee");
                Console.WriteLine("2 - Get by positions");
                Console.WriteLine("3 - Display count employees");
                Console.WriteLine("4 - Display work");
                Console.WriteLine("5 - Set task");
                Console.WriteLine("6 - Check Workers tasks\n");
                int act;

                try
                {
                     act = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Try enter task");
                    act = 7;
                }

                if (act == 0) CreateEmployee();

                if (act == 1) RemoveEmployee();

                if (act == 2) GetEmployeesByPostion();

                if (act == 3) CountEmployees();

                if (act == 4) Work();
                
                if (act == 5) SetTaskToWorker();
                
                if (act == 6) CheckWorkersTask();

                Console.WriteLine("\nContinu? yes/no");
                var isExit = Console.ReadLine();

                if (isExit.ToUpper() == "NO")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                }

            }
        }

        public void CreateEmployee()
        {
            Console.Clear();
            Console.WriteLine("Enter Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter LastName");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Middle");
            var middle = Console.ReadLine();

            Console.WriteLine("Enter experience");
            double experience = 0;
            try
            {
                experience = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("Wrong experience");
            }


            Console.WriteLine("Enter Task");
            var task = Console.ReadLine();


            var position = GetSelectedPosition();

            if (position == Position.Worker)
            {
                Worker worker = new Worker(firstName, lastName, middle, experience, Position.Worker,task);

                if (ContainEmployee(worker.Name, worker.Position))
                {
                    Console.WriteLine("This employee exist. Try again");
                    CreateEmployee();
                }
                Workers.Add(worker);

            }

            if (position == Position.Taskmaster)
            {
                var taskmaster = new Taskmaster(firstName, lastName, middle, experience, Position.Worker, task);

                if (ContainEmployee(taskmaster.Name, taskmaster.Position))
                {
                    Console.WriteLine("This employee exist. Try again");
                    CreateEmployee();
                }

                Taskmasters.Add(taskmaster);
            }

            if (position == Position.Manager)
            {
                var manager = new Manager(firstName, lastName, middle, experience, Position.Worker, task);

                if (ContainEmployee(manager.Name, manager.Position))
                {
                    Console.WriteLine("This employee exist. Try again");
                    CreateEmployee();
                }

                Managers.Add(manager);
            }

        }

        public void RemoveEmployee()
        {
            var position = GetSelectedPosition();

            Console.WriteLine("Enter FirstName to delete");
            var firstName = Console.ReadLine();

            if (position == Position.Worker)
            {
                Worker currentWorker = Workers.FirstOrDefault(e => e.Name == firstName);

                if (currentWorker != null)
                {
                    Workers.Remove(currentWorker);
                }
            }

            if (position == Position.Taskmaster)
            {
                Taskmaster currentTaskmaster = Taskmasters.FirstOrDefault(e => e.Name == firstName);

                if (currentTaskmaster != null)
                {
                    Taskmasters.Remove(currentTaskmaster);
                }
            }

            if (position == Position.Manager)
            {
                Manager currentManager = Managers.FirstOrDefault(e => e.Name == firstName);

                if (currentManager != null)
                {
                    Managers.Remove(currentManager);
                }
            }
        }

        public void Work()
        {
            Console.WriteLine("Enter FirstName");
            var firstName = Console.ReadLine();

            var position = GetSelectedPosition();

            if (position == Position.Worker)
            {
                Worker currentEmployee = Workers.FirstOrDefault(e => e.Name == firstName);

                currentEmployee.Work(currentEmployee.Task);
            }

            if (position == Position.Taskmaster)
            {
                Taskmaster currentTaskmaster = Taskmasters.FirstOrDefault(e => e.Name == firstName);

                Taskmaster.Work(currentTaskmaster.Task);
            }

            if (position == Position.Manager)
            {
                Manager currentManager = Managers.FirstOrDefault(e => e.Name == firstName);

                Manager.Work(currentManager.Task);
            }

        }

        public void GetEmployeesByPostion()
        {
            Console.Clear();
            var position = GetSelectedPosition();

            if (position == Position.Worker)

                foreach (var worker in Workers)
                {
                    Console.WriteLine("FirstName - " + worker.Name + " LastName - " + worker.Surname + " Middle - " + worker.Middle + " Experience - "
                        + worker.Experience + " Position - " + worker.Position);
                }

            if (position == Position.Taskmaster)

                foreach (var taskmaster in Taskmasters)
                {
                    Console.WriteLine("FirstName - " + taskmaster.Name);
                }


            if (position == Position.Manager)

                foreach (var manager in Managers)
                {
                    Console.WriteLine("FirstName - " + manager.Name);
                }
        }

        public bool ContainEmployee(string name, Position position)
        {
            if (position == Position.Manager)
            {
                var contain = Managers.Any(e => e.Name == name);
                return contain;
            }

            if (position == Position.Taskmaster)
            {
                var contain = Taskmasters.Any(e => e.Name == name);
                return contain;
            }

            if (position == Position.Worker)
            {
                var contain = Workers.Any(e => e.Name == name);
                return contain;
            }

            return false;

        }

        public void CountEmployees()
        {
            Console.Clear();
            Console.WriteLine("Count workers:" + " " + Workers.Count() + "\nCount managers: " + " " + Managers.Count() + "\nCount taskmasters:" + " " + Taskmasters.Count());
            var sum = Workers.Count() + Managers.Count() + Taskmasters.Count();
            Console.WriteLine("\nAll employees" + " " + sum);
        }

        public Position GetSelectedPosition()
        {
            Console.WriteLine("Select position \n0 - Worker \n1 - Manager \n2 - Taskmaster");
            
            var selected = int.Parse(Console.ReadLine());
            var position = (Position)Enum.ToObject(typeof(Position), selected);
            return position;
        }

        public void SetTaskToWorker()
        {
            Console.Clear();
            if (Workers.Count == 0)
            {
                Console.WriteLine("Now not Employee");
            }
            else 
            {
                Console.WriteLine("Enter FirstName for set task to worker");
                
                var firstName = Console.ReadLine();
                Worker currentWorker = Workers.FirstOrDefault(e => e.Name == firstName);
                Manager.SetTask(currentWorker);
            }
        }

        public void CheckWorkersTask()
        {
            Console.Clear();
            if (Workers.Count == 0)
            {
                Console.WriteLine("There are no tasks at the moment");
            }
            else
            Taskmaster.CheckWorker(Workers);
        }
    }
}