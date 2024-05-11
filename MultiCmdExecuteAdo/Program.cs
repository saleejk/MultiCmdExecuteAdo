using Microsoft.Data.SqlClient;
using System.Data;

class Program
{
    public static void Main(string[] args)
    {
        Program program=new Program();
        program.MultiCommandExecuteWithParameter("student", "teacher");
        program.MultiCommandExecute();
    }
    public void MultiCommandExecuteWithParameter(string table1,string table2)
    {
        string connectionString= "data source= SALEEJK; database= master;integrated security=SSPI;TrustServerCertificate=True";
        using(SqlConnection connection=new SqlConnection(connectionString))
        {
            if (connection.State == ConnectionState.Closed)
            
                connection.Open();
            SqlCommand command = new SqlCommand($"select * from {table1};select * from {table2}", connection);
                
                    //command.Parameters.AddWithValue("table1", table1);
                    //command.Parameters.AddWithValue("table2", table2);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[1]);
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
    }
    public void MultiCommandExecute()
    {
        string connectionString = "data source= SALEEJK; database= master;integrated security=SSPI;TrustServerCertificate=True";
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlCommand command = new SqlCommand("select * from student; select * from teacher", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
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
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Sql exception is occured", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wxception is occured", ex);

        }
    }
}