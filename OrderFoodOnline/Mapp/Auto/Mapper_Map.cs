using AutoMapper;
using OrderFoodOnline.Dto.Analyes;
using OrderFoodOnline.Dto.Comment.CommentFood.Command;
using OrderFoodOnline.Dto.Comment.CommentFood.Quesreis;
using OrderFoodOnline.Dto.Comment.CommentRestaurant.Command;
using OrderFoodOnline.Dto.Comment.CommentRestaurant.Quesreis;
using OrderFoodOnline.Dto.job.Recruitment.Command;
using OrderFoodOnline.Dto.job.Recruitment.Quereies;
using OrderFoodOnline.Dto.Location.Command;
using OrderFoodOnline.Dto.Location.Quesries;
using OrderFoodOnline.Dto.Product.Food.Command;
using OrderFoodOnline.Dto.Product.Food.Queries;
using OrderFoodOnline.Dto.Score.Command;
using OrderFoodOnline.Dto.T_Relation_T.DeliveryAndRestaurant.Command;
using OrderFoodOnline.Dto.User.Delivery.Command;
using OrderFoodOnline.Dto.User.Delivery.Quesries;
using OrderFoodOnline.Dto.User.Restaurant.Quesries;
using OrderFoodOnline.Model.Analyes;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.job.recruitment;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.Product.Food;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Mapp.Auto
{
    public class Mapper_Map : Profile
    {
        public Mapper_Map()
        {

            #region Food

            CreateMap< Food_En , Food_Dto>().ReverseMap();

            CreateMap<Food_En, Food_Create_Dto>().ReverseMap();

            CreateMap<Food_En, Food_Update_Dto>().ReverseMap();

            #endregion

            
            #region Delivery
            CreateMap<Delivery_En, Delivery_Dto>().ReverseMap();
            
            CreateMap<Delivery_En, Delivery_Create_Dto>().ReverseMap();
            
            CreateMap<Delivery_En, Delivery_Update_Dto>().ReverseMap();
            #endregion


            #region restaurant
            CreateMap<Restaurant_En, Restaurant_Dto>().ReverseMap();
            CreateMap<Restaurant_En, Delivery_Restaurant_Relation_Create_Dto>().ReverseMap();
            #endregion


            #region location
            
            CreateMap<Location_En , Location_Dto>().ReverseMap();

            CreateMap<Location_En, Location_Create_Dto>().ReverseMap();
            #endregion


            #region job
            
            CreateMap<Recruitment_En , Recruitment_Dto>().ReverseMap();
            
            CreateMap<Recruitment_En , Recruitment_Create_Dto>().ReverseMap();

            #endregion


            #region comment

            #region commentFood
           
            CreateMap<CommentFood_En , CommentFood_Dto>().ReverseMap();
            
            CreateMap<CommentFood_En, CommentFood_Create_Dto>().ReverseMap();

            #endregion

            #region comment
           
            CreateMap<CommentRestaurant_En, CommentRestaurant_Dto>().ReverseMap();
            
            CreateMap<CommentRestaurant_En, CommentRestaurant_Create_Dto>().ReverseMap();

            #endregion

            #endregion


            #region Score

            CreateMap<Score_En , Score_Create_Dto>().ReverseMap();
          
            CreateMap<Score_En , Restaurant_En>().ReverseMap();

            #endregion

            #region Analyes

            CreateMap<Analyes_En ,Analyes_Dto >().ReverseMap();

            CreateMap<ProductAnalyes_En , ProductAnalyes_Dto>().ReverseMap();

            #endregion

        }
    }
}
