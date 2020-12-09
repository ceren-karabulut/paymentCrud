using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Request
{
    public class PaymentCreateRequest
    {
        public string CardOwnerName { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }
    }
}
