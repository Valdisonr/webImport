<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfFoto.aspx.cs" Inherits="webImport.forms.wfFoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
<%-- <h3 class="well" style="background-color: #0068B4; color: #FFFFFF;">Fotos</h3>--%>
     <div class="panel panel-primary">
   <div class="panel-heading" style="font-size: large">Importar Fotos</div>
         </div>
        <hr />
     <div class="panel panel-default">
    <br />
<div class="form-inline" style="font-weight: bold">
   <%-- &nbsp; Folha planilha .: &nbsp;
               <asp:TextBox ID="txtNome" runat="server" placeholder="Folha planilha" Width="45%" CssClass="form-control"/>--%>
         <%-- <br />--%>
               <%--  <asp:RequiredFieldValidator
                      ID="requiredNome"
                     runat="server" 
                     ControlToValidate="txtNome"
                     ErrorMessage="Por Favor,digite o nome da folha."
                     ForeColor="Red"
                     /> 
                
           
         &nbsp; &nbsp; 
    --%>
 <%--&nbsp;      <asp:TextBox ID="txtIdent" runat="server" CssClass="form-control" Width="200px" placeholder="Informe o identifcador"></asp:TextBox>
        <br />--%>
   <br />
       
    <%--accept="image/png, image/jpeg ,image/jpg"--%>
       
    <asp:FileUpload ID="Fupload" runat="server" CssClass="btn btn-danger"  AllowMultiple="true" />
            
            <br />
         &nbsp; <asp:Button ID="Button1"  runat="server" CssClass="btn btn-primary"  Text="Enviar" OnClick="Button1_Click" />

                <%--<asp:TextBox ID="Txtlocal" runat="server" placeholder="Local" Width="45%" CssClass="form-control"/>--%> 
                 
    
       <%-- <br />--%>
   
           
                <%--<asp:RequiredFieldValidator
                    ID="RequiredLocal"
                    runat="server"
                    ControlToValidate="txtLocal"
                    ErrorMessage="Local Não encontrado !!."
                    ForeColor="Red"
                     />--%>
               <asp:Label ID="lblMsg" runat="server"  Font-Bold ="true"></asp:Label>
                  <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                  </div> 
           <br />
           
               </div>
    
        <asp:Panel ID="PnGv" runat="server" BackColor="WhiteSmoke" GroupingText="Lista de Fotos">
              
           <div class="panel panel-primary">
                <div class="panel-heading" style="font-size:large">Pessoas </div>
           
   
                      
            
            <div style=" OVERFLOW: auto; WIDTH: auto; HEIGHT: 208px">

               

            <asp:GridView ID="Gv" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                runat="server" AutoGenerateColumns="False" Height="100px" Width="100px" > 
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID"  />                  
                              <%-- <asp:BoundField DataField="Imagem" HeaderText="Imagem" SortExpression="File"></asp:BoundField>--%>
                                <asp:TemplateField HeaderText="Imagem">
                                    <ItemTemplate>
                                        <asp:Image ID="woundimage" runat="server" ImageUrl='<%# "data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagem"))%>' Height="150px" Width="150px"></asp:Image>
                                    </ItemTemplate>
                                </asp:TemplateField>





                </Columns>
            
            <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" ForeColor="#003300" />
            <HeaderStyle BackColor="white" BorderColor="Silver"  BorderStyle="Solid" 
                BorderWidth="1px" VerticalAlign="Top" Width="208px"  Wrap="True" ForeColor="Black" />
              
        </asp:GridView>
                
 
                   
                
 
   
    </div>
</div>


    </asp:Panel>
   
</asp:Content>
