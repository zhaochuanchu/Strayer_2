using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.SqlClient;


/// <summary>
/// 联网
/// </summary>
public static class ConnectNetWork {



    public static void ConnectMyAzure() {


        //using(声明变量){变量的作用范围 代码块结束后,调用其dispose方法注销对象}
        //这样可以不用等待系统的垃圾回收 一出using生命周期立刻调用析构，释放资源。也就是代码退出后自动关闭连接
        // Got it~
        using (var connection = new SqlConnection(
                   "Server=tcp:zcczcc.database.windows.net,1433;" +
                   "Initial Catalog=ZCC;" +
                   "Persist Security Info=False;" +
                   "User ID=zcc992833886;" +
                   "Password=zc970701.;" +
                   "MultipleActiveResultSets=False;" +
                   "Encrypt=False;" +
                   //"TrustServerCertificate=False;" +
                   "Connection Timeout=30;"
                   )) {
            try {
                connection.Open();
            }
            //实际上是这个异常System.Data.SqlClient.SqlException
            //但是Unity的Console提示的是SocketException
            //猜测SQLException应当是被Unity/CLR?捕捉,却抛出了另一种类型的异常
            catch (SqlException e) {
                Debug.Log("无法连接到服务器");
                Debug.Log(e.Message);
                return;
            }

            Debug.Log("Connected successfully!");
            TakeQuery(connection);
        }
    }

    public static void TakeQuery(SqlConnection connection) {
        using (var command = new SqlCommand()) {
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"  
    SELECT  
        TOP 5  
            COUNT(soh.SalesOrderID) AS [OrderCount],  
            c.CustomerID,  
            c.CompanyName  
        FROM  
                            SalesLT.Customer         AS c  
            LEFT OUTER JOIN SalesLT.SalesOrderHeader AS soh  
                ON c.CustomerID = soh.CustomerID  
        GROUP BY  
            c.CustomerID,  
            c.CompanyName  
        ORDER BY  
            [OrderCount] DESC,  
            c.CompanyName; ";

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Debug.Log(reader.GetInt32(0) + " " + reader.GetInt32(1) + " " + reader.GetString(2));
            }
        }
    }

}
