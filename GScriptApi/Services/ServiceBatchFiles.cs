using GScriptNuget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GScriptApi.Services
{
    public class ServiceBatchFiles
    {
        public String CreateExe(String instructions)
        {
            String result = $"@echo off {Environment.NewLine}";
            result += $"{instructions}exit";

            return result;
        }

        public String CreateExeWithConsole(String instructions, String dir)
        {
            String result = $"@echo off {Environment.NewLine}"
                + $"title GScript {Environment.NewLine}"
                + $"color 9F {Environment.NewLine}";

            result += instructions;
            if (dir != null)
            {
                result += $"cd \"{dir}\" {Environment.NewLine}";

            }
            result += $"cmd {Environment.NewLine}";

            return result;
        }

        public String OpenApp(App app)
        {
            return $"start \"{app.ExeName}\" \"{app.Path}\" {Environment.NewLine}";
        }

        public String Shut(String operation, int time, String msg)
        {
            String result = "shutdown ";

            // EXTRAS
            if (msg != null)
            {
                result += $"-c \"{msg}\" ";
            }
            if (time != 0)
            {
                result += $"-t {time} ";
            }

            // OPERATIONS
            if (operation == "shut")
            {
                result += "-s";
            }
            else if (operation == "reboot")
            {
                result += "-r";
            }
            else if (operation == "hibern")
            {
                result += "-h";
            }
            else if (operation == "session")
            {
                result += "-l";
            }
            else if (operation == "abort")
            {
                result += "-a";
            }
            result += $" {Environment.NewLine}";

            return result;
        }
    }
}
