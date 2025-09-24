using System.ComponentModel.DataAnnotations;

namespace ApiServico.Models.Duo
{
    public class ChamadoDuo
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        public required string Titulo { get; set; }

        public required string Descricao { get; set; }
    }
}
