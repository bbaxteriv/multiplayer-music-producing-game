// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Data.Sql;
// using System.Data.SqlClient;
// using UnityEngine.UI;


// public class SQLManager : MonoBehaviour
// {
//   void Start ()
//   {
//     data = ConnectToDB();
//     Debug.Log(data);
//   }

//   // function to connect to the db and the users list
//   void ConnectToDB()
//   {
//     // Build connection string
//     SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//     builder.DataSource = "mysql.2122.lakeside-cs.org";
//     builder.UserID = "student2122";
//     builder.Password = "m545CS42122";
//     builder.InitialCatalog = "2122project";

//     try
//     {
//       // connect to the databases
//       using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//       {
//         // if open then the connection is established
//         connection.Open();
//         Debug.Log("connection established");
//         // sql command
//         string sql = "SELECT * FROM Music_Game;";
//         // execute sql command
//         using (SqlCommand command = new SqlCommand(sql, connection))
//         {
//           // read
//           using (SqlDataReader reader = command.ExecuteReader())
//           {
//             // each line in the output
//             while (reader.Read())
//             {
//               // to avoid SqlNullValueException
//               if (!reader.IsDBNull(0) & !reader.IsDBNull(1) & !reader.IsDBNull(2))
//               {
//                 // Skills list to be attached to each user object
//                 List data = new List();

//                 // Get SQL output
//                 string username = reader.GetString(0);
//                 string wav = reader.GetString(1);
//                 int rating = reader.GetString(2);

//                 // Get row of data and add to list
//                 string[] row = {username, wav, rating};
//                 data.Add(row);
//               }
//             }
//           }
//         }
//       }
//     }
//     catch (SqlException e)
//     {
//       Debug.Log(e.ToString());
//     }
//     return data;
//   }
// }
