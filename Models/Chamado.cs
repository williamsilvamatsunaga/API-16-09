﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ApiServico.Models
{
    [Table("chamado")]
    public class Chamado
    {
        [Column("id_cha")]
        public int Id { get; set; }

        [Column("titulo_cha")]
        public required string Titulo { get; set; }

        [Column("descricao_cha")]
        public required string Descricao { get; set; }

        [Column("data_abertura_cha")]
        public DateTime DataAbertura { get; set; }

        [Column("data_fechamento_cha")]
        public DateTime? DataFechamento { get; set; }

        [Column("situacao_cha")]
        public string Status { get; set; } = "Aberto";
    }
}
