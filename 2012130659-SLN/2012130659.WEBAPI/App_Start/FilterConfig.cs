﻿using System.Web;
using System.Web.Mvc;

namespace _2012130659.WEBAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
