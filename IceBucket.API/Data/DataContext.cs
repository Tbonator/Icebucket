using IceBucket.API.models;
using Microsoft.EntityFrameworkCore;

namespace IceBucket.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions <DataContext> options) : base(options) {}

        public DbSet<Value> Values { get; set; }


        
    }
}