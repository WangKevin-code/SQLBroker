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
        //public DBService() 
        //{
        //    Initialization();
        //}
        public List<Employees> GetEmployees() 
        {
            using (var conn = new SqlConnection(_connString))
            {
                var result = conn.Query<Employees>("SELECT * FROM Employees").ToList();
                return result;
            }
            
        }

        //void Initialization()
        //{
        //    //設定好SQL連接字串，開啟
        //    SqlDependency.Start(_connString);

        //    //建立SqlDependency OnChangeEventHandler
        //    SqlDependencyWatch();

        //    //先刷新一次
        //    RefreshTable();
        //}
        //private void SqlDependencyWatch()
        //{
        //    //這邊用的查詢欄位不能式PK，資料表也必須是完整的像dbo.TableName
        //    string sSQL = "select Name,Email,Department from [dbo].[Employees]";
        //    using (SqlConnection connection = new SqlConnection(_connString))
        //    {
        //        using (SqlCommand command = new SqlCommand(sSQL, connection))
        //        {
        //            //command.CommandType = CommandType.Text;
        //            connection.Open();
        //            SqlDependency dependency = new SqlDependency(command);
        //            //這間加入監聽事件SQLTableOnChange
        //            dependency.OnChange += new OnChangeEventHandler(SQLTableOnChange);
        //            SqlDataReader sdr = command.ExecuteReader();
        //        }
        //    }
        //}
        //void SQLTableOnChange(object sender, SqlNotificationEventArgs e)
        //{
        //    //觸發後再開啟一次監聽事件    
        //    SqlDependencyWatch();
        //    //執行我自己要執行的邏輯處理
        //    RefreshTable();
        //}
        //private void RefreshTable()
        //{
            
        //}
    }
}