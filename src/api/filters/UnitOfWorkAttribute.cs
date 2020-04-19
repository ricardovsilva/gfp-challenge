using System;
using domain.interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.filters
{

    public class UnitOfWorkAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new UnitOfWorkFilter((IDatabase)serviceProvider.GetService(typeof(IDatabase)));
        }
    }
}