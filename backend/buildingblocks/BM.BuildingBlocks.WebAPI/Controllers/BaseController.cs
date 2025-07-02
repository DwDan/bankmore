using BM.BuildingBlocks.Core.Exception;
using BM.BuildingBlocks.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BM.BuildingBlocks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Ok<T>(T data) =>
                base.Ok(new ApiResponseWithData<T> { Data = data, Success = true });

        protected void EnsureRouteMatchesBodyId(Guid routeId, Guid bodyId)
        {
            if (routeId != bodyId)
                throw new BadRequestException("Error.RequestBodyIdMismatch");
        }
    }
}
