using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> Create([FromForm]Create.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> Edit(Guid id, [FromForm]Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }
    }
}