using System;
using System.Text.Json;
using System.Threading.Tasks;
using DNP_Assignment3_API.Data;
using DNP_Assignment3_API.Models.List;
using DNP_Assignment3_API.Models.Unit;
using Microsoft.AspNetCore.Mvc;

namespace DNP_Assignment3_API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserListController : ControllerBase
    {
        private IModelManager modelManager;

        public UserListController()
        {
            modelManager = ModelManager.GetModelManager();
        }
        
        [HttpGet]
        public async Task<ActionResult<UserList>> GetAllUser()
        {
            try
            {
                var userList = modelManager.GetAllUser();
                return Ok(JsonSerializer.Serialize(userList,new JsonSerializerOptions {WriteIndented = true}));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [Route("login")]
        [HttpGet]
        public async Task<ActionResult<bool>> Login([FromQuery] string userJson)
        {
            try
            {
                var user = JsonSerializer.Deserialize<User>(userJson);
                return Ok(modelManager.Login(user));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}