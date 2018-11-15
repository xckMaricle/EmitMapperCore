using System.Collections.Generic;
using EmitMapperCore.AST.Interfaces;

namespace EmitMapperCore.AST.Nodes
{
    class AstComplexNode: IAstNode
    {
        public List<IAstNode> nodes = new List<IAstNode>();

        public void Compile(CompilationContext context)
        {
            foreach (IAstNode node in nodes)
            {
                if (node != null)
                {
                    node.Compile(context);
                }
            }
        }
    }
}