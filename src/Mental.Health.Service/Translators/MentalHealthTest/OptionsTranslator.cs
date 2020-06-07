using System.Collections.Generic;
using System.Linq;

namespace Mental.Health.Service
{
    public static class OptionsTranslator
    {
        public static List<Option> ToOptionsContract(this List<Health.Option> options)
        {
            return options == null
                ? null
                : options?.Select(option => option.ToOptionContract()).ToList();
        }
    }
}
