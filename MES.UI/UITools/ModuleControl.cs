using System;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using LanyunMES.Entity;

	public class ModuleControl
	{
        /// <summary>
        /// ���dllģ���Ƿ���ص�������
        /// </summary>
        /// <param name="moduleItem">ģ����Ϣ����</param>
        /// <param name="type"></param>
        /// <param name="objValues"></param>
        /// <returns></returns>
		public static bool GetModuleInfo(ModuleItem moduleItem, ref Type type, out object[] objValues)
		{
			Assembly[] assemblys = AppDomain.CurrentDomain.GetAssemblies();

			bool bAssemblyExist = false;
			AssemblyName assemblyName = null;
			Assembly assembly = null;
			foreach(Assembly iAssembly in assemblys)
			{
				assemblyName = iAssembly.GetName();
				if(assemblyName.Name.ToUpper() == moduleItem.FileName.ToUpper())
				{
					bAssemblyExist = true; assembly = iAssembly; break;
				}
			}

			try
			{
				if(!bAssemblyExist && moduleItem.FileType.ToLower() == "dll".ToLower())
					assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + moduleItem.FileName + ".dll");

				if(assembly != null)
				{
					type = assembly.GetType(moduleItem.ClassFullName);
					string strParams = moduleItem.Params;
					if(strParams != null && strParams.Length > 0)
					{
						char[] chrAryDelimiter = ",.;:".ToCharArray();
						string[] strValues = strParams.Split(chrAryDelimiter);
						objValues = strValues;
					}
					else
					{
						objValues = null;
					}

					return true;
				}
				else
				{
					objValues = null;
					return false;
				}
			}
			catch(Exception Exp)
			{
				throw new Exception("��" + moduleItem.ModuleName + "��ģ����س���\n" + Exp.Message);
			}
		}
	}
}