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
        public static UserManager mUserManager = new UserManager();
        int a = 0;

        static string message = "";
        private readonly ILogger<TestController> _logger;
        WebSocket socket;
        public SendController(ILogger<TestController> logger)
        {
            _logger = logger;
            a += 1;
        }



        [HttpGet]
        public string Get(string message)
        {
            TestController.mUserManager.SendMessage(message);

            return "Ok";
        }
    }
}
