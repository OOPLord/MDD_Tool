using ModelTransformer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDD_Tool.Models
{
    public static class UmlHelper
    {
        public static string ParseView(string pseudoCode)
        {
            return UmlParser.Parse(pseudoCode);
        }
    }
}
