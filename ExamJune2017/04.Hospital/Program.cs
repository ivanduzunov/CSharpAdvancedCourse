using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Output")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var departmentName = tokens[0];
                var doctorName = $"{tokens[1]} {tokens[2]}";
                var patientName = tokens[3];

                int room = patients.Count(p => p.Department == departmentName) / 3 + 1;

                if (room <= 20)
                {
                    Patient patient = new Patient(departmentName, doctorName, patientName, room);
                    patients.Add(patient);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    int counter = patients.Count(p => p.Doctor == $"{tokens[0]} {tokens[1]}");

                    if (counter > 0)
                    {
                        foreach (var patient in patients.Where(p => p.Doctor == $"{tokens[0]} {tokens[1]}").OrderBy(p => p.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        foreach (var patient in
                            patients.Where(p => p.Room == int.Parse(tokens[1])
                                                && p.Department == tokens[0])
                                .OrderBy(p => p.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }

                }
                else
                {
                    foreach (var patient in patients.Where(p => p.Department == tokens[0]))
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
            }
        }
    }
    public class Patient
    {
        public Patient(string department, string doctor, string name, int room)
        {
            this.Department = department;
            this.Doctor = doctor;
            this.Name = name;
            this.Room = room;
        }

        public string Department { get; set; }

        public string Doctor { get; set; }

        public string Name { get; set; }

        public int Room { get; set; }
    }


}
