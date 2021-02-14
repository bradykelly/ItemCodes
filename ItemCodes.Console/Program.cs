using System;
using Oracle.ManagedDataAccess.Client;

namespace ItemCodes.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new OracleConnection())
            {
                using (var cmd = new OracleCommand("", conn))
                {
                    
                }
            }
        }
    }
}
