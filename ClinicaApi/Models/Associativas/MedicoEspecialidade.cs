namespace ClinicaApi.Models.Associativas
{
    public class MedicoEspecialidade
    {
        public int EspecialidadeCodigo { get; set; }
        public Especialidade Especialidade { get; set; }
        public int MedicoCRM { get; set; }
        public Medico Medico { get; set; }
    }
}