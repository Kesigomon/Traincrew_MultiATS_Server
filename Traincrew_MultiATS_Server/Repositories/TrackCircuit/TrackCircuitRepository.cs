using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Traincrew_MultiATS_Server.Data;


namespace Traincrew_MultiATS_Server.Repositories.TrackCircuit;

public class TrackCircuitRepository(ApplicationDbContext context) : ITrackCircuitRepository
{
    public async Task<List<int>> GetBougoZoneByTrackCircuitList(List<Models.TrackCircuit> trackCircuitList)
    {
        List<int> zones = new List<int>();
        foreach (var trackCircuit in trackCircuitList)
        {
            Models.TrackCircuit trackCircuit_db = await context.TrackCircuits
                .Where(obj => obj.Name == trackCircuit.Name)
                .FirstOrDefaultAsync();

            if (trackCircuit_db != null)
            {
                zones.Add(trackCircuit_db.ProtectionZone);
            }
        }
        return zones;
    }
    public async Task<List<Models.TrackCircuit>> GetAllTrackCircuitList()
    {
        List<Models.TrackCircuit> trackcircuitlist_db = await context.TrackCircuits
            .Include(obj => obj.TrackCircuitState).ToListAsync();
        return trackcircuitlist_db;
    }

    public async Task<List<Models.TrackCircuit>> GetTrackCircuitListByTrainNumber(string trainNumber)
    {
        List<Models.TrackCircuit> trackcircuitlist_db = await context.TrackCircuits
            .Where(odj => odj.TrackCircuitState.TrainNumber == trainNumber)
            .Include(obj => obj.TrackCircuitState).ToListAsync();
        return trackcircuitlist_db;
    }

    public async Task SetTrackCircuitList(List<Models.TrackCircuit> trackCircuitList, string trainNumber)
    {
        // Todo: N+1問題の解消
        foreach (var trackCircuit in trackCircuitList)
        {
            Models.TrackCircuitState item = context.TrackCircuits
                .Include(item => item.TrackCircuitState)
                .Where(obj => obj.Name == trackCircuit.Name)
                .Select(item => item.TrackCircuitState)
                .FirstOrDefault()!;
            item.IsShortCircuit = true;
            item.TrainNumber = trainNumber;
            context.Update(item);
        }
        await context.SaveChangesAsync();
    }

    public async Task ClearTrackCircuitList(List<Models.TrackCircuit> trackCircuitList)
    {
        // Todo: N+1問題の解消
        foreach (var trackCircuit in trackCircuitList)
        {
            Models.TrackCircuitState item = context.TrackCircuits
                .Include(item => item.TrackCircuitState)
                .Where(obj => obj.Name == trackCircuit.Name)
                .Select(item => item.TrackCircuitState)
                .FirstOrDefault()!;
            item.IsShortCircuit = false;
            item.TrainNumber = "";
            context.Update(item);
        }
        await context.SaveChangesAsync();
    }
}