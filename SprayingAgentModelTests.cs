using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using SprayingAgent.Core.Interfaces;
using SprayingAgent.Web.Pages;
using SprayingAgentTool.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SprayingAgent.Web.Tests
{
    public class SprayingAgentModelTests
    {
        private ISprayingAgent _sprayingAgent;
        private SprayingDetailsModel _sprayingDetailsModel;
        private SprayingDetails _details;
        private SprayingAgentResult _results;

        [Theory]
        [InlineData(typeof(PageResult), false, null)]
        [InlineData(typeof(PageResult), true, DeskBookingResultCode.NoDeskAvailable)]
        [InlineData(typeof(RedirectToPageResult), true, DeskBookingResultCode.Success)]
        public void ShouldReturnExpectedActionResult(Type expectedActionResultType, bool isModelValid, DeskBookingResultCode? deskBookingResultCode)
        {
            // Arrange
            if (!isModelValid)
            {
                _sprayingDetailsModel.ModelState.AddModelError("JustAKey", "AnErrorMessage");
            }

            if (deskBookingResultCode.HasValue)
            {
                _deskBookingResult.Code = deskBookingResultCode.Value;
            }

            // Act
            IActionResult actionResult = _sprayingDetailsModel.OnPost();

            // Assert
            Assert.IsType(expectedActionResultType, actionResult);
        }

        [Fact]
        public void ShouldReturnCalculatedResults()
        {
            //Arrange
            _details.SprayingAgentLitres = 1.6;
            _details.TotalHectaresToBeSprayed = 21.94;
            _details.SprayingAgentLitres = 250;

            // Act
            _results.TotalSprayingAgent = _sprayingAgent.CalculateSprayingAgent(_details.SprayingAgentLitres, _details.TotalHectaresToBeSprayed);
            _results.TotalWater = _sprayingAgent.CalculateWater(_results.TotalSprayingAgent, _details.TotalHectaresToBeSprayed, _details.MinimumAprayingAgentLitres);
            IActionResult actionResult = _sprayingDetailsModel.OnPost();
        }
    }
}
