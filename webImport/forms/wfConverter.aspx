<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfConverter.aspx.cs" Inherits="webImport.forms.wfConverter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <script src="../Scripts/WebForms/MsgExcluirDupli.js"></script>
      <div class="panel panel-primary">
     <div class="panel-heading" style="font-size: large">Converter Campos</div>
         </div>
    <hr />

    <div class="panel panel-primary">
     
      
        <br />
   
     
            &nbsp; &nbsp; &nbsp; &nbsp;
            <div style="float: left; width: 70px">
              
            </div>
       &nbsp;
            <div style="float: left; width: 80px">
                &nbsp;</div>  	
            

        <br />
        
        
    &nbsp;     <asp:Button ID="Button1" runat="server" OnClientClick ="this.disable=true;this.value='Enviando.Por favor aguarde...';" CssClass="btn btn-warning " Text="Listar Todos" OnClick="Button1_Click1"/>
        <%--<asp:Button ID="btnExcluiDup" runat="server" OnClientClick ="this.disable=true;this.value='Enviando.Por favor aguarde...';" UseSubmitBehavior ="false"  CssClass="btn btn-danger" data-dismiss="modal" Text="Excluir" OnClick="Button1_Click"/>--%> 
        <asp:Button ID="Button2" runat="server" OnClientClick ="this.value='Enviando.Por favor aguarde...';" CssClass ="btn btn-warning" Text="Caixa Alta" OnClick="Button2_Click1" />
       
        <asp:Button ID="Button3" runat="server"   OnClientClick ="this.value='Enviando.Por favor aguarde...';" CssClass ="btn btn-warning" Text="Alta e Baixa"  OnClick="Button3_Click1" />
       <%-- <asp:Button ID="Button3" runat="server" OnClientClick ="this.value='Enviando.Por favor aguarde...';" CssClass ="btn btn-warning" Text="Caixa Alta" OnClick="Button2_Click1" />--%>

               <asp:Label ID="lblItemQty" runat="server" Font-Bold="true" CssClass="pull-right"></asp:Label> 
               		
				<br />	
		<br />
            <br />
  
  </div>   
        
            
                                              
            
    <hr />
    
      <div class="panel panel-primary">
                <div class="panel-heading" style="font-size:large">Lista de pessoas </div>
           
            <asp:Label ID="lblMsg" runat="server" Font-Bold="true"/>
            
          
             <div style=" OVERFLOW: auto; WIDTH: 600px; HEIGHT: 208px"> 

            <asp:GridView ID="gv" runat="server" OnRowCreated="gv_RowCreated" HorizontalAlign="Justify">
           
            <RowStyle Width="175px" />
                
            <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" ForeColor="#003300" />
            <HeaderStyle BackColor="white" BorderColor="Silver"  BorderStyle="Solid" 
                BorderWidth="1px" VerticalAlign="Top" Width="200px"  Wrap="True" ForeColor="Black" />
              
                <SelectedRowStyle BackColor="#000099" />
              
        </asp:GridView>
            </div>
    

      </div>
    
     


</asp:Content>
