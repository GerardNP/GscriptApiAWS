using GScriptNuget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GScriptApi.Repositories
{
    public interface IRepositoryScripts
    {
        #region APPS
        // USER
        List<App> GetApps();
        App GetApp(int id);
        List<App> GetApps(List<int> ids);

        //ADMIN
        void PostApp(String name, String exeName, String path, String icon);
        void PutApp(int id, String name, String exeName, String path, String icon);
        void PutApp(int id, String name, String exeName, String path);
        void DeleteApp(int id);
        #endregion


        #region SCRIPTS
        List<Script> GetScripts(int userId);
        Script GetScript(int id);
        void PostScript(String name, String script, int userId);
        void DeleteScript(int id);
        #endregion


        #region USERS
        void Signup(String name, String email, String password);
        User LogIn(String email, String password);
        User GetUser(int id);
        bool ExistsUser(String email);
        #endregion
    }
}
