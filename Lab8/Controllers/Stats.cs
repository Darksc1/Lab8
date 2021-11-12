using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stats : Controller
    {
        Context context = new Context();
        [HttpGet]
        public List<Stat> Get()
        {
            IQueryable<User> users = from user in context.Users
                select user;
            List<Stat> result = new List<Stat>();
            if (!users.Any())
            {
                result.Add(new Stat
                {
                    Name = "User", Like = 0
                });
                return result;
            }
            foreach (User user in users)
            {
                Stat stat = new Stat();
                stat.Like = user.Like;
                stat.Name = user.Name;
                result.Add(stat);
            }
            return result.OrderByDescending(count => count.Like).ToList();
        }
    }

    public struct Stat
    {
        public string Name { get; set; }
        public int Like { get; set; }
    }
}