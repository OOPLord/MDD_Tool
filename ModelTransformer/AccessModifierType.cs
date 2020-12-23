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
        Internal = 4,
    }

    public static class ParserHelper
    {
        public static string ToCorrectString(this AccessModifierType accessModifier)
        {
            switch (accessModifier)
            {
                case AccessModifierType.Default:
                    return "default";

                case AccessModifierType.Public:
                    return "public";

                case AccessModifierType.Private:
                    return "private";

                case AccessModifierType.Protected:
                    return "protected";

                case AccessModifierType.Internal:
                    return "internal";

                default:
                    throw new ArgumentException("Access modifier type is unknown.");
            }
        }
    }
}
