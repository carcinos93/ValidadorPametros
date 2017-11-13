using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;
namespace ValidadorPametros.Validators
{
    public class Logger
    {
        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            PatternLayout layout = new PatternLayout();
            AdoNetAppender roller = new AdoNetAppender();
            roller.BufferSize = 1;
            roller.CommandText = "";
            roller.CommandType = System.Data.CommandType.StoredProcedure;
            roller.ConnectionString = "";
            hierarchy.Root.AddAppender(roller);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
            
        }
    }
}
