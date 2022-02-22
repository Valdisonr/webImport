using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using daoDLL;
using System.Data;

namespace webImport.forms
{
    public partial class wfCamposNulos : System.Web.UI.Page
    {
        string stID = string.Empty;
        string Nome = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listNulo();

            }

        }

        void listNulo()
        {
            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("listNulo");
            // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            gv.DataBind();
            gv.AutoGenerateColumns = false;

            lblItemQty.ForeColor = System.Drawing.Color.Red;
            lblItemQty.Text = this.gv.Rows.Count.ToString() + " Registro(s)";
        }

        void delNulos()
        {

            try
            {




                foreach (GridViewRow row in gv.Rows)
                {

                    CheckBox cb = (CheckBox)row.FindControl("chkCheck");




                    if (cb != null && cb.Checked)

                    {

                        stID = gv.DataKeys[row.DataItemIndex].Values["ID"].ToString();
                        //   str += "<b>EmpName :- </b>" + gvrow.Cells[2].Text + ", ";
                        Nome = row.Cells[3].Text;

                        Connection objCost = new Connection();

                        objCost.storedProcedure("pessoaDel");
                        objCost.addParameter("@id", SqlDbType.Int, row.Cells[1].Text);
                        objCost.addParameterOutput("@result", SqlDbType.VarChar, 255);
                        objCost.execute();

                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = objCost.getParameter("@result").ToString();

                        if (!ClientScript.IsStartupScriptRegistered("alert"))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(),
                                "alert", "alertNuloex();", true);

                        }



                    }



                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(),
                            "alert", "alerterro();", true);

                    }
                }
            }
            catch (Exception eee)
            {
                lblMsg.Text = eee.Message;

            }




        }
        protected void btrnulos_Click(object sender, EventArgs e)
        {
            delNulos();
        }

        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))


                e.Row.TabIndex = -1;
            e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
            e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
            e.Row.Attributes["onselectstart"] = "javascript:return false;";
        }
    }
}