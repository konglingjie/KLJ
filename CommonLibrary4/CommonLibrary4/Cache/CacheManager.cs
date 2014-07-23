﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary4.Cache.Configuration;

namespace CommonLibrary4.Cache
{
    /// <summary>
    /// 缓存
    /// </summary>
    public static class CacheManager
    {
        private static readonly ConcurrentDictionary<string, ICache> cachers;

        static CacheManager()
        {
            cachers = new ConcurrentDictionary<string, ICache>();
        }

        /// <summary>
        /// 添加缓存对象
        /// </summary>
        /// <param name="regionName"></param>
        /// <param name="cache"></param>
        /// <returns>返回true表示添加成功，false则表示<paramref name="regionName"/>已经有对应的缓存对象，不能再次添加。</returns>
        public static bool AddCache(string regionName, ICache cache)
        {
            return cachers.TryAdd(regionName, cache);
        }

        /// <summary>
        /// 移除绑在对象
        /// </summary>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static bool RemoveCache(string regionName)
        {
            ICache cache;
            return cachers.TryRemove(regionName, out cache);
        }

        private static ICache CreateCache(string regionName)
        {
            Type type;
            string conn;
            CacheSettings.Settings.GetCache(regionName, out type, out conn);
            if (string.IsNullOrEmpty(conn))
                return (ICache)Activator.CreateInstance(type, new object[] { regionName });
            else
                return (ICache)Activator.CreateInstance(type, new object[] { regionName, conn });
        }

        /// <summary>
        /// 获取默认的缓存对象
        /// </summary>
        /// <returns></returns>
        public static ICache GetCache()
        {
            return GetCache(CacheSettings.Settings.DefaultRegionName);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ICache GetCache(string regionName)
        {
            return cachers.GetOrAdd(regionName, x => CreateCache(x));
        }

        /// <summary>
        /// 验证缓存<paramref name="key"/>是否存在。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            return GetCache().Contains(key);
        }
        /// <summary>
        /// 验证缓存<paramref name="key"/>是否存在。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static bool Contains(string key, string regionName)
        {
            return GetCache(regionName).Contains(key);
        }
        /// <summary>
        /// 获取指定<paramref name="key"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return GetCache().Get(key);
        }
        /// <summary>
        /// 获取指定<paramref name="key"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static object Get(string key, string regionName)
        {
            return GetCache().Get(key);
        }
        /// <summary>
        /// 获取指定<paramref name="key"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return GetCache().Get<T>(key);
        }
        /// <summary>
        /// 获取指定<paramref name="key"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static T Get<T>(string key, string regionName)
        {
            return GetCache(regionName).Get<T>(key);
        }
        /// <summary>
        /// 获取一组指定<paramref name="keys"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Get(string[] keys)
        {
            return GetCache().Get(keys);
        }
        /// <summary>
        /// 获取一组指定<paramref name="keys"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Get(string[] keys, string regionName)
        {
            return GetCache(regionName).Get(keys);
        }
        /// <summary>
        /// 获取一组指定<paramref name="keys"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Get(IEnumerable<string> keys)
        {
            return GetCache().Get(keys);
        }
        /// <summary>
        /// 获取一组指定<paramref name="keys"/>的缓存对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static IDictionary<string, object> Get(IEnumerable<string> keys, string regionName)
        {
            return GetCache(regionName).Get(keys);
        }
        /// <summary>
        /// 设置一个缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(string key, T value)
        {
            GetCache().Set(key, value);
        }
        /// <summary>
        /// 设置一个缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="regionName"></param>
        public static void Set<T>(string key, T value, string regionName)
        {
            GetCache(regionName).Set(key, value);
        }
        /// <summary>
        /// 设置一个缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireAt">对象绝对过期时间</param>
        public static void Set<T>(string key, T value, DateTime expireAt)
        {
            GetCache().Set(key, value, expireAt);
        }
        /// <summary>
        /// 设置一个缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireAt">对象绝对过期时间</param>
        public static void Set<T>(string key, T value, DateTime expireAt, string regionName)
        {
            GetCache(regionName).Set(key, value, expireAt);
        }
    }
}
