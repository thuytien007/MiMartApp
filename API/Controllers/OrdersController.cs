using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Orders;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class OrdersController : BaseController
    {
         [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Order>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Order>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        // [HttpPost]
        // [AllowAnonymous]
        // public async Task<ActionResult<Unit>> Create(Create.Command command)
        // {
        //     return await Mediator.Send(command);
        // }
        // [HttpPut("{id}")]
        // [AllowAnonymous]
        // public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        // {
        //     command.Id = id;
        //     return await Mediator.Send(command);
        // }
        // [HttpDelete("{id}")]
        // [AllowAnonymous]
        // public async Task<ActionResult<Unit>> Delete(Guid id)
        // {
        //     return await Mediator.Send(new Delete.Command { Id = id });
        // }
    }
}