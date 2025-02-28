using Microsoft.AspNetCore.SignalR;
using Traincrew_MultiATS_Server.Services;
using Microsoft.AspNetCore.Authorization;
using OpenIddict.Validation.AspNetCore;


namespace Traincrew_MultiATS_Server.Hubs;

[Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
public class InterlockingHub(TrackCircuitService trackCircuitService) : Hub
{
    public async Task<Models.DataToInterlocking> SendData_Interlocking(Models.DataToInterlocking dataToInterlocking)
    {
        Models.DataToInterlocking response = new Models.DataToInterlocking();
        response.TrackCircuits = await trackCircuitService.GetAllTrackCircuitDataList();

        // Todo: TraincrewRole Authenticationsを設定する
        // response.Authentications =                       

        // Todo: List<InterlockingSwitchData> Pointsを設定する
        // response.Points =                              

        // Todo: List<InterlockingSignalData> Signalsを設定する
        // response.Signals =                               

        // Todo: List<InterlockingLeverData> PhysicalLeversを設定する
        // response.PhysicalLevers =                           

        // Todo: List<DestinationButtonState> PhysicalButtonsを設定する
        // response.PhysicalButtons =                        

        // Todo: List<InterlockingDirectionData> Directionsを設定する
        // response.PhysicalButtons =                          

        // Todo: List<InterlockingRetsubanData> Retsubansを設定する
        // response.Retsubans =                              

        // Todo: List<Dictionary<string, bool>> Lampsを設定する
        // response.Lamps = 
        return response;
    }
}