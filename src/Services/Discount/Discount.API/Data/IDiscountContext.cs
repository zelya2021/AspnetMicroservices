using Discount.API.Entities;
using MongoDB.Driver;

namespace Discount.API.Data
{
    public interface IDiscountContext
    {
        IMongoCollection<Coupon> Coupons { get; }
    }
}
