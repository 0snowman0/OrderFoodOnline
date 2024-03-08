using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderFoodOnline.Dto.Product.Food.Command;
using OrderFoodOnline.Dto.User.Delivery.Command;
using OrderFoodOnline.Dto.User.user.Command;
using OrderFoodOnline.Email;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IAnalyes;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Irepository.IDelivery;
using OrderFoodOnline.Interface.Irepository.IFood;
using OrderFoodOnline.Interface.Irepository.IImage;
using OrderFoodOnline.Interface.Irepository.Ijob.IRecruitment;
using OrderFoodOnline.Interface.Irepository.ILocation;
using OrderFoodOnline.Interface.Irepository.IPayment;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Interface.Irepository.IUser;
using OrderFoodOnline.Interface.IT_R_T.DeliveryAndRestaurant;
using OrderFoodOnline.Interface.IT_R_T.LocationAndRestaurant;
using OrderFoodOnline.Interface.Itools.HelpFunction;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.Product.Food;
using OrderFoodOnline.Model.User;
using OrderFoodOnline.Repository.Analyes;
using OrderFoodOnline.Repository.Comment;
using OrderFoodOnline.Repository.Delivery;
using OrderFoodOnline.Repository.Food;
using OrderFoodOnline.Repository.HelpFunction;
using OrderFoodOnline.Repository.Image;
using OrderFoodOnline.Repository.IT_R_T.DeliveryAndRestaurant;
using OrderFoodOnline.Repository.IT_R_T.LocationAndRestaurant;
using OrderFoodOnline.Repository.job.Recruitment;
using OrderFoodOnline.Repository.Location;
using OrderFoodOnline.Repository.payment;
using OrderFoodOnline.Repository.Restaurant;
using OrderFoodOnline.Repository.Tools.UserAuth;
using OrderFoodOnline.Repository.user_rep;
using OrderFoodOnline.Status;
using OrderFoodOnline.Validate.Product.Food;
using OrderFoodOnline.Validate.User;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using ZarinPal.Class;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add http
builder.Services.AddHttpContextAccessor();



 void ConfigureServices(IServiceCollection services)
{
  // Add Swagger
  services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
  });
}



#region Authorization
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));
#endregion

#region Add Dep ...

#region Dep for tbl

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IRestaurant , Restaurant_Rep>();

builder.Services.AddScoped<IDelivery, Delivery_Rep>();

builder.Services.AddScoped<IFood , Food_Rep>();

builder.Services.AddScoped<Iuser , User_Rep>();

builder.Services.AddScoped<IDelivery_Restaurant_Relation, Delivery_Restaurant_Relation_Rep>();

builder.Services.AddScoped<ILocation , Location_Rep>();

builder.Services.AddScoped<ILocation_Restaurant, Location_Restaurant_Rep>();

builder.Services.AddScoped<IRecruitment, Recruitment_Rep>();

builder.Services.AddScoped<ICommentFood , CommentFood_Rep>();

builder.Services.AddScoped<ICommentRestaurant, CommentRestaurant_Rep>();

builder.Services.AddScoped<IScore, Score_Rep>();

builder.Services.AddScoped<Ipayment, payment_Rep>();

builder.Services.AddScoped<IAnalyes, Analyes_Rep>();

builder.Services.AddScoped<IProductAnalyes, ProductAnalyes_Rep>();

#endregion


#region Dep for Validation

builder.Services.AddScoped<IValidator<Food_Create_Dto> , Food_Create_V>();

builder.Services.AddScoped<IValidator<Food_Update_Dto>, Food_Update_V>();

builder.Services.AddScoped<IValidator<User_ForRegister_Dto> , User_Create_V>();

builder.Services.AddScoped<IValidator<Delivery_Create_Dto>, Delivery_Create_V>();

#endregion

#region Oders

builder.Services.AddScoped<IFileService , FileService>();

builder.Services.AddScoped<Istatus , StatusFunction>();

builder.Services.AddScoped<IAuthenticationTools , AuthenticationTools>();

builder.Services.AddScoped<IuserService, UserService>();

builder.Services.AddScoped<LocalMailService>();

builder.Services.AddScoped<Payment, ZarinPal.Class.Payment>();

builder.Services.AddSingleton<ZarinPal.Class.Authority>();

builder.Services.AddTransient<ZarinPal.Class.Transactions>();

builder.Services.AddTransient<IHelpFunction , HelpFunction_Rep>();

#endregion

#endregion






//Add Db Context
builder.Services.AddDbContext<Context_En>(optionsAction: options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection_1"]));

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
