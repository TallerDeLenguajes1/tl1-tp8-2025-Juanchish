namespace EspacioTarea
{
    public class Tarea
    {
        public Tarea(int tareaID, string? descripcion, int duracion)
        {
            TareaID = tareaID;
            Descripcion = descripcion;
            Duracion = duracion;
        }

        public int TareaID { get; set; }
        public string? Descripcion { get; set; }
        public int Duracion { get; set; } // Validar que esté entre 10 y 100
        // Puedes añadir un constructor y métodos auxiliares si lo consideras necesario

        // Sobrescribir ToString() para una salida legible
        
    }
}