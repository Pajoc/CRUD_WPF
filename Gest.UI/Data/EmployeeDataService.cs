using Gest.Model;
using System.Collections.Generic;

namespace Gest.UI.Data
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public IEnumerable<Employee> GetAll()
        {
            yield return new Employee { Code = "IRV", Name = "Irmãos Valente", Treshold = 250000, MainEmail = "comercial@irmãosvalente.pt", IsActive = true, DepartmentId = 2, DepartmentOfEmployee = new Department { Id = 2, Description = "Custom" } };
            yield return new Employee { Code = "EXA", Name = "Mecanica Exata", Treshold = 150000, MainEmail = "comercial@mexata.pt", IsActive = false };
            yield return new Employee { Code = "ACE", Name = "Acebron", Treshold = 200000, MainEmail = "comercial@Acebron.es" };
            yield return new Employee { Code = "CAB", Name = "CarbenInox", Treshold = 50000, MainEmail = "comercial@CarbenInox.pt", IsActive = true, DepartmentId = 1,  DepartmentOfEmployee = new Department {Id = 1 ,Description = "Catalog" } };
        }
    }
}
