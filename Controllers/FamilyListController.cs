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
    [Route("api/family")]
    public class FamilyListController : ControllerBase
    {
        private IModelManager modelManager;

        public FamilyListController()
        {
            modelManager = ModelManager.GetModelManager();
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddFamily([FromBody] Family newFamily)
        {
            try
            {
                return modelManager.AddFamily(newFamily);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FamilyList>> GetAllFamily()
        {
            try
            {
                var familyList = modelManager.GetAllFamily();
                return Ok(JsonSerializer.Serialize(familyList, new JsonSerializerOptions {WriteIndented = true}));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<string>> UpdateFamily([FromBody] List<Family> familyList)
        {
            try
            {
                return modelManager.UpdateFamily(familyList[0], familyList[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task RemoveFamily([FromQuery] string streetName,[FromQuery] int houseNumber)
        {
            try
            {
                modelManager.RemoveFamily(modelManager.GetAllFamily().GetFamilyByStreetNameAndHouseNumber(streetName,houseNumber));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}