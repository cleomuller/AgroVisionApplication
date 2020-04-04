using SprayingAgentTool.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SprayingAgent.Core.Interfaces
{
    public interface ISprayingAgent
    {
        double CalculateSprayingAgent(double sprayingAgentLitres, double totalHectaresToBeSprayed);

        double CalculateWater(double sprayingAgentLitres, double totalHectaresToBeSprayed, double minimumAprayingAgentLitres);
    }
}
