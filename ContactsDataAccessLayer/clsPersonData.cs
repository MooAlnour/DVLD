using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
   public class clsPersonData
    {
        public static int AddNewPerson( string FirstName, string SecondName, string ThirdName, string LastName, short Gendor,
            string Email, string Phone, string Address, DateTime DateOfBirth, int NationalityCountryID, string ImagePath)
        {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People (FirstName,SecondName, ThirdName, LastName,Gendor, Email, Phone, Address,DateOfBirth, NationalityCountryID,ImagePath)
                             VALUES (@FirstName,@SecondName, @ThirdName, @LastName, @Gendor ,@Email, @Phone, @Address,@DateOfBirth, @NationalityCountryID,@ImagePath);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            Command.Parameters.AddWithValue("@LastName", LastName); 
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
           
            if (ImagePath == "")
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            }

            try
            {
                connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }

            }
            catch (Exception ex) { }

            finally
            {

                connection.Close();

            }

            return ContactID;
        }


        public static bool GetPersonInfoByID(int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref short Gendor,
          ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PersonID", ID);
            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    Gendor = (short)reader["Gendor"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] == DBNull.Value)
                    {
                        ImagePath = "";
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }

                    reader.Close();
                }

            }
            catch (Exception en)
            {
                IsFound = false;

            }
            finally
            {
                connection.Close();

            }

            return IsFound;

        }


        public static bool UpDatePerson(int ID, string FirstName, string SecondName, string ThirdName, string LastName, short Gendor,
    string Email, string Phone, string Address, DateTime DateOfBirth, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE People
                     SET FirstName = @FirstName,
                         SecondName = @SecondName,
                         ThirdName = @ThirdName,
                         LastName = @LastName,
                         Gendor = @Gendor,
                         Email = @Email,
                         Phone = @Phone,
                         Address = @Address,
                         DateOfBirth = @DateOfBirth,
                         NationalityCountryID = @NationalityCountryID,
                         ImagePath = @ImagePath
                     WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@PersonID", ID);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qurey = "SELECT *FROM People ";
            SqlCommand command = new SqlCommand(qurey, Connection);
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();


            }
            return dt;
        }


        public static bool IsContactExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FORM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);
            try
            {
                connection.Open();
                object rs = command.ExecuteScalar();
                if (rs != null)
                {
                    IsFound = true;
                }

            }
            catch { }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
                                   
    }
}
