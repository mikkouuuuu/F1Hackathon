using Microsoft.AspNetCore.Mvc;

namespace F1Hack_api.Controllers
{
    public abstract class F1Controller : Controller
    {
        protected F1Context _context { get; }

        public F1Controller(F1Context context)
        {
            _context = context;
        }
    }
}
