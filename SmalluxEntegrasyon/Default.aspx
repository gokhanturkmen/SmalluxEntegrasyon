<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmalluxEntegrasyon.Default" %>

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
            display: none !important;
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
<body onkeypress="return KeyPressed(event)">
    <form id="form1" runat="server">
    <div class="wrapper">
        <span class="block">Enter what is necessary or simply close the page...</span>
        <a href="integrate.aspx?supplier=1" class="block hidden">Toptancınız.com XML</a>
        <a href="check.html" class="block hidden">Check</a>
    </div>
    </form>
    <script>
        function KeyPressed(e) {
            var keynum;

            if (window.event) { // IE                    
                keynum = e.keyCode;
            } else if (e.which) { // Netscape/Firefox/Opera                   
                keynum = e.which;
            }
            if (keynum == 115) {
                document.getElementsByTagName("a")[0].className = "block";
            }
        }
    </script>
</body>
</html>
