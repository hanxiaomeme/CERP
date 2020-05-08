using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QWF.Framework.Common
{
    /// <summary>
    /// 简单缓存处理类
    /// </summary>
    public class EasyCacheHelper
    {
         /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="Timeout"> 单位分钟</param>
        public static void SetCache(string cacheKey, object obj, int Timeout)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(cacheKey, obj, null, DateTime.Now.AddMinutes(Timeout), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
        }

        /// <summary>
        /// 移除指定缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        public static void RemoveAllCache(string cacheKey)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }

        /// <summary>
        ///  移除全部缓存 
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
    
}
