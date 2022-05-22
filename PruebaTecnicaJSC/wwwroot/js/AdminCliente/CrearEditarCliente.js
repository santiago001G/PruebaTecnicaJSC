$('#PaisCodigo').change(function () {
    var id = $(this).val();
    $('#DepartamentoCodigo').find('option:not(:first)').remove();
    $('#MunicipioCodigo').find('option:not(:first)').remove();
    if (id) {
        $.ajax({
            url: UrlObtenerDepartamentos,
            data: { idPais: id },
            type: "JSON"
        }).done(function (json) {

            for (let i = 0; i < json.length; i++) {
                $('#DepartamentoCodigo').append($('<option>', {
                    value: json[i].dptColCodigoDane,
                    text: json[i].dptColNombredelDepartamento
                }));
            }
        });
    } 
});

$('#DepartamentoCodigo').change(function () {
    var id = $(this).val();
    $('#MunicipioCodigo').find('option:not(:first)').remove();
    if (id) {
        $.ajax({
            url: UrlObtenerDivisiones,
            data: { idDepartamento: id },
            type: "JSON"
        }).done(function (json) {
            for (let i = 0; i < json.length; i++) {
                $('#MunicipioCodigo').append($('<option>', {
                    value: json[i].dvsPltColCodigoDane,
                    text: json[i].dvsPltColNombreMunicipio
                }));
            }
        });
    }
});