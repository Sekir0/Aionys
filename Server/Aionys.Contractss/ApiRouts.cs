using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.Contractss
{
    /// <summary>
    /// routing
    /// </summary>
    public static class ApiRouts
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        /// <summary>
        /// routs for notes controller
        /// </summary>
        public static class Notes
        {
            public const string GetAll = Base + "/notes";
            public const string GetById = Base + "/notes/{noteId}";
            public const string Create = Base + "/notes";
            public const string Update = Base + "/notes/{noteId}";
            public const string Delete = Base + "/notes/{noteId}";
        }
    }
}
