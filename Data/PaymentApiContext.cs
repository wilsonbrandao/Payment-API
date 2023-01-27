using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Payment_API.Data
{
    public class PaymentApiContext : DbContext
    {

        public PaymentApiContext(DbContextOptions<PaymentApiContext> options) : base(options)
        {
            
        }
        
    }
}