using System;
using System.Data;
using System.Data.SqlClient;

public class States
{
    public Int64 ID { get; set; }
    public string Name { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string Error { get; set; }

    #region SELECT DATA FROM DATABASE

    public DataSet Select()
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "SELECT * FROM tbl_states ORDER BY Name ASC";
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

    #region INSERT DATA INTO DATABASE

    public bool Insert()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            string query = "INSERT INTO tbl_states (Name,created_at) VALUES (@Name, @created_at)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", this.Name);
            cmd.Parameters.AddWithValue("@created_at", this.created_at);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        return isSuccess;
    }

    #endregion INSERT DATA INTO DATABASE

    #region UPDATE DATA INTO DATABASE

    public bool Update()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "UPDATE tbl_states SET Name=@Name, updated_at = @updated_at WHERE ID= @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@updated_at", this.updated_at);
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

    #endregion UPDATE DATA INTO DATABASE

    #region DELETE DATA FROM DATABASE

    public bool Delete()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "DELETE FROM tbl_states WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
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

    #endregion DELETE DATA FROM DATABASE

    #region CHECK NAME DUPLICATE

    public bool CheckName(string Name)
    {
        bool isAvail = false;
        SqlConnection conn = new SqlConnection(Database.connection);
        try
        {
            string query = "SELECT COUNT(Name) FROM tbl_states WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", Name);
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

    #endregion CHECK NAME DUPLICATE

    #region TRUNCATE TABLE

    public bool Truncate()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "DELETE FROM tbl_states";
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
}