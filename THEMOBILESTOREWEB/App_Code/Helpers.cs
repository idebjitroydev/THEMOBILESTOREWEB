using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

public class Helpers
{
    public string Error { get; set; }

    #region SELECT DATA FROM DATABASE

    public DataSet Select(string tableName, string OrderByName)
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "SELECT * FROM " + tableName + " ORDER BY " + OrderByName + " ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        return ds;
    }

    #endregion SELECT DATA FROM DATABASE

    #region DELETE FROM DATABASE

    public bool Delete(string tableName, int ID)
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "DELETE FROM " + tableName + " WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        return isSuccess;
    }

    #endregion DELETE FROM DATABASE

    #region CHECK DUPLICATE

    public bool CheckName(string tableName, string columnName, string txtBoxName)
    {
        bool isAvail = false;
        SqlConnection conn = new SqlConnection(Database.connection);
        try
        {
            string query = "SELECT COUNT(" + columnName + ") FROM " + tableName + " WHERE " + columnName + " = '" + txtBoxName + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            if (rows > 0)
            {
                isAvail = false;
            }
            else
            {
                isAvail = true;
            }
        }
        catch (Exception ex)
        {
            this.Error = ex.Message;
        }
        finally
        {
            conn.Close();
        }

        return isAvail;
    }

    #endregion CHECK DUPLICATE

    #region GENERATE ACCOUNT NUMBER

    public string GenerateAccountNumber(string TableName, string Prefix)
    {
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            string qry = "SELECT COUNT(ID) FROM " + TableName + "";
            SqlCommand cmd = new SqlCommand(qry, conn);
            conn.Open();
            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            rows++;
            int Random = GenerateRandomNo();
            string acc_no = Prefix + "-" + Random + "-" + rows;
            return acc_no;
        }
    }

    #endregion GENERATE ACCOUNT NUMBER

    #region GENERATE RANDOM NUMBERS

    public int GenerateRandomNo()
    {
        int _min = 1000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }

    #endregion GENERATE RANDOM NUMBERS

    #region TRUNCATE TABLE

    public bool Truncate(string tableName)
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "TRUNCATE TABLE " + tableName + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        return isSuccess;
    }

    #endregion TRUNCATE TABLE

    #region ENCODING STRINGS

    public static string Encode(string s)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
    }

    #endregion ENCODING STRINGS

    #region DECODING STRINGS

    public static string Decode(string s)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(s));
    }

    #endregion DECODING STRINGS

    #region MESSAGES

    public string SuccessSaved(string Taxonomy)
    {
        string msg = "<strong>Yippie!</strong> " + Taxonomy + " Saved Successfully";
        return msg;
    }

    public string SuccessUpdated(string Taxonomy)
    {
        string msg = "<strong>Yippie!</strong> " + Taxonomy + " Updated Successfully";
        return msg;
    }

    public string SuccessDeleted(string Taxonomy)
    {
        string msg = "<strong>Yippie!</strong> " + Taxonomy + " Deleted Successfully";
        return msg;
    }

    public string ErrorSaved(string Taxonomy, string Error)
    {
        string msg = "<strong>Oops!</strong> Something wrong happened while saving " + Taxonomy + " " + Error;
        return msg;
    }

    public string ErrorUpdate(string Taxonomy, string Error)
    {
        string msg = "<strong>Oops!</strong> Something wrong happened while updating " + Taxonomy + " " + Error;
        return msg;
    }

    public string ErrorDelete(string Taxonomy, string Error)
    {
        string msg = "<strong>Oops!</strong> Something wrong happened while Deleting " + Taxonomy + " " + Error;
        return msg;
    }

    public string ErrMessage(string Taxonomy, string Error, string Message)
    {
        string msg = "<strong>Oops!</strong> Something wrong happened  " + Taxonomy + " " + Message + " " + Error;
        return msg;
    }

    public string SuccessMessage(string Taxonomy, string Message)
    {
        string msg = "<strong>Yippie!</strong> " + Taxonomy + " " + Message;
        return msg;
    }

    #endregion MESSAGES

    #region GET CLIENT COMPUTER USER NAME

    public string GetClientComputerName()
    {
        var request = HttpContext.Current.Request;

        string com = request.LogonUserIdentity.Name.ToString();
        return com;
    }

    #endregion GET CLIENT COMPUTER USER NAME

    #region STRING FORMATTER

    public string Format(string txt)
    {
        string text = txt.ToUpper().Trim();
        return text;
    }

    #endregion STRING FORMATTER

    #region REDIRECT

    public void Redirect(string URL)
    {
        var response = HttpContext.Current.Response;

        response.Redirect("" + URL + "");
    }

    #endregion REDIRECT

    #region GET COUNT

    public string Count(string tableName)
    {
        string count;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            string qry = "SELECT COUNT(ID) FROM " + tableName + "";
            SqlCommand cmd = new SqlCommand(qry, conn);
            conn.Open();
            int rows = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return count = rows.ToString();
        }
    }

    #endregion GET COUNT
}