using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace PaymentAPI.Helper
{
    public class ApiHelper
    {

        public static string GetRandomId()
        {
            return MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        }
    }
}
