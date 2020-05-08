using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    public abstract class Singleton<T>
    {
        private static object syncObject = new object();
        private static T instance;

        /// <summary> 
        /// Entry for access singleton unique value 
        /// </summary> 
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObject)
                    {
                        if (instance == null)
                        {
                            instance = (T)Activator.CreateInstance(typeof(T), true);
                        }
                    }
                }
                return instance;
            }
            set
            {
                lock (syncObject)
                {
                    instance = value;
                }
            }
        }
    }
}
