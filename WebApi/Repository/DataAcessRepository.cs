using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public class DataAcessRepository : IDataAcessRepository
    {
        private readonly IConfiguration Configuration; 

        public DataAcessRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public List<Person> ReadInfo()
        {
            List<Person> obj = new List<Person>(); 
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Configuration.GetConnectionString("DefaultConnection").ToString();
                conn.Open();
                // use the connection here  
                SqlCommand command = new SqlCommand("SELECT * FROM Person", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   
                    while (reader.Read())
                    {
                        obj.Add(new Person()
                        {
                            FirstName = reader[0].ToString(),
                            LastName = reader[1].ToString(),
                            Id = Convert.ToInt32(reader[2])
                        }) ;
                    }
                }
                return obj;
            }
        }
    }
}
