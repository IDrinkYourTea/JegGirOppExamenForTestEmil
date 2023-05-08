<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JSONOppgava.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Emils vær</h1>
            Temperaturen nå i den ene byen, Fredrikstad: <asp:Label ID="LabelTempNow" runat="server" Text="TempNowValue"></asp:Label> celsius
            <br />
            <br />
            Vindstyrke nå i den ene byen, Fredrikstad: <asp:Label ID="LabelStyrkeNow" runat="server" Text="StyrkeNowValue"></asp:Label> m/s
            <br />
            <br />
            Vindretningen nå i den ene byen, Fredrikstad: <asp:Label ID="LabelRetningNow" runat="server" Text="RetningNowValue"></asp:Label> degrees
            <br />
            <br />
            Temp °C, Styrke m/s og Retning ° er i den ene byen, Fredrikstad: <asp:Label ID="LabelThreeNow" runat="server" Text="ThreeNowValue"></asp:Label> 
        </div>
    </form>
</body>
</html>
