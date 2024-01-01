namespace OrderFoodOnline.TestBackGroundJob
{
    public class CalculateRestaurantScoresBackgroundService :  IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private int executionCount = 0;

        public CalculateRestaurantScoresBackgroundService(Timer? timer, int executionCount)
        {
            _timer = timer;
            this.executionCount = executionCount;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

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
