using DNP_Assignment3_API.Data;
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
    }
}