using System;
using System.Data.SqlClient;

public class Brands
{
    public Int64 ID { get; set; }
    public string Account_No { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string created_by { get; set; }
    public string updated_by { get; set; }
    public string created_com_name { get; set; }
    public string updated_com_name { get; set; }
    public string Status { get; set; }
    public string Error { get; set; }

    #region INSERT DATA INTO DATABASE

    public bool Insert()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "INSERT INTO tbl_brands (Account_No ,Name,Email, created_at,created_by,Status,created_com_name) VALUES " +
                    "(@Account_No, @Name,@Email, @created_at,@created_by,@Status,@created_com_name)";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@Account_No", this.Account_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@created_at", this.created_at);
                cmd.Parameters.AddWithValue("@created_by", this.created_by);
                cmd.Parameters.AddWithValue("@Status", this.Status);
                cmd.Parameters.AddWithValue("@created_com_name", this.created_com_name);
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
                string qry = "UPDATE tbl_brands SET Account_No=@Account_No ,Name=@Name, Email=@Email, " +
                    "updated_at=@updated_at,updated_by=@updated_by,Status=@Status, updated_com_name=@updated_com_name WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Account_No", this.Account_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@updated_at", this.updated_at);
                cmd.Parameters.AddWithValue("@updated_by", this.updated_by);
                cmd.Parameters.AddWithValue("@Status", this.Status);
                cmd.Parameters.AddWithValue("@updated_com_name", this.updated_com_name);
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