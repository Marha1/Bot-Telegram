using Microsoft.AspNetCore.Mvc;
using QuartzApp.Jobs;
using Telegram.Bot.Types;

namespace WebApplication12.Controllers
{
   [ApiController]

    public class BotController : ControllerBase
    {
        [Route("api/message")]
        [HttpPost]
        public IActionResult Update() 
        {
            //Tg telegram = new Tg();
            //telegram.Bot();
            PostcardSheduler.Start();
            Console.WriteLine("Задача запущена");
            return Ok();
        }
        [Route("api/message")]
        [HttpGet]
        public IActionResult Get()
        {
            PostcardSheduler.Start();

            return Ok();
        }
    }
}
