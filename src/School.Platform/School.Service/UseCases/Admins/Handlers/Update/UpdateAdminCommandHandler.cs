﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Exceptions.Admins;
using School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions;
using School.Service.Abstractions.DataAccess;
using School.Service.Interfaces.File;
using School.Service.Security.Password;
using School.Service.UseCases.Admins.Commands.Update;

namespace School.Service.UseCases.Admins.Handlers.Update
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, int>
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _context;

        public UpdateAdminCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId, cancellationToken);

            if (admin == null)
            {
                throw new AdminNotFound();
            }

            Admin? checkUserName = await _context.Admins.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

            Admin? checkEmail = await _context.Admins.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkUserName != null)
            {
                throw new UserNameAlreadyExistsException();
            }
            else if (checkEmail != null)
            {
                throw new EmailAlreadyExistsException();
            }

            admin.UserName = request.UserName;
            admin.Email = request.Email;
            admin.FirstName = request.FirstName;
            admin.LastName = request.LastName;
            admin.UpdatedAt = DateTime.Now;
            admin.PasswordHash = Hash512.ComputeSHA512HashFromString(request.Passwor);
            admin.UpdatedAt = DateTime.Now;


            if (request.ImagePath != null)
            {
                await _fileService.DeleteImageAsync(admin.ImagePath);
                admin.ImagePath = await _fileService.UploadImageAsync(request.ImagePath);
            }

            _context.Admins.Update(admin);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
