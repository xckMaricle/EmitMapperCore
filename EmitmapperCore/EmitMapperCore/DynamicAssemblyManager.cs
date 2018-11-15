using System;
using System.Reflection.Emit;
using System.Reflection;
using EmitMapperCore.Mappers;

namespace EmitMapperCore
{
	/// <summary>
	/// Class which maintains an assembly for created object Mappers
	/// </summary>
	public class DynamicAssemblyManager
	{


		#region Non-public members

		private static AssemblyName assemblyName;
		private static AssemblyBuilder assemblyBuilder;
		private static ModuleBuilder moduleBuilder;

		static DynamicAssemblyManager()
		{
            assemblyName = new AssemblyName("EmitMapperCoreAssembly");
            assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
        }

		private static string CorrectTypeName(string typeName)
		{
			if (typeName.Length >= 1042)
			{
				typeName = "type_" + typeName.Substring(0, 900) + Guid.NewGuid().ToString().Replace("-", "");
			}
			return typeName;
		}

		internal static TypeBuilder DefineMapperType(string typeName)
		{
			lock (typeof(DynamicAssemblyManager))
			{
				return moduleBuilder.DefineType(
					CorrectTypeName(typeName + Guid.NewGuid().ToString().Replace("-", "")),
					TypeAttributes.Public,
					typeof(MapperForClassImpl),
					null
					);
			}
		}

		internal static TypeBuilder DefineType(string typeName, Type parent)
		{
			lock (typeof(DynamicAssemblyManager))
			{
				return moduleBuilder.DefineType(
					CorrectTypeName(typeName),
					TypeAttributes.Public,
					parent,
					null
					);
			}
		}
		#endregion
	}
}