using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POQualityCheck
{
    public partial class fn_supplier : System.Web.UI.Page
    {
        static string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdBind();
            }
        }

        private void grdBind()
        {
            string query = "SELECT * FROM tbl_Supplier";
            SqlCommand cmd = new SqlCommand(query);
            grd_supplier.DataSource = getData(cmd);
            grd_supplier.DataBind();
        }

        private DataTable getData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }

        protected void addSupplier(object sender, EventArgs e)
        {
            string supplier = ((TextBox)grd_supplier.FooterRow.FindControl("txt_supplier")).Text;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO tbl_supplier (Name) VALUES (@Name);" +
                "SELECT ID, Name FROM tbl_supplier";
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = supplier;
            grd_supplier.DataSource = getData(cmd);
            grd_supplier.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            grdBind();
            grd_supplier.PageIndex = e.NewPageIndex;
            grd_supplier.DataBind();
        }

        protected void EditSupplier(object sender, GridViewEditEventArgs e)
        {
            grd_supplier.EditIndex = e.NewEditIndex;
            grdBind();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grd_supplier.EditIndex = -1;
            grdBind();
        }

        protected void UpdateSupplier(object sender, GridViewUpdateEventArgs e)
        {
            string ID = ((Label)grd_supplier.Rows[e.RowIndex].FindControl("lbl_id")).Text;
            string supplier = ((TextBox)grd_supplier.Rows[e.RowIndex].FindControl("txt_supplier")).Text;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE tbl_supplier SET Name = @Name WHERE ID = @ID;" +
                "SELECT ID, Name FROM tbl_supplier";
            cmd.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(ID);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = supplier;
            grd_supplier.EditIndex = -1;
            grd_supplier.DataSource = getData(cmd);
            grd_supplier.DataBind();
        }

    }
}