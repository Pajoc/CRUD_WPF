using System.Collections.Generic;
using Gest.Model;

namespace Gest.UI.Data
{
    public interface ISupplierDataService
    {
        IEnumerable<Supplier> GetAll();
    }
}