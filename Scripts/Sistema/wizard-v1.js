var KTWizardV1 = function () {
    // Base elements
    var wizardEl;
    var formEl;
    var validator;
    var wizard;

    // Private functions
    var initWizard = function () {
        var avatar = new KTAvatar('kt_user_avatar');
        // Initialize form wizard
        wizard = new KTWizard('kt_wizard_v1', {
            startStep: 1
        });

        // Validation before going to next page
        wizard.on('beforeNext', function (wizardObj) {
            if (validator.form() !== true) {
                wizardObj.stop();  // don't go to the next step
            }
        });

        wizard.on('beforePrev', function (wizardObj) {
            if (validator.form() !== true) {
                wizardObj.stop();  // don't go to the next step
            }
        });

        // Change event
        wizard.on('change', function (wizard) {
            setTimeout(function () {
                KTUtil.scrollTop();
            }, 500);
        });
    }

    var initValidation = function () {
        validator = formEl.validate({
            // Validate only visible fields
            ignore: ":hidden",

            // Validation rules
            rules: {
                //= Client Information(step 1)
                nombre: {
                    required: true
                },
                correo: {
                    required: true,
                    email: true
                },
                clave: {
                    required: true
                },
                tipo: {
                    required: true
                },

                //= Client Information(step 2)
                'ListaPerfil[]': {
                    required: true,
                    minlength: 1
                },

                //= Confirmation(step 3)
                accept: {
                    required: true
                }
            },

            // Validation messages
            messages: {
                tipo: { required: "Seleccione un tipo de usuario!"},
                accept: {
                    required: "Debe aceptar los términos y condiciones del acuerdo!"
                }
            },

            // Display error  
            invalidHandler: function (event, validator) {
                KTUtil.scrollTop();

                swal.fire({
                    "title": "",
                    "text": "Hay algunos errores en su envío. Por favor corríjalos.",
                    "type": "error",
                    "confirmButtonClass": "btn btn-secondary m-btn m-btn--wide"
                });
            },

            // Submit valid form
            submitHandler: function (form) {

            }
        });
    }

    var initSubmit = function () {
        var btn = formEl.find('[data-ktwizard-type="action-submit"]');
        btn.on('click', function (e) {
            e.preventDefault();

            if (validator.form()) {
                KTApp.progress(btn);
                KTApp.block(formEl);

                var options = {
                    target: '#output2',   // target element(s) to be updated with server response 
                    //beforeSubmit: showRequest,   pre-submit callback 
                    success: showResponse  // post-submit callback 
                }; 


                KTApp.unprogress(btn);
                KTApp.unblock(formEl);

                //formEl.ajaxSubmit(options); 

                formEl.ajaxSubmit({
                    success: function () {
                        var perfils = [];
                        var dataString = new FormData($("#kt_form").get(0));

                        $("input[name='ListaPerfil[]']:checked").each(function (index) {
                            //item = {};
                            //item['Id'] = $(this).val();
                            perfils.push($(this).val());
                        });

                        //var table = $('#tablaDetallado').DataTable();
                        //$.each(table.rows().data(), function (k, v) {
                        //    var idDetallado = v[0],
                        //        idProducto = v[1],
                        //        cantidad = v[3],
                        //        costo = v[4],
                        //        precio = v[5];

                        //    item = {};

                        //    if (idDetallado !== '') {
                        //        item['id'] = idDetallado;
                        //        item['idProducto'] = idProducto;
                        //        item['cantidad'] = cantidad;
                        //        item['cantidadsuministrada'] = 0;
                        //        item['costo'] = costo;
                        //        item['precio'] = precio;
                        //        datos.push(item);
                        //    }
                        //});
                       //JSON.stringify( {})

                        $.ajax({
                            type: "POST",
                            url: 'GuardarUsuario/',
                            dataType: "json",
                            data: dataString,
                            contentType: false,
                            processData: false,
                            success: function (resp) {
                                if (resp.mensaje == 1) {
                                    var objOrden = {
                                        'Id': resp.id
                                    };

                                    $.ajax({
                                        type: "POST",
                                        url: 'GuardaUsuarioPerfil/',
                                        dataType: "json",
                                        data: JSON.stringify({ model: objOrden, perfil: perfils }),
                                        contentType: "application/json; charset=utf-8",
                                        success: function (resp) {
                                            if (resp.mensaje == 1) {
                                                Swal.fire({
                                                    title: 'GUARDADO',
                                                    text: "GUARDADO EXITOSO.!!!",
                                                    type: 'success',
                                                    showCancelButton: false,
                                                }).then((result) => {
                                                    location.reload();
                                                    KTUtil.scrollTo("form", -200);
                                                });
                                            }
                                            else {
                                                swal.fire("USUARIO GUARDADO, ERROR AL GUARDAR PERFIL", "DETALLE: " + resp.errorMensaje + ".", "warning");
                                            }
                                        },
                                        error: function (xhr, desc, err) {
                                            swal.fire("VALIDAZACIÓN", "DETALLE: " + desc + "\nError: " + err + "\n" + xhr.responseText + ".", "error");
                                        }
                                    });
                                }
                                else {
                                    //setTimeout(function () {
                                    //    KTApp.unblock('#kt_form');
                                    //}, 500);

                                    KTUtil.scrollTo("form", -200);
                                    swal.fire("ERROR AL GUARDAR", resp.errorMensaje.toUpperCase() + ".", "warning");
                                }
                            },
                            error: function (xhr, desc, err) {
                                //setTimeout(function () {
                                //    KTApp.unblock('#kt_form');
                                //}, 500); 
                                //console.log(JSON.stringify(dataString));
                                console.log("Error: " + err + "\n" + xhr.responseText + " termino.");
                                //swal.fire("VALIDAZACIÓN", "DETALLE: " + desc + "\nError: " + err + "\n" + xhr.responseText + ".", "error");
                            }
                        });


                        KTApp.unprogress(btn);
                        KTApp.unblock(formEl);
                        //alert('ajaxSubmit');
                        //swal.fire({
                        //    "title": "",
                        //    "text": "La solicitud ha sido enviada con éxito!",
                        //    "type": "success",
                        //    "confirmButtonClass": "btn btn-secondary"
                        //});
                    }
                });
            }
        });
    }

    return {
        // public functions
        init: function () {
            wizardEl = KTUtil.get('kt_wizard_v1');
            formEl = $('#kt_form');

            initWizard();
            initValidation();
            initSubmit();
        }
    };
}();

function showResponse(responseText, statusText, xhr, $form) {
    // for normal html responses, the first argument to the success callback 
    // is the XMLHttpRequest object's responseText property 

    // if the ajaxSubmit method was passed an Options Object with the dataType 
    // property set to 'xml' then the first argument to the success callback 
    // is the XMLHttpRequest object's responseXML property 

    // if the ajaxSubmit method was passed an Options Object with the dataType 
    // property set to 'json' then the first argument to the success callback 
    // is the json data object returned by the server 

    alert('status: ' + statusText + '\n\nresponseText: \n' + responseText +
        '\n\nThe output div should have already been updated with the responseText.');
}

jQuery(document).ready(function () {
    KTWizardV1.init();
});