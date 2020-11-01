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
    [Route("api/person")]
    public class PersonListController : ControllerBase
    {
        private IModelManager modelManager;

        public PersonListController()
        {
            modelManager = ModelManager.GetModelManager();
        }
        
        [HttpGet]
        public async Task<ActionResult<PersonList>> GetAllPerson()
        {
            try
            {
                var personList = new PersonList();
                foreach (var adult in modelManager.GetAllAdult().GetAllWithList())
                {
                    personList.AddPerson(adult);
                }
                foreach (var child in modelManager.GetAllChild().GetAllWithList())
                {
                    personList.AddPerson(child);
                }
                return Ok(JsonSerializer.Serialize(personList,new JsonSerializerOptions {WriteIndented = true}));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        
    }
}