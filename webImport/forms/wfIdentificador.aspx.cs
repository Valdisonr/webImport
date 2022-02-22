using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;using System.Configuration;
using System.Data;
using System.Threading;
using daoDLL;

namespace webImport.forms
{
    public partial class wformIdentificador : System.Web.UI.Page
    {
        string stID = string.Empty;
        string Nome = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    loadIdentificador();
            //}
           

            if (IsPostBack)
            {
                listIdentificador();
            }
            txtIdent.Focus();
        }

        



        void listIdentificador()

        {

            DataTable dtcli = new DataTable();
            Connection objcliente = new Connection();
            objcliente.storedProcedure("listIdentificador");
            objcliente.addParameter("@identificador", SqlDbType.VarChar, txtIdent.Text);
            objcliente.execute();
            dtcli = objcliente.getDataTable();
            gv.DataSource = null;
            gv.DataSource = dtcli;
            gv.DataBind();

            lblItemQty.ForeColor = System.Drawing.Color.Red;
         // lblItemQty.Text = this.gv.Rows.Count.ToString() + " Item(ns)";
            txtIdent.Focus();

        }



       


        void IdentificadorDEL()
        {
            try
            {


                

                    

                       
                        Connection objCost = new Connection();

                        objCost.storedProcedure("IdentDel");
                objCost.addParameter("@identifica", SqlDbType.VarChar, Nome);
                        objCost.addParameterOutput("@result", SqlDbType.VarChar, 255);
                        objCost.execute();
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = objCost.getParameter("@result").ToString();

                       
                
            }
            catch (Exception eee)
            {
                lblMsg.Text = eee.Message;

            }

        }




        protected void txtIdent_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdent.Text))
            {
                string teste = txtIdent.Text;
                txtIdent.Text = teste.TrimStart('0');

                listIdentificador();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

          
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           
            
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {



            foreach (GridViewRow row in gv.Rows)
            {







                if (gv != null)

                {

                  //stID = gv.DataKeys[row.DataItemIndex].Values["ID"].ToString();
                    //   str += "<b>EmpName :- </b>" + gvrow.Cells[2].Text + ", ";
                    Nome = row.Cells[2].Text;
                    IdentificadorDEL();
                    //lblMsg.Text = stID;
                    //lblMsg.Text = Nome;
                }

                //  lblMsg.Text= gv.DataKeys[e.RowIndex].Values["ID"].ToString();

                //stID= gv.DataKeys[e.RowIndex].Values["Identificador"].ToString();

                //IdentificadorDEL();
                // lblMsg.Text = gv.DataKeys[row.DataItemIndex].Values["ID"].ToString();
            }
        }
    }
}

    