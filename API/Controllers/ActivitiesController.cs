using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //CQRS là một pattern cho việc xử lý CRUD dữ liệu, viết tắt của từ Command Query Responsibility Segregation
    public class ActivitiesController : BaseController
    {
         //lấy hết những gì có trong bảng Activity
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Activity>>> List(){
            return await Mediator.Send(new List.Query());
        }
        // lấy theo Id 
        [HttpGet("{id}")]
        //thêm Authorize ở đây có nghĩ pthuc get theo id này k dc phép truy cập
        //phải là authorize và có token mới vô dc
        //[Authorize]
        public async Task<ActionResult<Activity>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        //Unit đảm bảo tất cả các repository đều dùng chung một DbContext,khi thực hiện xong tất cả các tác vụ 
        //thay đổi database, chỉ cần gọi DbContext.SaveChanges() 1 lần duy nhất, và các thay đổi đó sẽ được lưu lại trong database
         [HttpPost]
         [AllowAnonymous]
         public async Task<ActionResult<Unit>> Create(Create.Command command){
             return await Mediator.Send(command);
         }
         [HttpPut("{id}")]
         [AllowAnonymous]
         public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command){
             command.Id = id;
             return await Mediator.Send(command);
         }
         [HttpDelete("{id}")]
         [AllowAnonymous]
          public async Task<ActionResult<Unit>> Delete(Guid id){
             return await Mediator.Send(new Delete.Command{Id = id});
         }
    }
}