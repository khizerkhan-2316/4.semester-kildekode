﻿using System.Web;
using System.Web.Mvc;

namespace Lesson02_Startup {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}