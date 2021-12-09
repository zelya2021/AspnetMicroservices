using Dapper;
using Discount.API.Data;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IDiscountContext _context;

        public DiscountRepository(IDiscountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Coupon> GetDiscount(string productName)
        {
            return await _context
                           .Coupons
                           .Find(p => p.ProductName == productName)
                           .FirstOrDefaultAsync();
        }

        public async Task CreateDiscount(Coupon coupon)
        {
            await _context.Coupons.InsertOneAsync(coupon);
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var updateResult = await _context
                                        .Coupons
                                        .ReplaceOneAsync(filter: g => g.Id == coupon.Id, replacement: coupon);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            FilterDefinition<Coupon> filter = Builders<Coupon>.Filter.Eq(p => p.ProductName, productName);

            DeleteResult deleteResult = await _context
                                                .Coupons
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
