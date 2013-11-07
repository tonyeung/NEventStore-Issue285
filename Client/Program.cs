using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var esr = new EventStoreRepository<Employees>();

            var newEmployee = Employees.Builder.Create()
                                .WithFirstName("John")
                                .ToEmployee();

            esr.Save(newEmployee);
        }
    }
}
