using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OpenIddict.Validation.AspNetCore;
using Traincrew_MultiATS_Server.Services;

namespace Traincrew_MultiATS_Server.Hubs;

[Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
public class TIDHub(TrackCircuitService trackCircuitService): Hub
{
	public async Task<List<TrackCircuitData>> SendData_TID()
	{
		List<TrackCircuitData> trackCircuitDataList = await trackCircuitService.GetAllTrackCircuitDataList();
		return trackCircuitDataList;
	}
}