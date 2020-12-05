namespace PokerStrategy.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PokerStrategy.Common;
    using PokerStrategy.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
