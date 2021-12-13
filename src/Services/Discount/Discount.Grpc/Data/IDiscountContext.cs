using Discount.Grpc.Entities;
using MongoDB.Driver;

namespace Discount.Grpc.Data
{
    public interface IDiscountContext
    {
        IMongoCollection<Coupon> Coupons { get; }
    }
}
