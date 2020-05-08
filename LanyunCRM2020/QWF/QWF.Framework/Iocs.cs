using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework
{
    public class Iocs
    {
        //private IUnityContainer container;
        private static Iocs ioc = new Iocs();
        private Iocs()
        {

        }
        public static Iocs GetInstance()
        {
            return ioc;

        }

        /// <summary>
        /// 解析创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return Resolve<T>(null);
        }

        /// <summary>
        /// 解析创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Resolve<T>(string name)
        {
            //默认的配置文件获取
            IUnityContainer container = LoadUnityConfig();

            if (container.IsRegistered<T>())
            {
                if (string.IsNullOrEmpty(name))
                {
                    return container.Resolve<T>();
                }

                return container.Resolve<T>(name);

            }
            return default(T);
        }

        private IUnityContainer LoadUnityConfig()
        {
            ////根据文件名获取指定config文件
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\Config\qwf.ioc.config";
            if (!System.IO.File.Exists(filePath))
                throw new QWF.Framework.GlobalException.UIValidateException("ioc.config配置文件路径错误!");

            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };

            //从config文件中读取配置信息
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            var container = new UnityContainer();

            unitySection.Configure(container, "iocset");

            return container;
        }
    }
}
