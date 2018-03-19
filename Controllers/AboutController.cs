
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    //[Route("About")]
    [Route("[controller]/[action=phone]")]
    public class AboutController 
    {
        //[Route("")]
        //[Route("[action]")]
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