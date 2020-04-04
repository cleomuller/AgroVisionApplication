using System;
using SprayingAgent.Core.Interfaces;
using SprayingAgentTool.Core.Domain;
using Xunit;


namespace SprayingAgentTool.Core.Processor
{
    public class SprayingAgentCalculationTests
    {
        private readonly SprayingAgentCalculation _processor;

        public SprayingAgentCalculationTests()
        {
             _processor = new SprayingAgentCalculation();
        }

        [Fact]
        public void ShouldReturnSprayingAgentResultWithRequestValues()
        {
            //Arrange
            var request = new SprayingDetails
            {
                SprayingAgentLitres = 1.6,
                MinimumAprayingAgentLitres = 250,
                TotalHectaresToBeSprayed = 21.94
            };

            //Act
            SprayingAgentResult result = _processor.SprayingAgentDetails(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.SprayingAgentLitres, result.SprayingAgentLitres);
            Assert.Equal(request.MinimumAprayingAgentLitres, result.MinimumAprayingAgentLitres);
            Assert.Equal(request.TotalHectaresToBeSprayed, result.TotalHectaresToBeSprayed);
        }

        [Fact]
        public void SprayingAgentNeeded()
        {
            //Arrange
            var request = new SprayingDetails
            {
                SprayingAgentLitres = 1.6,
                MinimumAprayingAgentLitres = 250,
                TotalHectaresToBeSprayed = 21.94
            };

            var sprayAgentNeededExpected = Math.Round(request.SprayingAgentLitres * request.TotalHectaresToBeSprayed, 3);

            //Act
            double actualResult = _processor.CalculateSprayingAgent(request.SprayingAgentLitres, request.TotalHectaresToBeSprayed);

            //Assert
            Assert.Equal(sprayAgentNeededExpected, actualResult);
        }

        [Fact]
        public void WaterNeeded()
        {
            //Arrange
            var request = new SprayingDetails
            {
                SprayingAgentLitres = 1.6,
                MinimumAprayingAgentLitres = 250,
                TotalHectaresToBeSprayed = 21.94
            };

            var sprayAgentNeededExpected = request.SprayingAgentLitres * request.TotalHectaresToBeSprayed;
            var totalForSpraying = request.MinimumAprayingAgentLitres * request.TotalHectaresToBeSprayed;
            var waterNeededExpected = Math.Round(totalForSpraying - sprayAgentNeededExpected, 3);

            double actualResult = _processor.CalculateWater(sprayAgentNeededExpected, request.TotalHectaresToBeSprayed, request.MinimumAprayingAgentLitres);

            Assert.Equal(waterNeededExpected, actualResult);

        }

    }
}
