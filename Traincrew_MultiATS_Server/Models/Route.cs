using System.ComponentModel.DataAnnotations.Schema;

namespace Traincrew_MultiATS_Server.Models;

[Table("route")]
public class Route : InterlockingObject
{
    public string TcName { get; set; }
    public RouteType RouteType { get; set; }
    public ulong? RootId { get; set; }
    public Route? Root { get; set; }
    public string? Indicator { get; set; }
    public int? ApproachLockTime { get; set; }
    public RouteState? RouteState { get; set; }
}