using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    //[NonAction] //Bu bir endpoint değildir.Swagger bu attribute'u enpoint olarak algılamaması için NonAction attribute'ını ekliyorum.
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204) //204 no content
                return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };

            return new ObjectResult(response)   //Bunun bize faydası controller'da süreki Ok,BadRequest,NoContent,Created gibi ifadelerden kurtulmak ve clean code yazmaktır.
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

