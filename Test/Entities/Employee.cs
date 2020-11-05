namespace FirmProject
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middle { get; set; }
        public double Experience { get; set; }
        public Position Position { get; set; }
        public string Task { get; set; }

        public Employee(string _fistName, string _lastName, string _middleName, double _expirience, Position _position, string _task)
        {
            Name = _fistName;
            Surname = _lastName;
            Middle = _middleName;
            Experience = _expirience;
            Position = _position;
            Task = _task;
        }
    }
}
