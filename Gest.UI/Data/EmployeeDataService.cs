using Gest.Model;
using System;
using System.Collections.Generic;

namespace Gest.UI.Data
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public IEnumerable<Employee> GetAll()
        {
            var guid = Guid.NewGuid();
            yield return new Employee { Code = "IRV", Name = "Irmãos Valente", Treshold = 250000, MainEmail = "comercial@irmãosvalente.pt", IsActive = true, DepartmentId = guid, DepartmentOfEmployee = new Department { Id = guid, Description = "Custom" } };
            yield return new Employee { Code = "EXA", Name = "Mecanica Exata", Treshold = 150000, MainEmail = "comercial@mexata.pt", IsActive = false };
            yield return new Employee { Code = "ACE", Name = "Acebron", Treshold = 200000, MainEmail = "comercial@Acebron.es" };
            yield return new Employee { Code = "CAB", Name = "CarbenInox", Treshold = 50000, MainEmail = "comercial@CarbenInox.pt", IsActive = true, DepartmentId = guid,  DepartmentOfEmployee = new Department {Id = guid, Description = "Catalog" } };
        }
    }
}
