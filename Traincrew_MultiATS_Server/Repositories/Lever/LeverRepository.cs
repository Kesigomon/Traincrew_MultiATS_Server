using Microsoft.EntityFrameworkCore;
using Traincrew_MultiATS_Server.Data;

namespace Traincrew_MultiATS_Server.Repositories.Lever;

public class LeverRepository(ApplicationDbContext context) : ILeverRepository
{
    public async Task<Models.Lever?> GetLeverByNameWitState(string name)
    {
        return await context.Levers
            .Include(lever => lever.LeverState)
            .FirstOrDefaultAsync(lever => lever.Name == name);
    }

    public async Task<List<ulong>> GetIdsBySwitchingMachineIds(List<ulong> ids)
    {
        return await context.Levers
            .Where(lever => lever.SwitchingMachineId != null && ids.Contains(lever.SwitchingMachineId.Value))
            .Select(lever => lever.Id)
            .ToListAsync();
    }
}