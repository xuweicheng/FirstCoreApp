
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    //[Route("About")]
    //[Route("[controller]/[action=phone]")] can't use the default convention in attribute routing, specifically list them out
    [Route("[controller]/[action]")]
    public class AboutController 
    {
        //[Route("")]
        //[Route("[action]")]
        [Route("[controller]")] //specifically list the default routing
        public string Phone()
        {
            return "123-456-7890";
        }

        //[Route("Address")]
        //[Route("[action]")]
        public string Address()
        {
            return "Canada";
        }
    }
}