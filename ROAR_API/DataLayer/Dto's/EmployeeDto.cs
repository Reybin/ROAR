using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dto_s
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string  PhoneNumber{ get; set; }

        public string Email { get; set; }

        public string  Address { get; set; }
    }
}
