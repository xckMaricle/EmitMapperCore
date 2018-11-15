using System;

namespace EmitMapperCore.AST.Interfaces
{
    interface IAstStackItem: IAstNode
    {
        Type itemType { get; }
    }
}