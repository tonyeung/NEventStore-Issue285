using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IEmployeesBuilder
    {
        IEmployeesBuilder WithFirstName(string FirstName);
        Employees ToEmployee();
    }

    public class Employees : AggregateRoot
    {

        #region members
        private Guid id;
        public override Guid Id
        {
            get { return id; }
        }

        private string firstName;
        private string FirstName { set { firstName = value; } }

        #endregion

        #region ctor
        public Employees()
        {
        }
        #endregion

        #region behavior
        #endregion

        #region apply
        private void Apply(EmployeeCreated e)
        {
            FirstName = e.FirstName;
        }
        #endregion

        #region builder

        public class Builder : IEmployeesBuilder
        {
            private EmployeeCreated newEmployee;

            private Builder()
            {
                newEmployee = new EmployeeCreated();
            }

            public static IEmployeesBuilder Create()
            {
                return new Builder();
            }
            
            public IEmployeesBuilder WithFirstName(string FirstName)
            {
                newEmployee.FirstName = FirstName;
                return this;
            }
            
            public Employees ToEmployee()
            {
                var employee = new Employees();
                employee.ApplyChange(newEmployee);
                return employee;
            }
        }
        #endregion
    }
}
