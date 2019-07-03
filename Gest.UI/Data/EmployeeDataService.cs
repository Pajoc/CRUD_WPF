using Gest.DataAccess;
using Gest.Model;
using System;
using System.Collections.Generic;

namespace Gest.UI.Data
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private IDataReaderAccess<Employee> _employeeDA;

        public EmployeeDataService(IDataReaderAccess<Employee> employeeDA)
        {
            _employeeDA = employeeDA;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeDA.GetAll(new Employee());
        }
    }
}
