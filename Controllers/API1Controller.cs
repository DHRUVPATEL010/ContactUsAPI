using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Web1.Models;
using System.Security.Cryptography.X509Certificates;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API1Controller :  ControllerBase
    {
        private IConfiguration _configuration;

        public API1Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public int AddData(Web1.Models.ContactUs model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection _conn = new SqlConnection())
                {
                    _conn.ConnectionString = _configuration.GetValue<string>("ConnectionStrings");
                    _conn.Open()
                   ;

                    SqlCommand command = _conn.CreateCommand();
                command.CommandText = "INSERT INTO ContactUs (FirstName, LastName, Phone, Mobile, ReasonForContact, CompanyName, Email, Comment, Inactive, Status) " +
                                          "VALUES (@FirstName, @LastName, @Phone, @Mobile, @ReasonForContact, @CompanyName, @Email, @Comment, @Inactive, @Status)";

                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Phone", model.Phone);
                    command.Parameters.AddWithValue("@Mobile", string.IsNullOrWhiteSpace(model.Mobile) ? "": model.Mobile);
                    command.Parameters.AddWithValue("@ReasonForContact", model.ReasonForContact);
                    command.Parameters.AddWithValue("@CompanyName", string.IsNullOrWhiteSpace(model.CompanyName) ? "": model.CompanyName);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Comment", string.IsNullOrWhiteSpace(model.Comment) ? "" : model.Comment);
                    command.Parameters.AddWithValue("@Inactive", false);
                    command.Parameters.AddWithValue("@Status", 'O');

                    Int32 rowsAdded = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAdded + " rows added!");

                    _conn.Close();
                }

                return 1;
            }
            else
            {
                return 0;
            }

            
        }

       
        }
    }


    

