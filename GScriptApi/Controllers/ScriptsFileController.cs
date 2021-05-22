using GScriptNuget;
using GScriptApi.Repositories;
using GScriptApi.Services;
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
    public class ScriptsFileController : ControllerBase
    {
        private IRepositoryScripts repo;
        private ServiceBatchFiles ServiceBatchFiles;

        public ScriptsFileController(IRepositoryScripts repo, ServiceBatchFiles serviceBatchFiles)
        {
            this.repo = repo;
            this.ServiceBatchFiles = serviceBatchFiles;
        }

        [HttpGet]
        [Route("[action]/{showConsole}/{dir}")]
        public String CreateApssScript(bool showConsole, [FromQuery] List<int> id, String dir)
        {
            List<App> apps = this.repo.GetApps(id);
            String instructions = "";
            foreach (App app in apps)
            {
                instructions += this.ServiceBatchFiles.OpenApp(app);
            }

            String script = "";
            if (showConsole)
            {
                script = this.ServiceBatchFiles.CreateExeWithConsole(instructions, dir);
            }
            else
            {
                script = this.ServiceBatchFiles.CreateExe(instructions);
            }

            return script;
        }

        [HttpGet]
        [Route("[action]/{operation}/{time}/{msg}")]
        public String CreateShutScript(String operation, int time, String msg)
        {
            String instructions = this.ServiceBatchFiles.Shut(operation, time, msg);

            return this.ServiceBatchFiles.CreateExe(instructions);
        }
    }
}
