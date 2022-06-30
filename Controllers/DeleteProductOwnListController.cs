using Microsoft.AspNetCore.Mvc;
using botapi.Model;
using System.IO;

namespace botapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DeleteProductOwnListController : Controller
    {
        [HttpDelete("{id:long}")]
        public async Task<string> DeleteProduct(long id, string product)
        {
            var result = Data.Data.DeleteProduct(id, product);
            return result;
        }
    }
}
