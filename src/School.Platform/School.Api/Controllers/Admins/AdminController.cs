﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Admins;
using School.Service.UseCases.Admins.Commands.Create;
using School.Service.UseCases.Admins.Commands.Delete;
using School.Service.UseCases.Admins.Commands.Update;
using School.Service.UseCases.Admins.Queries.Get;
using TelegramBot;

namespace School.Api.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateAdminCommand admin)
        {
            int result = await _mediator.Send(admin);

            BotMessage bot = new BotMessage();
            await bot.Added("School.Api -> Admin");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int adminId)
        {
            GetAdminByIdQuery command = new GetAdminByIdQuery()
            {
                AdminId = adminId
            };

            Admin admin = await _mediator.Send(command);

            return Ok(admin);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int adminId)
        {
            DeleteAdminCommand command = new DeleteAdminCommand()
            {
                AdminId = adminId
            };

            int result = await _mediator.Send(command);

            BotMessage bot = new BotMessage();
            await bot.Deleted("School.Api -> Admin");

            return Ok(result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Admin> admins = await _mediator.Send(new GetAllAdminQuery());

            return Ok(admins);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateAdminCommand admin)
        {
            int result = await _mediator.Send(admin);

            BotMessage bot = new BotMessage();
            await bot.Updated("School.Api -> Admin");

            return Ok(result);
        }


        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async ValueTask<FileContentResult> GetImageAsync(int adminId)
        {
            byte[] image = await _mediator.Send(new GetAdminImageQuery() { AdminId = adminId});

            return File(image, "image/png");
        }
    }
}