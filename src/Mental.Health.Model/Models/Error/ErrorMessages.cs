using Mental.Health.Model.Models.Error;

namespace Mental.Health
{
    public static partial class ErrorMessages
    {
        public static string InvalidField(string value)
        {
            return string.Format(FaultMessages.InvalidField, value);
        }
        public static string MissingField(string value)
        {
            return string.Format(FaultMessages.MissingField, value);
        }
    }
}
