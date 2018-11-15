using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using EmitMapperCore.AST.Interfaces;

namespace EmitMapperCore.AST.Nodes
{
    class AstBox : IAstRef
    {
        public IAstRefOrValue value;

        #region IAstReturnValueNode Members

        public Type itemType
        {
            get 
            {
                return value.itemType;  
            }
        }

        #endregion

        #region IAstNode Members

        public void Compile(CompilationContext context)
        {
            value.Compile(context);

            if (value.itemType.IsValueType)
            {
                context.Emit(OpCodes.Box, itemType);
            }
        }

        #endregion
    }
}