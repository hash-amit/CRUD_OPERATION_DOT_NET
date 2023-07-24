<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistrationForm.aspx.cs" Inherits="School.StudentRegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Full Name: </td>
                    <td><asp:TextBox ID="text_fullname" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Father's Name: </td>
                    <td><asp:TextBox ID="text_fathersname" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Class: </td>
                    <td><asp:DropDownList ID="textddl_class" runat="server"></asp:DropDownList></td>
                    <%--  The list for this Class field is coming form database --%>
                </tr>

                <tr>
                    <td>Gender: </td>
                    <td><asp:RadioButtonList ID="textrbl_gender" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
                    <%--  The list for this Gender field is coming form database --%>
                </tr>

                <tr>
                    <td>Age: </td>
                    <td><asp:TextBox ID="text_age" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Address: </td>
                    <td><asp:TextBox ID="text_address" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Mobile: </td>
                    <td><asp:TextBox ID="text_mobile" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Button ID="savebtn" runat="server" Text="Save" OnClick="savebtn_Click" /></td>
                </tr>

                <asp:GridView ID="gv_students" runat="server" AutoGenerateColumns="false" OnRowCommand="gv_students_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Student ID">
                            <ItemTemplate>
                                <%#Eval("ID") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("FULL_NAME") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Father's Name">
                            <ItemTemplate>
                                <%#Eval("FATHERS_NAME") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Class">
                            <ItemTemplate>
                                <%#Eval("CLASS_NUMBER") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Age">
                            <ItemTemplate>
                                <%#Eval("AGE") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <%#Eval("ADDRESS") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                <%#Eval("MOBILE") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("G_NAME") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="deletebtn" Text="Delete" runat="server" CommandName="D" CommandArgument='<%#Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="editbtn" Text="Edit" runat="server" CommandName="E" CommandArgument='<%#Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </table>
        </div>
    </form>
</body>
</html>
