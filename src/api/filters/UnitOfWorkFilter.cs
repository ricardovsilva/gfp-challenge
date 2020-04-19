using domain.interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.filters
{
    public class UnitOfWorkFilter : IResultFilter
    {
        private readonly IDatabase Database;

        public UnitOfWorkFilter(IDatabase database)
        {
            this.Database = database;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            this.Database.Commit();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }
}