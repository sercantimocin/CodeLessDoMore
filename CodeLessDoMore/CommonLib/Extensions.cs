using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    using Newtonsoft.Json;

    public static class Extensions
    {
        /// <summary>
        /// The to json.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToJson(this object obj)
        {

            return JsonConvert.SerializeObject(obj);
        }
    }
}
