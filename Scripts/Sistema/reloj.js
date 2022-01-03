(function () {
    var actualizarHora = function () {
        $.post('./home/do', {}, function (result) {
            var pReloj = document.getElementById('reloj');
            var strDate = result;
            pReloj.textContent = strDate;
        });
        //var fecha = new Date();
        //var ampm = '';
        //var horas = fecha.getHours();
        //var minutos = fecha.getMinutes();
        //var segundos = fecha.getSeconds();

        //var pReloj = document.getElementById('reloj');

        //if (horas >= 12) {
        //    horas = horas - 12;
        //    ampm = 'PM';
        //} else {
        //    ampm = 'AM';
        //}

        //if (horas == 0) {
        //    horas = 12;
        //}

        //if (minutos < 10) {
        //    minutos = '0' + minutos;
        //}

        //if (segundos < 10) {
        //    segundos = '0' + segundos;
        //}
        //console.log(segundos);

        ////var d = new Date();
        //var d = new Date(@{ DateTime.Now() });
        ////var strDate = d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();
        //var strDate = (d.getDate() < 10 ? '0' + d.getDate() : d.getDate()) + "/" + ((d.getMonth() + 1) < 10 ? '0' + (d.getMonth() + 1) : (d.getMonth() + 1)) + "/" + d.getFullYear() + " " + d.getHours() + ":" + (d.getMinutes() < 10 ? '0' + d.getMinutes() : d.getMinutes()) + ":" + (d.getSeconds() < 10 ? '0' + d.getSeconds() : d.getSeconds()) + ' ' + (d.getHours() >= 12 ? 'PM' : 'AM');
        ////+ " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
        //pReloj.textContent = strDate;// + ' ' + horas + ':' + minutos + ":" + segundos+ ' ' + ampm;

    };

    actualizarHora();

    //var intervalo = setInterval(actualizarHora(), 1000);
    setInterval(actualizarHora, 1000);

}());