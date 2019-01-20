using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transforma.infrastructure;

namespace Transforma.API.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public readonly IMediator _mediator;
    }
}
