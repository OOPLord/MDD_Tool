using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTransformer
{
    public class ClassTemplate
    {
        public ClassTemplate(
            string name,
            AccessModifierType accessModifier = AccessModifierType.Public)
        {
            Name = name;
            AccessModifier = accessModifier;

            References = new List<string>();
            Properties = new List<PropertyTemplate>();
            Methods = new List<MethodTemplate>();
        }

        public IList<string> References { get; set; }
        public AccessModifierType AccessModifier { get; set; }
        public string Name { get; set; }
        public IList<PropertyTemplate> Properties { get; set; }
        public IList<MethodTemplate> Methods { get; set; }

        public override string ToString()
        {
            StringBuilder classBuilder = new StringBuilder();

            // adding references to namespace
            foreach (var refereces in References)
            {
                classBuilder.AppendLine($"using {refereces};");
            }

            // adding namespace
            classBuilder.AppendLine();
            //classBuilder.AppendLine($"namespace {Namespace}\n{{");

            // creating class
            classBuilder.AppendLine($"\t{AccessModifier.ToCorrectString()} class {Name}\n\t{{");

            // adding properties to class
            foreach (var property in Properties)
            {
                classBuilder.AppendLine("\t\t" + property.ToString());
            }

            // adding methods to class
            foreach (var method in Methods)
            {
                classBuilder.AppendLine("\t\t" + method.ToString());
            }

            // end of class
            classBuilder.AppendLine($"\t}}");

            // end of namespace
            //classBuilder.AppendLine($"}}");

            return classBuilder.ToString();
        }
    }
}
