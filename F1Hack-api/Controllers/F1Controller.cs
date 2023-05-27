using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1Hack_api.Controllers
{
    [Authorize]
    public abstract class F1Controller : ControllerBase
    {
        protected F1Context _context { get; }

        public F1Controller(F1Context context)
        {
            _context = context;
        }
    }
}
