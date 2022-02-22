using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using daoDLL;
using System.Data;
using System.Threading;

namespace webImport.forms
{
    public partial class wfDuplicado : System.Web.UI.Page
    {

        string stID = string.Empty;

        bool result = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                listduplicado();
            }
        }
        void listduplicado()
        {
            try
            {
                DataTable dtcli = new DataTable();
                Connection objcliente = new Connection();
                objcliente.storedProcedure("listDuplicidade");
                // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
                objcliente.execute();
                dtcli = objcliente.getDataTable();
                gv.DataSource = null;
                gv.DataSource = dtcli;
                gv.DataBind();

                lblItemQty.ForeColor = System.Drawing.Color.Red;
                lblItemQty.Text = this.gv.Rows.Count.ToString() + " Registro(s)";
            }

            catch (Exception eerr)
            {
                lblMsg.Text = eerr.Message;
            }


        }

        void duplicadoDEL()
        {



            foreach (GridViewRow row in gv.Rows)
            {

                CheckBox cb = (CheckBox)row.FindControl("chkCheck");




                if (cb != null && cb.Checked)

                {
                    result = true;


                    stID += gv.DataKeys[row.DataItemIndex].Values["ID"].ToString();
                    //   str += "<b>EmpName :- </b>" + gvrow.Cells[2].Text + ", ";
                    // Nome = row.Cells[3].Text;

                    Connection objCost = new Connection();

                    objCost.storedProcedure("pessoaDel");
                    objCost.addParameter("@id", SqlDbType.VarChar, row.Cells[1].Text);
                    objCost.addParameterOutput("@result", SqlDbType.VarChar, 255);
                    objCost.execute();

                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = objCost.getParameter("@result").ToString();



                }
            }
            if (result != false)
            {
                ////    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Alert,'Operação efetuada com sucesso !!')", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(),
                //       "alert", "alertDupliex();", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "script", "alert('" + lblMsg.Text + "')", true);


               
            } 


            

            else
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(),
                    "alert", "alertDuperro();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Alert,'Operação efetuada com sucesso !!')", true);
            }

            
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            

            duplicadoDEL();
        
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