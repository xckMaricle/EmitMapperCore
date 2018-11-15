using System;
using System.Collections.Generic;
using System.Text;
using EmitMapperCore.AST;
using EmitMapperCore.AST.Helpers;
using EmitMapperCore.AST.Interfaces;
using EmitMapperCore.AST.Nodes;
using EmitMapperCore.Mappers;
using EmitMapperCore.Utils;
using System.Reflection.Emit;
using System.Reflection;
using EmitMapperCore.MappingConfiguration.MappingOperations;

namespace EmitMapperCore
{
    class CreateTargetInstanceBuilder
    {
		public static void BuildCreateTargetInstanceMethod(Type type, TypeBuilder typeBuilder)
		{
			if (ReflectionUtils.IsNullable(type))
			{
				type = Nullable.GetUnderlyingType(type);
			}

			MethodBuilder methodBuilder = typeBuilder.DefineMethod(
				"CreateTargetInstance",
				MethodAttributes.Public | MethodAttributes.Virtual,
				typeof(object),
				null
				);

			ILGenerator ilGen = methodBuilder.GetILGenerator();
			CompilationContext context = new CompilationContext(ilGen);
			IAstRefOrValue returnValue;

			if (type.IsValueType)
			{
				LocalBuilder lb = ilGen.DeclareLocal(type);
				new AstInitializeLocalVariable(lb).Compile(context);

				returnValue =
					new AstBox()
					{
						value = AstBuildHelper.ReadLocalRV(lb)
					};
			}
			else
			{
				returnValue =
					ReflectionUtils.HasDefaultConstructor(type)
						?
							new AstNewObject()
							{
								objectType = type
							}
						:
							(IAstRefOrValue)new AstConstantNull();
			}
			new AstReturn()
			{
				returnType = type,
				returnValue = returnValue
			}.Compile(context);
		}
    }
}