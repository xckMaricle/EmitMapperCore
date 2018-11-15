using EmitMapperCore.AST.Interfaces;
using System.Reflection.Emit;

namespace EmitMapperCore.AST.Nodes
{
    class AstReturnVoid:IAstNode
    {
        #region IAstNode Members

        public void Compile(CompilationContext context)
        {
            context.Emit(OpCodes.Ret);
        }

        #endregion
    }
}