namespace Traincrew_MultiATS_Server.Repositories.Station;

public interface IStationRepository
{
    Task<Models.Station?> GetStationByName(string name);
    Task Save(Models.Station station);
}