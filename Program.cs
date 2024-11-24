using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;


namespace Trabajo
{
    internal class Program
    {
        static string connectionString = "Server=localhost;Database=Biblioteca1;User=root;";

        static void Main(string[] args)
        {
            crearautotabla();
            int opcionPrincipal;

            do
            {
                Console.Clear();
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Usuarios");
                Console.WriteLine("2. Libros");
                Console.WriteLine("3. Prestamos");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out opcionPrincipal) || opcionPrincipal < 1 || opcionPrincipal > 4)
                {
                    Console.Write("Entrada inválida. Por favor, seleccione una opción entre 1 y 4: ");
                }

                switch (opcionPrincipal)
                {
                    case 1:
                        UsuariosMenu1();
                        break;
                    case 2:
                        LibrosMenu2();
                        break;
                    case 3:
                        PrestamosMenu3();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                }

                if (opcionPrincipal != 4)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcionPrincipal != 4);
        }
        static void UsuariosMenu1()
        {
            int subOpcion;
            do
            {
                Console.Clear();
                Console.WriteLine("--Usuarios--");
                Console.WriteLine("1. Agregar Usuario");
                Console.WriteLine("2. Buscar Usuario");
                Console.WriteLine("3. Actualizar Usuario");
                Console.WriteLine("4. Borrar Usuario");
                Console.WriteLine("5. Mostrar Usuarios");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out subOpcion) || subOpcion < 1 || subOpcion > 6)
                {
                    Console.Write("Entrada inválida. Por favor, seleccione una opción entre 1 y 6: ");
                }

                switch (subOpcion)
                {
                    case 1:
                        AgregarUsuario();
                        break;
                    case 2:
                        BuscarUsuarios();
                        break;
                    case 3:
                        MenuActualizarUsuario();
                        break;
                    case 4:
                        Estado();
                        break;
                    case 5:
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            MostrarUsuarios(conn);
                        }
                        break;
                    case 6:
                        break;
                }

                if (subOpcion != 6)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (subOpcion != 6);
        }
        static void LibrosMenu2()
        {
            int subOpcion;
            do
            {
                Console.Clear();
                Console.WriteLine("--Libros--");
                Console.WriteLine("1. Agregar Libros");
                Console.WriteLine("2. Agregar Genero");
                Console.WriteLine("3. Agregar Autor");
                Console.WriteLine("4. Buscar Libros");
                Console.WriteLine("5. Actulizar Libro");
                Console.WriteLine("6. Mostrar Libros");
                Console.WriteLine("7. Mostrar generos");
                Console.WriteLine("8. Borrar Libro");
                Console.WriteLine("9. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out subOpcion) || subOpcion < 1 || subOpcion > 9)
                {
                    Console.Write("Entrada inválida. Por favor, seleccione una opción entre 1 y 9: ");
                }

                switch (subOpcion)
                {
                    case 1:
                        MenuAgregarLibros();
                        break;
                    case 2:
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            AgregarGenero(conn);
                        }
                        break;
                    case 3:
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            AgregarAutor(conn);
                        }
                        break;
                    case 4:
                        BuscarLibros();
                        break;
                    case 5:
                        ActualizarLibro();
                        break;
                    case 6:
                        MostrarLibros();
                        break;
                    case 7:
                        EliminarLibro();
                        break;
                    case 8:
                        MostrarGenerosEnTabla();
                        break;
                    case 9:
                        break;
                }

                if (subOpcion != 9)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (subOpcion != 9);
        }
        static void PrestamosMenu3()
        {
            int subOpcion;
            do
            {
                Console.Clear();
                Console.WriteLine("-Prestamos--");
                Console.WriteLine("1. Agregar Prestamo");
                Console.WriteLine("2. Fecha de devolucio");
                Console.WriteLine("3. Buscar Prestamo");
                Console.WriteLine("4. Mostrar Prestamos");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out subOpcion) || subOpcion < 1 || subOpcion > 5)
                {
                    Console.Write("Entrada inválida. Por favor, seleccione una opción entre 1 y 5: ");
                }

                switch (subOpcion)
                {
                    case 1:
                        AgregarPrestamo();
                        break;
                    case 2:
                        ActualizarPrestamo();
                        break;
                    case 3:
                        BuscarPrestamo();
                        break;
                    case 4:
                        MostrarPrestamos();
                        break;
                    case 5:
                        break;
                }

                if (subOpcion != 5)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (subOpcion != 4);
        }
        static void BuscarUsuarios()
        {
            int subOpcion;
            do
            {
                Console.Clear();
                Console.WriteLine("--Buscar Usuarios--");
                Console.WriteLine("1. por Numero de Usuario");
                Console.WriteLine("2. por  DNI");
                Console.WriteLine("3. Volver a Usuarios");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out subOpcion) || subOpcion < 1 || subOpcion > 3)
                {
                    Console.Write("Entrada inválida. Por favor, seleccione una opción entre 1 y 3: ");
                }

                switch (subOpcion)
                {
                    case 1:
                        BuscarNumeroUsuario();

                        break;
                    case 2:
                        BuscarDNI();
                        break;
                    case 3:
                        break;
                }

                if (subOpcion != 3)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (subOpcion != 3);
        }
        static void BuscarLibros()
        {
            int subOpcion;
            do
            {
                Console.Clear();
                Console.WriteLine("--Buscar Libros--");
                Console.WriteLine("1. por N°");
                Console.WriteLine("2. por  Genero");
                Console.WriteLine("3. por  Autor");
                Console.WriteLine("4. Volver a Libros");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out subOpcion) || subOpcion < 1 || subOpcion > 4)
                {
                    Console.Write("Entrada inválida. Por favor, seleccione una opción entre 1 y 4: ");
                }

                switch (subOpcion)
                {
                    case 1:
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            BuscarLibro_Numero(conn);
                        }
                        break;
                    case 2:
                        BuscarGenero();
                        break;
                    case 3:
                        BuscarAutor();
                        break;
                    case 4:
                        break;
                }

                if (subOpcion != 4)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (subOpcion != 4);
        }
        static void Estado()
        {
            Console.Write("Ingrese el N° del usuario que desea Eliminar: ");
            int Numero_Usuario;

            while (!int.TryParse(Console.ReadLine(), out Numero_Usuario))
            {
                Console.WriteLine("Por favor, ingrese un N° de usuario válido.");
                Console.Write("Ingrese el N° del usuario que desea Eliminar: ");
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                if (ExisteUsuario(conn, Numero_Usuario))
                {
                    Console.Write("¿Está seguro que desea eliminar al usuario? (s/n): ");
                    string confirm = Console.ReadLine();

                    if (confirm?.ToLower() == "s")
                    {
                        CambiarEstadoU(conn, Numero_Usuario);
                        Console.WriteLine("Usuario eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("El Número de usurío no existe.");
                }
            }
        }
        static bool ExisteUsuario(MySqlConnection conn, int Numero_Usuario)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE Numero_Usuario = @Numero_Usuario";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Numero_Usuario", Numero_Usuario);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        static void CambiarEstadoU(MySqlConnection conn, int Numero_Usuario)
        {
            string updateQuery = "UPDATE usuarios SET estado = 0 WHERE Numero_Usuario = @Numero_Usuario";
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@Numero_Usuario", Numero_Usuario);

            cmd.ExecuteNonQuery();
        }
        static void AgregarGenero(MySqlConnection conn)
        {
            Console.Clear();
            Console.Write("Ingrese el nombre del género que desea agregar: ");
            string genero = Console.ReadLine();
            string query = "INSERT INTO Generos (genero) VALUES (@genero)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@genero", genero);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Género agregado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar el género: {ex.Message}");
                }
            }
        }
        static void AgregarAutor(MySqlConnection conn)
        {
            Console.Clear();
            Console.Write("Ingrese el nombre del autor que desea agregar: ");
            string autor = Console.ReadLine();
            string query = "INSERT INTO Autor (autor) VALUES (@autor)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@autor", autor);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Autor agregado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar el autor: {ex.Message}");
                }
            }
        }
        static void BuscarLibro_Numero(MySqlConnection conn)
        {
            Console.Clear();
            Console.Write("Ingrese el número del libro que desea buscar: ");
            int Numero_Libro;

            while (!int.TryParse(Console.ReadLine(), out Numero_Libro))
            {
                Console.WriteLine("Por favor, ingrese un número de libro válido.");
                Console.Write("Ingrese el número del libro que desea buscar: ");
            }

            string query = @"
                SELECT l.Numero_Libro, l.titulo, l.estado, g.genero, a.Autor 
                FROM libros l
                JOIN Generos g ON l.Numero_Genero = g.Numero_Genero
                JOIN Autor a ON l.Numero_Autor = a.Numero_Autor
                WHERE l.numero = @Numero_Libro";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Numero_Libro", Numero_Libro);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string estado = reader["estado"].Equals(1) ? "Activo" : "Inactivo";
                        Console.WriteLine($"Número de Libro: {reader["Numero_Libro"]}");
                        Console.WriteLine($"Título: {reader["Nombre_Libro"]}");
                        Console.WriteLine($"Estado: {estado}");
                        Console.WriteLine($"Género: {reader["genero"]}");
                        Console.WriteLine($"Autor: {reader["Autor"]}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron libros con ese número.");
                }
            }
        }
        static void MenuAgregarLibros()
        {
            Console.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var generos = ObtenerGeneros(connection);
                var autores = ObtenerAutores(connection);

                Console.WriteLine("Selecciona un género:");
                int idGenero = SeleccionarOpcion(generos);

                Console.WriteLine("Selecciona un autor:");
                int idAutor = SeleccionarOpcion(autores);

                Console.Write("Ingresa el nombre del libro: ");
                string nombreLibro = Console.ReadLine();

                Console.Write("Ingresa la fecha de lanzamiento (YYYY-MM-DD): ");
                DateTime fechaLanzamiento = DateTime.Parse(Console.ReadLine());

                AgregarLibro(connection, nombreLibro, fechaLanzamiento, idGenero, idAutor);
                Console.WriteLine("Libro agregado exitosamente.");
            }
        }
        static List<(int Id, string Nombre)> ObtenerGeneros(MySqlConnection connection)
        {
            var generos = new List<(int, string)>();
            using (var command = new MySqlCommand("SELECT Numero_Genero, genero FROM Generos", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    generos.Add((reader.GetInt32(0), reader.GetString(1)));
                }
            }
            return generos;
        }
        static List<(int Id, string Nombre)> ObtenerAutores(MySqlConnection connection)
        {
            var autores = new List<(int, string)>();
            using (var command = new MySqlCommand("SELECT Numero_Autor, Autor FROM Autor", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    autores.Add((reader.GetInt32(0), reader.GetString(1)));
                }
            }
            return autores;
        }
        static int SeleccionarOpcion(List<(int Id, string Nombre)> opciones)
        {
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i].Nombre}");
            }

            int seleccion;
            while (true)
            {
                Console.Write("Selecciona una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion > 0 && seleccion <= opciones.Count)
                {
                    break;
                }
                Console.WriteLine("Selección inválida, intenta nuevamente.");
            }
            return opciones[seleccion - 1].Id;
        }
        static void AgregarLibro(MySqlConnection connection, string nombreLibro, DateTime fechaLanzamiento, int idGenero, int idAutor)
        {
            using (var command = new MySqlCommand("INSERT INTO Libros (nombre_libro, fecha_lanzamiento, id_genero, id_autor) VALUES (@nombre_libro, @fecha_lanzamiento, @id_genero, @id_autor)", connection))
            {
                command.Parameters.AddWithValue("@nombre_libro", nombreLibro);
                command.Parameters.AddWithValue("@fecha_lanzamiento", fechaLanzamiento);
                command.Parameters.AddWithValue("@id_genero", idGenero);
                command.Parameters.AddWithValue("@id_autor", idAutor);
                command.ExecuteNonQuery();
            }
        }
        static void BuscarDNI()
        {
            Console.Clear();
            Console.Write("Ingrese el DNI del usuario: ");
            string dni = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuarios WHERE dni = @dni";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dni", dni);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("Información del Usuario:");
                                Console.WriteLine($"Numero de usuario: {reader["numero_usuario"]}");
                                Console.WriteLine($"Nombre: {reader["nombre"]}");
                                Console.WriteLine($"Apellido: {reader["apellido"]}");
                                Console.WriteLine($"DNI: {reader["dni"]}");
                                Console.WriteLine($"Teléfono: {reader["telefono"]}");
                                Console.WriteLine($"Email: {reader["email"]}");
                                Console.WriteLine($"Creado el: {reader["creado_el"]}");
                                Console.WriteLine($"Actualizado el: {reader["actualizado_el"]}");
                                Console.WriteLine($"Estado: {(reader["estado"].ToString() == "1" ? "Activo" : "Inactivo")}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un usuario con ese DNI.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        static void AgregarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Agregar nuevo usuario");

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Ingrese el DNI (8 caracteres): ");
            string dni = Console.ReadLine();

            Console.Write("Ingrese el teléfono (opcional): ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese el email: ");
            string email = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Usuarios (nombre, apellido, dni, telefono, email) VALUES (@nombre, @apellido, @dni, @telefono, @email)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@dni", dni);
                        command.Parameters.AddWithValue("@telefono", telefono);
                        command.Parameters.AddWithValue("@email", email);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Usuario agregado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar el usuario.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        Console.WriteLine("El DNI o el email ya existe.");
                    }
                    else
                    {
                        Console.WriteLine("Error de MySQL: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        static void MenuActualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el DNI del usuario a actualizar:");
            string dni = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                if (!UsuarioExisteDNI(connection, dni))
                {
                    Console.WriteLine("El usuario no existe.");
                    return;
                }

                Console.WriteLine("¿Qué campo desea actualizar?");
                Console.WriteLine("1. Nombre");
                Console.WriteLine("2. Apellido");
                Console.WriteLine("3. Teléfono");
                Console.WriteLine("4. Email");
                Console.WriteLine("Ingrese el número de la opción:");

                int opcion = Convert.ToInt32(Console.ReadLine());
                string nuevoValor = string.Empty;

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nuevo nombre:");
                        nuevoValor = Console.ReadLine();
                        ActualizarCampo(connection, dni, "nombre", nuevoValor);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el nuevo apellido:");
                        nuevoValor = Console.ReadLine();
                        ActualizarCampo(connection, dni, "apellido", nuevoValor);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el nuevo teléfono:");
                        nuevoValor = Console.ReadLine();
                        ActualizarCampo(connection, dni, "telefono", nuevoValor);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el nuevo email:");
                        nuevoValor = Console.ReadLine();
                        ActualizarCampo(connection, dni, "email", nuevoValor);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
        static bool UsuarioExisteDNI(MySqlConnection connection, string dni)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE dni = @dni";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        static void ActualizarCampo(MySqlConnection connection, string dni, string campo, string nuevoValor)
        {
            string query = $"UPDATE Usuarios SET {campo} = @nuevoValor, actualizado_el = CURRENT_TIMESTAMP WHERE dni = @dni";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@nuevoValor", nuevoValor);
                cmd.Parameters.AddWithValue("@dni", dni);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                }
                else
                {
                    Console.WriteLine("No se pudo actualizar.");
                }
            }
        }
        static void AgregarPrestamo()
        {
            Console.Clear();
            Console.Write("Ingrese el N° del libro: ");
            int libroId = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el N° del usuario: ");
            int usuarioId = int.Parse(Console.ReadLine());

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                if (!EstadoValido(connection, "Libros", libroId) || !EstadoValido(connection, "Usuarios", usuarioId))
                {
                    Console.WriteLine("No se puede realizar el préstamo. El libro o el usuario están en estado 0.");
                    return;
                }

                DateTime fechaPrestamo = DateTime.Now;
                DateTime fechaDevolucionEstimada = fechaPrestamo.AddDays(7);

                string query = "INSERT INTO Prestamos (usuario_id, libro_id, fecha_prestamo, fecha_devolucion_estimada) VALUES (@usuarioId, @libroId, @fechaPrestamo, @fechaDevolucionEstimada)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuarioId", usuarioId);
                    command.Parameters.AddWithValue("@libroId", libroId);
                    command.Parameters.AddWithValue("@fechaPrestamo", fechaPrestamo);
                    command.Parameters.AddWithValue("@fechaDevolucionEstimada", fechaDevolucionEstimada);
                    command.ExecuteNonQuery();
                }
                ActualizarEstado(connection, "Libros", libroId, 0);
                Console.WriteLine("Préstamo agregado con éxito.");
            }
        }
        static void ActualizarPrestamo()
        {
            Console.Clear();
            Console.Write("Ingrese el N° del préstamo: ");
            int prestamoId = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la fecha de devolución real (yyyy-mm-dd): ");
            DateTime fechaDevolucionReal = DateTime.Parse(Console.ReadLine());

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                int libroId = 0, usuarioId = 0;
                string query = "SELECT libro_id, usuario_id FROM Prestamos WHERE Numero_Prestamo = @prestamoId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prestamoId", prestamoId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            libroId = reader.GetInt32("libro_id");
                            usuarioId = reader.GetInt32("usuario_id");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el préstamo.");
                            return;
                        }
                    }
                }

                query = "UPDATE Prestamos SET fecha_devolucion_real = @fechaDevolucionReal WHERE Numero_Prestamo = @prestamoId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fechaDevolucionReal", fechaDevolucionReal);
                    command.Parameters.AddWithValue("@prestamoId", prestamoId);
                    command.ExecuteNonQuery();
                }
                ActualizarEstado(connection, "Libros", libroId, 1);
                DateTime fechaDevolucionEstimada = DateTime.Now.AddDays(-7);
                if (fechaDevolucionReal > fechaDevolucionEstimada)
                {
                    ActualizarEstado(connection, "Usuarios", usuarioId, 0);
                }

                Console.WriteLine("Préstamo actualizado con éxito.");
            }
        }
        static bool EstadoValido(MySqlConnection connection, string tabla, int id)
        {
            string query = $"SELECT estado FROM {tabla} WHERE Numero_{tabla.Substring(0, tabla.Length - 1)} = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                return Convert.ToInt32(command.ExecuteScalar()) != 0;
            }
        }
        static void ActualizarEstado(MySqlConnection connection, string tabla, int id, int nuevoEstado)
        {
            string query = $"UPDATE {tabla} SET estado = @nuevoEstado WHERE Numero_{tabla.Substring(0, tabla.Length - 1)} = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        static void BuscarPrestamo()
        {
            Console.Clear();
            Console.Write("Ingrese el Numero del préstamo: ");
            int prestamoId = int.Parse(Console.ReadLine());

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT u.Numero_Usuario, u.nombre, u.apellido, u.telefono, u.dni, u.email, 
                       l.Numero_Libro, l.nombre_libro
                FROM Prestamos p
                JOIN Usuarios u ON p.usuario_id = u.Numero_Usuario
                JOIN Libros l ON p.libro_id = l.Numero_Libro
                WHERE p.Numero_Prestamo = @prestamoId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prestamoId", prestamoId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Detalles del préstamo:");
                            Console.WriteLine($"Número de usuario: {reader["Numero_Usuario"]}");
                            Console.WriteLine($"Nombre: {reader["nombre"]}");
                            Console.WriteLine($"Apellido: {reader["apellido"]}");
                            Console.WriteLine($"Teléfono: {reader["telefono"]}");
                            Console.WriteLine($"DNI: {reader["dni"]}");
                            Console.WriteLine($"Email: {reader["email"]}");
                            Console.WriteLine($"Número del libro: {reader["Numero_Libro"]}");
                            Console.WriteLine($"Nombre del libro: {reader["nombre_libro"]}");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el préstamo.");
                        }
                    }
                }
            }
        }
        static void BuscarNumeroUsuario()
        {
            Console.Clear();
            Console.Write("Ingrese el número de usuario: ");
            int numeroUsuario;

            while (!int.TryParse(Console.ReadLine(), out numeroUsuario))
            {
                Console.Write("Por favor, ingrese un número de usuario válido: ");
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuarios WHERE Numero_Usuario = @NumeroUsuario";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroUsuario", numeroUsuario);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("Usuario encontrado:");
                                Console.WriteLine($"Número de Usuario: {reader["Numero_Usuario"]}");
                                Console.WriteLine($"Nombre: {reader["nombre"]}");
                                Console.WriteLine($"Apellido: {reader["apellido"]}");
                                Console.WriteLine($"DNI: {reader["dni"]}");
                                Console.WriteLine($"Teléfono: {reader["telefono"]}");
                                Console.WriteLine($"Email: {reader["email"]}");
                                Console.WriteLine($"Creado el: {reader["creado_el"]}");
                                Console.WriteLine($"Actualizado el: {reader["actualizado_el"]}");
                                Console.WriteLine($"Estado: {(reader["estado"].ToString() == "1" ? "Activo" : "Inactivo")}");
                            }
                            else
                            {
                                Console.WriteLine("Usuario no encontrado.");
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error en la conexión: {ex.Message}");
                }
            }
        }
        static void BuscarAutor()
        {
            Console.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string autoresQuery = "SELECT Numero_Autor, Autor FROM Autor";
                using (MySqlCommand autoresCommand = new MySqlCommand(autoresQuery, connection))
                {
                    using (MySqlDataReader autoresReader = autoresCommand.ExecuteReader())
                    {
                        Console.WriteLine("Autores disponibles:");
                        while (autoresReader.Read())
                        {
                            int numeroAutor = autoresReader.GetInt32("Numero_Autor");
                            string nombreAutor = autoresReader.GetString("Autor");
                            Console.WriteLine($"{numeroAutor}: {nombreAutor}");
                        }
                    }
                }

                Console.WriteLine("Ingrese el número:");
                if (int.TryParse(Console.ReadLine(), out int numeroAutorInput))
                {
                    string librosQuery = @"
                    SELECT L.nombre_libro, L.fecha_lanzamiento, G.genero, A.Autor 
                    FROM Libros L
                    JOIN Generos G ON L.id_genero = G.Numero_Genero
                    JOIN Autor A ON L.id_autor = A.Numero_Autor
                    WHERE A.Numero_Autor = @NumeroAutor";

                    using (MySqlCommand librosCommand = new MySqlCommand(librosQuery, connection))
                    {
                        librosCommand.Parameters.AddWithValue("@NumeroAutor", numeroAutorInput);

                        using (MySqlDataReader librosReader = librosCommand.ExecuteReader())
                        {
                            if (!librosReader.HasRows)
                            {
                                Console.WriteLine("No se encontraron libros para el autor especificado.");
                            }
                            else
                            {
                                Console.WriteLine("Libros encontrados:");
                                while (librosReader.Read())
                                {
                                    string nombreLibro = librosReader["nombre_libro"].ToString();
                                    DateTime fechaLanzamiento = Convert.ToDateTime(librosReader["fecha_lanzamiento"]);
                                    string genero = librosReader["genero"].ToString();
                                    string autor = librosReader["Autor"].ToString();

                                    Console.WriteLine($"Título: {nombreLibro}, Autor: {autor}, Género: {genero}, Fecha de Lanzamiento: {fechaLanzamiento.ToShortDateString()}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Asegúrate de ingresar un numero valido.");
                }
            }
        }
        static void BuscarGenero()
        {
            Console.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine("Géneros disponibles:");
                string genreQuery = "SELECT Numero_Genero, genero FROM Generos";
                MySqlCommand genreCommand = new MySqlCommand(genreQuery, conn);

                using (MySqlDataReader reader = genreCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Numero_Genero"]}: {reader["genero"]}");
                    }
                }

                Console.Write("Ingresa el número: ");
                if (int.TryParse(Console.ReadLine(), out int numeroGenero))
                {
                    string bookQuery = @"
                    SELECT l.Numero_Libro, l.nombre_libro, a.Autor, g.genero, l.fecha_lanzamiento
                    FROM Libros l
                    JOIN Autor a ON l.id_autor = a.Numero_Autor
                    JOIN Generos g ON l.id_genero = g.Numero_Genero
                    WHERE l.id_genero = @Genero";

                    MySqlCommand bookCommand = new MySqlCommand(bookQuery, conn);
                    bookCommand.Parameters.AddWithValue("@Genero", numeroGenero);

                    using (MySqlDataReader bookReader = bookCommand.ExecuteReader())
                    {
                        Console.WriteLine("\nLibros en este género:");
                        while (bookReader.Read())
                        {
                            Console.WriteLine($"Número: {bookReader["Numero_Libro"]}, Título: {bookReader["nombre_libro"]}, Autor: {bookReader["Autor"]}, Género: {bookReader["genero"]}, Fecha: {bookReader["fecha_lanzamiento"]}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Número de género no válido.");
                }
            }
        }
        static void ActualizarLibro()
        {
            Console.Clear();
            Console.WriteLine("Actualizar Libro");
            Console.Write("Ingrese el número del libro a actualizar: ");
            int numeroLibro = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                while (true)
                {
                    Console.WriteLine("¿Qué desea actualizar?");
                    Console.WriteLine("1. Nombre del libro");
                    Console.WriteLine("2. Autor");
                    Console.WriteLine("3. Fecha de lanzamiento");
                    Console.WriteLine("4. Género");
                    Console.WriteLine("5. Salir");
                    Console.Write("Seleccione una opción: ");
                    int opcion = int.Parse(Console.ReadLine());

                    if (opcion == 5) break;

                    string campo = "";
                    string nuevoValor = "";

                    switch (opcion)
                    {
                        case 1:
                            campo = "nombre_libro";
                            Console.Write("Ingrese el nuevo nombre del libro: ");
                            nuevoValor = Console.ReadLine();
                            break;
                        case 2:
                            campo = "id_autor";
                            Console.WriteLine("Seleccione un nuevo autor:");
                            nuevoValor = SeleccionarAutor(connection);
                            break;
                        case 3:
                            campo = "fecha_lanzamiento";
                            Console.Write("Ingrese la nueva fecha de lanzamiento (YYYY-MM-DD): ");
                            nuevoValor = Console.ReadLine();
                            break;
                        case 4:
                            campo = "id_genero";
                            Console.WriteLine("Seleccione un nuevo género:");
                            nuevoValor = SeleccionarGenero(connection);
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            continue;
                    }

                    if (!string.IsNullOrEmpty(nuevoValor))
                    {
                        string query = $"UPDATE Libros SET {campo} = @nuevoValor WHERE Numero_Libro = @numeroLibro";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@nuevoValor", nuevoValor);
                            command.Parameters.AddWithValue("@numeroLibro", numeroLibro);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Libro actualizado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró el libro con ese número.");
                            }
                        }
                    }
                }
            }
        }
        static string SeleccionarAutor(MySqlConnection connection)
        {
            MostrarAutores(connection);
            Console.Write("Ingrese el número del autor: ");
            return Console.ReadLine();
        }
        static string SeleccionarGenero(MySqlConnection connection)
        {
            MostrarGeneros(connection);
            Console.Write("Ingrese el número del género: ");
            return Console.ReadLine();
        }
        static void MostrarAutores(MySqlConnection connection)
        {
            string query = "SELECT Numero_Autor, Autor FROM Autor";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Autores disponibles:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Numero_Autor"]}: {reader["Autor"]}");
                    }
                }
            }
        }
        static void MostrarGeneros(MySqlConnection connection)
        {
            string query = "SELECT Numero_Genero, genero FROM Generos";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Géneros disponibles:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Numero_Genero"]}: {reader["genero"]}");
                    }
                }
            }
        }
        static void EliminarLibro()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Libro");
            Console.Write("Ingrese el número del libro a eliminar: ");
            int numeroLibro = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Libros SET estado = 0 WHERE Numero_Libro = @numeroLibro";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numeroLibro", numeroLibro);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("El libro ha sido eliminado (estado cambiado a inactivo).");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el libro con ese número.");
                    }
                }
            }
        }
        static void MostrarUsuarios(MySqlConnection connection)
        {
            string query = "SELECT Numero_Usuario, nombre, apellido, dni, telefono, email, creado_el, actualizado_el, estado FROM Usuarios";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string> users = new List<string>();

            while (reader.Read())
            {
                int estado = reader.GetInt32("estado");
                string estadoTexto = estado == 1 ? "Activo" : "Inactivo";
                string userData = $"{reader.GetInt32("Numero_Usuario"),-5} {reader.GetString("nombre"),-20} {reader.GetString("apellido"),-20} {reader.GetString("dni"),-10} {reader.GetString("telefono"),-15} {reader.GetString("email"),-20} {reader.GetDateTime("creado_el"),-25} {reader.GetDateTime("actualizado_el"),-25} {estadoTexto,-10}";
                users.Add(userData);
            }

            reader.Close();

            Console.Clear();
            Console.WriteLine("### Lista de Usuarios ###");
            Console.WriteLine($"{"ID",-5} {"Nombre",-20} {"Apellido",-20} {"DNI",-10} {"Teléfono",-15} {"Email",-20} {"Creado",-25} {"Actualizado",-25} {"Estado",-10}");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        static void crearautotabla()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");

                    string createTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS Usuarios (
                        Numero_Usuario INT AUTO_INCREMENT PRIMARY KEY,
                        nombre VARCHAR(20) NOT NULL,
                        apellido VARCHAR(20) NOT NULL,
                        dni VARCHAR(8) NOT NULL UNIQUE,
                        telefono VARCHAR(12),
                        email VARCHAR(20) NOT NULL UNIQUE,
                        creado_el TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        actualizado_el TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                        estado TINYINT DEFAULT 1
                    );

                    CREATE TABLE IF NOT EXISTS Generos (
                        Numero_Genero INT AUTO_INCREMENT PRIMARY KEY,
                        genero VARCHAR(100) NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Autor (
                        Numero_Autor INT AUTO_INCREMENT PRIMARY KEY,
                        Autor VARCHAR(100) NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Libros (
                        Numero_Libro INT AUTO_INCREMENT PRIMARY KEY,
                        nombre_libro VARCHAR(25) NOT NULL,
                        fecha_lanzamiento DATE NOT NULL,
                        id_genero INT,
                        id_autor INT,
                        creado_el TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        actualizado_el TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                        estado TINYINT DEFAULT 1,
                        FOREIGN KEY (id_genero) REFERENCES Generos(Numero_Genero),
                        FOREIGN KEY (id_autor) REFERENCES Autor(Numero_Autor)
                    );

                    CREATE TABLE IF NOT EXISTS Prestamos (
                        Numero_Prestamo INT AUTO_INCREMENT PRIMARY KEY,
                        usuario_id INT,
                        libro_id INT,
                        fecha_prestamo DATE NOT NULL,
                        fecha_devolucion_estimada DATE NOT NULL,
                        fecha_devolucion_real DATE,
                        FOREIGN KEY (usuario_id) REFERENCES Usuarios(Numero_Usuario),
                        FOREIGN KEY (libro_id) REFERENCES Libros(Numero_Libro)
                    );
                ";

                    using (var command = new MySqlCommand(createTablesQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Las tablas fueron creadas exitosamente.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
        static void MostrarLibros()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                    SELECT L.Numero_Libro, L.nombre_libro, L.fecha_lanzamiento, 
                           G.nombre_genero, A.nombre_autor, L.estado, 
                           DATE_FORMAT(L.creado_el, '%d-%m-%Y') AS creado_el, 
                           DATE_FORMAT(L.actualizado_el, '%d-%m-%Y') AS actualizado_el
                    FROM Libros L
                    JOIN Generos G ON L.id_genero = G.Numero_Genero
                    JOIN Autor A ON L.id_autor = A.Numero_Autor";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    Console.Clear();
                    Console.WriteLine("=== Lista de Libros ===");

                    Console.WriteLine(String.Format("{0,-6}  {1,-25}  {2,-20}  {3,-12}  {4,-18}  {5,-12}  {6,-10}  {7,-12}",
                        "Num.", "Nombre del Libro", "Autor", "Género", "Fecha Lanzamiento", "Estado", "Creado", "Actualizado"));
                    Console.WriteLine(new string('-', 110));

                    while (reader.Read())
                    {
                        string estado = reader.GetInt32("estado") == 1 ? "Disponible" : "Ocupado";
                        Console.WriteLine(String.Format("{0,-6}  {1,-25}  {2,-20}  {3,-12}  {4,-18}  {5,-12}  {6,-10}  {7,-12}",
                            reader.GetInt32("Numero_Libro"),
                            reader.GetString("nombre_libro"),
                            reader.GetString("autor"),
                            reader.GetString("nombre_genero"),
                            reader.GetDateTime("fecha_lanzamiento").ToString("dd-MM-yyyy"),
                            estado,
                            reader.GetString("creado_el"),
                            reader.GetString("actualizado_el")));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú.");
                    Console.ReadKey();
                }
            }
        }
        static void MostrarPrestamos()
        {
            string query = @"
            SELECT 
                p.Numero_Prestamo, 
                u.Nombre AS Nombre_Usuario, 
                u.Apellido AS Apellido_Usuario, 
                l.Nombre AS Nombre_Libro, 
                p.fecha_prestamo, 
                p.fecha_devolucion_estimada, 
                p.fecha_devolucion_real
            FROM 
                Prestamos p
            INNER JOIN 
                Usuarios u ON p.usuario_id = u.Numero_Usuario
            INNER JOIN 
                Libros l ON p.libro_id = l.Numero_Libro";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();


                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("{0,-15} {1,-20} {2,-20} {3,-25} {4,-15} {5,-25} {6,-25}",
                        "Número Prestamo", "Nombre Usuario", "Apellido Usuario", "Nombre Libro",
                        "Fecha Prestamo", "Fecha Devolucion Estimada", "Fecha Devolucion Real"));
                    sb.AppendLine(new string('-', 130));

                    while (reader.Read())
                    {
                        sb.AppendLine(string.Format("{0,-15} {1,-20} {2,-20} {3,-25} {4,-15} {5,-25} {6,-25}",
                            reader["Numero_Prestamo"],
                            reader["Nombre_Usuario"],
                            reader["Apellido_Usuario"],
                            reader["Nombre_Libro"],
                            reader["fecha_prestamo"].ToString(),
                            reader["fecha_devolucion_estimada"].ToString(),
                            reader.IsDBNull(reader.GetOrdinal("fecha_devolucion_real"))
                            ? "No devuelto"
                            : reader["fecha_devolucion_real"].ToString()
                        ));
                    }

                    Console.Clear();
                    Console.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        static void MostrarGenerosEnTabla()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Numero_Genero, genero FROM Generos";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    Console.Clear();
                    Console.WriteLine("{0,-10} {1,-30}", "Número", "Género");
                    Console.WriteLine(new string('-', 40));

                    while (reader.Read())
                    {
                        int numeroGenero = reader.GetInt32("Numero_Genero");
                        string genero = reader.GetString("genero");
                        Console.WriteLine("{0,-10} {1,-30}", numeroGenero, genero);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}