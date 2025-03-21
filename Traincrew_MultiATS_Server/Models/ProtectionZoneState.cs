using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traincrew_MultiATS_Server.Models;

[Table("protection_zone_state")]
public class ProtectionZoneState
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
	public ulong id { get; set; }
	public int ProtectionZone { get; set; }
	public required string TrainNumber { get; set; }
}