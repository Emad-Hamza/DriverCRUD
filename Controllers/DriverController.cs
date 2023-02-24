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
    public ActionResult<List<Driver>> index()
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();
        List<Driver> driversList = new List<Driver>();

        try
        {
            string sql = "SELECT * FROM drivers";
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
        }

        catch (Exception exception)
        {
            throw exception;

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
    public ActionResult<Driver> get(int Id)
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        string sql = "SELECT * FROM drivers WHERE id = @Id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", Id);
        conn.Open();
        MySqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Console.WriteLine(sql);
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

    [HttpPost("new")]
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
        conn.Open();
        if (cmd.ExecuteNonQuery() > 0)
        {
            return Ok(driver);
        }
        return BadRequest();

    }

    [HttpPatch("edit/{Id}")]
    public ActionResult<Driver> edit(int Id, [FromBody] UpdateDriverBody updateDriverBody)
    {
        if (updateDriverBody != null)
        {
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

            string readSql = "SELECT * FROM drivers WHERE id = @Id";
            MySqlCommand readCmd = new MySqlCommand(readSql, conn);
            readCmd.Parameters.AddWithValue("@Id", Id);
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
        else
        {
            return BadRequest();

        }


    }


    [HttpDelete("{Id}")]
    public IActionResult delete(int Id)
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        conn.ConnectionString = AppConfig.GetConnectionString("Default").ToString();

        string sql = "DELETE FROM drivers WHERE id = @Id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", Id);
        conn.Open();
        if (cmd.ExecuteNonQuery() > 0)
        {
            return Ok("Deleted driver.");
        }
        return NotFound();

    }



    [HttpPost("batchCreate")]
    public IActionResult batchCreate()
    {

        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("id", typeof(Int64)));
        tbl.Columns.Add(new DataColumn("first_name", typeof(string)));
        tbl.Columns.Add(new DataColumn("last_name", typeof(string)));
        tbl.Columns.Add(new DataColumn("email", typeof(string)));
        tbl.Columns.Add(new DataColumn("phone_number", typeof(string)));

        // Randomizer.Seed = new Random(100);



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
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
        cmd.CommandType = CommandType.Text;
        if (cmd.ExecuteNonQuery() > 0)
        {
            return Ok();

        }
        return BadRequest();
    }
}
