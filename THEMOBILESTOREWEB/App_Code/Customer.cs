using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public Int64 ID { get; set; }
    public string Account_No { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Pincode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Type { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string created_by { get; set; }
    public string updated_by { get; set; }
    public string created_com_name { get; set; }
    public string updated_com_name { get; set; }
    public string Status { get; set; }

    public string Error { get; set; }

    public bool Insert()
    {
        bool insert = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "INSERT INTO tbl_customers (Account_No,Name,Email,Phone,Address,State,City,Pincode,Country,Type,created_at,created_by,created_com_name,Status)" +
                    "VALUES (@Account_No,@Name,@Email,@Phone,@Address,@City,@State,@Pincode,@Country,@Type,@created_at,@created_by,@created_com_name,@Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Account_No", this.Account_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@Phone", this.Phone);
                cmd.Parameters.AddWithValue("@Address", this.Address);
                cmd.Parameters.AddWithValue("@City", this.City);
                cmd.Parameters.AddWithValue("@State", this.State);
                cmd.Parameters.AddWithValue("@Pincode", this.Pincode);
                cmd.Parameters.AddWithValue("@Country", this.Country);
                cmd.Parameters.AddWithValue("@Type", this.Type);
                cmd.Parameters.AddWithValue("@created_at", this.created_at);
                cmd.Parameters.AddWithValue("@created_by", this.created_by);
                cmd.Parameters.AddWithValue("@created_com_name", this.created_com_name);
                cmd.Parameters.AddWithValue("@Status", this.Status);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    insert = true;
                }
                else
                {
                    insert = false;
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
        return insert;
    }

    public bool Update()
    {
        bool update = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string sql = "UPDATE tbl_customers SET Account_No = @Account_No,Name = @Name, Email = @Email, Phone = @Phone, Address = @Address, " +
                    "City = @City, State=@State,Pincode = @Pincode, Country = @Country, Type = @Type, updated_at = @updated_at, " +
                    "updated_by = @updated_by, updated_com_name = @updated_com_name, Status = @Status WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Account_No", this.Account_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@Phone", this.Phone);
                cmd.Parameters.AddWithValue("@Address", this.Address);
                cmd.Parameters.AddWithValue("@City", this.City);
                cmd.Parameters.AddWithValue("@State", this.State);
                cmd.Parameters.AddWithValue("@Pincode", this.Pincode);
                cmd.Parameters.AddWithValue("@Country", this.Country);
                cmd.Parameters.AddWithValue("@Type", this.Type);
                cmd.Parameters.AddWithValue("@updated_at", this.updated_at);
                cmd.Parameters.AddWithValue("@updated_by", this.updated_by);
                cmd.Parameters.AddWithValue("@updated_com_name", this.updated_com_name);
                cmd.Parameters.AddWithValue("@Status", this.Status);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    update = true;
                }
                else
                {
                    update = false;
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
        return update;
    }
}