<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="viewregularization.aspx.cs" Inherits="HR_Web_Application.viewregularization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script type="text/javascript">

        <!-- Date Picker -->
    $(function () {
        $("#ContentPlaceHolder1_txtFromdate").datepicker({
            showOn: 'both',
            buttonImageOnly: true,
            buttonImage: 'assets/img/calendarnew.png',
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '-80:+0',
            endDate: 'today',
            maxDate: '0',
            autoclose: true
        });
    });

    $(function () {
        $("#ContentPlaceHolder1_txtTodate").datepicker({
            showOn: 'both',
            buttonImageOnly: true,
            buttonImage: 'assets/img/calendarnew.png',
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '-80:+0',
            endDate: 'today',
            maxDate: '0',
            autoclose: true
        });
    });



        </script>

    <style>
        .dobcss {
            width: 85%;
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }
    </style>

     <div class="page-wrapper">
        <div class="content container-fluid">

            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">View Regularize Attendance</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">View Employee Attendance</li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm">
                                        <form class="needs-validation">
                                            <div class="row">
                                                <div class="col-md-4 mb-3">
                                                    <label for="Dob">From Date: </label>
                                                    <asp:TextBox runat="server" ID="txtFromdate" AutoComplete="off" CssClass="dobcss"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                                        ControlToValidate="txtFromdate"
                                                        ErrorMessage="Select From Date"
                                                        ValidationGroup="attendance"
                                                        Display="Dynamic"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 mb-3">
                                                    <label for="Dob">To Date: </label>
                                                    <asp:TextBox runat="server" ID="txtTodate" AutoComplete="off" CssClass="dobcss"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvAttendenceDate"
                                                        ControlToValidate="txtTodate"
                                                        ErrorMessage="Select To Date"
                                                        ValidationGroup="attendance"
                                                        Display="Dynamic"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                                <div class="row">
                                                    <div class="form-group col-md-12">
                                                        <%--<input type="submit" value="Submit" class="btn btn-sm btn-rounded btn-success">--%>
                                                        <asp:Button ID="btnviewRegAttendance" runat="server" ValidationGroup="attendance" Text="Get Attendance" class="btn btn-sm btn-rounded btn-success" OnClick="btnviewRegAttendance_Click" />

                                                    </div>
                                                </div>


                                            </div>
                                        </form>
                                        <div class="row" style="padding: 20px;">
                                            <div class="col-md-12 col-lg-12">


                                                <asp:GridView ID="GridView1" Style="" Width="100%" CellPadding="5"
                                                    runat="server" AutoGenerateColumns="false"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <FooterStyle BackColor="#fafafa" ForeColor="#330099" HorizontalAlign="Center" />
                                                    <HeaderStyle Font-Bold="True" ForeColor="black" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                Sr.No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Attendance Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAttendanceDate" Text='<%# Bind("Attendance_date") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Checkin Time">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCheckintime" Text='<%# Bind("Checkin_time") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Category">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MyReason">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" Text='<%# Bind("Att_Status") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         
                                                        <asp:TemplateField HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

</asp:Content>
