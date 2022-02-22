<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfBloqAcesso.aspx.cs" Inherits="webImport.forms.wfBloqAcesso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="js/navegarLinha.js"></script>
     <br />
      <div class="panel panel-primary">
     <div class="panel-heading" style="font-size: large">Bloquear Acesso</div>
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
        
        &nbsp;  <asp:TextBox ID="txtdata" runat="server" TextMode="Date"></asp:TextBox>
         <asp:Button ID="Button1" runat="server" CssClass="btn btn-success " Text="Listar Visitantes" OnClick="Button1_Click1"/>
           <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger " Text="Bloquear Acesso" OnClick="Button2_Click1"/>
               <asp:Label ID="lblItemQty" runat="server" Font-Bold="true" CssClass="pull-right"></asp:Label> 
               		
				<br />	
		<br />
            <br />
  
  </div>   
        
            
                                              
            
    <hr />
    <div class="panel panel-primary">
                <div class="panel-heading" style="font-size:large">Lista de Visitantes</div>
           
              <asp:Label ID="lblMsg" runat="server" Font-Bold="true"/>
            
          
            <div style=" OVERFLOW: auto; WIDTH: 900px; HEIGHT: 208px"> 

            <asp:GridView ID="gv" runat="server" OnRowCreated="gv_RowCreated">
           
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
