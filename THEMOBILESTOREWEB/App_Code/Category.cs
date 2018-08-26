using System;
using System.Data.SqlClient;

public class Category
{
    public Int64 ID { get; set; }
    public string Category_No { get; set; }
    public string Name { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string created_by { get; set; }
    public string updated_by { get; set; }
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
                string qry = "INSERT INTO tbl_categories (Category_No ,Name, created_at,created_by,Status) VALUES (@Category_No, @Name, @created_at,@created_by,@Status)";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@Category_No", this.Category_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@created_at", this.created_at);
                cmd.Parameters.AddWithValue("@created_by", this.created_by);
                cmd.Parameters.AddWithValue("@Status", this.Status);
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
                string qry = "UPDATE tbl_categories SET Category_No=@Category_No ,Name=@Name, updated_at=@updated_at,updated_by=@updated_by,Status=@Status WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Category_No", this.Category_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@updated_at", this.updated_at);
                cmd.Parameters.AddWithValue("@updated_by", this.updated_by);
                cmd.Parameters.AddWithValue("@Status", this.Status);
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