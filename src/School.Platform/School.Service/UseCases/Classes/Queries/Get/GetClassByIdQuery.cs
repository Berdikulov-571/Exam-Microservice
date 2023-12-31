﻿using MediatR;
using School.Domain.Entities.Classes;

namespace School.Service.UseCases.Classes.Queries.Get
{
    public class GetClassByIdQuery : IRequest<Class>
    {
        public int ClassId { get; set; }
    }
}