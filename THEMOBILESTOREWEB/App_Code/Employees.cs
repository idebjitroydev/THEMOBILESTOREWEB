using System;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Employees
/// </summary>
public class Employees
{
    public Int64 ID { get; set; }
    public string Account_No { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Pincode { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Gender { get; set; }
    public string Type { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string created_by { get; set; }
    public string updated_by { get; set; }
    public string created_com_name { get; set; }
    public string updated_com_name { get; set; }
    public string Status { get; set; }
    public DateTime Last_Login { get; set; }
    public DateTime Last_Logout { get; set; }
    public string Secret_Question1 { get; set; }
    public string Answer1 { get; set; }
    public string Secret_Question2 { get; set; }
    public string Answer2 { get; set; }
    public string Pin { get; set; }

    public string Error { get; set; }

    #region INSERT DATA INTO DATABASE

    public bool Insert()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "INSERT INTO tbl_employees (Account_No,Name, Email, Password, Phone, Address, City, Pincode, State, Country, " +
                "Gender, Type, created_at,created_by,created_com_name, Status) VALUES " +
                "(@Account_No,@Name, @Email, @Password, @Phone, @Address, @City, @Pincode, @State, @Country, @Gender, @Type, " +
                "@created_at,@created_by,@created_com_name,@Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Account_No", this.Account_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@Password", this.Password);
                cmd.Parameters.AddWithValue("@Phone", this.Phone);
                cmd.Parameters.AddWithValue("@Address", this.Address);
                cmd.Parameters.AddWithValue("@City", this.City);
                cmd.Parameters.AddWithValue("@Pincode", this.Pincode);
                cmd.Parameters.AddWithValue("@State", this.State);
                cmd.Parameters.AddWithValue("@Country", this.Country);
                cmd.Parameters.AddWithValue("@Gender", this.Gender);
                cmd.Parameters.AddWithValue("@Type", this.Type);
                cmd.Parameters.AddWithValue("@created_at", this.created_at);
                cmd.Parameters.AddWithValue("@created_by", this.created_by);
                cmd.Parameters.AddWithValue("@created_com_name", this.created_com_name);
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

    #region UPDATE DATA INTO DATABASE

    public bool Update()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string query = "UPDATE tbl_employees SET Account_No=@Account_No,Name=@Name, Email=@Email, Phone=@Phone, Address=@Address, City=@City, Pincode=@Pincode, State=@State, Country=@Country, " +
                "Gender=@Gender, Type=@Type, updated_at=@updated_at,updated_by=@updated_by,updated_com_name=@updated_com_name,Status=@Status WHERE ID= @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Account_No", this.Account_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@Phone", this.Phone);
                cmd.Parameters.AddWithValue("@Address", this.Address);
                cmd.Parameters.AddWithValue("@City", this.City);
                cmd.Parameters.AddWithValue("@Pincode", this.Pincode);
                cmd.Parameters.AddWithValue("@State", this.State);
                cmd.Parameters.AddWithValue("@Country", this.Country);
                cmd.Parameters.AddWithValue("@Gender", this.Gender);
                cmd.Parameters.AddWithValue("@Type", this.Type);
                cmd.Parameters.AddWithValue("@updated_at", this.updated_at);
                cmd.Parameters.AddWithValue("@updated_by", this.updated_by);
                cmd.Parameters.AddWithValue("@updated_com_name", this.updated_com_name);
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

    #endregion UPDATE DATA INTO DATABASE

    #region CHANGE PASSWORD

    public bool ChangePassword()
    {
        bool Changed = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            string qry = "UPDATE tbl_employees SET Password=@Password WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@ID", this.ID);
            cmd.Parameters.AddWithValue("@Password", this.Password);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Changed = true;
            }
            else
            {
                Changed = false;
            }
        }
        return Changed;
    }

    #endregion CHANGE PASSWORD
}