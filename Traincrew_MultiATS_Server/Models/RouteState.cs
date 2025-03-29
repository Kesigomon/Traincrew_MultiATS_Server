﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traincrew_MultiATS_Server.Models;

[Table("route_state")]
public class RouteState
{
    [Key]
    public ulong Id { get; init; }
    /// <summary>
    /// てこ反応リレー
    /// </summary>
    public RaiseDrop IsLeverRelayRaised { get; set; }
    /// <summary>
    /// 進路照査リレー
    /// </summary>
    public RaiseDrop IsRouteRelayRaised { get; set; }
    /// <summary>
    /// 信号制御リレー
    /// </summary>
    public RaiseDrop IsSignalControlRaised { get; set; }
    /// <summary>
    /// 接近鎖錠リレー(MR)
    /// </summary>
    public RaiseDrop IsApproachLockMRRaised { get; set; }
    /// <summary>
    /// 接近鎖錠リレー(MS)
    /// </summary>
    public RaiseDrop IsApproachLockMSRaised { get; set; }
    /// <summary>
    /// 進路鎖錠リレー(実在しない)
    /// </summary>
    public RaiseDrop IsRouteLockRaised { get; set; }
    /// <summary>
    /// 総括反応リレー
    /// </summary>
    // ReSharper disable InconsistentNaming
    [Column("is_throw_out_xr_relay_raised")]
    public RaiseDrop IsThrowOutXRRelayRaised { get; set; }
    /// <summary>
    /// 総括反応中継リレー
    /// </summary>
    [Column("is_throw_out_ys_relay_raised")]
    public RaiseDrop IsThrowOutYSRelayRaised { get; set; }
    // ReSharper restore InconsistentNaming
}