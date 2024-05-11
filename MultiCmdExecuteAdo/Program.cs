using Microsoft.Data.SqlClient;
using System.Data;

class Program
{
    public static void Main(string[] args)
    {

        string connectionString= "data source= SALEEJK; database= master;integrated security=SSPI;TrustServerCertificate=True";
        try
        {
            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed) 
                    connection.Open();
                using (SqlCommand command = new SqlCommand("select * from student; select * from teacher",connection)){
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine(reader[1] + " " + reader[2]);
                        }
                        while (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[1] + " " + reader[2]);
                            }
                        }
                    }
                }
                {

                }

            }
        }catch (SqlException ex)
        {
            Console.WriteLine("Sql exception is occured",ex);
        }catch (Exception ex)
        {
            Console.WriteLine("Wxception is occured",ex);

        }
    }
}