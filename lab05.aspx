<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lab05.aspx.cs" Inherits="Laboratorio_05.lab05" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Laboratorio_07</title>
    <script type="text/javascript">

        function limpiar_contenido() {
            var vacio = "";
            document.getElementById("<%= nombre.ClientID %>").value = vacio;
            document.getElementById("<%= apellido.ClientID %>").value = vacio;
            var sexoList = document.getElementById("<%= sexoList.ClientID %>");
            var radioButtonListItems = sexoList.getElementsByTagName("input");
            for (var i = 0; i < radioButtonListItems.length; i++) {
                radioButtonListItems[i].checked = false;
            }
            document.getElementById("<%= email.ClientID %>").value = vacio;
            document.getElementById("<%= direccion.ClientID %>").value = vacio;
            document.getElementById("<%= ciudad.ClientID %>").value = "";
            document.getElementById("<%= requerimiento.ClientID %>").value = vacio;
            return false;
        }
        function validar_nombre() {
            let abc = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ abcdefghijklmnñopqrstuvwxyz";
            let t_abc = abc.length;
            let t_nombre = document.getElementById("nombre").value.length;
            let nombre = document.getElementById("nombre").value;
            let cont = 0;
            for (let i = 0; i < t_nombre; i++) {
                for (let j = 0; j < t_abc; j++) {
                    if (nombre[i] == abc[j])
                        cont += 1;
                }
            }
            if (cont == t_nombre && cont != 0)
                return true;
            else {
                alert("INDICAR NOMBRE CORRECTAMENTE");
                return false;
            }
        }
        function validar_apellido() {
            let abc = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ abcdefghijklmnñopqrstuvwxyz";
            let t_abc = abc.length;
            let t_nombre = document.getElementById("apellido").value.length;
            let nombre = document.getElementById("apellido").value;
            let cont = 0;
            for (let i = 0; i < t_nombre; i++) {
                for (let j = 0; j < t_abc; j++) {
                    if (nombre[i] == abc[j])
                        cont += 1;
                }
            }
            if (cont == t_nombre && cont != 0)
                return true;
            else {
                alert("INDICAR APELLIDO CORRECTAMENTE");
                return false;
            }
        }
        function validar_email() {
            let email = document.getElementById("<%= email.ClientID %>").value
            let obligatorio = "@unsa.edu.pe";
            if (email.includes(obligatorio)) {
                return true;
            }
            else {
                alert("INDICAR EMAIL CORRECTAMENTE");
                return false;
            }
        }
        function validar_sexo() {
            var sexoList = document.getElementById("<%= sexoList.ClientID %>");
            var Botonradio = sexoList.getElementsByTagName("input");
            var seleccionado = false;

            for (var i = 0; i < Botonradio.length; i++) {
                if (Botonradio[i].checked) {
                    seleccionado = true;
                    return true;
                }
            }

            if (!seleccionado) {
                alert("INDICAR SEXO");
                return false;
            }
        }

        function validar_ciudad() {
            let ciudad = document.getElementById("<%= ciudad.ClientID %>").value;
            if (ciudad !== "")
                return true;
            else {
                alert("SELECCIONE UNA CIUDAD");
                return false;
            }
        }
        function enviar_datos() {
            let Correcto = true;
            if (!validar_nombre()) {
                Correcto = false;
            }
            if (!validar_apellido()) {
                Correcto = false;
            }
            if (!validar_sexo()) {
                Correcto = false;
            }
            if (!validar_email()) {
                Correcto = false;
            }
            if (!validar_ciudad()) {
                Correcto = false;
            }
            if (Correcto) {
                let fecha = new Date().toLocaleString();
                alert("Usted se registro con la fecha de: " + fecha);
                
                return true;
            } else {
                return false;
            }
        }
        
    </script>
    <style>
        *{         
            font-family: 'Agency FB';
            font-size: 25px;
            border-radius: 20px;
        }
        body {
            background-image: url("https://wallpaperaccess.com/full/5669692.jpg");            
            background-repeat: repeat;
            background-size:  1350px;
            
            
        }
        h1 {
            text-shadow: 4px 3px black;
            color: white;
            font-size: 45px;
            width: 400px;
            text-align: center;
        }
        label{
            text-shadow: 2px 1px white;
            color: maroon;
            width: 100px;
            font-size: 30px;
            display: inline-flex;
            justify-content: flex-start;
        }
        input[type=text],select{
            background-color: darkslategray;
            color: white;
            width: auto;
            padding: 4px 10px;
            text-align: center;
        }
        form {
            background-color: rgba(240, 240, 240, 0.5);
            width: auto;
            padding: 20px;
            margin-inline-end: 650px;
            border: groove;

        }
        #requerimiento{
            background-color: darkslategrey;
            color: white;
            width: 50%;
        }
        #FF, #MM, #datosRegistro{
            color: white;
            background-color: darkslategrey;
        }
        #button1 {
            color: maroon;
            background-color: white;
            border: ridge;
            border-color: gray;
            padding: 16px 32px;
            margin: 4px 2px;
            cursor: pointer;            
        }
        #button2 {
            color: white;
            background-color: maroon;
            border: ridge;
            border-color: gray;
            padding: 16px 32px;
            margin: 4px 2px;
            cursor: pointer;         
            
        }
        .radio-list {
          display: inline-flex;
          align-items: center;
          gap: 10px;
        }
    </style>
</head>
<body>
    <h1>Registro de Alumnos</h1>
    <div class="todo">
    <form id="form1" runat="server">
        <div>
            <label for="Nombre">Nombres: </label>
            <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
        </div>
        
        <div>
            <label for="Apellido">Apellidos: </label>
            <asp:TextBox ID="apellido" runat="server"></asp:TextBox>
        </div>
        
        <div>
            <label for="sexo">Sexo: </label>
            <asp:RadioButtonList ID="sexoList" runat="server" RepeatLayout="Flow" CssClass="radio-list">
                <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        
        <div>
            <label for="email">Email: </label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
        
        <div>
            <label for="direccion">Direccion: </label>
            <asp:TextBox ID="direccion" runat="server"></asp:TextBox>
            <label for="ciudad">Ciudad: </label>
            <asp:DropDownList ID="ciudad" runat="server">
                <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div>            
            <asp:TextBox ID="requerimiento" runat="server" TextMode="MultiLine" Rows="3" Columns="11" placeholder="REQUERIMIENTO..."></asp:TextBox>
        </div>
        
        <div>
            <asp:Button id="button1" runat="server" Text="Limpiar" OnClientClick="return limpiar_contenido();"/>
            <asp:Button id="button2" runat="server" Text="Enviar" OnClientClick="var a = enviar_datos(); return a;" class="btn btn-success btn-lg" OnClick="ButtonEnviar_Click"/>
        </div>

        <asp:TextBox ID="datosRegistro" runat="server" TextMode="MultiLine" Rows="8" Columns="40" ReadOnly="true" Style="display: none;"></asp:TextBox>

    </form>
    </div>
</body>
</html>