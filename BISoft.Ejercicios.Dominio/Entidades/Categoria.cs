namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class Categoria : Entity
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
