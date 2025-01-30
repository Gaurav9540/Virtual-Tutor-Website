<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="viewupdatequestion.aspx.cs" Inherits="HR_Web_Application.viewupdatequestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">

        <!-- Date Picker -->
    /*$(function () {
        $("#ContentPlaceHolder1_txtAttendanceDate").datepicker({
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
    });*/






    </script>
    <style type="text/css">
        .gridview .fixed-width-column {
            width: 800px; /* Set the desired fixed width */
        }

            .gridview .fixed-width-column:nth-child(4) {
                width: 1400px; /* Adjust width for the video link column (4th column in this example) */
            }
    </style>
    <style type="text/css">
        .pagination-footer {
            font-size: 14px;
            font-weight: bold;
            border-top: 1px solid #ddd;
            padding: 10px 0;
        }

            .pagination-footer a {
                padding: 5px 10px;
                margin: 0 2px;
                color: #333;
                text-decoration: none;
                border: 1px solid #ccc;
                background-color: #f9f9f9;
                border-radius: 3px;
            }

                .pagination-footer a:hover {
                    background-color: #e9e9e9;
                }

            .pagination-footer .current {
                background-color: #007bff;
                color: #fff;
                border: 1px solid #007bff;
            }
    </style>

    <style type="text/css">
        .gridview .edit-button {
            background-color: #4CAF50;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .edit-button:hover {
                background-color: #45a049;
            }

        .gridview .delete-button {
            background-color: #f44336;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .delete-button:hover {
                background-color: #e57373;
            }
    </style>

    <style>
        .dobcss {
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
    <style type="text/css">
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

            .gridview th, .gridview td {
                border: 1px solid #ddd;
                /*padding: 8px;*/
                text-align: left;
            }

            .gridview tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .gridview th {
                padding-top: 12px;
                padding-bottom: 12px;
                background-color: #4CAF50;
                color: white;
            }
    </style>
    <style type="text/css">
        .gridview .edit-button {
            background-color: #4CAF50;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .edit-button:hover {
                background-color: #45a049;
            }

        .gridview .delete-button {
            background-color: #f44336;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .delete-button:hover {
                background-color: #e57373;
            }
    </style>




    <script type="text/javascript">

        <!-- Date Picker -->
    /*$(function () {
        $("#ContentPlaceHolder1_txtAttendanceDate").datepicker({
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
    });*/






    </script>
    <style type="text/css">
        .gridview .fixed-width-column {
            width: 800px; /* Set the desired fixed width */
        }

            .gridview .fixed-width-column:nth-child(4) {
                width: 1400px; /* Adjust width for the video link column (4th column in this example) */
            }
    </style>
    <style type="text/css">
        .pagination-footer {
            font-size: 14px;
            font-weight: bold;
            border-top: 1px solid #ddd;
            padding: 10px 0;
        }

            .pagination-footer a {
                padding: 5px 10px;
                margin: 0 2px;
                color: #333;
                text-decoration: none;
                border: 1px solid #ccc;
                background-color: #f9f9f9;
                border-radius: 3px;
            }

                .pagination-footer a:hover {
                    background-color: #e9e9e9;
                }

            .pagination-footer .current {
                background-color: #007bff;
                color: #fff;
                border: 1px solid #007bff;
            }
    </style>

    <style type="text/css">
        .gridview .edit-button {
            background-color: #4CAF50;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .edit-button:hover {
                background-color: #45a049;
            }

        .gridview .delete-button {
            background-color: #f44336;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .delete-button:hover {
                background-color: #e57373;
            }
    </style>

    <style>
        .dobcss {
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
    <style type="text/css">
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

            .gridview th, .gridview td {
                border: 1px solid #ddd;
                /*padding: 8px;*/
                text-align: left;
            }

            .gridview tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .gridview th {
                padding-top: 12px;
                padding-bottom: 12px;
                background-color: #4CAF50;
                color: white;
            }
    </style>
    <style type="text/css">
        .gridview .edit-button {
            background-color: #4CAF50;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .edit-button:hover {
                background-color: #45a049;
            }

        .gridview .delete-button {
            background-color: #f44336;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            transition-duration: 0.4s;
        }

            .gridview .delete-button:hover {
                background-color: #e57373;
            }
    </style>



    <div class="page-wrapper">
        <div class="content container-fluid">

            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">View & Update Question</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">View & Update Question</li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">

                            <div class="card-body">

                                <div class="row" style="padding: 20px;" runat="server" id="gridArea" visible="true">
                                    <div class="col-md-12 col-lg-12">


                                        <asp:GridView ID="GridView1" Width="100%" CellPadding="5" runat="server" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="5" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                            OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="gridview" DataKeyNames="QuesCode">
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
                                                <asp:TemplateField HeaderText="QuesCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblquescode" runat="server" Text='<%# Bind("QuesCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Question">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblquestion" Text='<%# Bind("QuestName") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Option 1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbloption1" Text='<%# Bind("option1") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Option 2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbloption2" runat="server" Text='<%# Bind("option2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Option 3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbloption3" runat="server" Text='<%# Bind("option3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Option 4">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbloption4" runat="server" Text='<%# Bind("option4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Corect Answer">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcorrectans" runat="server" Text='<%# Bind("Correctanw") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Class">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClass" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="edit-button" CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="update-button" CommandName="Update" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cancel-button" CommandName="Cancel" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="delete-button" CommandName="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>

                                <div runat="server" id="formArea" visible="false">

                                    <form class="needs-validation">
                                        <div class="row">
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Enter Question*: </label>

                                                <asp:TextBox ID="txtQuestion" TextMode="MultiLine" runat="server"
                                                    placeholder="Enter Question" CssClass="dobcss"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                                    ControlToValidate="txtQuestion"
                                                    ErrorMessage="Enter Question"
                                                    ValidationGroup="questionBank"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Option 1*: </label>

                                                <asp:TextBox ID="txtopt1" CssClass="dobcss" runat="server" placeholder="Enter Option 1"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                                                    ControlToValidate="txtopt1"
                                                    ErrorMessage="Enter Option 1"
                                                    ValidationGroup="questionBank"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Option 2*: </label>

                                                <asp:TextBox ID="txtopt2" CssClass="dobcss" runat="server" placeholder="Enter Option 2"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                                                    ControlToValidate="txtopt2"
                                                    ErrorMessage="Enter Option 3"
                                                    ValidationGroup="questionBank"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Option 3*: </label>

                                                <asp:TextBox ID="txtopt3" CssClass="dobcss" runat="server" placeholder="Enter Option 3"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                                                    ControlToValidate="txtopt3"
                                                    ErrorMessage="Enter Option 3"
                                                    ValidationGroup="questionBank"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Option 4*: </label>

                                                <asp:TextBox ID="txtopt4" CssClass="dobcss" runat="server" placeholder="Enter Option 4"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5"
                                                    ControlToValidate="txtopt4"
                                                    ErrorMessage="Enter Option 4"
                                                    ValidationGroup="questionBank"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Correct Answer*: </label>

                                                <asp:TextBox ID="txtcorrect" CssClass="dobcss" runat="server" placeholder="Enter Correct Answer"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                                                    ControlToValidate="txtcorrect"
                                                    ErrorMessage="Enter  Correct Answer"
                                                    ValidationGroup="questionBank"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>



                                        <div class="row">
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Select Class*: </label>

                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="dobcss">
                                                    <asp:ListItem Value="0">-Select Class-</asp:ListItem>
                                                    <asp:ListItem Value="1">Class V</asp:ListItem>
                                                    <asp:ListItem Value="2">Class VI</asp:ListItem>
                                                    <asp:ListItem Value="3">Class VII</asp:ListItem>
                                                    <asp:ListItem Value="4">Class VIII</asp:ListItem>
                                                    <asp:ListItem Value="5">Class IX</asp:ListItem>
                                                    <asp:ListItem Value="6">Class X</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvClass"
                                                    ControlToValidate="ddlclass"
                                                    ErrorMessage="Select Class"
                                                    ValidationGroup="questionBank" InitialValue="0"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                <label for="role">Select Subject*: </label>

                                                <asp:DropDownList ID="ddlsubject" runat="server" CssClass="dobcss">
                                                    <asp:ListItem Value="0">-Select Subject-</asp:ListItem>
                                                    <asp:ListItem Value="1">English</asp:ListItem>
                                                    <asp:ListItem Value="2">EVS</asp:ListItem>
                                                    <asp:ListItem Value="3">Science</asp:ListItem>
                                                    <asp:ListItem Value="4">Mathematics</asp:ListItem>
                                                    <asp:ListItem Value="5">Social Science</asp:ListItem>
                                                    <asp:ListItem Value="6">ICT</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvSubject"
                                                    ControlToValidate="ddlsubject"
                                                    ErrorMessage="Select Subject"
                                                    ValidationGroup="questionBank" InitialValue="0"
                                                    Display="Dynamic"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>

                                                <%--  <div id="errddlcategory" style="display: none; color: red;"></div>--%>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-md-12 mb-3">

                                                <%--<asp:Button ID="addQuestion" runat="server" Text="Submit" ValidationGroup="questionBank" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                    OnClick="addQuestion_Click" />--%>
                                                <asp:Button ID="btnUpdate" runat="server" Visible="false" Text="Update" ValidationGroup="questionBank" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                    OnClick="btnUpdate_Click" />
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>

