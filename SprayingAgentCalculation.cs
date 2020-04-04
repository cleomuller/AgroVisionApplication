using SprayingAgent.Core.Interfaces;
using SprayingAgentTool.Core.Domain;
using System;

namespace SprayingAgentTool.Core.Processor
{
    public class SprayingAgentCalculation: ISprayingAgent
    {
        public SprayingAgentCalculation()
        {
        }

        public SprayingAgentResult SprayingAgentDetails(SprayingDetails request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return new SprayingAgentResult
            {
                SprayingAgentLitres = request.SprayingAgentLitres,
                MinimumAprayingAgentLitres = request.MinimumAprayingAgentLitres,
                TotalHectaresToBeSprayed = request.TotalHectaresToBeSprayed
            };
        }

        public double CalculateSprayingAgent(double sprayingAgentLitres, double totalHectaresToBeSprayed)
        {
            return Math.Round(sprayingAgentLitres * totalHectaresToBeSprayed, 3);
        }

        public double CalculateWater(double sprayingAgentLitres, double totalHectaresToBeSprayed, double minimumAprayingAgentLitres)
        {
            var total = totalHectaresToBeSprayed * minimumAprayingAgentLitres;

            return Math.Round(total - sprayingAgentLitres, 3);
        }
    }
}