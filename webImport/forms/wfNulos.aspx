<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfNulos.aspx.cs" Inherits="webImport.forms.wfCamposNulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="../Scripts/navegarLinha.js"></script>
     <script language="javascript" type="text/javascript">
     function SelectAllCheckboxes(chk) {
            var totalRows = $("#<%=gv.ClientID %> tr").length;
            var selected = 0;
            $('#<%=gv.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
                selected += 1;
            }
        });
    }

    function CheckedCheckboxes(chk) {
        if (chk.checked) {
            var totalRows = $('#<%=gv.ClientID %> :checkbox').length;
        var checked = $('#<%=gv.ClientID %> :checkbox:checked').length
        if (checked == (totalRows - 1)) {
            $('#<%=gv.ClientID %>').find("input:checkbox").each(function () {
                this.checked = true;
            });
        }
        else {
            $('#<%=gv.ClientID %>').find('input:checkbox:first').removeAttr('checked');
        }
    }
    else {
        $('#<%=gv.ClientID %>').find('input:checkbox:first').removeAttr('checked');
    }
}
    </script>


     <br />
      <div class="panel panel-primary">
     <div class="panel-heading" style="font-size: large">Campos Nulos</div>
         </div>
    <hr />

   
        <br />

    <div class="panel panel-primary">
     
      
        <br />
   
     
            &nbsp; &nbsp; &nbsp; &nbsp;
            <div style="float: left; width: 70px">
              
            </div>
       &nbsp;
            <div style="float: left; width: 80px">
                &nbsp;</div>  	
            

        <br />
      &nbsp;  <asp:Button ID="btrnulos" runat="server" Text="Excluir registro(s)" CssClass="btn btn-danger" OnClick="btrnulos_Click" OnClientClick="javascript:return confirm('Tem certeza que deseja realizar a ação?');"/>
       
         <asp:Label ID="lblMsg" runat="server" Font-Bold="true"/>
               <asp:Label ID="lblItemQty" runat="server" Font-Bold="true" CssClass="pull-right"></asp:Label> 
               		
				<br />	
		<br />
            <br />
  
  </div>   
        
            
                                              
            
    <hr />

    <div class="panel panel-primary">

                <div class="panel-heading" style="font-size:large">Lista de  Nulos</div>
               
            
          
            <div style=" OVERFLOW: auto; WIDTH: 600px; HEIGHT: 208px"> 
           
            <asp:GridView ID="gv" runat="server" OnRowCreated="gv_RowCreated" DataKeyNames="ID" CellPadding="4" AutoGenerateColumns="False" EmptyDataText="Não existe dados a serem carregados">
           
            <RowStyle Width="175px" />
                <Columns>
                   <asp:TemplateField >
                <HeaderTemplate>                    
                       &nbsp; <asp:CheckBox ID="chkCheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)" />
                    &nbsp;
                </HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<asp:CheckBox ID="chkCheck" runat="server" onclick="javascript:CheckedCheckboxes(this)" />
             </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="ID" />  
                    <asp:BoundField HeaderText="Identificador" DataField="Identificador" />  
                    <asp:BoundField HeaderText="Nome" DataField="nome" />                      
                </Columns>
            <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" ForeColor="#003300" />
            <HeaderStyle BackColor="white" BorderColor="Silver"  BorderStyle="Solid" 
                BorderWidth="1px" VerticalAlign="Top" Width="200px"  Wrap="True" ForeColor="Black" />
              
                <SelectedRowStyle BackColor="#000099" />
              
        </asp:GridView>
           
            </div>
    

      </div>

</asp:Content>
