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
    public class ScriptsController : ControllerBase
    {
        private IRepositoryScripts repo;

        public ScriptsController(IRepositoryScripts repo)
        {
            this.repo = repo;
        }

        #region SCRIPTS
        [HttpGet("{userId}")]
        public ActionResult<List<Script>> GetScripts(int userId)
        {
            return this.repo.GetScripts(userId);
        }

        //[HttpGet("{id}")]
        //public ActionResult<Script> GetScript(int id)
        //{
        //    return this.repo.GetScript(id);
        //}

        [HttpPost]
        public void PostScript(Script s)
        {
            this.repo.PostScript(s.Name, s.Code, s.UserId);
        }

        [HttpDelete("{id}")]
        public void DeleteScript(int id)
        {
            this.repo.DeleteScript(id);
        }
        #endregion
    }
}
