using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTransformer
{
    public class ParameterTemplate
    {
        public ParameterTemplate(
           string name,
           string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }

        public override string ToString()
        {
            return @$"{Type} {Name}";
        }
    }
}
