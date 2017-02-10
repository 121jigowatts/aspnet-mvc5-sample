using aspnet_mvc5_sample.Framework;
using System;
using System.Collections.Generic;
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
        // キャッシュラッパーオブジェクトへの内部参照
        private static ICacheService _internalCacheObject;

        public  static void RegisterCacheService(ICacheService cacheService)
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
            // グローバルキャッシュサービスの注入
            RegisterCacheService(new AspNetCacheService());

            // アプリケーションスコープのデータをキャッシュ
            CacheService["StartTime"] = DateTime.Now;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
