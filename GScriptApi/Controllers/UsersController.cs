using GScriptNuget;
using GScriptApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GScriptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryScripts repo;

        public UsersController(IRepositoryScripts repo)
        {
            this.repo = repo;
        }

        #region USERS
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return this.repo.GetUser(id);
        }

        [HttpGet]
        [Route("[action]/{email}")]
        public ActionResult<bool> ExistsUser(String email)
        {
            return this.repo.ExistsUser(email);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<User> LogIn(User u)
        {
            // CHAPUZILLA PARA OBTENER LA PASS
            return this.repo.LogIn(u.Email, u.Name);
        }

        [HttpPost]
        [Route("[action]")]
        public void Signup(User u)
        {
            // CHAPUZILLA PARA OBTENER LA PASS  
            this.repo.Signup(u.Name, u.Email, u.Salt);
        }
        #endregion
    }
}
