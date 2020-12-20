using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTransformer
{
    public class PropertyTemplate
    {
        public PropertyTemplate(
            string name,
            string type,
            AccessModifierType accessor = AccessModifierType.Public)
        {
            Name = name;
            Type = type;
            AccessModifier = accessor;
        }

        public string Name { get; }
        public string Type { get; }

        public AccessModifierType AccessModifier { get; }

        public override string ToString()
        {
            return @$"{AccessModifier.ToCorrectString()} {Type} {Name} {{ get; set; }}";
        }
    }
}
