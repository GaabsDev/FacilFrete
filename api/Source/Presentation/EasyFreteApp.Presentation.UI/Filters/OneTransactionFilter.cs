using EasyFreteApp.Infra.Data.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyFreteApp.Presentation.UI.Filters
{
    public class OneTransactionFilter : IActionFilter
    {
        private readonly IUnitOfWork UnitOfWork;

        public OneTransactionFilter(IUnitOfWork unitOfWork)
            => UnitOfWork = unitOfWork;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (UnitOfWork.ExistsTransaction())
            {
                if (context.Exception != null)
                    UnitOfWork.Rollbak();
                else
                    UnitOfWork.Commit();
            }
        }
    }
}
