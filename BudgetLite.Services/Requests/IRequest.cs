using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLite.Services.Requests
{
    public interface IRequest
    {
        bool IsValid();
    }
}
