using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NetTopologySuite.Mathematics;
using System.Runtime.Serialization;

namespace _2._0.Pages
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            clientInfo.id=Request.Form["id"];
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
                clientInfo.idNumber.Length==0)
            {
                errorMessage = "All the field are required";
                return;
            }

            //save the new client into the database

            try
            {
                string connectionString = "Data Source=DESKTOP-KEHNOHF\\SQLEXPRESS;Initial Catalog=2.0;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand("INSERT INTO clients (firstName,lastName,address,homeNumber," +
                        "cellNumber,dateOfBirth,dateVaccine1,vaccineManufacturer1,dateVaccine2,vaccineManufacturer2" +
                        ",dateVaccine3,vaccineManufacturer3,dateVaccine4,vaccineManufacturer4," +
                        "datePositiveResult,dateRecovery,idNumber" +
                        ") VALUES(@firstName,@lastName,@address,@homeNumber" +
                        ",@cellNumber,@dateOfBirth,@dateVaccine1,@vaccineManufacturer1,@dateVaccine2,@vaccineManufacturer2" +
                        ",@dateVaccine3,@vaccineManufacturer3,@dateVaccine4,@vaccineManufacturer4," +
                        "@datePositiveResult,@dateRecovery,@idNumber);", connection))
                    {
                        command.Parameters.AddWithValue("@firstName", clientInfo.firstName);
                        command.Parameters.AddWithValue("@lastName", clientInfo.lastName);
                        command.Parameters.AddWithValue("@address", clientInfo.address);
                        command.Parameters.AddWithValue("@homeNumber", clientInfo.homeNumber);
                        command.Parameters.AddWithValue("@cellNumber", clientInfo.cellNumber);
                        command.Parameters.AddWithValue("@dateOfBirth",clientInfo.dateOfBirth);
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
                        command.Parameters.AddWithValue("@idNumber", clientInfo.idNumber ?? (object)DBNull.Value );
                        command.Parameters.AddWithValue("@id", clientInfo.id ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }
            clientInfo.id = "";
            clientInfo.firstName = "";
            clientInfo.lastName = "";
            clientInfo.address = "";
            clientInfo.homeNumber = "";
            clientInfo.cellNumber = "";
            clientInfo.dateOfBirth = "";
            clientInfo.dateVaccine1 = "";
            clientInfo.vaccineManufacturer1 = "";
            clientInfo.dateVaccine2 = "";
            clientInfo.vaccineManufacturer2 = "";
            clientInfo.dateVaccine3 = "";
            clientInfo.vaccineManufacturer3 = "";
            clientInfo.dateVaccine4 = "";
            clientInfo.vaccineManufacturer4 = "";
            clientInfo.datePositiveResult = "";
            clientInfo.dateRecovery = "";
            clientInfo.idNumber = "";


            successMessage = "New client added correctly";

            Response.Redirect("/Clients");
        }
    }
}
