using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.job.recruitment;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.Product.Food;
using OrderFoodOnline.Model.T_Relation_T;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Model.ConnectionToBank
{
    public class Context_En : DbContext
    {
        public Context_En(DbContextOptions<Context_En> options)
          : base(options)
        {

        }

        //Add tbl
        public DbSet<Food_En> food_Ens { get; set; } = null!;
        public  DbSet<Location_En> location_Ens { get; set; } = null!;
        public DbSet<Delivery_En> delivery_Ens  { get; set; } = null!;
        public DbSet<Delivery_Restaurant_Relation_En> delivery_Restaurant_Relation_Ens { get; set; } = null!;
        public DbSet<User_En> user_Ens { get; set; } = null!;
        public  DbSet<Restaurant_En> restaurant_Ens { get; set; } = null!;
        public  DbSet<Location_Restaurant_Relation_En> location_Restaurant_Relation_Ens { get; set; }
        public DbSet<Recruitment_En> recruitment_Ens { get; set; } = null!;
        public DbSet<CommentFood_En> commentFood_Ens  { get; set; } = null!;
        public DbSet<CommentRestaurant_En> commentRestaurant_Ens  { get; set; } = null!;
        public DbSet<Score_En> score_Ens  { get; set; } = null!;

    }
}
