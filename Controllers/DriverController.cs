using System.Data;
using DriverCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MySql.Data;
using MySql.Data.MySqlClient;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using System.Text;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace DriverCRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{

    private readonly IConfiguration AppConfig;
    private static Faker faker;


    public DriverController(IConfiguration AppConfig)
    {
        this.AppConfig = AppConfig;
        faker = new Faker();

    }

    [HttpGet]
    [SwaggerOperation(
    Summary = "Returns a list of drivers in alphabetical order"
    )]
    [SwaggerResponse(500, "Database connection error.")]
    public ActionResult<List<Driver>> index()
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();
        List<Driver> driversList = new List<Driver>();

        try
        {
            //in alphabetical order 
            string sql = "SELECT * FROM drivers ORDER BY first_name";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
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
        }

        catch (MySql.Data.MySqlClient.MySqlException mySqlException)
        {
            Console.WriteLine(mySqlException.Data);
            return StatusCode(500);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Data);
            return StatusCode(500);

        }

        finally

        {


            if (conn.State != System.Data.ConnectionState.Closed)

            {

                // Close the connection as a good Garbage Collecting practice

                conn.Close();

            }

        }
        return driversList;


    }

    [HttpGet("{Id}")]
    [SwaggerResponse(200, "", typeof(Driver))]
    [SwaggerResponse(404, "The driver was not found.")]
    [SwaggerResponse(500, "Database connection error.")]
    public ActionResult<Driver> get(int Id)
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        string sql = "SELECT * FROM drivers WHERE id = @Id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", Id);
        try
        {
            conn.Open();
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
                conn.Close();
                return driver;
            }

            return NotFound();
        }
        catch (MySql.Data.MySqlClient.MySqlException mySqlException)
        {
            Console.WriteLine(mySqlException.Data);
            return StatusCode(500);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Data);
            return StatusCode(500);

        }



    }

    [HttpGet("getAlphabetalizedName/{Id}")]
    [SwaggerOperation(
    Summary = "Returns a certain driver's full name alphabetized. (Use one of the drivers ID in the /Driver API)"
    )]
    [SwaggerResponse(200, "The driver's name alphabetalized.", typeof(string))]
    [SwaggerResponse(500, "Database connection error.")]
    public ActionResult<string> getAlphabetalizedName(int Id)
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        string sql = "SELECT * FROM drivers WHERE id = @Id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", Id);
        try
        {
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // return Convert.ToString(rdr["first_name"]);
                Driver driver = new Driver();
                driver.FirstName = String.Concat(Convert.ToString(rdr["first_name"]));
                driver.LastName = String.Concat(Convert.ToString(rdr["last_name"]));
                // the name in the sample.
                Console.WriteLine(sortStringCaseInsensitively("Oliver"));
                Console.WriteLine(sortStringCaseInsensitively("Johnson"));

                conn.Close();

                driver.FirstName = sortStringCaseInsensitively(driver.FirstName);
                driver.LastName = sortStringCaseInsensitively(driver.LastName);
                return driver.FirstName + " " + driver.LastName;
            }

            return NotFound();
        }
        catch (MySql.Data.MySqlClient.MySqlException mySqlException)
        {
            Console.WriteLine(mySqlException.Source);
            return StatusCode(500);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Source);
            return StatusCode(500);

        }

    }


    [HttpPost("new")]
    [SwaggerResponse(201, "", typeof(Driver))]
    [SwaggerResponse(400, "")]
    [SwaggerResponse(500, "Database connection error.")]
    public ActionResult<Driver> create([FromBody] NewDriverBody driver)
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        string sql = "INSERT INTO drivers (first_name, last_name, email, phone_number) VALUES (@first_name, @last_name, @email, @phone_number)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@first_name", driver.FirstName);
        cmd.Parameters.AddWithValue("@last_name", driver.LastName);
        cmd.Parameters.AddWithValue("@email", driver.Email);
        cmd.Parameters.AddWithValue("@phone_number", driver.PhoneNumber);
        try
        {
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                return Created("", driver);
            }
            return BadRequest();
        }
        catch (MySql.Data.MySqlClient.MySqlException mySqlException)
        {
            Console.WriteLine(mySqlException.Data);
            return StatusCode(500);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Data);
            return StatusCode(500);

        }

    }

    [HttpPatch("edit/{Id}")]
    [SwaggerResponse(200, "", typeof(Driver))]
    [SwaggerResponse(404, "The driver was not found.")]
    [SwaggerResponse(400, "")]
    [SwaggerResponse(500, "Database connection error.")]
    public ActionResult<Driver> edit(int Id, [FromBody] UpdateDriverBody updateDriverBody)
    {
        if (updateDriverBody != null)
        {
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

            string readSql = "SELECT * FROM drivers WHERE id = @Id";
            MySqlCommand readCmd = new MySqlCommand(readSql, conn);
            readCmd.Parameters.AddWithValue("@Id", Id);


            try
            {
                conn.Open();
                MySqlDataReader rdr = readCmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.Close();
                }
                else
                {
                    return NotFound();
                }

                string updateSql = "UPDATE drivers SET";
                MySqlCommand updateCmd = new MySqlCommand(null, conn);

                string updateStatements = null;
                if (updateDriverBody.FirstName != null)
                {
                    updateStatements += " first_name = @first_name,";
                    updateCmd.Parameters.AddWithValue("@first_name", updateDriverBody.FirstName);
                }
                if (updateDriverBody.LastName != null)
                {
                    updateStatements += " last_name = @last_name,";
                    updateCmd.Parameters.AddWithValue("@last_name", updateDriverBody.LastName);
                }
                if (updateDriverBody.Email != null)
                {
                    updateStatements += " email = @email,";
                    updateCmd.Parameters.AddWithValue("@email", updateDriverBody.Email);
                }

                if (updateDriverBody.PhoneNumber != null)
                {
                    updateStatements += " phone_number = @phone_number,";
                    updateCmd.Parameters.AddWithValue("@phone_number", updateDriverBody.PhoneNumber);

                }

                if (updateStatements.EndsWith(','))
                {
                    updateStatements = updateStatements.Remove(updateStatements.Length - 1, 1);
                    // Console.WriteLine(updateStatements);
                }

                updateSql += updateStatements + " WHERE id = @Id";
                updateCmd.Parameters.AddWithValue("@Id", Id);
                updateCmd.CommandText = updateSql;

                if (updateCmd.ExecuteNonQuery() > 0)
                {
                    rdr = readCmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Driver driver = new Driver();
                        driver.Id = Convert.ToInt64(rdr["id"]);
                        driver.FirstName = Convert.ToString(rdr["first_name"]);
                        driver.LastName = Convert.ToString(rdr["last_name"]);
                        driver.Email = Convert.ToString(rdr["email"]);
                        driver.PhoneNumber = Convert.ToString(rdr["phone_number"]);
                        conn.Close();
                        return driver;
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    return BadRequest();

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException mySqlException)
            {
                Console.WriteLine(mySqlException.Data);
                return StatusCode(500);
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Data);
                return StatusCode(500);

            }

        }
        else
        {
            return BadRequest();

        }


    }


    [HttpDelete("{Id}")]
    [SwaggerResponse(200, "")]
    [SwaggerResponse(404, "The driver was not found.")]
    [SwaggerResponse(400, "")]
    [SwaggerResponse(500, "Database connection error.")]
    public IActionResult delete(int Id)
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        string sql = "DELETE FROM drivers WHERE id = @Id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", Id);
        try
        {
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                return Ok("Deleted driver.");
            }
            return NotFound();
        }
        catch (MySql.Data.MySqlClient.MySqlException mySqlException)
        {
            Console.WriteLine(mySqlException.Data);
            return StatusCode(500);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Data);
            return StatusCode(500);

        }


    }



    [HttpPost("batchCreate")]
    [SwaggerResponse(200, "")]
    [SwaggerResponse(400, "")]
    [SwaggerResponse(500, "Database connection error.")]
    public IActionResult batchCreate()
    {


        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        StringBuilder sql = new StringBuilder("INSERT INTO drivers (first_name, last_name, email, phone_number) VALUES ");

        List<string> Rows = new List<string>();
        for (int i = 0; i < 100; i++)
        {
            Rows.Add(string.Format("('{0}','{1}', '{2}', '{3}')",
             MySqlHelper.EscapeString(faker.Name.FirstName()),
              MySqlHelper.EscapeString(faker.Name.LastName()),
              MySqlHelper.EscapeString(faker.Internet.Email(faker.Name.FirstName(), faker.Name.LastName())),
              MySqlHelper.EscapeString(faker.Phone.PhoneNumber())
              ));
        }
        sql.Append(string.Join(",", Rows));
        sql.Append(";");
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
            cmd.CommandType = CommandType.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                return Ok();

            }
            return BadRequest();
        }
        catch (MySql.Data.MySqlClient.MySqlException mySqlException)
        {
            Console.WriteLine(mySqlException.Data);
            return StatusCode(500);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Data);
            return StatusCode(500);

        }

    }

    // Function to return the sorted string
    public static string sortStringCaseInsensitively(string s)
    {
        char[] arr = s.ToCharArray();
        List<char> v1 = new List<char>();//lower case letters list
        List<char> v2 = new List<char>();//upper case letters list
        List<char> newList = new List<char>();
        for (int k = 0; k < s.Length; k++)
        {
            if (Char.IsLower(arr[k]))
            {
                v1.Add(arr[k]);
            }

            if (Char.IsUpper(arr[k]))
            {
                v2.Add(arr[k]);
            }
        }


        v1.Sort();
        v2.Sort();

        //two pointers 
        int i = 0;
        int j = 0;

        while (i < v1.Count && j < v2.Count)
        {

            //if the letter in lowercase list is earlier than the letter in the uppercase list
            if (string.Compare(v1[i].ToString(), v2[j].ToString().ToLower(), StringComparison.Ordinal)
             < 0)
            {
                newList.Add(v1[i]);
                i++;
            }
            //if the letter in uppercase list is earlier than the letter in the lowercase list
            else if (string.Compare(v1[i].ToString(), v2[j].ToString().ToLower(), StringComparison.Ordinal)
             > 0)
            {
                newList.Add(v2[j]);
                j++;

            }
            //if they are both in the same position it add the uppercase letter firsts
            else if (string.Compare(v1[i].ToString(), v2[j].ToString().ToLower(), StringComparison.Ordinal)
             == 0)
            {

                newList.Add(v2[j]);
                newList.Add(v1[i]);
                j++;
                i++;
            }

        }

        //2 other while loops to check if the 2 lists have completely looped over
        while (i < v1.Count)
        {
            newList.Add(v1[i]);
            i++;
        }

        while (j < v2.Count)
        {
            newList.Add(v2[j]);
            j++;
        }

        // return "z";
        // for (int z = 0; z < newList.Count; z++)
        // {
        //     Console.WriteLine(newList[i]);
        // }
        return String.Join("", newList.ToArray());


    }

}
