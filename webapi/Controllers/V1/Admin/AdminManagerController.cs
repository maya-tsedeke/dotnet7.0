using Applications.Features.Admin.Commands.AddAdminCommand;
using Applications.Features.Admin.Queries.GetToken;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.ApiModels.Admin;
using webapi.ApiModels.Admin.AdminManagement;
using webapi.Base2Controller;

namespace webapi.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/AdminManager")]
    public class AdminManagerController : BaseController
    {
        private readonly ISender _sender;

        public AdminManagerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> AdminLogin(AdminLoginViewModel model)
        {
            var query = await _sender.Send(new AdminGetTokenQuery(model.UserName, model.Password));

            return base.OperationResult(query);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("NewAdmin")]
        public async Task<IActionResult> AddNewAdmin(AddAdminViewModel model)
        {
            var commandResult = await _sender.Send(new AddAdminCommandModel(model.AdminUserName, model.AdminEmail,
                model.AdminPassword, model.RoleId));

            return base.OperationResult(commandResult);
        }
    }
}
