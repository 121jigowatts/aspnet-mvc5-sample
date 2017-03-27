using aspnet_mvc5_sample.Data;
using aspnet_mvc5_sample.Framework;
using aspnet_mvc5_sample.Migrations;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace aspnet_mvc5_sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        // キャッシュラッパーオブジェクトへの内部参照
        private static ICacheService _internalCacheObject;

        public static void RegisterCacheService(ICacheService cacheService)
        {
            _internalCacheObject = cacheService;
        }

        // コントローラーメソッドからキャッシュオブジェクトにアクセスするためのプロパティ
        // Cacheオブジェクトの代わり
        public static ICacheService CacheService
        {
            get { return _internalCacheObject; }
        }

        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
            logger.Trace("Application Start");
            // グローバルキャッシュサービスの注入
            RegisterCacheService(new AspNetCacheService());

            // アプリケーションスコープのデータをキャッシュ
            CacheService["StartTime"] = DateTime.Now;
            logger.Trace($"Start Time : {CacheService["StartTime"]}");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            var id = "testId";
            var role = new RoleManager(id);
            Session["role"] = role;
            var menu = role.GetMenu();
            Session["menu"] = menu;
        }
    }
}
