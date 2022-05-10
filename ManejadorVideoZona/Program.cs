using Practico1Definitivo.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorVideoZona
{
    class Program
    {
        static void Main(string[] args)
        //Le robo el menu profe muy bueno 
        {
        IngresoOpcionMenu:
            DibujarMenuPrincipal();
            int opcionMenuPrinciapal = ProcesarOpcionMenuPrincipal();

            switch (opcionMenuPrinciapal)
            {
                case 0:
                    altaCliente();
                    goto IngresoOpcionMenu;
                case 1:
                    altaPelicula();
                    goto IngresoOpcionMenu;
                case 2:
                    altaCopia();
                    goto IngresoOpcionMenu;
                case 3:
                    registrarAlquiler();
                    goto IngresoOpcionMenu;
                case 4:
                    actualizarAlquiler();
                    goto IngresoOpcionMenu;
                case 5:
                    actualizarCopia();
                    goto IngresoOpcionMenu;
                case 6:

                    IngresoOpcionMenuSecundario:
                    DibujarMenuSecundario();
                    int opcionMenuSecundario = ProcesarOpcionMenuSecundario();

                    switch (opcionMenuSecundario)
                    {
                        case 0:
                            copiasEnStock();
                            goto IngresoOpcionMenuSecundario;
                        case 1:
                            clientesRegistrados();
                            goto IngresoOpcionMenuSecundario;
                        case 2:
                            copiasDisponibles();
                            goto IngresoOpcionMenuSecundario;
                        case 3:
                            historialAlquileres();
                            Console.ReadLine();
                            goto IngresoOpcionMenuSecundario;
                        case 4:
                            historialAlquileresCliente();
                            Console.ReadLine();
                            goto IngresoOpcionMenuSecundario;
                        case 5:
                            alquileresActivos();
                            Console.ReadLine();
                            goto IngresoOpcionMenuSecundario;
                        case 6:
                            alquileresActivosFechaTope();
                            goto IngresoOpcionMenuSecundario;

                        case 7:
                            goto IngresoOpcionMenu;
                        default:
                            goto IngresoOpcionMenu;
                    }

                    
                default:
                    goto IngresoOpcionMenu;
            }
        }

        private static void DibujarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("0.Alta Cliente");
            Console.WriteLine("1.Alta Pelicula");
            Console.WriteLine("2.Alta Copia");
            Console.WriteLine("3.Registrar Alquiler");
            Console.WriteLine("4.Actualizar Alquiler");
            Console.WriteLine("5.Actualizar Copia");
            Console.WriteLine("6.Consultas");


            Console.WriteLine("");
        }

        private static void DibujarMenuSecundario()
        {
            Console.Clear();

            Console.WriteLine("0.Copias en stock");
            Console.WriteLine("1.Clientes registrados");
            Console.WriteLine("2.Copias disponibles");
            Console.WriteLine("3.Historial de alquileres");
            Console.WriteLine("4.Historial de alquileres de un cliente");
            Console.WriteLine("5.Alquileres activos");
            Console.WriteLine("6.Alquileres activos pasada la fecha limite");
            Console.WriteLine("7.Volver");



            Console.WriteLine("");
        }

        private static int ProcesarOpcionMenuPrincipal()
        {
            int opcion = -1;
            string inputUsuario = string.Empty;

            do
            {
                Console.WriteLine("Ingrese la opcion deseada");

                inputUsuario = Console.ReadLine();

                if (int.TryParse(inputUsuario, out opcion) && opcion >= 0 && opcion <= 6)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    DibujarMenuPrincipal();
                }

            } while (true);

            return opcion;
        }

        private static int ProcesarOpcionMenuSecundario()
        {
            int opcion = -1;
            string inputUsuario = string.Empty;

            do
            {
                Console.WriteLine("Ingrese la opcion deseada");

                inputUsuario = Console.ReadLine();

                if (int.TryParse(inputUsuario, out opcion) && opcion >= 0 && opcion <= 7)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    DibujarMenuSecundario();
                }

            } while (true);

            return opcion;
        }

        private static void altaCliente()
        {
            Console.Clear();

            Console.WriteLine("Ingrese el nombre del cliente");
            string nombreCliente = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del cliente");
            string apellidoCliente = Console.ReadLine();

            Console.WriteLine("Ingrese la direccion del cliente");
            string direccionCliente = Console.ReadLine();

            Console.WriteLine("Ingrese el documento del cliente");
            int documentoCliente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el correo del cliente");
            string correoCliente = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono del cliente");
            int telefonoCliente = int.Parse(Console.ReadLine());

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Clientes nuevoCliente = new Clientes()
                        {
                            Nombre = nombreCliente,
                            Apellido = apellidoCliente,
                            Direccion = direccionCliente,
                            DocumentoIdentidad = documentoCliente.ToString(),
                            Correo = correoCliente,
                            Telefono = telefonoCliente.ToString()
                        };

                        context.Clientes.Add(nuevoCliente);
                        context.SaveChanges();

                        transaction.Commit();

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void altaPelicula()
        {
            Console.Clear();

            Console.WriteLine("Ingrese el titulo de la pelicula");
            string tituloPelicula = Console.ReadLine();

            Console.WriteLine("Ingrese el año de la pelicula");
            int anioPelicula = int.Parse(Console.ReadLine());

        CalificarPelicua:
            Console.WriteLine("Ingrese la calificacion de la pelicula");
            int calificacionPelicula = int.Parse(Console.ReadLine());



            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (calificacionPelicula > 10 || calificacionPelicula < 1)
                        {
                            goto CalificarPelicua;
                        }

                        Peliculas nuevaPelicula = new Peliculas()
                        {
                            Titulo = tituloPelicula,
                            Anio = anioPelicula,
                            Calificacion = calificacionPelicula,

                        };

                        context.Peliculas.Add(nuevaPelicula);
                        context.SaveChanges();

                        transaction.Commit();

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void altaCopia()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                    SeleccionarPelicula:
                        Console.WriteLine("Ingrese el ID de la pelicula");
                        string Formato = string.Empty;
                        int idPelicula = int.Parse(Console.ReadLine());
                        var Pelicula = context.Peliculas.FirstOrDefault(p => p.Id == idPelicula);
                        if (Pelicula == null)
                        {
                            goto SeleccionarPelicula;
                        }
                    SeleccionarFormato:

                        Console.WriteLine("Seleccione Formato de la copia 1)DVD 2)BluRay");
                        int formatoIngreasdo = int.Parse(Console.ReadLine());
                        if (formatoIngreasdo == 1)
                        {
                            Formato = "DVD";
                        }
                        else if (formatoIngreasdo == 2)
                        {
                            Formato = "BluRay";
                        }
                        else
                        {
                            goto SeleccionarFormato;
                        }

                        //Precio Copia
                        //Calculo que las copias de las mismma pelicula salen lo mismo idk
                        var copia = context.Copias.FirstOrDefault(c => c.IdPelicula == idPelicula);
                        Copias nuevaCopia = new Copias()
                        {
                            IdPelicula = idPelicula,
                            Deteriorada = false,
                            Formato = Formato,
                            PrecioAlquiler = copia.PrecioAlquiler

                        };

                        context.Copias.Add(nuevaCopia);
                        context.SaveChanges();

                        transaction.Commit();

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void registrarAlquiler()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                    SeleccionarCopia:
                        Console.WriteLine("Ingrese el ID de la copia para alquilar");
                        int idCopia = int.Parse(Console.ReadLine());
                        
                        if (copiaDisponible(idCopia) == false)
                        {
                            goto SeleccionarCopia;
                        }

                    SeleccionarClienteAlquiler:
                        Console.WriteLine("Ingrese el ID del cliente");
                        int idCliente = int.Parse(Console.ReadLine());
                        var Cliente = context.Clientes.FirstOrDefault(c => c.Id == idCliente);
                        if (Cliente == null)
                        {
                            goto SeleccionarClienteAlquiler;
                        }
                        DateTime fechaAlquiler = DateTime.Now;

                        DateTime fechaTope = fechaAlquiler.AddDays(+3);

                        Alquileres nuevoAlquiler = new Alquileres()
                        {
                            FechaAlquiler = fechaAlquiler,
                            FechaTope = fechaTope,
                            IdCopia = idCopia,
                            IdCliente = idCliente

                        };

                        context.Alquileres.Add(nuevoAlquiler);
                        Console.ReadLine();
                        context.SaveChanges();

                        transaction.Commit();

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void actualizarAlquiler()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        //Listar alquileres activos
                        var alquileresActivos = context.Alquileres.Include("Clientes").Where(a => a.FechaEntregada == null).ToList();

                        foreach (Alquileres aux in alquileresActivos)
                        {
                            Console.WriteLine("ID Alquiler :" + aux.Id + " Cliente: " + aux.Clientes.Nombre + " " + aux.Clientes.Apellido + " Fecha de alquiler: " + aux.FechaAlquiler + " Fecha tope: " + aux.FechaTope);
                        }
                    SeleccionarAlquiler:
                        Console.WriteLine("Ingrese el ID del alquiler para entregar");
                        int idAlquiler = int.Parse(Console.ReadLine());
                        var Alquiler = context.Alquileres.FirstOrDefault(a => a.Id == idAlquiler);
                        if (Alquiler == null)
                            goto SeleccionarAlquiler;

                        DateTime FechaEntregada = DateTime.Now;

                        Alquiler.FechaEntregada = FechaEntregada;

                        context.SaveChanges();

                        transaction.Commit();

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void actualizarCopia()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                    SeleccionarCopia:
                        Console.WriteLine("Ingrese el ID de la copia para actualizar el estado");
                        int idCopia = int.Parse(Console.ReadLine());

                        var Copia = context.Copias.FirstOrDefault(c => c.Id == idCopia);

                        if (Copia == null)
                            goto SeleccionarCopia;
                        SeleccionarOpcion:
                        Console.WriteLine("Seleccione opcion: 0)Buen estado 1)Deteriorada");
                        int Opcion = int.Parse(Console.ReadLine());

                        if (Opcion == 0)
                        {
                            Copia.Deteriorada = false;
                        }
                        else if (Opcion == 1)

                        {
                            Copia.Deteriorada = true;
                        }
                        else
                        {
                            goto SeleccionarOpcion;
                        }

                        context.SaveChanges();

                        transaction.Commit();

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void copiasEnStock()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var stockCopias = context.Copias.Include("Peliculas");
                        foreach (Copias aux in stockCopias)
                        {
                            Console.WriteLine("ID copia: " + aux.Id + " " + "Titulo: " + aux.Peliculas.Titulo + " " + "Año: " + aux.Peliculas.Anio + " " + "Clasificacion: " + aux.Peliculas.Calificacion);
                        }

                        Console.ReadLine();


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void clientesRegistrados()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        
                        foreach (Clientes aux in context.Clientes)
                        {
                            Console.WriteLine("ID cliente: " + aux.Id + " " + "Nombre: " + aux.Nombre + " " +aux.Apellido  + " " + "Direccion: " + aux.Direccion + " " + "Documento: " + aux.DocumentoIdentidad + " " + "Correo: " +aux.Correo + " " + "Telefono: " + aux.Telefono);
                        }

                        Console.ReadLine();


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void copiasDisponibles()
        {
            Console.Clear();

            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var copiasDisponibles = context.Copias.Include("Peliculas").ToList();
                        foreach (Copias aux in context.Copias)
                        {
                            if (copiaDisponible(aux.Id) == false)
                            {
                                copiasDisponibles.Remove(aux);
                            }
                        }

                        foreach(Copias aux in copiasDisponibles)
                        {
                            Console.WriteLine("ID copia: " + aux.Id + " " + "Titulo: " + aux.Peliculas.Titulo + " " + "Año: " + aux.Peliculas.Anio + " " + "Clasificacion: " + aux.Peliculas.Calificacion);
                        }

                        Console.ReadLine();




                        context.SaveChanges();

                        transaction.Commit();

                        Console.ReadLine();


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static bool copiaDisponible(long idCopia)
        {
            bool disponible = false;
            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //No existe
                        if (!context.Copias.Any(a => a.Id == idCopia))
                        {
                            return disponible;
                        }
                        //Si no esta en alquileres esta disponible
                        if (!context.Alquileres.Any(a => a.IdCopia == idCopia))
                        {
                            disponible = true;
                        }
                        //Si tiene todas tienen fecha de entrega esta disponible
                        else
                        {
                            var ListaAlquileres = context.Alquileres.Where(a => a.IdCopia == idCopia).ToList();
                            disponible = ListaAlquileres.All(x => x.FechaEntregada != null);
                        }
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
                return disponible;
        }

        public static void historialAlquileres()
        {
            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var alquileres = context.Alquileres.Include("Copias").Include("Clientes");
                        foreach (Alquileres aux in alquileres)
                        {

                            Console.WriteLine("ID alquiler: " + aux.Id + " Fecha alquiler: " +aux.FechaAlquiler+ " Fecha tope: "+aux.FechaTope+ " Fecha entrega: "+ aux.FechaEntregada + " Pelicula: "+ aux.Copias.Peliculas.Titulo + " Formato: " + aux.Copias.Formato );
                            Console.WriteLine("Nombre cliente: " + aux.Clientes.Nombre + " " + aux.Clientes.Apellido + " Contacto: " + aux.Clientes.Correo + " " + aux.Clientes.Telefono + " ID cliente: " + aux.Clientes.Id);
                            Console.WriteLine("------------------------------------------------------------");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public static void historialAlquileresCliente()
        {
            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        seleccionarCliente:
                        Console.WriteLine("Ingrese ID cliente para ver sus alquileres");
                        long idCliente = long.Parse(Console.ReadLine());
                        var alquileresCliente = context.Alquileres.Include("Copias").Include("Clientes").Where(c => c.IdCliente == idCliente).OrderBy(a => a.FechaEntregada).ToList();
                        if (alquileresCliente.Count == 0)
                            goto seleccionarCliente;
                        foreach (Alquileres aux in alquileresCliente)
                        {

                            Console.WriteLine("ID alquiler: " + aux.Id + " Fecha alquiler: " + aux.FechaAlquiler + " Fecha tope: "+ aux.FechaTope + " Fecha entrega: " + aux.FechaEntregada + " Pelicula: " + aux.Copias.Peliculas.Titulo + " Formato: " + aux.Copias.Formato);
                            Console.WriteLine("Nombre cliente: " + aux.Clientes.Nombre + " " + aux.Clientes.Apellido + " Contacto: " + aux.Clientes.Correo + " " + aux.Clientes.Telefono + " ID cliente: " + aux.Clientes.Id);
                            Console.WriteLine("------------------------------------------------------------");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public static void alquileresActivos()
        {
            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var alquileresActivos = context.Alquileres.Include("Copias").Include("Clientes").Where(a => a.FechaEntregada == null).ToList();
                        foreach (Alquileres aux in alquileresActivos)
                        {

                            Console.WriteLine("ID alquiler: " + aux.Id + " Fecha alquiler: " + aux.FechaAlquiler + " Fecha tope: " + aux.FechaTope + " Fecha entrega: " + aux.FechaEntregada + " Pelicula: " + aux.Copias.Peliculas.Titulo + " Formato: " + aux.Copias.Formato);
                            Console.WriteLine("Nombre cliente: " + aux.Clientes.Nombre + " " + aux.Clientes.Apellido + " Contacto: " + aux.Clientes.Correo + " " + aux.Clientes.Telefono + " ID cliente: " + aux.Clientes.Id);
                            Console.WriteLine("------------------------------------------------------------");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void alquileresActivosFechaTope()
        {
            using (var context = new Acceso())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        DateTime fechaActual = DateTime.Now;
                        var alquileresActivos = context.Alquileres.Include("Copias").Include("Clientes").Where(a => a.FechaEntregada == null && a.FechaTope < fechaActual).ToList();
                        foreach (Alquileres aux in alquileresActivos)
                        {

                            Console.WriteLine("ID alquiler: " + aux.Id + " Fecha alquiler: " + aux.FechaAlquiler + " Fecha tope: " + aux.FechaTope + " Fecha entrega: " + aux.FechaEntregada + " Pelicula: " + aux.Copias.Peliculas.Titulo + " Formato: " + aux.Copias.Formato);
                            Console.WriteLine("Nombre cliente: " + aux.Clientes.Nombre + " " + aux.Clientes.Apellido + " Contacto: " + aux.Clientes.Correo + " " + aux.Clientes.Telefono + " ID cliente: " + aux.Clientes.Id);
                            Console.WriteLine("------------------------------------------------------------");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }

}


