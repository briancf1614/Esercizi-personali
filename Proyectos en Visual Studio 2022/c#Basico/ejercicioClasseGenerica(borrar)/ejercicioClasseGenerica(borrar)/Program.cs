using ejercicioClasseGenerica_borrar_;
using ejercicioClasseGenerica_borrar_.Escuela;
using ejercicioClasseGenerica_borrar_.Trabajadores;

AlmacenDePersonas<Camarero> trabajador = new AlmacenDePersonas<Camarero>(3);

trabajador.agregar(new Camarero(3455));
trabajador.agregar(new Camarero(3456));
trabajador.agregar(new Camarero(4563));
trabajador.agregar(new Camarero(3453));
trabajador.agregar(new Camarero(9834));
