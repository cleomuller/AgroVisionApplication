using SprayingAgent.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SprayingAgentTool.Core.Domain
{
    public class SprayingDetails
    {
        [Required]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Please enter a valid value, greater than 0")]
        public double SprayingAgentLitres { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Please enter a valid value, greater than 0")]
        public double MinimumAprayingAgentLitres { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Please enter a valid value, greater than 0")]
        public double TotalHectaresToBeSprayed { get; set; }
    }
}