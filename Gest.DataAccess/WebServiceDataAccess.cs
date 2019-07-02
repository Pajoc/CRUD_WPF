using Gest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gest.DataAccess
{
    public class WebServiceDataAccess<TEntity> :IDataReaderAccess<TEntity>
        where TEntity : class
    {
        WebClient client = new WebClient();
        string baseUri = "http://localhost:4070/api/";

        public IEnumerable<TEntity> GetAll(TEntity entity)
        {
            baseUri += entity.GetType().Name.ToLower();
            string result = client.DownloadString(baseUri);
            var departments = JsonConvert.DeserializeObject <IEnumerable<TEntity>>(result);
            return departments;
        }

      
    }
}
