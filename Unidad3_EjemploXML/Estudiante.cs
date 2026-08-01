namespace EjemploXML
{
    // Modelo que representa a un estudiante leído desde el XML.
    // (Unidad 1: POO — una clase por archivo, con propiedades.)
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Carnet { get; set; }
        public double Nota { get; set; }

        // Regla del curso: se aprueba con 61 puntos o más.
        public bool Aprobado => Nota >= 61;

        public override string ToString()
        {
            string estado = Aprobado ? "APROBADO" : "REPROBADO";
            return $"[{Id}] {Nombre} (carnet {Carnet}) — Nota: {Nota} → {estado}";
        }
    }
}
