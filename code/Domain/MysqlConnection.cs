using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace Domain
{
    public class MysqlConnection
    {
        private static MysqlConnection instance;
        public static MysqlConnection GetInstance(string IP, string UserName, string Password, string Database)
        {
            if (instance == null)
            {
                instance = new MysqlConnection(IP,UserName,Password,Database);
            }
            return instance;
        }

        private static MySqlConnection mysqlConnection;
        private DataSet dataSet;
        private static Mutex databaseMutex; 

        private MysqlConnection(string IP, string UserName, string Password, string Database)
        {
            try
            {
                string connectionString = "datasource=" + IP + ";username=" + UserName + ";password=" + Password + ";database=" + Database + ";charset=utf8";
                mysqlConnection = new MySqlConnection(connectionString);
                databaseMutex = new Mutex();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string MysqlInfo()
        {
            string mysqlInfo = null;
            try
            {
                mysqlConnection.Open();
                mysqlInfo += "Connection Opened." + Environment.NewLine;
                mysqlInfo += "Connection String:" + mysqlConnection.ConnectionString.ToString() + Environment.NewLine;
                mysqlInfo += "Database:" + mysqlConnection.Database.ToString() + Environment.NewLine;
                mysqlInfo += "Connection ServerVersion:" + mysqlConnection.ServerVersion.ToString() + Environment.NewLine;
                mysqlInfo += "Connection State:" + mysqlConnection.State.ToString() + Environment.NewLine;
            }
            catch (MySqlException ex)
            {
                CLog4net.LogError("MySqlException Error:" + ex);
            }
            finally
            {
                mysqlConnection.Close();
            }
            return mysqlInfo;
        }

        public int MysqlCommand(string MysqlCommand)
        {
            try
            {
                mysqlConnection.Open();
                Console.WriteLine("MysqlConnection Opened.");
                MySqlCommand mysqlCommand = new MySqlCommand(MysqlCommand, mysqlConnection);
                return mysqlCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                CLog4net.LogError("MySqlException Error:" + ex);
                if (Regex.IsMatch(ex.ToString(), ""))
                {
                    CLog4net.LogError("数据库已经存在唯一键值");
                }
            }
            finally
            {
                mysqlConnection.Close();
            }
            return -1;
        }

        //
        public DataView MysqlDataAdapter(string table)
        {
            DataView dataView = new DataView();
            try
            {
                mysqlConnection.Open();
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter("Select * from " + table, mysqlConnection);
                dataSet = new DataSet();
                mysqlDataAdapter.Fill(dataSet, table);
                dataView = dataSet.Tables[table].DefaultView;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
            return dataView;
        }

        ///// <summary>
        ///// 存储数据库连接（保护类，只有由他派生的类才能访问）
        ///// </summary>
        //protected OleDbConnection Connection;

        /// <summary>
        /// 执行批处理（事务）
        /// </summary>
        /// <param name="arrlist"></param>
        /// <returns></returns>
        public bool ExecuteBatch(System.Collections.ArrayList arrlist)
        {
            bool bFlag = true;
            string strSQL = string.Empty;

            if (mysqlConnection.State == ConnectionState.Closed)
            { mysqlConnection.Open(); }
            MySqlCommand command = null;

            using (MySqlTransaction myTrans = mysqlConnection.BeginTransaction())
            {
                try
                {
                    foreach (Object objSql in arrlist)
                    {
                        strSQL = objSql.ToString().Trim();
                        if (!string.IsNullOrEmpty(strSQL))
                            command = new MySqlCommand(strSQL, mysqlConnection, myTrans);
                    }
                    myTrans.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteBatch Error:" + e.ToString());
                    myTrans.Rollback();
                }
                finally
                {
                    if (mysqlConnection.State == ConnectionState.Open)
                    {
                        mysqlConnection.Close();
                    }
                    if (mysqlConnection != null)
                    {
                        mysqlConnection.Dispose();
                    }
                }
            }

            return bFlag;
        }

        /// <summary>
        /// 执行SQL语句没有返回结果，如：执行删除、更新、插入等操作
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>操作成功标志</returns>
        public bool ExecuteNonQuery(string strSQL)
        {
            int begintime = Environment.TickCount;

            databaseMutex.WaitOne();

            bool resultState = false;
            if (mysqlConnection.State != ConnectionState.Open)
            { mysqlConnection.Open(); }

            MySqlTransaction myTrans = mysqlConnection.BeginTransaction();//不支持并行用户
            MySqlCommand command = new MySqlCommand(strSQL, mysqlConnection, myTrans);

            try
            {
                command.ExecuteNonQuery();
                myTrans.Commit();
                resultState = true;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                resultState = false;
                CLog4net.LogError(strSQL+ " "+e);
            }
            finally
            {
                databaseMutex.ReleaseMutex();
                mysqlConnection.Close();
            }

            CLog4net.LogInfo(strSQL + " 执行结束:" + (Environment.TickCount - begintime) + "ms");
            return resultState;
        }

        /// <summary>
        /// 执行SQL语句返回结果到DataReader中
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>dataReader</returns>
        public MySqlDataReader ExecuteDataReader(string strSQL)
        {
            if (mysqlConnection.State == ConnectionState.Closed)
            { mysqlConnection.Open(); }
            MySqlCommand command = new MySqlCommand(strSQL, mysqlConnection);
            MySqlDataReader dataReader = command.ExecuteReader();
            mysqlConnection.Close();

            return dataReader;
        }

        /// <summary>
        /// 执行SQL语句返回结果到DataSet中
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(string strSQL)
        {
            if (mysqlConnection.State == ConnectionState.Closed)
            { mysqlConnection.Open(); }
            DataSet dataSet = new DataSet();
            MySqlDataAdapter OleDbDA = new MySqlDataAdapter(strSQL, mysqlConnection);
            OleDbDA.Fill(dataSet, "myDataSet");

            mysqlConnection.Close();
            return dataSet;
        }

        /// <summary>
        /// 执行SQL语句返回结果到DataTable中
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string strSQL)
        {
            int begintime = Environment.TickCount;

            databaseMutex.WaitOne();

            DataTable table;
            try
            {
                if (mysqlConnection.State == ConnectionState.Closed)
                { mysqlConnection.Open(); }

                table = new DataTable();

                MySqlDataAdapter dbda = new MySqlDataAdapter(strSQL, mysqlConnection);

                dbda.Fill(table);
            }
            catch (Exception e)
            {
                CLog4net.LogError(strSQL + " " + e);
                return null;
            }
            finally
            {
                databaseMutex.ReleaseMutex();
                mysqlConnection.Close();
            }
            CLog4net.LogInfo(strSQL + " 执行结束:"+(Environment.TickCount-begintime)+"ms");
            return table;
        }


    }//end class
}
