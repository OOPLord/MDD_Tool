using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTransformer
{
    public class MethodTemplate
    {
        public MethodTemplate(
            string name,
            string returnType,
            AccessModifierType accessModifier = AccessModifierType.Public)
        {
            Name = name;
            ReturnType = returnType;
            AccessModifier = accessModifier;

            Parameters = new List<ParameterTemplate>();
        }

        public AccessModifierType AccessModifier { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public IList<ParameterTemplate> Parameters { get; set; }

        public override string ToString()
        {
            StringBuilder methodBuilder = new StringBuilder();

            methodBuilder.Append(@$"{AccessModifier} {ReturnType} {Name} (");

            for (int i = 0; i < Parameters.Count; i++)
            {
                if (i != 0)
                {
                    methodBuilder.Append(", ");
                }

                methodBuilder.Append(@$"{Parameters[i]}");
            }

            methodBuilder.Append(@$")\n{{ // Method implementation }}");

            return methodBuilder.ToString();
        }
    }
}
