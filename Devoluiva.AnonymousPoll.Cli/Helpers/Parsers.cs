using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoluiva.AnonymousPoll.Cli.Helpers
{
    public static class Parsers
    {
        public static int ParseInteger(string value)
        {
            return int.TryParse(value, out int result)
                ? result
                : throw new Exception("Error parsing integer");
        }
    }
}
