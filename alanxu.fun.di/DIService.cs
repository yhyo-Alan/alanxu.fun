using alanxu.fun.data;
using alanxu.fun.idata;
using alanxu.fun.iserver;
using alanxu.fun.server;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.di
{
    public static class DIService
    {
        public static IServiceCollection AddDI(this IServiceCollection service)
        {
            service.AddScoped<IArticleData, ArticleData>();
            service.AddScoped<IArticleServer, ArticleServer>();
            return service;
        }
    }
}
