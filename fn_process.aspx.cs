using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;

namespace POQualityCheck
{
    public partial class fn_processZero : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["LID"] = 0;
            //Session["type"] = 0;
            
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
                    fillPlaceHolder(type);
                }

                if (Session["type"].ToString() == "0")
                {
                    btn_back.Visible = false;
                } else if (Session["type"].ToString() == "1")
                {
                    btn_back.Visible = true;
                    btn_next.Visible = true;
                } else
                {
                    btn_next.Visible = false;
                }
            }
        }

        private DataTable getData(string type)
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(tbl_DefectLog.id) AS marked, tbl_Defect.Name as Name, tbl_Defect.ID as ID FROM tbl_DefectLog RIGHT OUTER JOIN tbl_Defect ON tbl_DefectLog.DefectID = tbl_Defect.id and tbl_DefectLog.OrderLineID = "+ Session["LID"] + " WHERE tbl_Defect.Type =  " + type + " GROUP BY tbl_Defect.Name, tbl_Defect.ID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        private void fillPlaceHolder(string type)
        {
            DataTable dt = getData(type);
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                //html.Append("<tr>");
                //foreach (DataColumn column in dt.Columns)
                //{
                html.Append("<div>");
                //html.Append("<button type='button' onclick='alert(\"" + row["ID"] + "\")'>" + row["Name"] + "</button>");
                html.Append("<button type='button' class='btn' id=" + row["ID"] + " onclick='getButton(" + row["ID"] + ","+ Session["LID"].ToString() +")'>" + row["Name"] + ": <span id='s_" + row["ID"] + "'>" + row["marked"] + "</span></button>");
                //html.Append(row[column.ColumnName]);
                html.Append("</div>");
                //}
                //html.Append("</tr>");
            }
            //html.Append("</table>");
            ph_defButtons.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (Session["type"].ToString() == "1")
            {
                Response.Redirect("fn_process.aspx?LID=" + Session["LID"] + "&type=0");
            }
            else if (Session["type"].ToString() == "2")
            {
                Response.Redirect("fn_process.aspx?LID=" + Session["LID"] + "&type=1");
            }
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            if (Session["type"].ToString() == "0")
            {
                Response.Redirect("fn_process.aspx?LID=" + Session["LID"] + "&type=1");
            } else if (Session["type"].ToString() == "1")
            {
                Response.Redirect("fn_process.aspx?LID=" + Session["LID"] + "&type=2");
            }
        }

        protected void btn_finish_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            using (var con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_orderLine_checked"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORDERLINE", Session["LID"]);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                    Response.Redirect("fn_orderline.aspx?id=" + Session["orderno"]);
                }
            }
        }

        [WebMethod]
        public static void storePress(int id, int lid)
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            using (var con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_add_defect"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ORDERLINE", lid);
                        cmd.Parameters.AddWithValue("@DEFECTID", id);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        con.Close();

                    

                    }
            }
        }

    }
}