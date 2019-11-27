using System;

namespace CompanyNameGenerator
{
    /// <summary>
    /// Design-by-contract utilities.
    /// </summary>
    public class Dbc
    {
        public static void Precondition(bool condition)
        {
            if (!condition)
            {
                throw new Exception("Failed precondition.");
            }
        }
        public static void Invariant(bool condition)
        {
            if (!condition)
            {
                throw new Exception("Failed invariant.");
            }
        }
        public static void Postcondition(bool condition)
        {
            if (!condition)
            {
                throw new Exception("Failed postcondition.");
            }
        }
    }
}
