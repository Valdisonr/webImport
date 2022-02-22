using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using daoDLL;
using System.Configuration;
using System.Data;
using webImport.classes;
using System.Drawing;
using System.Text.RegularExpressions;


namespace webImport.forms
{
    public partial class wfFoto : System.Web.UI.Page
    {

        private List<ImagePes> ListImage = new List<ImagePes>();



        protected void Page_Load(object sender, EventArgs e)
        {

        }



        void validaFotos()
        {

            string erros = string.Empty;


            if (Fupload.HasFiles)
            {
                foreach (HttpPostedFile uploadFile in Fupload.PostedFiles)
                {
                    // uploadFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Arquivo/"), uploadFile.FileName));

                    string descricaoImagem = Path.GetFileNameWithoutExtension(uploadFile.FileName);

                    if (Regex.IsMatch(descricaoImagem, @"^[0-9]"))
                    {


                        Response.Write("<script type=text/javascript>alert('Existe letra na descrição!!!"+descricaoImagem+"')</script>");

                        
                            /*onsole.WriteLine("The Given String is a Number.");*/


                        lblMsg.Text += String.Format("{0} <br />", uploadFile.FileName);

                        int tamanho = Fupload.PostedFile.ContentLength;
                        byte[] imgbyte = new byte[tamanho];
                        //uploadFile
                        uploadFile.InputStream.Read(imgbyte, 0, tamanho);

                       

                        ListImage.Add(new ImagePes()
                        {
                            Id = descricaoImagem,
                            Imagem = imgbyte


                        });

                        Gv.DataSource = ListImage;
                        Gv.DataBind();
                    }

                    else
                    {
                        Response.Write("<script type=text/javascript>alert('Existe letra na descrição!!!"+descricaoImagem+" ')</script> ");
                    }


                }
            }
          




            //    ListImage.Add(new ImagePes()
            //    {
            //        Id = descricaoImagem,
            //        Imagem = imgbyte


            //    });

            //    Gv.DataSource = ListImage;
            //    Gv.DataBind();







        }


        void listgrid()
        {

            //lblModalBody.Text = String.Empty;

            Gv.DataSource = ListImage;
            Gv.DataBind();

            Response.Write("<script type=text/javascript>alert('LISTA CARREGADA!!!')</script> ");
        

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Fupload.HasFiles)
            {
                foreach (HttpPostedFile uploadFile in Fupload.PostedFiles)
                {
                    // uploadFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Arquivo/"), uploadFile.FileName));

                    string descricaoImagem = Path.GetFileNameWithoutExtension(uploadFile.FileName);

                    if (Regex.IsMatch(descricaoImagem, @"^[0-9]"))
                    {


                        //Response.Write("<script type=text/javascript>alert('Existe letra na descrição!!!" + descricaoImagem + "')</script>");
                        lblMsg.Text = "existe numeros na descrição";

                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Operação permitida";
                        /*onsole.WriteLine("The Given String is a Number.");*/


                        lblMsg.Text += String.Format("{0} <br />", uploadFile.FileName);

                        int tamanho = Fupload.PostedFile.ContentLength;
                        byte[] imgbyte = new byte[tamanho];
                        //uploadFile
                        uploadFile.InputStream.Read(imgbyte, 0, tamanho);



                        ListImage.Add(new ImagePes()
                        {
                            Id = descricaoImagem,
                            Imagem = imgbyte


                        });

                        Gv.DataSource = ListImage;
                        Gv.DataBind();
                    }

                    else
                    {
                        Response.Write("<script type=text/javascript>alert('Existe letra na descrição!!!" + descricaoImagem + " ')</script> ");

                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Por favor renomeie o arquivo ";
                      

                    }


                }
                //validaFotos();

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void Image1_DataBinding(object sender, EventArgs e)
        {

        }
    }
    
}


        


    
        
    
