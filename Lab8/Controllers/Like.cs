using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Like : ControllerBase
    {

        [HttpGet]
        public string Get(string login)
        {
            Context context = new Context();
            IQueryable<User> users = from user in context.Users 
                where (user.Name == login) 
                select user;
            if (users.Any() && users.Count() == 1)
            {
                users.First().Like += 1;
                
                try
                {
                    context.SaveChangesAsync();
                    return "Liked!";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "Some error";
                }
            }
            try
            {
                User newUser = new User() { Name = login, Like = 1 };
                context.Users.Add(newUser);
                context.SaveChangesAsync();
                return "Liked!";
            }
            catch
            {
                return "Some error";
            }
        }
    }
}