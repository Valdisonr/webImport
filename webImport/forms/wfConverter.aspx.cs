using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using daoDLL;

namespace webImport.forms
{
    public partial class wfConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void caixaAlta()
        {
            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("caixaAlta");
            // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            //gv.AutoGenerateColumns = false;
            gv.DataBind();


            lblItemQty.ForeColor = System.Drawing.Color.Red;
            lblItemQty.Text = this.gv.Rows.Count.ToString() + " Registro(s)";


        }
        void caixaAltaBaixa()
        {
            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("caixaAltabaixaup");
            // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            //gv.AutoGenerateColumns = false;
            gv.DataBind();


            lblItemQty.ForeColor = System.Drawing.Color.Red;
            lblItemQty.Text = this.gv.Rows.Count.ToString() + " Registro(s)";
        }
        void listarTodos()
        {

            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("listName");
            // objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            //gv.AutoGenerateColumns = false;
            gv.DataBind();


            lblItemQty.ForeColor = System.Drawing.Color.Red;
            lblItemQty.Text = this.gv.Rows.Count.ToString() + " Registro(s)";

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            listarTodos();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            caixaAlta();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            caixaAltaBaixa();
        }

        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}