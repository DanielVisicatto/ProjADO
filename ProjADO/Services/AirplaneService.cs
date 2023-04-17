using ProjADO.Model;
using ProjADO.Models;
using System.Data.SqlClient;
using System.Text;

namespace ProjADO.Services
{
    public class AirplaneService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true; AttachDbFileName=C:\Banco\fly.mdf;";
        readonly SqlConnection conn;

        public AirplaneService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Airplane airplane)
        {
            bool status = false;
            try
            {
                string strInsert = "INSERT INTO Airplane " +
                                        "(      Name" +
                                        "       ,NumbOfPassengers" +
                                        "       ,Description" +
                                        "       ,IdEngine) " +
                                        "       VALUES " +
                                        "(      @Name" +
                                        "       ,@NumbOfPassengers" +
                                        "       ,@Description" +
                                        "       ,@IdEngine)";


                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", airplane.Name));
                commandInsert.Parameters.Add(new SqlParameter("@NumbOfPassengers", airplane.NumbOfPassengers));
                commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Descripition));
                //commandInsert.Parameters.Add(new SqlParameter("@IdEngine", airplane.Engine.Id));
                commandInsert.Parameters.Add(new SqlParameter("@IdEngine", InsertEngine(airplane)));

                commandInsert.ExecuteNonQuery();
                status = true;                
            }
            catch (Exception e)
            {
                status = false;
                throw new (e.Message);
            }
            finally
            {
                conn.Close();
            }
            return status;
            
        }

        private int InsertEngine(Airplane airplane)
        {
            string strInsert = "INSERT INTO [Engine]" +
                               "(         Description)" +
                               "          VALUES " +
                               "(         @Description);" +
                               "          SELECT CAST(scope_identity() as int)";
            
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("Description", airplane.Engine.Description));

            return (int)commandInsert.ExecuteScalar(); // server para executa mais de um comando Sql de uma vez
        }

        public List<Airplane> FindAll()
        {
            List<Airplane> airplanes = new();

            StringBuilder sb = new();
            sb.Append("SELECT a.Id ");
            sb.Append("       ,a.Name");
            sb.Append("       ,a.NumbOfPassengers");
            sb.Append("       ,a.Description ");
            sb.Append("       ,e.Description Engine");
            sb.Append("       From [Airplane] a, ");
            sb.Append("       [Engine] e");
            sb.Append("       Where a.IdEngine = e.Id");

            //SELECT a.Id, a.Name, a.Description, a.NumbOfPassengers, e.Description Engine FROM[Airplane] a, [Engine] e where a.IdEngine = e.Id

            SqlCommand commandSelect = new (sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Airplane airplane = new ();

                airplane.Id =                   (int)       dr["Id"];
                airplane.Name =                 (string)    dr["Name"];
                airplane.NumbOfPassengers =     (int)       dr["NumbOfPassengers"];
                airplane.Descripition =         (string)    dr["Description"];
                airplane.Engine = new Engine() { Description = (string)dr["Engine"] };

                airplanes.Add(airplane);
            }
            return airplanes;
            
        }        
    }
}
