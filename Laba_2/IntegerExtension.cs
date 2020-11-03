namespace Laba_2
{
    public static class IntegerExtension
    {
        public static bool IsEven(this int number)
        {
            return (number % 2 == 0);
        }

        public static bool IsUnitNumber(this int number)
        {
            return (number % 1 == 0);
        }
    }
}
