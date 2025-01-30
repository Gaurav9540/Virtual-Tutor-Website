<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="viewprofile.aspx.cs" Inherits="HR_Web_Application.viewprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href='https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/ui-lightness/jquery-ui.css' rel='stylesheet'>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>

    <script>

        $(document).ready(function () {
            $('.keyup-email').keyup(function () {
                $('span.error-keyup-7').remove();
                var inputVal = $(this).val();
                var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                if (!emailReg.test(inputVal)) {
                    $(this).after('<span class="error error-keyup-7">Invalid Email Format.</span>');
                }
            });
        });


        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function validatePan(evt) {
            var panValue = document.getElementById('ContentPlaceHolder1_txtPan').value;
            var regex = /[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$/;

            if (regex.test(panValue)) {
                alert('123');
                return true;
            } else {
                document.getElementById('validatepan').style.display = 'block';
                document.getElementById('validatepan').innerText = 'Please enter proper pancard';
                return false;
            }

        }



        $(function () {
            $("#ContentPlaceHolder1_txtDob").datepicker({
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

        .newformcontrol {
            width: 100%;
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
                        <h3 class="page-title">PROFILE</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">View Profile</li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">

                        <div class="card">

                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm">
                                        <form class="needs-validation">




                                            <div class="row">
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4 mb-3">
                                                    <label for="validationCustom01">Select State</label>
                                                    <asp:DropDownList ID="ddlMobileNumber" runat="server" CssClass="newformcontrol" Style="height: 40px;"></asp:DropDownList>

                                                </div>
                                            </div>


                                            <div>
                                                <asp:Button ID="Button1" runat="server" Text="Search Records" ValidationGroup="profileGroup" class="btn btn-sm btn-rounded btn-success" OnClick="Button1_Click" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;" />
                                            </div>
                                            <br />
                                            <div>

                                                <asp:GridView ID="GridView1" Width="100%" CellPadding="5" runat="server" AutoGenerateColumns="false"
                                                    AllowPaging="true" PageSize="5" OnRowDeleting="GridView1_RowDeleting"
                                                    CssClass="gridview" DataKeyNames="proID">
                                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="White" ForeColor="#330099" />
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
                                                        <asp:TemplateField HeaderText="CODE" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("proID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Firstname">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfname" Text='<%# Bind("proFname") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Lastname">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLname" Text='<%# Bind("proLname") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Username">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblusername" Text='<%# Bind("proUsername") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Password">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpassword" Text='<%# Bind("proPassword") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Role">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLevel" Text='<%# Bind("proLevel") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstatus" Text='<%# Bind("proStatus") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DOB">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("proDOB") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Email">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemail" runat="server" Text='<%# Bind("proEmail") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mobile">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("proMobile") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="edit-button" CommandName="Edit" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="update-button" CommandName="Update" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cancel-button" CommandName="Cancel" />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="delete-button" CommandName="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
