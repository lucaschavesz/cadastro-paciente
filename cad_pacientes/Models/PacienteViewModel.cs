using System.Data;
using System;

namespace cad_pacientes.Models
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string Nome { get; set; }
        public string? NomeResponsavel { get; set; }
    }
}
