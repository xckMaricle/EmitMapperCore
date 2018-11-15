using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmitMapperCore.AST.Interfaces;
using System.Reflection.Emit;

namespace EmitMapperCore.AST.Nodes
{
	class AstNewNullable: IAstValue
	{
		private Type _nullableType;
		public Type itemType
		{
			get 
			{
				return _nullableType;
			}
		}
		public void Compile(CompilationContext context)
		{
			throw new NotImplementedException();
		}
	}
}
