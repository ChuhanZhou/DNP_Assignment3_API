﻿using System;
using System.Text.Json;
using System.Threading.Tasks;
using DNP_Assignment3_API.Data;
using DNP_Assignment3_API.Models.List;
using DNP_Assignment3_API.Models.Unit;
using Microsoft.AspNetCore.Mvc;

namespace DNP_Assignment3_API.Controllers
{
    [ApiController]
    [Route("api/person/adult")]
    public class AdultListController : ControllerBase
    {
        private IModelManager modelManager;

        public AdultListController()
        {
            modelManager = ModelManager.GetModelManager();
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> AddAdult([FromBody] Adult newAdult)
        {
            try
            {
                return modelManager.AddAdult(newAdult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<AdultList>> GetAllAdult()
        {
            try
            {
                var adultList = modelManager.GetAllAdult();
                return Ok(JsonSerializer.Serialize(adultList,new JsonSerializerOptions {WriteIndented = true}));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}