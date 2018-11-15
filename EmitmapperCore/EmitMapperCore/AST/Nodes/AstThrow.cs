using EmitMapperCore.AST.Interfaces;
using System.Reflection.Emit;

namespace EmitMapperCore.AST.Nodes
{
    class AstThrow: IAstNode
    {
        public IAstRef exception;

        public void Compile(CompilationContext context)
        {
            exception.Compile(context);
            context.Emit(OpCodes.Throw);
        }
    }
}