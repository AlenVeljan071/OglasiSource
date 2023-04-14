using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Entities;
using System.Reflection;


namespace OglasiSource.Infrastructure.Data.Context
{
    public class OglasiSourceContext : DbContext
    {
        public OglasiSourceContext(DbContextOptions options) : base(options)
        {

        }

        // USER
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //Category
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }

        //Ads
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<VehicleBrand> VehicleBrand { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
       
        // Comment
        public DbSet<Comment> Comment { get; set; }
        public DbSet<EntityTypeComment> EntityTypeComment { get; set; }

        //Rating and Review
        public DbSet<Review> Review { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<EntityTypeRating> EntityTypeRating { get; set; }
        public DbSet<EntityTypeReview> EntityTypeReview { get; set; }
        //Imgur
        public DbSet<SavedImage> SavedImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        }

    }
}
