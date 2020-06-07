namespace Mental.Health.Adapter
{
    public static class ChoiceTranslator
    {
        public static Option ToOption(this Choice choice)
        {
            return choice == null
                ? null
                : new Option()
                {
                    Name = choice.Option,
                    Number = choice.Number
                };
        }
    }
}
