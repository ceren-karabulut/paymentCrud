using MongoDB.Driver;
using PaymentAPI.DatabaseSettings;
using PaymentAPI.Models;
using PaymentAPI.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<PaymentDetail> _collection;
        public PaymentService(IPaymentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _collection = db.GetCollection<PaymentDetail>(settings.CollectionName);
        }
    
        public async Task<IEnumerable<PaymentDetail>> GetAll()
        {
            var enities = await _collection.Find(x => true).ToListAsync();
            
            return enities;
        }
        
        public async Task<PaymentDetail> GetById(string id)
        {
            var entity = await _collection.Find<PaymentDetail>(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task Add(PaymentDetail paymennt)
        {
            await _collection.InsertOneAsync(paymennt);
        }

        public async Task Update(string id , PaymentDetail paymentDetail)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, paymentDetail);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(x=> x.Id == id);
        }
    }
}
