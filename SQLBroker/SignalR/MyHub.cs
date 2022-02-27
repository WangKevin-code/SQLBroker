using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLBroker.Service;
using SQLBroker.Models;
using System.Data.SqlClient;
using System.Threading;

namespace SQLBroker.SignalR
{
    public class MyHub : Hub
    {
        string _connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        public MyHub() 
        {
            Initialization();
        }

        #region SignalR
        public static void TestMessage()
        {
            var db = new DBService();
            var employees = db.GetEmployees();
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.Test(employees);
        }
        #endregion

        #region SqlDependency
        void Initialization()
        {
            //設定好SQL連接字串，開啟
            SqlDependency.Start(_connString);

            //建立SqlDependency OnChangeEventHandler
            SqlDependencyWatch();
        }
        private void SqlDependencyWatch()
        {
            //這邊用的查詢欄位不能式PK，資料表也必須是完整的像dbo.TableName
            string sSQL = "select Name,Email,Department from [dbo].[Employees]";
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = new SqlCommand(sSQL, connection))
                {
                    //command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDependency dependency = new SqlDependency(command);
                    //這間加入監聽事件SQLTableOnChange
                    dependency.OnChange += new OnChangeEventHandler(SQLTableOnChange);
                    SqlDataReader sdr = command.ExecuteReader();
                }
            }
        }
        void SQLTableOnChange(object sender, SqlNotificationEventArgs e)
        {
            //觸發後再開啟一次監聽事件    
            SqlDependencyWatch();
            //執行我自己要執行的邏輯處理
            TestMessage();
        }
        #endregion
    }
}