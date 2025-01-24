using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OpenIddict.Validation.AspNetCore;
using Traincrew_MultiATS_Server.Services;

namespace Traincrew_MultiATS_Server.Hubs;
// Todo: 司令員、乗務助役使用可
[Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
public class TIDHub(TrackCircuitService trackCircuitService): Hub
{
	public async Task<List<TrackCircuitData>> SendData_TID()
	{
		List<TrackCircuitData> trackCircuitDataList = await trackCircuitService.GetAllTrackCircuitDataList();
		return trackCircuitDataList;
	}
}