using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payment_API.Models;

namespace Payment_API.Data
{
    public class PaymentApiContext : DbContext
    {

        public PaymentApiContext(DbContextOptions<PaymentApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //1:n
            builder.Entity<Sale>()
                .HasOne(sale => sale.Seller)
                .WithMany(seller => seller.Sales)
                .HasForeignKey(sale => sale.IdSeller);

            // n:n
            builder.Entity<Transaction>()
                .HasOne(transaction => transaction.Product)
                .WithMany(product => product.Transactions)
                .HasForeignKey(transaction => transaction.ProductId);

            builder.Entity<Transaction>()
                .HasOne(transaction => transaction.Sale)
                .WithMany(sale => sale.Transactions)
                .HasForeignKey(transaction => transaction.SaleId);

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}