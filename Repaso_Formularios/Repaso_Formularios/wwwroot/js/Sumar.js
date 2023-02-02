document.getElementById("btnSumar").onclick = function () {

    var numeroUno = parseFloat(document.getElementById("txtNumeroUno").value);
    var numeroDos = parseFloat(document.getElementById("txtNumeroDos").value);
    var suma = numeroUno + numeroDos;
    document.getElementById("lblResultado").innerHTML = `La suma es: ${suma}`;

}

document.getElementById("btnLimpiar").onclick = function () {

    document.getElementById("txtNumeroUno").value = "";
    document.getElementById("txtNumeroDos").value = "";
    document.getElementById("lblResultado").innerHTML = "";

}