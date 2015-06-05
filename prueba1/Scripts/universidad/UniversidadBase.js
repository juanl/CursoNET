function isSafari() {
    return /^((?!chrome).)*safari/i.test(navigator.userAgent);
}

(function ($) {
    jQuery.validator.addMethod('esmayordeedad', function (value, element, params) {
        //var otherValue = hoy.setFullYear(new Date().getFullYear - 18);
        var fechanac = $(element).val();
        var isChrome = window.chrome;
        if (isChrome || isSafari()) {
            var d = value.split("/");
            fechanac = new Date(d[1] + "/" + d[0] + "/" + d[2]);
        }
        else {
            fechanac = new Date(fechanac);
        }
        var hoy = new Date();
        var dif = hoy - fechanac;
        var anios = new Date(dif).getFullYear() - 1970;
        return (anios >= 18);
    }, '');

    jQuery.validator.unobtrusive.adapters.add('esmayordeedad', ['allowequality'], function (options) {

        options.rules['esmayordeedad'] = { allowequality: options.params.allowequality };
        if (options.message) {
            options.messages['esmayordeedad'] = options.message;
        }
    });

    jQuery.validator.unobtrusive.adapters.add("brequired", function (options) {
        //b-required for checkboxes
        if (options.element.tagName.toUpperCase() == "INPUT" && options.element.type.toUpperCase() == "CHECKBOX") {
            //setValidationValues(options, "required", true);
            options.rules["required"] = true;
            if (options.message) {
                options.messages["required"] = options.message;
            }
        }
    });
})(jQuery);

function GetPartidoByIdProvincia() {
    var id = $("#Provincia").val();
    var bandera = false;
    if (id != null && id != '') {
        $.getJSON('/User/GetPartidoByIdProvincia', { IdProvincia: id }, function (partidos) {
            var Select = $('#IdPartido');
            Select.empty();
            if (partidos.length != 0) {

                $.each(partidos, function (index, item) {
                    Select.append($('<option/>', {
                        value: item.Value,
                        text: item.Text
                    }));
                });
            }
            else {

                bandera = true;
            }

        });
    }
    else {
        bandera = true;
    }
    if (bandera) {
        var Select = $('#IdPartido');
        Select.empty();
        Select.append($('<option/>', {
            value: 0,
            text: "Seleccione el partido en el que vive"
        }));
    }
    else {

    }

}

$('#Provincia').change(GetPartidoByIdProvincia);
