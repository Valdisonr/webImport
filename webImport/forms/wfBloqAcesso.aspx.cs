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
    public partial class wfBloqAcesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (!IsPostBack)
        //    { 
        //    listVisitante();
        //}
        }

        public void listVisitante()
        {


            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("anteriorDay");           // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.addParameter("@dtinicial", SqlDbType.DateTime, DateTime.Parse(txtdata.Text).ToString("dd-MM-yyy HH:mm:ss"));
           
           
            //var dt = DateTime.Parse("2016-05-08 04:00:00 PM").ToString("dd-MM-yyyy HH:mm:ss");
          
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            // gv.AutoGenerateColumns = false;
            gv.DataBind();

            lblItemQty.ForeColor = System.Drawing.Color.Red;
            lblItemQty.Text = this.gv.Rows.Count.ToString() + " Itens(s)";



        }

        public void bloquearVisit()
        {
            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("bloquearAcesso");
            objcliente.addParameter("@dtinicial", SqlDbType.DateTime, DateTime.Parse(txtdata.Text));
            // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            gv.DataBind();

            lblItemQty.ForeColor = System.Drawing.Color.Red;
            lblItemQty.Text = this.gv.Rows.Count.ToString() + " Itens(s)";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           
            listVisitante();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            bloquearVisit();
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