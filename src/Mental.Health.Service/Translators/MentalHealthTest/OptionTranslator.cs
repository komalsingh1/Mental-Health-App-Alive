namespace Mental.Health.Service
{
    public static class OptionTranslator
    {
        public static Option ToOptionContract(this Health.Option option)
        {
            return option == null
                ? null
                : new Option()
                {
                    Number = option.Number,
                    Name = option.Name
                };
        }
    }
}
