function pintar(objConfiguracion) {


    fetch(objConfiguracion.url)
        .then(res => res.json())
        .then(res => {
            var contenido = "<table class='table'>";
            contenido += "<tr>";
            for (var i = 0; i < objConfiguracion.cabeceras.length; i++) {
                contenido += "<th>" + objConfiguracion.cabeceras[i]+"</th>";
            }
            contenido += "</tr>";
            var fila;
            var propiedadActual;
            for (var i = 0; i < res.length; i++) {
                fila = res[i]
                contenido += "<tr>";
                for (var j = 0; j < objConfiguracion.propiedades.length; j++) {
                    propiedadActual = objConfiguracion.propiedades[j]

                    contenido += "<td>" + fila[propiedadActual] + "</td>";

                }
                //contenido += "<td>" + fila.id + "</td>";    //equivalente: fila["id"] 
                //contenido += "<td>" + fila.nombre + "</td>";
                //contenido += "<td>" + fila.descripcion + "</td>";
                contenido += "</tr>";
            }

            contenido += "</table > ";
            document.getElementById(objConfiguracion.id).innerHTML = contenido;


        })

}