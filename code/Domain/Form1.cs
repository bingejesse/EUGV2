using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Diagnostics;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace Domain
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region nhibernate


        const int MaxRow = 1000;
        static ISessionFactory sessionFactory = null;

        public static void InitSessionFactory()
        {
            if (sessionFactory == null)
            {
                //Configuration config = new Configuration();
                //config.AddClass(typeof(Domain.Customer));

                Configuration config = new Configuration().AddAssembly("Domain");
;
                sessionFactory = config.BuildSessionFactory();
                if (sessionFactory == null)
                {
                    Console.WriteLine(" >> Error: Failed to build session factory!");
                }
            }
        }

        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                InitSessionFactory();
            }

            if (sessionFactory == null)
            {
                return null;
            }

            ISession session = sessionFactory.OpenSession();
            if (session == null)
            {
                Console.WriteLine(" >> Error: Failed to open session!");
            }

            return session;
        }

        public static void DeleteData()
        {
            ISession session = OpenSession();
            if (session != null)
            {
                ICriteria crit = session.CreateCriteria(typeof(Customer));
                IList result = crit.List();
                foreach (Customer item in result)
                {
                    session.Delete(item);
                }

                session.Flush();
                session.Close();
            }
        }

        public static void InsertData(Customer[] cs)
        {
            ISession session = OpenSession();
            if (session != null)
            {
                foreach (Customer c in cs)
                {
                    session.Save(c);
                }

                session.Flush();
                session.Close();
            }
        }

        public static void QueryData()
        {
            ISession session = OpenSession();
            if (session != null)
            {
                for (int i = 1; i <= MaxRow; i++)
                {
                    String address = i.ToString();
                    IList results = session.CreateQuery("from  Customer as t where t.Address = :value").SetString("value", address).List();
                    if (results.Count > 0)
                    {
                        Customer c = (Customer)(results[0]);
                        Console.WriteLine(c);
                    }
                }

                session.Close();
            }
        }

        protected static object LoadObjectByProperty(ISession session, string typeName, string propertyName, string propertyValue)
        {
            IList results = session.CreateQuery("from " + typeName + " as t where t." + propertyName + " = :value").SetString("value", propertyValue).List();
            if (results.Count > 0)
                return (results[0]);
            else
                return null;
        }

        protected static Customer LoadCustomerByName(ISession session, string name)
        {
            return (LoadObjectByProperty(session, "Customer", "Name", name) as Customer);
        }

        protected static Customer LoadCustomerByAddress(ISession session, string address)
        {
            return (LoadObjectByProperty(session, "Customer", "Address", address) as Customer);
        }

        private void Test()
        {
            Customer[] cs = new Customer[MaxRow];
            for (int i = 1; i <= MaxRow; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("用户");
                sb.Append(i);

                Customer c = new Customer();
                c.ID = i;
                c.Name = sb.ToString();
                c.Address = i.ToString();

                cs[i - 1] = c;
            }

            Console.WriteLine("=================== TEST START ===================");

            DeleteData();

            Console.WriteLine(">> Storage test start...");
            Stopwatch sw = Stopwatch.StartNew();

            InsertData(cs);

            sw.Stop();
            Console.WriteLine("<< Store data seconds: " + sw.ElapsedMilliseconds / 1000 + " ( " + sw.ElapsedMilliseconds + " miliseconds)");

            Console.WriteLine(">> Query test start...");
            sw = Stopwatch.StartNew();

            QueryData();

            sw.Stop();
            Console.WriteLine("<< Query data seconds: " + sw.ElapsedMilliseconds / 1000 + " ( " + sw.ElapsedMilliseconds + " miliseconds)");

            Console.WriteLine(">> Delete test start...");
            sw = Stopwatch.StartNew();

            DeleteData();

            sw.Stop();
            Console.WriteLine("<< Delete data seconds: " + sw.ElapsedMilliseconds / 1000 + " ( " + sw.ElapsedMilliseconds + " miliseconds)");

            Console.ReadLine();
        }
        #endregion

        #region MysqlConnection

        private void Test2()
        {
            //mysql.MysqlInfo();
            //DataView dateview= mysql.MysqlDataAdapter("customer");
           //DataTable table= mysql.ExecuteDataTable("Select * from cabinet");
            

            //DataTable table = dateview.Table;

           //this.PrintTableOrView(table, "id");

        }

        private void PrintTableOrView(DataTable table, string label)
        {
            // This function prints values in the table or DataView.
            Console.WriteLine("\n" + label);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Console.WriteLine("\table" + table.Rows[i][label]);
            }
            Console.WriteLine();
        }

        private void PrintTableOrView(DataView view, string label)
        {

            // This overload prints values in the table or DataView.
            Console.WriteLine("\n" + label);
            for (int i = 0; i < view.Count; i++)
            {
                Console.WriteLine("\table" + view[i][label]);
            }
            Console.WriteLine();
        }
        #endregion


        private void Test3()
        {
            DataView view = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from cabinet", null).Tables[0].DefaultView;

            this.PrintTableOrView(view, "sn");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggingData ld = new LoggingData("127.0.0.1", "root", "root", "eu");

            int id = 0;
            int boxcode = 0;
            int ip = 0;
            int password = 0;
            int value = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (j < 18)
                    {
                        boxcode += 1;
                    }
                    id = i * 24 + j + 1;
                    ip = i + 1;
                    password = 66051;
                    value = j;
                    if (j < 18)
                    {
                        ld.SaveELock(id, boxcode, ip.ToString(), password.ToString(), value.ToString());
                    }
                    else
                    {
                        ld.SaveELock(id, 0, ip.ToString(), password.ToString(), value.ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoggingData ld = new LoggingData("127.0.0.1", "root", "root", "eu");

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    byte size = 0;
                    int y=j+1;
                    if (y == 1 || y == 2 || y == 7 || y == 8)
                    {
                        size = 1;
                    }
                    else if (y == 9)
                    {
                        size = 2;
                    }


                    //ld.SaveBox(i * 9 + j+1, 1, i + 1, y, "", size, 2);
                    ld.SaveBox(i * 9 + j + 1, i * 9 + j + 1, 1, i + 1, y, "", size, 2);
                }
            }
        }
    }
}
