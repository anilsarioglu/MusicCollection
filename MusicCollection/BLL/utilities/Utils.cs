using System.Collections.Generic;
using System.Linq;

namespace BLL.utilities
{
    public static class Utils
    {
        public static bool IsAny<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}
