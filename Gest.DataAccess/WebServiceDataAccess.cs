using Gest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gest.DataAccess
{
    public class WebServiceDataAccess<T> :IDataReaderAccess<T>
        where T : class
    {
        WebClient _client = new WebClient() { Encoding = Encoding.UTF8 };
        readonly string _baseUri = "http://localhost:4070/api/";

        public IEnumerable<T> GetAll(T entity)
        {
            var Uri = _baseUri + entity.GetType().Name.ToLower();
            string result = _client.DownloadString(Uri);
            var returnedData = JsonConvert.DeserializeObject <IEnumerable<T>>(result);
            return returnedData;
        }

        public bool Remove(T entity,Guid guid)
        {
            var uri = _baseUri + entity.GetType().Name.ToLower()+"/"+ guid;
            byte[] dataBytes2 = Encoding.UTF8.GetBytes("");
            byte[] responseBytes = _client.UploadData(new Uri(uri), "DELETE", dataBytes2);
            return true;
        }

    }
}
