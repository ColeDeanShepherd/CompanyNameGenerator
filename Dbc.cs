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
    }
}
