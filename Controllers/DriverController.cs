using System.Data;
using DriverCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DriverCRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{

    private readonly IConfiguration AppConfig;


    public DriverController(IConfiguration AppConfig)
    {
        this.AppConfig = AppConfig;


    }

    [HttpGet(Name = "GetDrivers")]
    public string Get()
    {
        MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();
        List<Driver> driversList = new List<Driver>();

        try

        {

            conn.Open();


            switch (conn.State)

            {

                case System.Data.ConnectionState.Open:

                    // Connection has been made
                    string sql = "SELECT * FROM drivers";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        // return Convert.ToString(rdr["first_name"]);
                        Driver driver = new Driver();
                        driver.Id = Convert.ToInt64(rdr["id"]);
                        driver.FirstName = Convert.ToString(rdr["first_name"]);
                        driver.LastName = Convert.ToString(rdr["last_name"]);
                        driver.Email = Convert.ToString(rdr["email"]);
                        driver.PhoneNumber = Convert.ToString(rdr["phone_number"]);
                        driversList.Add(driver);

                    }
                    break;

                case System.Data.ConnectionState.Closed:

                    // Connection could not be made, throw an error

                    throw new Exception("The database connection state is Closed");
                    return "2";
                    break;

                default:
                    return "3";
                    // Connection is actively doing something else

                    break;

            }


            // Place Your Code Here to Process Data //

        }

        catch (MySql.Data.MySqlClient.MySqlException mySqlException)

        {

            // Use the mySqlException object to handle specific MySql errors
            Console.WriteLine(mySqlException.Data);

        }

        catch (Exception exception)

        {

            // Use the exception object to handle all other non-MySql specific errors

        }

        finally

        {

            // Make sure to only close connections that are not in a closed state

            if (conn.State != System.Data.ConnectionState.Closed)

            {

                // Close the connection as a good Garbage Collecting practice

                conn.Close();

            }

        }
        // Console.WriteLine(driversList.Count.ToString());
        string jsonString = JsonSerializer.Serialize(driversList);
        return jsonString;




    }

}
