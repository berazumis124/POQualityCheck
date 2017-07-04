using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POQualityCheck
{
    public partial class fn_processQty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_qty.Focus();

            if (!IsPostBack)
            {
                string orderLine = Request.QueryString["LID"].ToString();
                string type = Request.QueryString["type"].ToString();
                string OrderNo = Session["orderno"].ToString();
                Session["LID"] = Convert.ToInt32(orderLine);
                Session["type"] = Convert.ToInt32(type);
                if (OrderNo == null || orderLine == null || type == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {

                }
            }
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            using (var con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_add_checked_quantity"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORDERLINE", Session["LID"].ToString());
                    cmd.Parameters.AddWithValue("@QTY", txt_qty.Text);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                    Response.Redirect("fn_process.aspx?LID=" + Session["LID"] + "&type=0");
                }
            }
        }
    }
}