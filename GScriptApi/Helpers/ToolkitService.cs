using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GScriptApi.Helpers
{
    public class ToolkitService
    {
        #region JSON
        public static String SerializeJsonObject(object obj)
        {
            String result = JsonConvert.SerializeObject(obj);
            return result;
        }

        public static T DeserializeJsonObject<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion


        #region BYTES
        public static bool EqualsBytesArray(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion


        #region ROUTE
        public static RedirectToRouteResult GetRoute(String action, String controller)
        {
            RouteValueDictionary route = new RouteValueDictionary(
                new
                {
                    action = action,
                    controller = controller
                });
            //RedirectToRouteResult result = new RedirectToRouteResult(ruta);
            //return result;
            return new RedirectToRouteResult(route);
        }
        #endregion

    }
}
