"use strict";
// Class definition

var KTFormWidgets = function () {
    // Private functions
    var validator;
    var initValidation = function () {
        validator = $("#kt_form").validate({
            // define validation rules
            rules: {
                Nombre: {
                    required: true
                },
                IdTipo: {
                    required: true,
                    min: 1
                },
                IdTipoUso: {
                    required: true,
                    min: 1
                },
                IdTipoCombustible: {
                    required: true,
                    min: 1
                },
                IdMarca: {
                    required: true,
                    min: 1
                },
                IdLinea: {
                    required: true,
                    min: 1
                },
                Llantas: {
                    required: true
                },
                Potencia: {
                    required: true
                },
                Modelo: {
                    required: true
                },
                Placas: {
                    required: true
                },
                Serial: {
                    serial: true,
                    minlength: 16,
                    maxlength: 18
                }

            },

            //display error alert on form submit  
            invalidHandler: function (event, validator) {
                var alert = $('#kt_form_msg');
                alert.parent().removeClass('kt-hide');
                swal.fire({
                    "title": "",
                    "text": "HAY ALGUNOS ERRORES EN SU ENVÍO. POR FAVOR CORRÍJALOS.",
                    "type": "error",
                    "confirmButtonClass": "btn btn-secondary kt-btn kt-btn--wide",
                    "onClose": function (e) {
                        KTUtil.scrollTo("form", -200);
                    }
                });
            },

            submitHandler: function (form) {
                KTApp.block('#kt_form', {
                    overlayColor: '#000000',
                    type: 'v2',
                    state: 'primary',
                    message: 'Procesando...'
                });
                var radio = $("input[name='Rendimiento']:checked").val();

                //$("input[name='Rendimiento']:radio").change(function () {
                //    radio = $(this).val();
                //});

                var objOrden = {
                    'Id': $("#Id").val(),
                    'Nombre': $("#Nombre").val(),
                    'IdTipo': $("#IdTipo").val(),
                    'IdTipoUso': $("#IdTipoUso").val(),
                    'IdTipoCombustible': $("#IdTipoCombustible").val(),
                    'Potencia': $("#Potencia").val(),
                    'IdMarca': $("#IdMarca").val(),
                    'Llantas': $("#Llantas").val(),
                    'IdLinea': $("#IdLinea").val(),
                    'Modelo': $("#Modelo").val(),
                    'Placas': $("#Placas").val(),
                    'Serial': $("#Serial").val(),
                    'IdAccesorio': $("#IdAccesorio").val()
                };

                var dataString = new FormData($("#kt_form").get(0));

                $.ajax({
                    type: "POST",
                    url:"GuardarVehiculo",
                    //url: '@Url.Action("GuardarVehiculo", "Vehiculo")',
                    dataType: "json",
                    data: dataString,
                    contentType: false,
                    processData: false,
                    success: function (resp) {
                        
                        if (resp.mensaje == 1) {
                            Swal.fire({
                                title: 'GUARDADO',
                                text: "VEHÍCULO GUARDADO.!!!",
                                type: 'success',
                                showCancelButton: false,
                            }).then((result) => {
                                clear();
                                setTimeout(function () {
                                    KTApp.unblock('#kt_form');
                                }, 500);
                                KTUtil.scrollTo("form", -200);
                            });
                        }
                        else {
                            setTimeout(function () {
                                KTApp.unblock('#kt_form');
                            }, 500);
                            
                            KTUtil.scrollTo("form", -200);
                            swal.fire("ERROR AL GUARDAR", resp.errorMensaje.toUpperCase() + ".", "warning");
                        }
                    },
                    error: function (xhr, desc, err) {
                        setTimeout(function () {
                            KTApp.unblock('#kt_form');
                        }, 500);
                        //swal.fire("VALIDAZACIÓN", "DETALLE: " + desc + "\nError: " + err + "\n" + xhr.responseText + ".", "error");
                        alert("DETALLE: " + desc + "\nError: " + err + "\n" + xhr.responseText + ".");
                    }
                });

                return false;
            }
        });
    }

    return {
        // public functions
        init: function () {
            initValidation();
        }
    };
}();

jQuery(document).ready(function () {
    KTFormWidgets.init();
});