namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class Fabricante :Entity
    {
        public int FabricanteId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
