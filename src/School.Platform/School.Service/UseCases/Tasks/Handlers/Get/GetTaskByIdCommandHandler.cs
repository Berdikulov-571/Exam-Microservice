﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Exceptions.Task;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Tasks.Queries.Get;

namespace School.Service.UseCases.Tasks.Handlers.Get
{
    public class GetTaskByIdCommandHandler : IRequestHandler<GetTaskByIdQuery, Domain.Entities.Task.Tasks>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Task.Tasks> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Task.Tasks? task = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskId == request.TaskId, cancellationToken);

            if (task == null)
                throw new TaskNotFound();

            return task;
        }
    }
}