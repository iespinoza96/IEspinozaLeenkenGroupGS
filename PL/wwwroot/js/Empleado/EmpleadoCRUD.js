$(document).ready(function () {
    GetAll();

});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:44104/api/Empleado/getall',

        success: function (result) { //200 OK
            $('#tblEmpleado tbody').empty();//SELECTOR POR ID
            $.each(result.objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a class="btn btn-warning bi bi-pencil-fill" href="#" onclick="GetById(' + empleado.idEmpleado + ')">'

                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + empleado.idEmpleado + "</td>"
                    + "<td  id='id' class='text-center'>" + empleado.numeronomina + "</td>"
                    + "<td class='text-center'>" + empleado.nombre + "</td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.estado.idEstado + "</td>"
                    + "<td class='text-center'>" + empleado.estado.nombre + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + empleado.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tblEmpleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Add() {

    //var empleado = {
    //    IdEmpleado: 0,
    //    NumeroNomina: $('#txtNumeroNomina').val(),
    //    Nombre: $('#txtNombre').val(),
    //    ApellidoPaterno: $('#txtApellidoPaterno').val(),
    //    ApellidoMaterno: $('#txtApellidoMaterno').val(),
    //    Estado: {
    //        IdEstado: $('#ddlEstado').val()
    //    }
    //}

    var empleadoJSON = {
        "idEmpleado": 0,
        "numeroNomina": $('#txtNumeroNomina').val(),
        "nombre": $('#txtNombre').val(),
        "apellidoPaterno": $('#txtApellidoPaterno').val(),
        "apellidoMaterno": $('#txtApellidoMaterno').val(),
        "estado": {
            "idEstado": $('#ddlEstado').val(),
            "nombre": "string",
            "estados": [
                "string"
            ]
        },
        
    }
   /* var json = JSON2.stringify(empleadoJSON); */
    $.ajax({
        type: 'POST',
        url: 'http://localhost:44104/api/Empleado/add',
        dataType: 'json',
        data: empleadoJSON,
        //contentType: "application/json; charset=utf-8",

        success: function (result) {
            $('#myModal').modal();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function CategoriaGetAll() {
    $("#ddlCategorias").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:14982/api/Categoria/GetAll',
        success: function (result) {
            $("#ddlCategorias").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, categoria) {
                $("#ddlCategorias").append('<option value="'
                    + categoria.IdCategoria + '">'
                    + categoria.Descripcion + '</option>');
            });
        }
    });
}