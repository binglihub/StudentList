using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace StudentList.Models
{
    public class DataBase
    {
        private readonly string connectionString;
        public DataBase()
        {
            connectionString = "Data Source=DESKTOP-R92ALGS\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> result = new List<Student>();

            string query = "select * from Student";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Student {
                        ID = reader["ID"] as int? ?? 0,
                        FirstName = reader["FirstName"] as string,
                        LastName = reader["LastName"] as string
                    });
                }
                reader.Close();
            }

            return result;
        }
        public bool Add(Student student)
        {
            string query = "insert into Student values('" +
                student.ID + "','" +
                student.FirstName + "','" +
                student.LastName + "')";

            int result;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commad = new SqlCommand(query, connection);
                connection.Open();
                result = commad.ExecuteNonQuery();
            }
            return !(result == -1);
        }
    }
}