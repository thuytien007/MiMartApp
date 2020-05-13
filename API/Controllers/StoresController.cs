using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Stores;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StoresController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Store>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Store>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
    }
}