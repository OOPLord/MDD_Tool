using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTransformer
{
    public class UmlParser
    {
        public static string Parse(string pseudocode)
        {
            string[] code = pseudocode.Split(new[] { '{', '}' });

            if (!code[0].Contains("classDiagram"))
            {
                throw new ArgumentException("Current UML diagram is not supported!");
            }
            else
            {
                code[0] = code[0].Replace("classDiagram", string.Empty);
            }

            var classes = new List<ClassTemplate>();

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i].Contains("class"))
                {
                    var properties = new List<PropertyTemplate>();
                    var methods = new List<MethodTemplate>();

                    var className = code[i].Trim(' ', '\n', '\r', '\t', '{', '}').Split(' ')[1];
                    var classParts = code[i + 1].Split(new[] { '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < classParts.Length; j++)
                    {
                        string part = classParts[j].Trim();

                        if (part.Contains("("))
                        {
                            // method
                            var methodCode = part.Split(":");

                            var accessor = methodCode[0];
                            var name = methodCode[0].Substring(1, part.IndexOf('(') - 1);
                            string type = "void";
                            if (methodCode.Length == 2)
                            {
                                type = methodCode[1].Trim();
                            }

                            var method = new MethodTemplate(name, type);
                            methods.Add(method);
                        }
                        else
                        {
                            // property
                            if (string.IsNullOrEmpty(part))
                            {
                                continue;
                            }

                            var propertyCode = part.Split(" ");
                            var typeProperty = propertyCode[0];
                            var nameProperty = propertyCode[1];

                            var accessor = typeProperty[0];
                            var typeString = typeProperty.Substring(1);

                            var property = new PropertyTemplate(nameProperty, typeString);
                            properties.Add(property);
                        }
                    }

                    var classObject = new ClassTemplate(className);
                    classObject.Properties = properties;
                    classObject.Methods = methods;

                    classes.Add(classObject);

                    // skip next step
                    i++;
                }
                else if (code[i].Contains("--") || code[i].Contains(".."))
                {
                    // relationships
                }
            }

            StringBuilder namespaceBuilder = new StringBuilder();
            classes.ForEach(item => namespaceBuilder.Append(item.ToString()));

            return namespaceBuilder.ToString();
        }
    }
}
