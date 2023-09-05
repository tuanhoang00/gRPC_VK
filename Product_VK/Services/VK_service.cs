using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Product_VK.Protos;
using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Product_VK.Services
{
    public class VK_service : VKProtoService.VKProtoServiceBase
    {
        private readonly ILogger<VK_service> _logger;

        public VK_service(ILogger<VK_service> logger)
        {
            _logger = logger;
        }

        public override async Task<Getstatus> GetVK_Test(GetVKRequest request, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";


            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            string strSQL = string.Format("Select * from VK where ID_VK = '{0}'", request.IDVK);


            SqlCommand command = new SqlCommand(strSQL, conn);
            
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["Name_VK"]));
                }

                conn.Close();


            }

            

            var response = new Getstatus
            {
                Success = true,
            };

            return response;
        }

        public override async Task<VKModel> GetVK(GetVKRequest request, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";





            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            string strSQL = string.Format("Select * from VK where ID_VK = '{0}'", request.IDVK);


            SqlCommand command = new SqlCommand(strSQL, conn);

            // int result = command.ExecuteNonQuery();


            string[] VkInfor = new string[10];

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //Console.WriteLine(String.Format("{0}", reader["Name_VK"]));
                    Console.WriteLine("Data binding");
                    VkInfor[0] = (string)reader["Name_VK"];

                    
                }

                conn.Close();
                Console.WriteLine(VkInfor[0]);


            }

            
            var vkModel = new VKModel
            {
                VKID = 1,
                NameVK = VkInfor[0],
                NameOther = "Sungtruong",
                DescriptionVK = "Description",
                AccessoriesVK = "ACC",
                ImageVK = "Image",
                NoteVK = "Note",
                IDGroupVK = 1,
                WeightVK = 100,
                WidthVK = 100,
                HeightVK = 100,
                DepthVK = 100,
                RangeOperation = 13
            };
            




            return vkModel;
        }


        public override async Task<VKModel> UpdateVK(UpdateVKRequest request, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";





            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            /*
             * 
             * UPDATE table_name
                SET column1 = value1, column2 = value2, ...
                WHERE condition;
             */

            string[] VkInfor_update = new string[10];
            VkInfor_update[0] = request.VK.VKID.ToString();
            //Console.WriteLine("here is vk request: {0}", request.VK);
            //Console.WriteLine("here is vk request: {0}", VkInfor_update[0]);

            // check isExist or not then update


            string strSQL = string.Format("update vk set Name_VK = '{0}'," +
                " Name_Other = '{1}', " +
                " Description_VK = '{2}', " +
                " Accessories_VK = '{3}'," +
                " Image_VK = '{4}'," +
                " Note_VK = '{5}'," +
                " ID_GroupVK =  '{6}'," +
                " Weight_VK = '{7}'," +
                " Width_VK = '{8}'," +
                " Height_VK = '{9}'," +
                " Depth_VK = '{10}'," +
                " Range_operation = '{11}' where ID_VK = '{12}'", request.VK.NameVK, request.VK.NameOther, 
                request.VK.DescriptionVK, request.VK.AccessoriesVK, request.VK.ImageVK, request.VK.NoteVK, request.VK.IDGroupVK, request.VK.WeightVK,
                request.VK.WidthVK, request.VK.HeightVK, request.VK.DepthVK, request.VK.RangeOperation, request.VK.VKID);



            SqlCommand command = new SqlCommand(strSQL, conn);

            // int result = command.ExecuteNonQuery();


            string[] VkInfor = new string[10];

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //Console.WriteLine(String.Format("{0}", reader["Name_VK"]));
                    //Console.WriteLine("Data binding");
                    //VkInfor[0] = (string)reader["Name_VK"];


                }

                conn.Close();
                Console.WriteLine(VkInfor[0]);


            }


            var vkModel = new VKModel
            {
                VKID = 1,
                NameVK = "abc",
                NameOther = "Sungtruong",
                DescriptionVK = "Description",
                AccessoriesVK = "ACC",
                ImageVK = "Image",
                NoteVK = "Note",
                IDGroupVK = 1,
                WeightVK = 100,
                WidthVK = 100,
                HeightVK = 100,
                DepthVK = 100,
                RangeOperation = 13
            };





            return vkModel;
        }

        public override async Task<DeleteVKResponse> DeleteVK(DeleteVKRequest request, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";





            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            //DELETE FROM table_name WHERE condition;

            // check isExist or not then delete

            string strSQL = string.Format("Delete from VK where ID_VK = '{0}'", request.IDVK);


            SqlCommand command = new SqlCommand(strSQL, conn);

            int result = command.ExecuteNonQuery();                    
            
            conn.Close();

            var response = new DeleteVKResponse
            {
                Success = result > 0
            };

            return response;

            
        }


        public override async Task GetAllVK(GetAllVKRequest request, IServerStreamWriter<VKModel> responseStream, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";





            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            string strSQL = string.Format("Select * from VK ");


            SqlCommand command = new SqlCommand(strSQL, conn);

            // int result = command.ExecuteNonQuery();


            var VKModel_Map = new VKModel();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                var countI = 0;
                while (reader.Read())
                {
                    countI++;

                    VKModel_Map.VKID = (int)reader["ID_VK"];
                    VKModel_Map.NameVK = (string)reader["Name_VK"];
                    VKModel_Map.NameOther = (string)reader["Name_Other"];
                    VKModel_Map.DescriptionVK = (string)reader["Description_VK"];
                    VKModel_Map.AccessoriesVK = (string)reader["Accessories_VK"];
                    VKModel_Map.ImageVK = (string)reader["Image_VK"];
                    VKModel_Map.NoteVK = (string)reader["Note_VK"];
                    VKModel_Map.IDGroupVK = (int)reader["ID_GroupVK"];
                    VKModel_Map.WeightVK = (double)reader["Weight_VK"];
                    VKModel_Map.WidthVK = (double)reader["Width_VK"];
                    VKModel_Map.HeightVK = (double)reader["Height_VK"];
                    VKModel_Map.DepthVK = (double)reader["Depth_VK"];
                    VKModel_Map.RangeOperation = (double)reader["Range_operation"];                   
                  

                  
                    await responseStream.WriteAsync(VKModel_Map);
                }
                


                conn.Close();


            }
        }


        public override async Task<AddResponse> AddVK(AddVKRequest request, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";





            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            //INSERT INTO table_name VALUES(value1, value2, value3, ...);


            // check isExist or not then delete

            string strSQL = string.Format("insert into VK values('{0}', '{1}', '{2}','{3}', '{4}', '{5}', " +
                "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}') ", request.VK.VKID, request.VK.NameVK, request.VK.NameOther,
                request.VK.DescriptionVK, request.VK.AccessoriesVK, request.VK.ImageVK, request.VK.NoteVK, request.VK.IDGroupVK, request.VK.WeightVK,
                request.VK.WidthVK, request.VK.HeightVK, request.VK.DepthVK, request.VK.RangeOperation);


            SqlCommand command = new SqlCommand(strSQL, conn);

            int result = command.ExecuteNonQuery();

            conn.Close();

            var response = new AddResponse
            {
                Success = result > 0
            };

            return response;
        }

        public override async Task<InsertBulkVKResponse> InsertBulkVK(IAsyncStreamReader<VKModel> requestStream, ServerCallContext context)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"HN2-TUANHOANG";//your server
            var database = "VKTB_1"; //your database name
            var username = "tuan"; //username of server to connect
            var password = "@abc1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";Trusted_Connection=true;TrustServerCertificate=True";





            //create instanace of database connection
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            

            

            
            while (await requestStream.MoveNext())
            {
                var VkInfo = requestStream.Current;
                Console.WriteLine(VkInfo.ToString());
                //INSERT INTO table_name VALUES(value1, value2, value3, ...);


                // check isExist or not then delete

                string strSQL = string.Format("insert into VK values('{0}', '{1}', '{2}','{3}', '{4}', '{5}', " +
                    "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}') ", VkInfo.VKID, VkInfo.NameVK, VkInfo.NameOther,
                    VkInfo.DescriptionVK, VkInfo.AccessoriesVK, VkInfo.ImageVK, VkInfo.NoteVK, VkInfo.IDGroupVK, VkInfo.WeightVK,
                    VkInfo.WidthVK, VkInfo.HeightVK, VkInfo.DepthVK, VkInfo.RangeOperation);


                SqlCommand command = new SqlCommand(strSQL, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();

            var response = new InsertBulkVKResponse
            {
                Success = true
            };
            return response;
        }



    }
}
