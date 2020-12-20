using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTransformer
{
    public enum AccessModifierType
    {
        Default = 0,
        Public = 1,
        Private = 2,
        Protected = 3,
    }

    public static class ParserHelper
    {
        public static string ToCorrectString(this AccessModifierType accessModifier)
        {
            switch (accessModifier)
            {
                case AccessModifierType.Default:
                    return "default";

                    break;
                case AccessModifierType.Public:
                    return "public";

                    break;
                case AccessModifierType.Private:
                    return "private";

                    break;
                case AccessModifierType.Protected:
                    return "protected";

                    break;
                default:
                    throw new ArgumentException("Access modifier type is unknown.");
            }
        }
    }
}
