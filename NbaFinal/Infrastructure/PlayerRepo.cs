﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NbaFinal.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace NbaFinal.Infrastructure
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly ConnectionStrings _connectionStrings;
        public PlayerRepo(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }
        public IEnumerable<Player> GetAll()
        {
            List<Player> playersList = new List<Player>();
            using (SqlConnection connection = new SqlConnection(_connectionStrings.DefaultConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Players", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Player p = new Player();
                            p.PlayerID = reader["PlayerId"].ToString();
                            p.PlayerName = reader["PlayerName"].ToString();
                            p.AssistsPerGame = decimal.Parse(reader["AssistsPerGame"].ToString());
                            p.BlocksPerGame = decimal.Parse(reader["BlocksPerGame"].ToString());
                            p.EffMin = decimal.Parse(reader["EffMin"].ToString());
                            p.EffPerGame = decimal.Parse(reader["EffPerGame"].ToString());
                            p.FieldsGoalPercentage = decimal.Parse(reader["FieldsGoalPercentage"].ToString());
                            p.FreeThrowsPercentage = decimal.Parse(reader["FreeThrowsPercentage"].ToString());
                            p.GamesPlayed = Int32.Parse(reader["GamesPlayed"].ToString());
                            p.MinsPerGame = decimal.Parse(reader["MinsPerGame"].ToString());
                            p.PointsPerGame = decimal.Parse(reader["PointsPerGame"].ToString());
                            p.ReboundsPerGame = decimal.Parse(reader["ReboundsPerGame"].ToString());
                            p.StealsPerGame = decimal.Parse(reader["StealsPerGame"].ToString());
                            p.ThreePointsPercentage = decimal.Parse(reader["ThreePointsPercentage"].ToString());
                            p.TurnoversPerGame = decimal.Parse(reader["TurnoversPerGame"].ToString());
                            playersList.Add(p);
                        }
                    }
                }
            }
            return playersList;
        }
    }
}
