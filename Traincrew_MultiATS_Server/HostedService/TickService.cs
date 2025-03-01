using Traincrew_MultiATS_Server.Services;

namespace Traincrew_MultiATS_Server.HostedService;

public class TickService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly Task _task;

    public TickService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _task = Task.Run(async () => await RunAsync(_cancellationTokenSource.Token));
    }

    private async Task RunAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var timer = Task.Delay(100, cancellationToken);
            await ExecuteTaskAsync();
            await timer;
        }
    }

    private async Task ExecuteTaskAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<SwitchingMachineService>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<TickService>>();
        try
        {
            await service.SwitchingMachineControl();
        }
        catch (System.Exception ex)
        {
            // Log the exception
            logger.LogError(ex, "An error occurred while executing the task.");
        }
    }

    public async Task Stop()
    {
        await _cancellationTokenSource.CancelAsync();
        await _task;
    }
}
