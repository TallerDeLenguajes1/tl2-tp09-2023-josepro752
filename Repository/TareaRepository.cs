using System.Data.SQLite;

namespace tl2_tp09_2023_josepro752;

public class TareaRepository : ITareaRepository{
    private string cadenaDeConexion = "Data Source=DataBase/kanban.db;Cache=Shared";
    public void AddTarea(Tarea tarea) {
        var query = @"INSERT INTO Tarea (id_tablero,nombre,estado,descripcion,color,id_usuario_asignado) VALUES (@id_tablero,@nombre,@estado,@descripcion,@color,@id_usuario_asignado);"; // Esto se ejecutara en la base de datos
        using (SQLiteConnection connection = new SQLiteConnection(cadenaDeConexion)){ // Me crea la conexion
            var command = new SQLiteCommand(query,connection); // Crea el comando que se ejecutara en la base de datos
            command.Parameters.Add(new SQLiteParameter("@id_tablero",tarea.IdTablero));
            command.Parameters.Add(new SQLiteParameter("@nombre",tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@estado",tarea.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion",tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color",tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@id_usuario_asignado",tarea.IdUsuarioAsignado));
            connection.Open();
            command.ExecuteNonQuery(); // Se usa ExecuteNonQuery, cuando es una modificacion (ALTA, BAJA, ACTUALIZACION)
            connection.Close();
        }
    }
    public void UpdateTarea(int id, Tarea tarea) {
        var query = @"UPDATE Tarea SET id_tablero = @id_tablero, nombre = @nombre, estado = @estado, descripcion = @descripcion, color = @color WHERE id=@id;"; // Esto se ejecutara en la base de datos
        using (SQLiteConnection connection = new SQLiteConnection(cadenaDeConexion)){ // Me crea la conexion
            var command = new SQLiteCommand(query,connection); // Crea el comando que se ejecutara en la base de datos
            command.Parameters.Add(new SQLiteParameter("@id_tablero",tarea.IdTablero));
            command.Parameters.Add(new SQLiteParameter("@nombre",tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@estado",tarea.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion",tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color",tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@id",tarea.Id));
            // command.Parameters.Add(new SQLiteParameter("@id_usuario_asignado",tarea.IdUsuarioAsignado));
            connection.Open();
            command.ExecuteNonQuery(); // Se usa ExecuteNonQuery, cuando es una modificacion (ALTA, BAJA, ACTUALIZACION)
            connection.Close();
        }
    }
    public Tarea GetTarea(int id) {
        var tarea = GetAllTareas().FirstOrDefault(tarea => tarea.Id == id);
        return tarea;
    }
    public List<Tarea> GetAllTareas() { // Extra
        List<Tarea> tareas = new List<Tarea>();
        var query = @"SELECT * FROM Tarea;"; // Esto se ejecutara en la base de datos
        using (SQLiteConnection connection = new SQLiteConnection(cadenaDeConexion)){ // Me crea la conexion
            using (SQLiteCommand command = new SQLiteCommand(query,connection)) {
                connection.Open();
                using (SQLiteDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt64(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        if (reader["id_usuario_asignado"] != DBNull.Value) {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        } else {
                            tarea.IdUsuarioAsignado = 0;
                        }
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
        }
        return tareas;
    } // Extra
    public List<Tarea> GetAllTareasForUsuario(int idUsuario){
        var tareas = GetAllTareas().FindAll(tarea => tarea.IdUsuarioAsignado == idUsuario);
        return tareas;
    }
    public List<Tarea> GetAllTareasForTablero(int idTablero){
        var tareas = GetAllTareas().FindAll(tarea => tarea.IdTablero == idTablero);
        return tareas;
    }
    public void DeleteTarea(int id){
        var query = @"DELETE FROM Tarea WHERE id=@id;"; // Esto se ejecutara en la base de datos
        using (SQLiteConnection connection = new SQLiteConnection(cadenaDeConexion)){ // Me crea la conexion
            var command = new SQLiteCommand(query,connection); // Crea el comando que se ejecutara en la base de datos
            command.Parameters.Add(new SQLiteParameter("@id",id));
            connection.Open();
            command.ExecuteNonQuery(); // Se usa ExecuteNonQuery, cuando es una modificacion (ALTA, BAJA, ACTUALIZACION)
            connection.Close();
        } 
    }
    public void AssignTarea(int idUsuario, int idTarea){
        var query = @"UPDATE Tarea SET id_usuario_asignado = @id_usuario_asignado WHERE id=@id;"; // Esto se ejecutara en la base de datos
        using (SQLiteConnection connection = new SQLiteConnection(cadenaDeConexion)){ // Me crea la conexion
            var command = new SQLiteCommand(query,connection); // Crea el comando que se ejecutara en la base de datos
            command.Parameters.Add(new SQLiteParameter("@id_usuario_asignado",idUsuario));
            command.Parameters.Add(new SQLiteParameter("@id",idTarea));
            connection.Open();
            command.ExecuteNonQuery(); // Se usa ExecuteNonQuery, cuando es una modificacion (ALTA, BAJA, ACTUALIZACION)
            connection.Close();
        }
    }
}