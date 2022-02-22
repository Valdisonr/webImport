<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfIdentificador.aspx.cs" Inherits="webImport.forms.wformIdentificador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <%--<script src="../Scripts/WebForms/checkBox.js"></script>--%>
     <script src="../Scripts/WebForms/navegarLinha.js"></script>
    <script src="../Scripts/WebForms/ExcluirItem.js"></script>


     


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
     <div class="panel-heading" style="font-size: large">Manutenção de Identificador</div>
         </div>
    <hr />

    
    <%--<script language="javascript" type="text/javascript">--%>
    



    <div class="panel panel-primary">


        <br />

        
      
        
        <div class="form-group">

           <div class="col-md-4">
      <asp:Label ID="Label1" runat="server" Text="Identificador.:" Width="120" CssClass="col-md-1" Font-Bold="true"></asp:Label>
        
        <asp:TextBox ID="txtIdent" runat="server" CssClass="form-control" Width="200px" placeholder="Informe o identifcador" OnTextChanged="txtIdent_TextChanged"></asp:TextBox>
              
             </div>
            <div class ="col-md-2">
           
             <asp:Label ID="lblItemQty" runat="server" Font-Bold="true" CssClass="pull-right"></asp:Label> 
              </div>
        
  <asp:Label ID="lblMsg" runat="server" Font-Bold="true"/>
   
       <br />
        	
					
		<br />
    </div>
        </div>
    <hr />
    
      <div class="panel panel-primary">
                <div class="panel-heading" style="font-size:large">Identificador(es)</div>
           
            
            
          
            <div style=" OVERFLOW: auto; WIDTH: 610px; HEIGHT: 208px"> 

            <asp:GridView ID="gv" runat="server" DataKeyNames="ID" CellPadding="4" AutoGenerateColumns="False" EmptyDataText="Não existe dados a serem carregados" OnRowDeleting="gv_RowDeleting">
           
            <RowStyle Width="175px" />
                <Columns>
                 <%--  <asp:TemplateField >
                <HeaderTemplate>                    
                       &nbsp; <asp:CheckBox ID="chkCheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)" />
                    &nbsp;
                </HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<asp:CheckBox ID="chkCheck" runat="server" onclick="javascript:CheckedCheckboxes(this)" />
             </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="ID" DataField="ID" />  
                    <asp:BoundField HeaderText="Nome" DataField="Nome" />  
                    <asp:BoundField HeaderText="Identificador" DataField="Identificador" /> 

                 
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Excluir" HeaderText="Ação" >
                   <ControlStyle CssClass ="btn-excluir"/>
                       
                        </asp:CommandField>

                 
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
