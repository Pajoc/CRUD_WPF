using Gest.Model;
using System.Collections.Generic;

namespace Gest.UI.Data
{
    public class SupplierDataService : ISupplierDataService
    {
        public IEnumerable<Supplier> GetAll()
        {
            yield return new Supplier { Code = "IRV", Name = "Irmãos Valente", Treshold = 250000, MainEmail = "comercial@irmãosvalente.pt" };
            yield return new Supplier { Code = "EXA", Name = "Mecanica Exata", Treshold = 150000, MainEmail = "comercial@mexata.pt" };
            yield return new Supplier { Code = "ACE", Name = "Acebron", Treshold = 200000, MainEmail = "comercial@Acebron.es" };
            yield return new Supplier { Code = "CAB", Name = "CarbenInox", Treshold = 50000, MainEmail = "comercial@CarbenInox.pt" };
        }
    }
}
