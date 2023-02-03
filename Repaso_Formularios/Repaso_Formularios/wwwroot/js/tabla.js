$.get("RepasoHtml/ListarPersonas", function (data) {
    var contenido = "";

    contenido += "<table class = 'table'>";

    contenido += "<thead>";
    contenido += "<tr>";
    contenido += "<th>Id Persona</th>";
    contenido += "<th>Nombre</th>";
    contenido += "<th>Apellido</th>";
    contenido += "</tr>";
    contenido += "</thead>";

    contenido += "<tbody >";
    var filas = data.length;
    for (var i = 0; i < filas; i++) {
        contenido += "<tr>";

        contenido += "<td>" + data[i].idPersona + "</td> ";
        contenido += "<td>" + data[i].nombre + "</td> ";
        contenido += "<td>" + data[i].apellido + "</td> ";

        contenido += "</tr>";
    }

    contenido += "</tbody >";

    contenido += "</table>";

    document.getElementById("divTabla").innerHTML = contenido;

});