using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Cities
/// </summary>
public class Cities
{
    public Int64 ID { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
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
                string query = "SELECT * FROM tbl_cities ORDER BY Name ASC";
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
            try
            {
                string qry = "INSERT INTO tbl_cities (Name, State, created_at) VALUES (@Name, @State, @created_at)";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@State", this.State);
                cmd.Parameters.AddWithValue("@created_at", this.created_at);
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

    #endregion INSERT DATA INTO DATABASE

    #region UPDATE DATA IN DATABASE

    public bool Update()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "UPDATE tbl_cities SET Name=@Name, State = @State, updated_at = @updated_at WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@State", this.State);
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

    #endregion UPDATE DATA IN DATABASE
}