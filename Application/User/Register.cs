using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<User>
        {
            public string DisplayName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                //hàm validator EmailAddress dc cho sẵn, dựa vào đó viết 
                //tiếp hàm Password trong folder Validators của Application
                RuleFor(x => x.Email).EmailAddress();
                RuleFor(x => x.Password).Password();
            }
        }
        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(DataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                //handler logic
                if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email is already exists" });
                }
                if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { UserName = "Username is already exists" });
                }
                //nếu thỏa 2 đk trên thì tạo tài khoản mới cho user
                var user = new AppUser
                {
                    DisplayName = request.DisplayName,
                    Email = request.Email,
                    UserName = request.UserName
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Token = _jwtGenerator.CreateToken(user),
                        UserName = user.UserName,
                        Image = null
                    };
                }
                else
                    throw new Exception("Problem creating user");
            }
        }
    }
}