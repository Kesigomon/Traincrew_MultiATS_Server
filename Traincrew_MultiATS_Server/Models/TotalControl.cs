﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traincrew_MultiATS_Server.Models;

public class TotalControl
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public ulong Id { get; init; }
    public ulong SourceRouteId { get; init; }
    public Route? SourceRoute { get; init; }
    public ulong TargetRouteId { get; init; }
    public Route? TargetRoute { get; init; }
}