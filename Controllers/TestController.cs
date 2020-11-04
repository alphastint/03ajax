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
    public class TestController : ControllerBase
    {
        public static UserManager mUserManager = new UserManager();
        int a = 0;
        readonly object Mutex = new object();

        string message = "";
        private readonly ILogger<TestController> _logger;
        WebSocket socket;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
            a += 1;
        }

        [HttpGet]
        public string Get(string username)
        {
            Console.WriteLine(" string Get(string username)");
            lock (Mutex)
            {
                Monitor.Enter(Mutex);
            }
            Console.WriteLine("swait");
            var user = mUserManager.AddUser(username);
            user.MessageArrived += delegate (string message)
            {
                Console.WriteLine($"MessageArrived Username = {username}");
                lock (Mutex)
                {
                    this.message = message;
                    Monitor.Pulse(Mutex);
                }
            };

            lock (Mutex)
            {
                Monitor.Wait(Mutex);
                Monitor.Exit(Mutex);
            }
            Console.WriteLine("semaphore.WaitOne();");
            return message;

        }
    }
}
