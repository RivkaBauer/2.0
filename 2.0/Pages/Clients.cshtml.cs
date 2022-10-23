using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Scaffolding.Internal;
using System;
using System.Data;
using System.Reflection.PortableExecutable;

namespace _2._0.Pages
{
    public class ClientsModel : PageModel
    {
        
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-KEHNOHF\\SQLEXPRESS;Initial Catalog=2.0;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id ="" + reader.GetInt32(0);
                                clientInfo.firstName = reader.GetString(1);
                                clientInfo.lastName = reader.GetString(2);
                                clientInfo.address = reader.GetString(3);
                                clientInfo.homeNumber = reader.GetString(4);
                                clientInfo.cellNumber = reader.GetString(5);
                                clientInfo.dateOfBirth = reader.GetString(6);
                                clientInfo.dateVaccine1=reader.GetString(7);
                                clientInfo.vaccineManufacturer1 = reader.GetString(8);
                                clientInfo.dateVaccine2 = reader.GetString(9);
                                clientInfo.vaccineManufacturer2 = reader.GetString(10);
                                clientInfo.dateVaccine3 = reader.GetString(11);
                                clientInfo.vaccineManufacturer3 = reader.GetString(12);
                                clientInfo.dateVaccine4 = reader.GetString(13);
                                clientInfo.vaccineManufacturer4 = reader.GetString(14);
                                // clientInfo.datePositiveResult = reader.GetString(15);
                                if (!reader.IsDBNull(15))
                                {
                                    clientInfo.datePositiveResult = reader.GetString(15);
                                }
                                //clientInfo.dateRecovery = reader.GetString(16);
                                if (!reader.IsDBNull(16))
                                {
                                    clientInfo.dateRecovery = reader.GetString(16);
                                }
                                clientInfo.idNumber=reader.GetString(17);
                                
                               
                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    public class ClientInfo
    {
        public string id;
        public string firstName;
        public string lastName;
        public string address;
        public string homeNumber;
        public string cellNumber;
        public string dateOfBirth;
        public string dateVaccine1;
        public string vaccineManufacturer1;
        public string dateVaccine2;
        public string vaccineManufacturer2;
        public string dateVaccine3;
        public string vaccineManufacturer3;
        public string dateVaccine4;
        public string vaccineManufacturer4;
        public string datePositiveResult;
        public string dateRecovery;
        public string idNumber;


    }
}
