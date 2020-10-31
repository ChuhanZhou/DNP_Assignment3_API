using System;
using System.Threading.Tasks;
using DNP_Assignment3_API.Data;
using DNP_Assignment3_API.Models;
using DNP_Assignment3_API.Models.List;
using DNP_Assignment3_API.Models.Unit;
using Microsoft.AspNetCore.Mvc;

namespace DNP_Assignment3_API.Controllers
{
    [ApiController]
    [Route("api/all")]
    public class ModelManagerController : ControllerBase
    {
        private IModelManager modelManager;

        public ModelManagerController()
        {
            modelManager = ModelManager.GetModelManager();
        }
        
        [HttpGet]
        public async Task<ActionResult<ModelManager>> GetModelManager()
        {
            try
            {
                return Ok(modelManager);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}