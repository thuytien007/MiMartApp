using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    //class này tạo Mediator và route controller chung cho các lớp khác kế thừa k phải viết lại ở mỗi class
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        //GetService là của thư viện Extension.Extensions.DependencyInjection, nó k tự import dc mà gõ tay
        //Nếu vế bên trái null thì lấy gtri vế bên phải gán vào cho biết Mediator.
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}