using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace _2._0.Pages
{
    public class ViewModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=DESKTOP-KEHNOHF\\SQLEXPRESS;Initial Catalog=2.0;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientInfo.id = "" +reader.GetInt32(0);
                                clientInfo.firstName = reader.GetString(1);
                                clientInfo.lastName = reader.GetString(2);
                                clientInfo.address = reader.GetString(3);
                                clientInfo.homeNumber = reader.GetString(4);
                                clientInfo.cellNumber = reader.GetString(5);
                                clientInfo.dateOfBirth=reader.GetString(6);
                                clientInfo.dateVaccine1 = reader.GetString(7);
                                clientInfo.vaccineManufacturer1 = reader.GetString(8);
                                clientInfo.dateVaccine2 = reader.GetString(9);
                                clientInfo.vaccineManufacturer2 = reader.GetString(10);
                                clientInfo.dateVaccine3 = reader.GetString(11);
                                clientInfo.vaccineManufacturer3 = reader.GetString(12);
                                clientInfo.dateVaccine4 = reader.GetString(13);
                                clientInfo.vaccineManufacturer4 = reader.GetString(14);
                                clientInfo.datePositiveResult = reader.GetString(15);
                                clientInfo.dateRecovery = reader.GetString(16);
                                clientInfo.idNumber = reader.GetString(17);


                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}
