using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.DatabaseSettings
{
    public interface IPaymentDatabaseSettings
    {   
        string CollectionName { get; set; }

        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}
