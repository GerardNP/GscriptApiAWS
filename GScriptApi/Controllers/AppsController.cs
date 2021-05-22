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
    public class AppsController : ControllerBase
    {
        private IRepositoryScripts repo;

        public AppsController(IRepositoryScripts repo)
        {
            this.repo = repo;
        }

        #region APPS
        [HttpGet]
        public ActionResult<List<App>> GetApps()
        {
            return this.repo.GetApps();
        }

        [HttpGet("{id}")]

        public ActionResult<App> GetApp(int id)
        {
            return this.repo.GetApp(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<App>> GetAppsByIds([FromQuery] List<int> id)
        {
            return this.repo.GetApps(id);
        }

        [HttpPost]
        public void PostApp(App app)
        {
            this.repo.PostApp(app.Name, app.ExeName, app.Path, app.Icon);
        }

        [HttpPut]
        public void PutApp(App app)
        {
            if (app.Icon != null)
            {
                this.repo.PutApp(app.Id, app.Name, app.ExeName, app.Path, app.Icon);
            }
            else
            {
                this.repo.PutApp(app.Id, app.Name, app.ExeName, app.Path);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteApp(int id)
        {
            this.repo.DeleteApp(id);
        }
        #endregion
    }
}
