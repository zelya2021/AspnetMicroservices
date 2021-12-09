using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Discount.API.Data
{
    public class DiscountContext: IDiscountContext
    {
        public DiscountContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Coupons = database.GetCollection<Coupon>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            DiscountContextSeed.SeedData(Coupons);
        }

        public IMongoCollection<Coupon> Coupons { get; }
    }
}
