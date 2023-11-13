namespace tl2_tp09_2023_josepro752;

public enum EstadoTarea {
    Ideas,
    ToDo,
    Doing,
    Review,
    Done
}

public class Tarea {
    private int id;
    private string nombre;
    private string descripcion;
    private string color;
    private EstadoTarea estado;
    private int isUsuarioAsignado;
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
    public int IsUsuarioAsignado { get => isUsuarioAsignado; set => isUsuarioAsignado = value; }
}
