

//$('#fechaAgenda').datetimepicker({
//    language: "es",
//    startDate: '0d',
//    weekStart: 0,
//    todayBtn: "linked",
//    todayHighlight: true,
//    daysOfWeekHighlighted: "0",
//    autoclose: true,
//    format: 'dd/mm/yyyy hh:ii'
//});

//$('#fechaAgenda').datetimepicker({
//    startDate: '0d',
//    autoclose: true,
//    format: 'mm/dd/yyyy HH:ii'
//});

var KTBootstrapDatetimepickerFormat = function () {

    // Private functions
    var demos = function () {

        $.fn.datepicker.dates['es'] = {
            days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sabado", "Domingo"],
            daysShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom"],
            daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa", "Do"],
            months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
            monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dec"],
            today: "Hoy",
            clear: "Limpear",
            format: "dd/mm/yyyy",
            titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
            weekStart: 0
        };

        $.fn.datetimepicker.dates['es'] = {
            days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"],
            daysShort: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom"],
            daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa", "Do"],
            months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
            monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
            today: "Hoy",
            suffix: [],
            meridiem: [],
            clear: "Limpear",
            format: "dd/mm/yyyy",
            titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
            weekStart: 0
        };

        //$.fn.datetimepicker.dates['es'] = {
        //    days: ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"],
        //    daysShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom"],
        //    daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa", "Do"],
        //    months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
        //    monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dec"],
        //    today: "Hoy",
        //    clear: "Limpear",
        //    format: "dd/mm/yyyy",
        //    titleFormat: "MM yyyy",
        //    weekStart: 0
        //};

        //$.fn.datetimepicker.dates['es-es'] = {
        //    days: ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"],
        //    daysShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
        //    daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
        //    months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
        //    monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dec"],
        //    today: "Hoy"
        //};

        //var f = new Date();

        //var hoy = new Date();
        //var dd = hoy.getDate();
        //var mm = hoy.getMonth() + 1; //hoy es 0!
        //var yyyy = hoy.getFullYear();

        //if (dd < 10) {
        //    dd = '0' + dd;
        //}

        //if (mm < 10) {
        //    mm = '0' + mm;
        //}

        //hoy = mm + '/' + dd + '/' + yyyy;

        //var hora = f.getHours();
        //var minuto = f.getMinutes();

        //str_hora = new String(hora);
        //str_minuto = new String(minuto);

        //if (str_hora.length == 1)
        //    hora = '0' + f.getHours();

        //if (str_minuto.length == 1)
        //    minuto = '0' + f.getMinutes();

        //tiempo = hora + ':' + minuto;

        //$('#fecha').datepicker({
        //    language: "es",
        //    startDate: '-1d',
        //    format: "dd/mm/yyyy",
        //    weekStart: 0,
        //    todayBtn: "linked",
        //    todayHighlight: true,
        //    daysOfWeekHighlighted: "0",
        //    autoclose: true,
        //    minDate: new Date(yyyy, dd - 1, mm)
        //});

    };

    return {
        // public functions
        init: function () {
            demos();
        }
    };
}();

jQuery(document).ready(function () {
    KTBootstrapDatetimepickerFormat.init();
});


