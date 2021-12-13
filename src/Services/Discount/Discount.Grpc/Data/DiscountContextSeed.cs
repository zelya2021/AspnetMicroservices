using Discount.Grpc.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Discount.Grpc.Data
{
    public class DiscountContextSeed
    {
        public static void SeedData(IMongoCollection<Coupon> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Coupon> GetPreconfiguredProducts()
        {
            return new List<Coupon>()
            {
                new Coupon()
                {
                    Id=1,
                    ProductName = "IPhone X",
                    Description="IPhone Discount",
                    Amount = 150
                },
                new Coupon()
                {
                    Id=2,
                    ProductName = "Samsung 10",
                    Description="Samsung Discount",
                    Amount = 100
                }
            };
        }
    }
}
