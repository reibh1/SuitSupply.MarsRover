using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuitSupply.MarsRover.Exceptions;
using SuitSupply.MarsRover.Types;
using SuitSupply.MarsRover.WebApi.Extensions;
using PositionStruct = SuitSupply.MarsRover.Types.Position;
using Position = SuitSupply.MarsRover.WebApi.Model.Position;

namespace SuitSupply.MarsRover.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoverController : ControllerBase
    {
        private readonly ILogger<HoverController> _logger;

        public HoverController(ILogger<HoverController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Move")]
        public ActionResult<Position> Get(int x, int y, string direction, string commandSequence)
        {
            var position = new PositionStruct { Coordinate = new Coordinate(x, y), Direction = direction.ToDirection() };

            var finalPosition = Hover.BatchMove(position, commandSequence);

            return Ok(finalPosition.ToPositionModel());
        }

        [HttpGet("SafeMove")]
        public ActionResult<Position> Get(int x, int y, string direction, string commandSequence, string obstacleSequence)
        {
            var position = new PositionStruct { Coordinate = new Coordinate(x, y), Direction = direction.ToDirection() };

            try
            {
                var finalPosition = Hover.BatchMove(position, commandSequence, obstacleSequence);

                return Ok(finalPosition.ToPositionModel());
            }
            catch (CollisionException e)
            {
                return Ok(e.Message);
            }
        }
    }
}
