using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLBroker.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace SQLBroker.Service
{
    public class DBService
    {
        string _connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public List<Employees> GetEmployees() 
        {
            using (var conn = new SqlConnection(_connString))
            {
                var result = conn.Query<Employees>("SELECT * FROM Employees").ToList();
                return result;
            }
            
        }
    }
}