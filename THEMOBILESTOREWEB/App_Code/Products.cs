using System;
using System.Data.SqlClient;

public class Products
{
    public Int64 ID { get; set; }
    public string Product_No { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Barcode { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public Decimal CostPrice { get; set; }
    public Decimal SellingPrice { get; set; }
    public Decimal Discount { get; set; }
    public Int32 Stock { get; set; }
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
                string qry = "INSERT INTO tbl_products (Product_No ,Name,Code,Barcode,Category,Brand,CostPrice," +
                    "SellingPrice,Stock,Discount, created_at, created_by, created_com_name, Status) VALUES " +
                    "(@Product_No, @Name, @Code, @Barcode, @Category, @Brand, @CostPrice," +
                    "@SellingPrice, @Stock,@Discount, @created_at,@created_by, @created_com_name, @Status)";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@Product_No", this.Product_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Code", this.Code);
                cmd.Parameters.AddWithValue("@Barcode", this.Barcode);
                cmd.Parameters.AddWithValue("@Category", this.Category);
                cmd.Parameters.AddWithValue("@Brand", this.Brand);
                cmd.Parameters.AddWithValue("@CostPrice", this.CostPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", this.SellingPrice);
                cmd.Parameters.AddWithValue("@Stock", this.Stock);
                cmd.Parameters.AddWithValue("@Discount", this.Discount);
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

    #region UPDATE DATA IN DATABASE

    public bool Update()
    {
        bool isSuccess = false;
        using (SqlConnection conn = new SqlConnection(Database.connection))
        {
            try
            {
                string qry = "UPDATE tbl_products SET Product_No = @Product_No, Name = @Name, Code = @Code, Barcode = @Barcode, Category = @Category, " +
                    "Brand = @Brand, CostPrice = @CostPrice," +
                    "SellingPrice = @SellingPrice,Discount=@Discount, updated_at = @updated_at,updated_by = @updated_by, " +
                    "Status = @Status,Stock=@Stock, updated_com_name = @updated_com_name WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@Product_No", this.Product_No);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Code", this.Code);
                cmd.Parameters.AddWithValue("@Barcode", this.Barcode);
                cmd.Parameters.AddWithValue("@Category", this.Category);
                cmd.Parameters.AddWithValue("@Brand", this.Brand);
                cmd.Parameters.AddWithValue("@CostPrice", this.CostPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", this.SellingPrice);
                cmd.Parameters.AddWithValue("@Stock", this.Stock);
                cmd.Parameters.AddWithValue("@Discount", this.Discount);
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

    #endregion UPDATE DATA IN DATABASE
}