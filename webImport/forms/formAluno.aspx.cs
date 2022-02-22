using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Threading;
using Excel=Microsoft.Office.Interop.Excel;
//using daoDLL;


namespace webImport.forms
{
    public partial class formAlunos : System.Web.UI.Page
    {

    private   List<Pessoa> listPessoa = new List<Pessoa>();


      private  Excel.Application Process = new Excel.Application();
        
        

        protected void Page_Load(object sender, EventArgs e)
        {

            
            //if (IsPostBack)
            //{
            //    loadpage();
            //}
        }

       

         void validaDados()
         {

            

            string col0 = string.Empty;
            string col1 = string.Empty;
            string col2 = string.Empty;
            string col3 = string.Empty;
            string col4 = string.Empty;
            string col5 = string.Empty;
            string col6 = string.Empty;
            string col7 = string.Empty;
            string erros = string.Empty;

            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            string filename = string.Empty;
            // Para verificar se o arquivo for selecionado ou não uplaod
            if (FileUploadToServer.HasFile)
            {
                try
                {
                    string[] allowdFile = { ".xls", ".xlsx" };
                    //Aqui nós estamos permitindo que apenas arquivo excel tão verificando selecionado arquivo pdf ou não
                    string FileExt = System.IO.Path.GetExtension(FileUploadToServer.PostedFile.FileName);
                    //Verifica se o arquivo selecionado é extensão válida ou não
                    bool isValidFile = allowdFile.Contains(FileExt);
                    if (!isValidFile)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Por favor selecione o arquivo Excel";
                    }
                    else
                    {
                        // Pega o tamanho do arquivo carregado, aqui restringir o tamanho de arquivo
                        int FileSize = FileUploadToServer.PostedFile.ContentLength;
                        if (FileSize <= 1048576)//1048576 byte = 1MB
                        {
                            //Obtém nome de arquivo selecionado arquivo
                            filename = Path.GetFileName(Server.MapPath(FileUploadToServer.FileName));

                            //Salvar arquivo selecionado em local de servidor
                            FileUploadToServer.SaveAs(Server.MapPath(FilePath) + filename);
                            //Obter caminho do arquivo
                            string filePath = Server.MapPath(FilePath) + filename;
                            //Abra a conexão com o arquivo excel com base na versão do Excel
                            OleDbConnection con = null;
                            if ((FileExt == ".xls") || (FileExt == ".xlsx"))
                            {
                                //    con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");

                                //}
                                //else if (FileExt == ".xlsx")
                                //{
                              con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;");

                            }
                            con.Open();
                            //Obter a lista de folha disponível em folha de excel
                            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            //Obter primeiro nome da folha
                            string getExcelSheetName = dt.Rows[0]["Table_Name"].ToString();
                            //Selecione as linhas da primeira folha em folha de Excel e preencher em conjunto de dados
                            OleDbCommand ExcelCommand = new OleDbCommand(@"SELECT *FROM [" + getExcelSheetName + @"]", con);
                            OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                            OleDbDataReader reader = ExcelCommand.ExecuteReader();







                            int numLinhaErro = 0;

                            while (reader.Read())
                            {




                                numLinhaErro++;

                                col0 = Convert.ToString(reader["ID"]).Replace(".", "").Replace(".", "").Replace("-", "").Trim();
                                col1 = Convert.ToString(reader["NOME"]);
                                col2 = Convert.ToString(reader["EMPRESA"]);
                                col3 = Convert.ToString(reader["CLASSIFICAÇÃO"]);
                                col4 = Convert.ToString(reader["FUNÇÃO"]);
                                col5 = Convert.ToString(reader["DEPARTAMENTO"]);
                                col6 = Convert.ToString(reader["ESTADO"]);
                                col7 = Convert.ToString(reader["HORÁRIO"]);

                                listPessoa.Add(new Pessoa()
                                {
                                    Id = col0,
                                    Nome = col1,
                                    Empresa = col2,
                                    Classificacao = col3,
                                    Funcao = col4,
                                    Departamento = col5,
                                    Estado = col6,
                                    Horario = col7

                                });


                                //  lblMsg.Text= col0 = Convert.ToString(reader["ID"]).Replace(".", @"").Replace(".", @"").Replace("-", @"").Replace(" ", "");
                                if /*(string.IsNullOrEmpty(col0) ||*/(string.IsNullOrEmpty(col1) || string.IsNullOrEmpty(col2) || string.IsNullOrEmpty(col3)
                                    || string.IsNullOrEmpty(col4) || string.IsNullOrEmpty(col5) || string.IsNullOrEmpty(col6) || string.IsNullOrEmpty(col7))
                                {
                                    erros += string.Format("Linha numero {0} invalida , favor preecher as células vazias.", numLinhaErro);


                                }


                            }



                            if (!string.IsNullOrEmpty(erros))
                            {
                                erros = erros.Substring(0, erros.Length - 1);
                                lblMsg.ForeColor = System.Drawing.Color.Red;

                                lblMsg.Text = string.Format("Atenção campos invalidos: {0} \n\n", erros);

                            }

                            else
                            {



                                insertdados();
                                //listgrid();


                            }

                            con.Close();
                        }


                    }



                }

                catch (Exception ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = string.Format("Verifique o arquivo,ocorreu um erro enquanto carregava.: " + filename + " " + ex.Message);
                    Process.Quit();
                }


            }
            else

            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Por favor selecione o arquivo para upload.";
            }

        }

       
       


      


        void insertdados()
        {

           
            string Nidentificador = string.Empty;
            try
            {

           
            foreach (var itens in listPessoa )
            {

                    //Connection objinsert = new Connection();

                    //objinsert.storedProcedure("insertAluno");

                   

                    //objinsert.addParameter("@n_identificador", SqlDbType.VarChar, itens.Id);
                    //objinsert.addParameter("@nome", SqlDbType.VarChar, itens.Nome);
                    //objinsert.addParameter("@empresaNome", SqlDbType.VarChar, itens.Empresa);
                    //objinsert.addParameter("@classificaoNome", SqlDbType.VarChar, itens.Classificacao);
                    //objinsert.addParameter("@filtro1Nome", SqlDbType.VarChar, itens.Funcao);
                    //objinsert.addParameter("@filtro2Nome", SqlDbType.VarChar, itens.Departamento);
                    //objinsert.addParameter("@horarioNome", SqlDbType.VarChar,itens.Horario);
                    ////objinsert.addParameterOutput("@result", SqlDbType.VarChar, 255);
                    //objinsert.execute();

                    lblItemQty.ForeColor = System.Drawing.Color.Red;
                    lblItemQty.Text = this.listPessoa.Count.ToString() + " Itens(s)";


                }


                lblMsg.ForeColor = System.Drawing.Color.Blue;
                lblMsg.Text = "Dados inseridos com sucesso!!!";

                listgrid();

              //  ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#myModal').modal('hide');", true);

             // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);

            }
            catch (Exception  ere)
            {
                //  listgrid();
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Ocorreu um erro ao inserir os dados: " + ere.Message;
            }
        }

       
       
       
        void listgrid() {

      //lblModalBody.Text = String.Empty;
                        
            Gv.DataSource = listPessoa;
            Gv.DataBind();
        }
            
        

       

        //void celularVazia()


        //{
        //    try
        //    {
        //        foreach (GridViewRow row in Gv.Rows)
        //        {
        //            if ((row.Cells[0].Text == string.Empty) ||

        //                    (row.Cells[1].Text == string.Empty)) ;


        //            //&&
        //            //        (row.Cells[3].Text != null 
        //            //        !row.Cells[3].Text.Equals(string.Empty)) &&
        //            //       (row.Cells[4].Text != null &&
        //            //       !row.Cells[4].Text.Equals(string.Empty)) &&
        //            //       (row.Cells[5].Text != null &&
        //            //        !row.Cells[5].Text.Equals(string.Empty)) &&
        //            //        (row.Cells[6].Text != null &&
        //            //        !row.Cells[6].Text.Equals(string.Empty)) &&
        //            //        (row.Cells[7].Text != null &&
        //            //        !row.Cells[7].Text.Equals(string.Empty))))


        //        }
        //    }
        //    catch (Exception ee)
        //    {

        //        lblMsg.ForeColor = System.Drawing.Color.Red;
        //        lblMsg.Text = "Ocorreu um erro ao inserir os dados: " + ee.Message;
        //    }

        //}



        //bool insertAluno()
        //{
        //    bool result = true;

        //    string Nidentificador = string.Empty;

        //    try
        //    {

                



        //                Connection objinsert = new Connection();

        //            objinsert.storedProcedure("insertAluno");
        //            Nidentificador = (row.Cells[0].Text);
        //            // MessageBox.Show(Nidentificador, "Testando insert");


        //            objinsert.addParameter("@n_identificador", SqlDbType.VarChar, Nidentificador.TrimStart('0'));
        //            objinsert.addParameter("@nome", SqlDbType.VarChar, (row.Cells[1].Text));
        //            objinsert.addParameter("@empresaNome", SqlDbType.VarChar, (row.Cells[2].Text));
        //            objinsert.addParameter("@classificaoNome", SqlDbType.VarChar, (row.Cells[3].Text));
        //            objinsert.addParameter("@filtro1Nome", SqlDbType.VarChar, (row.Cells[4].Text));
        //            objinsert.addParameter("@filtro2Nome", SqlDbType.VarChar, (row.Cells[5].Text));
        //            objinsert.addParameter("@horarioNome", SqlDbType.VarChar, (row.Cells[7].Text));
        //            //objinsert.addParameterOutput("@result", SqlDbType.VarChar, 255);
        //            objinsert.execute();

        //            //barr.Value++;

        //            result = true;
        //            }
        //        }

                
        //            lblMsg.ForeColor = System.Drawing.Color.Green;
        //            lblMsg.Text = "Dados inseridos com sucesso!! ";

        //            //barr.Visible = false;
        //            //MessageBox.Show("Dados inseridos com sucesso!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            //this.Dispose();
                
        //    }
        //    catch (Exception ee)
        //    {
        //        lblMsg.ForeColor = System.Drawing.Color.Red;
        //        lblMsg.Text = "Ocorreu um erro ao inserir os dados: " + ee.Message;

        //        //MessageBox.Show(ee.Message, "Erro !!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        //this.Dispose();
        //        //result = false;
        //    }
          
        //    return result;





        //}

        protected void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
               
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            validaDados();

            //PostBackOptions optionsSubmit = new PostBackOptions(btnEnviar);
            //btnEnviar.OnClientClick = "disableButtonOnclik(this,'Aguarde...');";
            //btnEnviar.OnClientClick += ClientScript.GetPostBackEventReference(optionsSubmit);

        }

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    validaDados();
        //}
    }
}

