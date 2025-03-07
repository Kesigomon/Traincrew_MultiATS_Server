﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traincrew_MultiATS_Server.Models;

[Table("station_interlocking_object")]
public class StationInterlockingObject
{
    [Key]
    public required string StationId { get; set; }

    [Key]
    public required ulong ObjectId { get; set; }

    [ForeignKey("StationId")]
    public virtual Station Station { get; set; }

    [ForeignKey("ObjectId")]
    public virtual InterlockingObject InterlockingObject { get; set; }
}