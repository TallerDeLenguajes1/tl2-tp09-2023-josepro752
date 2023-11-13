namespace tl2_tp09_2023_josepro752;

public interface ITableroRepository {
    public void AddTablero(Tablero tablero);
    public void UpdateTablero(int id, Tablero tablero);
    public Tablero GetTablero(int id);
    public List<Tablero> GetAllTableros();
    public List<Tablero> GetAllTablerosForUsuario(int idUsuario);
    public void DeleteTablero(int id);
}