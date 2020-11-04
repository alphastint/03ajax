using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Net.WebSockets;

namespace _03ajax.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : ControllerBase
    {

        int a = 0;

        static string message = "";
        private readonly ILogger<SendController> _logger;
        WebSocket socket;
        public SendController(ILogger<SendController> logger)
        {
            _logger = logger;
            a += 1;
        }



        [HttpGet]
        public string Get(string message, string username)
        {
            if (username == "" || username == null)
            {
                Console.WriteLine($"mUserManager.SendMessageToAll({message});");
                LoginController.mUserManager.SendMessageToAll(message);
            }
            else
            {
                Console.WriteLine($"mUserManager.SendMessageToUser({message}, {username});");
                LoginController.mUserManager.SendMessageToUser(message, username);
            }

            return "Ok";
        }
    }
}
