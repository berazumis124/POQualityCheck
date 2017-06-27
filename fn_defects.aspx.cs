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
    public partial class fn_defects : System.Web.UI.Page
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
            string query = "SELECT * FROM tbl_defect";
            SqlCommand cmd = new SqlCommand(query);
            grd_defects.DataSource = getData(cmd);
            grd_defects.DataBind();
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

        protected void addDefect(object sender, EventArgs e)
        {
            string defect = ((TextBox)grd_defects.FooterRow.FindControl("txt_defect")).Text;
            string type = ((TextBox)grd_defects.FooterRow.FindControl("txt_type")).Text;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO tbl_defect (Type, Name) VALUES (@Type, @Name);" +
                "SELECT ID, Type, Name FROM tbl_defect";
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = defect;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Convert.ToInt32(type);
            grd_defects.DataSource = getData(cmd);
            grd_defects.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            grdBind();
            grd_defects.PageIndex = e.NewPageIndex;
            grd_defects.DataBind();
        }

        protected void EditDefects(object sender, GridViewEditEventArgs e)
        {
            grd_defects.EditIndex = e.NewEditIndex;
            grdBind();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grd_defects.EditIndex = -1;
            grdBind();
        }

        protected void UpdateDefects(object sender, GridViewUpdateEventArgs e)
        {
            string ID = ((Label)grd_defects.Rows[e.RowIndex].FindControl("lbl_id")).Text;
            string defect = ((TextBox)grd_defects.Rows[e.RowIndex].FindControl("txt_defects")).Text;
            string type = ((TextBox)grd_defects.Rows[e.RowIndex].FindControl("txt_type")).Text;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE tbl_defect SET Name = @Name, Type=@Type WHERE ID = @ID;" +
                "SELECT ID, Name, Type FROM tbl_defect";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(ID);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = defect;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Convert.ToInt32(type);
            grd_defects.EditIndex = -1;
            grd_defects.DataSource = getData(cmd);
            grd_defects.DataBind();
        }




    }
}