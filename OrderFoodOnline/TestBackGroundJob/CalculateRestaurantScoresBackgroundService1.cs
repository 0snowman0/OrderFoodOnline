using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Model.User;


namespace OrderFoodOnline.TestBackGroundJob
{
    public class CalculateRestaurantScoresBackgroundService1 : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private int executionCount = 0;
        private readonly IRestaurant _restaurant;
        private readonly IScore _score;
        public CalculateRestaurantScoresBackgroundService1(Timer? timer, int executionCount, IRestaurant restaurant, IScore score)
        {
            _timer = timer;
            this.executionCount = executionCount;
            _restaurant = restaurant;
            _score = score;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
             TimeSpan.FromHours(24));
            
        }

        private void DoWork(object? state)
        {

            // Do your work here

            // For example, you can calculate the scores for all restaurants

            List<Restaurant_En> restaurants = (List<Restaurant_En>)  _restaurant.GetAllWithOutAsync();

            foreach(var restaurant in restaurants)
            {
                 _score.CalculateScoreOfRestaurant(restaurant.Id);
            }

            _restaurant.Save();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }

}
