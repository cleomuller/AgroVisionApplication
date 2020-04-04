using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SprayingAgent.Core.Interfaces;
using SprayingAgentTool.Core.Domain;
using SprayingAgentTool.Core.Processor;


namespace SprayingAgent.Web.Pages
{
    public class SprayingDetailsModel : PageModel
    {

        private ISprayingAgent _sprayingAgent;

        public SprayingDetailsModel(ISprayingAgent sprayingAgentProcessor)
        {
            _sprayingAgent = sprayingAgentProcessor;
        }

        [BindProperty]
        public SprayingDetails sprayingDetails { get; set; }

        [BindProperty]
        public SprayingAgentResult results { get; set; }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
               results.TotalSprayingAgent = _sprayingAgent.CalculateSprayingAgent(sprayingDetails.SprayingAgentLitres, sprayingDetails.TotalHectaresToBeSprayed);
               results.TotalWater = _sprayingAgent.CalculateWater(results.TotalSprayingAgent, sprayingDetails.TotalHectaresToBeSprayed, sprayingDetails.MinimumAprayingAgentLitres);
            }

            return Page();
        }
    }
}