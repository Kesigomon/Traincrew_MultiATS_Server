﻿namespace Traincrew_MultiATS_Server.Repositories.NextSignal;

public interface INextSignalRepository
{
    public Task<List<Models.NextSignal>> GetNextSignalByNamesOrderByDepthDesc(List<string> signalNames);
}