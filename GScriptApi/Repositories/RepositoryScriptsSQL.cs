using GScriptApi.Data;
using GScriptApi.Helpers;
using GScriptNuget;
using GScriptApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GScriptApi.Repositories
{
    public class RepositoryScriptsSQL : IRepositoryScripts
    {
        private ScriptsContext context;

        public RepositoryScriptsSQL(ScriptsContext context)
        {
            this.context = context;
        }



        #region USERS
        private int GetMaxIdUsers()
        {
            int amount = this.context.Users.Count();
            if (amount == 0)
            {
                return 0;
            }
            else
            {
                return this.context.Users.Max(x => x.Id);
            }
        }

        public void Signup(String name, String email, String password)
        {
            User user = new User();
            user.Id = this.GetMaxIdUsers() + 1;
            user.Name = name;
            user.Email = email;
            String salt = "";
            byte[] cypherPass = CypherService.Cypher(password, ref salt);
            user.Salt = salt;
            user.Password = cypherPass;
            user.Role = "user";

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User LogIn(String email, String password)
        {
            User user = this.context.Users.Where(x => x.Email == email)
                .FirstOrDefault();

            if (user == null) // USUARIO NO ENCONTRADO
            {
                return null;
            }
            else
            {
                String salt = user.Salt;
                byte[] temporalPass = CypherService.Cypher(password, salt);
                byte[] bddPass = user.Password;

                bool check = ToolkitService.EqualsBytesArray(temporalPass, bddPass);
                if (check) // USUARIO LOGUEADO 
                {
                    return user;
                }
                else // CONTRASEÑA NO VÁLIDA
                {
                    return null;
                }
            }
        }

        public User GetUser(int id)
        {
            return this.context.Users.Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public bool ExistsUser(String email)
        {
            User user = this.context.Users.Where(x => x.Email == email)
                .FirstOrDefault();
            bool exist = (user != null) ? true : false;
            return exist;
        }
        #endregion



        #region APPS
        // USER
        public List<App> GetApps()
        {
            return this.context.Apps.ToList();
        }

        public App GetApp(int id)
        {
            return this.context.Apps.Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<App> GetApps(List<int> ids)
        {
            var query = from data in this.context.Apps
                        where ids.Contains(data.Id)
                        select data;
            return query.ToList();
        }


        // ADMIN
        private int GetMaxIdApps()
        {
            int amount = this.context.Apps.Count();
            if (amount == 0)
            {
                return 0;
            }
            else
            {
                return this.context.Apps.Max(x => x.Id);
            }
        }

        public void PostApp(String name, String exeName, String path, String icon)
        {
            App app = new App();
            app.Id = this.GetMaxIdApps() + 1;
            app.Name = name;
            app.ExeName = exeName;
            app.Path = path;
            app.Icon = icon;

            this.context.Apps.Add(app);
            this.context.SaveChanges();
        }
        
        public void PutApp(int id, String name, String exeName, String path)
        {
            // CONTROLAR SI NO EXISTE LA APP
            App app = this.GetApp(id);
            app.Name = name;
            app.ExeName = exeName;
            app.Path = path;

            this.context.SaveChanges();
        }

        public void PutApp(int id, String name, String exeName, String path, String icon)
        {
            // CONTROLAR SI NO EXISTE LA APP
            App app = this.GetApp(id);
            app.Name = name;
            app.ExeName = exeName;
            app.Path = path;
            app.Icon = icon;

            this.context.SaveChanges();
        }

        public void DeleteApp(int id)
        {
            App app = this.GetApp(id);

            this.context.Apps.Remove(app);
            this.context.SaveChanges();
        }
        #endregion



        #region SCRIPTS
        private int GetMaxIdScripts()
        {
            int amount = this.context.Scripts.Count();
            if (amount == 0)
            {
                return 0;
            }
            else
            {
                return this.context.Scripts.Max(x => x.Id);
            }
        }

        public List<Script> GetScripts(int userId)
        {
            return this.context.Scripts
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public Script GetScript(int id)
        {
            return this.context.Scripts.Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void PostScript(String name, String script, int userId)
        {
            Script s = new Script
            {
                Id = this.GetMaxIdScripts() + 1,
                Name = name,
                Code = script,
                UserId = userId
            };

            this.context.Scripts.Add(s);
            this.context.SaveChanges();
        }

        public void DeleteScript(int id)
        {
            this.context.Scripts.Remove(this.GetScript(id));
            this.context.SaveChanges();
        }
        #endregion
    }
}
