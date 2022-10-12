#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_exam_Jumpstarter.Models;
public class Pledge
{
    [Required]
    [Range(1,Int32.MaxValue,ErrorMessage ="Must be 1 or more dollars")]
    public int PledgeAmt {get; set; }

    public int ProjectId {get; set; }
}