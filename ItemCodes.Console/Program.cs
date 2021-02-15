using System;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace ItemCodes.Console
{
    class Program
    {
        private const string ConnectionString = "DATA SOURCE=oracledev.nra.co.za:1527/itisdev;PERSIST SECURITY INFO=True;USER ID=ITIS_web;PASSWORD=iweb123;Connection Timeout=60;";

        static void Main(string[] args)
        {
            DoMasterList();
        }

        static void DoMasterList()
        {
            var lines = File.ReadAllLines("ItemCodes.txt");
            foreach (var line in lines)
            {
                System.Console.Write($"{line}, ");
                BoqItemCode itemCode;
                try
                {
                    itemCode = BoqItemCode.Parse(line);
                    System.Console.WriteLine(itemCode.StringValue);
                }
                catch (ArgumentException ax)
                {
                    System.Console.WriteLine($"Invalid item code: {ax.Message}");
                }
            }
        }

        static void DoSqlSample()
        {
            var sql = @"select ITEM_CODE
                from ITIS_PRJ.PRJ_PROJECT_ITEM pi
                left join ITIS_PRJ.PRJ_CONTRACT_ITEM ci on pi.CONTRACT_ITEM_ID = ci.CONTRACT_ITEM_ID"
                      //+ " where pi.PROJECT_ID = '481AE79FFF2747B983E8F1576C8C4FDD'";
                      + " where pi.PROJECT_ID = :projectId";

            using var conn = new OracleConnection(ConnectionString);
            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new OracleParameter("projectId", "481AE79FFF2747B983E8F1576C8C4FDD"));
                conn.Open();

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var raw = dr["ITEM_CODE"].ToString();
                    System.Console.Write($"{raw}, ");
                    BoqItemCode itemCode;
                    try
                    {
                        itemCode = BoqItemCode.Parse(raw);
                        System.Console.WriteLine(itemCode.StringValue);
                    }
                    catch (ArgumentException ax)
                    {
                        System.Console.WriteLine($"Invalid item code: {ax.Message}");
                    }
                }
            }
        }
    }
}
