using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace _2._0.Pages
{
    public class EditModel : PageModel
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
                                clientInfo.id ="" + reader.GetInt32(0);
                                clientInfo.firstName = reader.GetString(1);
                                clientInfo.lastName = reader.GetString(2);
                                clientInfo.address = reader.GetString(3);
                                clientInfo.homeNumber = reader.GetString(4);
                                clientInfo.cellNumber = reader.GetString(5);
                                clientInfo.dateOfBirth = reader.GetString(6);
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
                                clientInfo.idNumber=reader.GetString(17);


                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            clientInfo.id = Request.Form["id"];
            clientInfo.firstName = Request.Form["firstName"];
            clientInfo.lastName = Request.Form["lastName"];
            clientInfo.address = Request.Form["address"];
            clientInfo.homeNumber = Request.Form["homeNumber"];
            clientInfo.cellNumber = Request.Form["cellNumber"];
            clientInfo.dateOfBirth = Request.Form["dateOfBirth"];
            clientInfo.dateVaccine1 = Request.Form["dateVaccine1"];
            clientInfo.vaccineManufacturer1 = Request.Form["vaccineManufacturer1"];
            clientInfo.dateVaccine2 = Request.Form["dateVaccine2"];
            clientInfo.vaccineManufacturer2 = Request.Form["vaccineManufacturer2"];
            clientInfo.dateVaccine3 = Request.Form["dateVaccine3"];
            clientInfo.vaccineManufacturer3 = Request.Form["vaccineManufacturer3"];
            clientInfo.dateVaccine4 = Request.Form["dateVaccine4"];
            clientInfo.vaccineManufacturer4 = Request.Form["vaccineManufacturer4"];
            clientInfo.datePositiveResult = Request.Form["datePositiveResult"];
            clientInfo.dateRecovery = Request.Form["dateRecovery"];
            clientInfo.idNumber = Request.Form["idNumber"];


            if (clientInfo.firstName.Length == 0 ||
                clientInfo.lastName.Length == 0 ||
                clientInfo.address.Length == 0 ||
                clientInfo.homeNumber.Length == 0 ||
                clientInfo.cellNumber.Length == 0||
                clientInfo.idNumber.Length==0
                 )
            {
                errorMessage = "All the field are required";
                return;
            }

            try
            {
                string connectionString = "Data Source=DESKTOP-KEHNOHF\\SQLEXPRESS;Initial Catalog=2.0;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    

                    using (SqlCommand command = new SqlCommand("UPDATE clients SET firstName=@firstname,lastName=@lastName,address=@address,homeNumber=@homeNumber,cellNumber=@cellNumber,dateOfBirth=@dateOfBirth" +
                        ",dateVaccine1=@dateVaccine1,vaccineManufacturer1=@vaccineManufacturer1,dateVaccine2=@dateVaccine2,vaccineManufacturer2=@vaccineManufacturer2" +
                        ",dateVaccine3=@dateVaccine3,vaccineManufacturer3=@vaccineManufacturer3,dateVaccine4=@dateVaccine4,vaccineManufacturer4=@vaccineManufacturer4" +
                        ",datePositiveResult=@datePositiveResult,dateRecovery=@dateRecovery,idNumber=@idNumber WHERE id=@id", connection))
                    {
                        command.Parameters.AddWithValue("@firstName", clientInfo.firstName);
                        command.Parameters.AddWithValue("@lastName", clientInfo.lastName);
                        command.Parameters.AddWithValue("@address", clientInfo.address);
                        command.Parameters.AddWithValue("@homeNumber", clientInfo.homeNumber);
                        command.Parameters.AddWithValue("@cellNumber", clientInfo.cellNumber);
                        command.Parameters.AddWithValue("@dateOfBirth", clientInfo.dateOfBirth);
                        command.Parameters.AddWithValue("@dateVaccine1", clientInfo.dateVaccine1 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@vaccineManufacturer1", clientInfo.vaccineManufacturer1 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@dateVaccine2", clientInfo.dateVaccine2 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@vaccineManufacturer2", clientInfo.vaccineManufacturer2 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@dateVaccine3", clientInfo.dateVaccine3 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@vaccineManufacturer3", clientInfo.vaccineManufacturer3 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@dateVaccine4", clientInfo.dateVaccine4 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@vaccineManufacturer4", clientInfo.vaccineManufacturer4 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@datePositiveResult", clientInfo.datePositiveResult ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@dateRecovery", clientInfo.dateRecovery ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@idNumber", clientInfo.idNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@id", clientInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }
            Response.Redirect("/Clients");
        }
    }
}
