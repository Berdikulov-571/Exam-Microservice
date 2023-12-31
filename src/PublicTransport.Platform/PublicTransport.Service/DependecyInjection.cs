﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PublicTransport.Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
