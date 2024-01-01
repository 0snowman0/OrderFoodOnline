namespace OrderFoodOnline.TestBackGroundJob
{
    public class CalculateRestaurantScoresBackgroundService1 : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private int executionCount = 0;

        public CalculateRestaurantScoresBackgroundService1(Timer? timer, int executionCount)
        {
            _timer = timer;
            this.executionCount = executionCount;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromHours(3));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            // Do your work here

            // For example, you can calculate the scores for all restaurants

            var restaurants = GetAllRestaurants();

            for (int i = 0; i < restaurants.Count; i++)
            {
                var restaurant = restaurants[i];

                // Calculate the score for the restaurant

                var score = CalculateScore(restaurant);

                // Save the score for the restaurant

                SaveScore(restaurant, score);
            }

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
