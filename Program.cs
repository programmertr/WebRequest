using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Amazon.DeviceFarm.Model;

class EntegraTask
{
    
    //public class Rootobject
    //{
    //    public string novakey { get; set; }
    //    public string novasecret { get; set; }
    //}
    public class Program
    {

        //public SQLiteConnection con;

        //public static async Task CreateDatabaseAndTable()
        //{
        //    SQLiteConnection con;
        //    SQLiteCommand cmd;
        //    SQLiteDataReader dr;

        //    if (!File.Exists("Mydatabase.sqlite"))
        //    {
        //        SQLiteConnection.CreateFile("MyDatabase.sqlite");

        //        string sql = @"CREATE TABLE Product(
        //                        id INTEGER NOT NULL,
        //                        title TEXT NOT NULL);";
        //        con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3");
        //        con.Open();
        //        cmd = new SQLiteCommand(sql, con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    else
        //    {
        //        con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3");
        //    }
        //}
        public static void Main(string[] args)
        {
            //CreateDatabaseAndTable();

            //Console.Write("Add id      :");
            //int id = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Add title  :");
            //string title = Console.ReadLine();

            //AddData(id, title);

            Cekme();
            Listeleme();
        }

        //public static async Task AddData(int id,string title)
        //{

        //    SQLiteConnection con;
        //    SQLiteCommand cmd;
        //    SQLiteDataReader dr;

        //    con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3");
       
        //    cmd = new SQLiteCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "insert into Product(id,title) values('" + id + "','" + title + "')'";
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        //public void SelectData()
        //{
        //    SQLiteConnection con;
        //    SQLiteCommand cmd;
        //    SQLiteDataReader dr;

        //    int counter = 0;
        //    cmd = new SQLiteCommand("Select * From Product", con);
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        counter++;
        //        Console.WriteLine(dr[0] + " : " + dr[1] + " : " + dr[2]);
        //    }
        //    con.Close();
        //}

        public static async Task Listeleme()
        {
            string connString = @"Data Source=C:\Users\Buseasenak\Desktop\EntegraTask\EntegraTask\database\entegraDB.db;Version=3;";

            SQLiteConnection connection = new SQLiteConnection(connString);

            DataTable dt = new DataTable();
            connection.Open();
            string sql = "Select * from Product";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
            adapter.Fill(dt);
            connection.Close();
            //Her satırda gezer
            foreach (DataRow item in dt.Rows)
            {
                String row = String.Format("id: {0}    Title: {1}", item["id"], item["title"]);
                Console.WriteLine(row);
            }
            Console.ReadLine();
        }

        public static async Task Ekleme(int id,string title)
        {


            //SQLiteConnection connection = new SQLiteConnection(connString);

            //DataTable dt = new DataTable();
            //connection.Open();
            ////string ekleme = "insert into Product(id, title) values(111,'Deneme')";

            

            ////adapter.Fill(dt);
            //using var cmd = new SQLiteCommand(connection);
            //cmd.CommandText = "INSERT INTO Product(id, title) VALUES(117,'Deneme')";
            //cmd.ExecuteNonQuery();
            //SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd.CommandText, connection);
            //adapter.Fill(dt);

            //connection.Close();
            //foreach (DataRow item in dt.Rows)
            //{
            //    String row1 = String.Format("id: {0}    Title: {1}", item["id"], item["title"]);
            //    Console.WriteLine(row1);
            //}
            //Console.ReadLine();
        }
        public static async Task Cekme()
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://rest.novadan.com.tr/rest/view/1");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"novakey\":\"vjJMQG2z50NTvCNG\"," +
                              "\"novasecret\":\"c96aScdae9tXJUTM\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
           
        }
    }


}
