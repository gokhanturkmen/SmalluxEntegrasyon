<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integrate.aspx.cs" Inherits="SmalluxEntegrasyon.integrate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <style>
        html, body {
            margin: 0;
            padding: 0;
            font: 14px "Segoe UI","Open Sans", Arial,sans-serif;
            zoom: 1;
            background: #fff;
        }

        a {
            color: #26E;
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }

        .wrapper {
            display: block;
            position: relative;
            margin: 10px;
            border: 1px solid #D0D0D0;
            background-color: #F5F5F5;
            padding: 10px;
            min-width: 240px;
            border-radius: 3px;
        }

        .hidden {
            display: none;
        }

        .block {
            display: block;
            position: relative;
            border: 1px dashed #CCC;
            background-color: #FFF;
            border-radius: 3px;
            padding: 10px;
            overflow: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <asp:Label ID="LblMessage" runat="server" Text="" CssClass="block"></asp:Label>
        <asp:Label ID="LblInner" runat="server" Text="" CssClass="block"></asp:Label>
        <asp:Label ID="LblFull" runat="server" Text="" CssClass="block"></asp:Label>
    </div>
    </form>
</body>
</html>
