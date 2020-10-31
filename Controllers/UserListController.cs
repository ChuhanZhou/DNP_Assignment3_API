﻿using System;
using System.Collections.Generic;
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

        [HttpPost]
        public async Task<ActionResult<string>> AddUser([FromBody] User newUser)
        {
            try
            {
                return modelManager.AddUser(newUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
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

        [HttpPatch]
        public async Task<ActionResult<string>> UpdatePassword([FromBody] List<User> userList)
        {
            try
            {
                return modelManager.UpdatePassword(userList[0],userList[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        public async Task RemoveUser([FromQuery] string userName)
        {
            try
            {
                modelManager.RemoveUser(modelManager.GetAllUser().GetUserByUserName(userName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}