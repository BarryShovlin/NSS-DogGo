using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public class WalkRepository : IWalkRepository
    {

        private readonly IConfiguration _config;
        public WalkRepository(IConfiguration config)
        { 
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walk> GetAllWalks()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Select w.Id, w.Duration, w.Date, w.WalkerId, w.DogId, o.Name AS OwnerName
                        FROM Walks w LEFT JOIN Dog d ON w.DogId = d.Id LEFT JOIN Owner o ON d.ownerId = o.Id
                ";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Walk> walks = new List<Walk>();
                    while (reader.Read())
                    {
                        Walk walk = new Walk
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            OwnerName = reader.GetString(reader.GetOrdinal("OwnerName"))
                        };
                        walks.Add(walk);
                    }
                    reader.Close();

                    return walks;
                }
            }
        }
    }
}