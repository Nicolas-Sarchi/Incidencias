namespace APIIncidencias.Dtos
{
    public class PaisXDepDto
    {
        public int Id { get; set; }
        public string NombrePais { get; set; }
        public List<DepartamentoDto> Departamentos { get; set; }
    }
}