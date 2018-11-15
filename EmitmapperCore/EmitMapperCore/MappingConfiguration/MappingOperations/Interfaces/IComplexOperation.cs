using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmitMapperCore.MappingConfiguration.MappingOperations
{
    interface IComplexOperation: IMappingOperation
    {
        List<IMappingOperation> Operations { get; set; }
    }
}
