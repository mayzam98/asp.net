//consumo
window.onload = function () {
    //listarTipoHabitacion();
}
//[{"id":1,"nombre":"simple","descripcion":"Solo para uno"},{"id":1,"nombre":"doble","descripcion":"Para dos"}]
function listarTipoHabitacion() {
    //Metodo generico para pintar tablas
    pintar({
        url: "TipoHabitacion/lista", id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    });
}