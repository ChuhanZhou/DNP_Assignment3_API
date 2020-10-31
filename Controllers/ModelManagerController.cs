using System;
using System.Threading.Tasks;
using DNP_Assignment3_API.Data;
using DNP_Assignment3_API.Models;
using DNP_Assignment3_API.Models.List;
using Microsoft.AspNetCore.Mvc;

namespace DNP_Assignment3_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ModelManagerController : ControllerBase
    {
        private IModelManager modelManager;

        public ModelManagerController()
        {
            modelManager = new ModelManager();
        }

        [Route("user")]
        [HttpGet]
        public async Task<ActionResult<UserList>> GetAllUser()
        {
            try
            {
                UserList userList = modelManager.GetAllUser();
                return Ok(userList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}