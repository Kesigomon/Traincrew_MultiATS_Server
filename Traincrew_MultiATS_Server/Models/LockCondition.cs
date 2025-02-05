using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Traincrew_MultiATS_Server.Models;

[Table("lock_condition")]
public class LockCondition
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public ulong Id { get; set; }
    public ulong LockId { get; set; }
    public ulong? ParentId { get; set; }
    public LockConditionType Type { get; set; }
}