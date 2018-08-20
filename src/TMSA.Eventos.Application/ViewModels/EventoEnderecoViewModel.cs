using System;
using System.ComponentModel.DataAnnotations;

namespace TMSA.Eventos.Application.ViewModels
{
    public class EventoEnderecoViewModel
    {
        public EventoEnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
            EventoId = Guid.NewGuid();
        }

        [Key]
        public Guid EventoId { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Evento")]
        public string Nome { get; set; }

        [Display(Name = "Descrição curta do Evento")]
        public string DescricaoCurta { get; set; }

        [Display(Name = "Descrição longa do Evento")]
        public string DescricaoLonga { get; set; }

        [Display(Name = "Início do Evento")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime DataInicioDoEvento { get; set; }

        [Display(Name = "Fim do Evento")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime DataFimDoEvento { get; set; }

        [Display(Name = "Será gratuito?")]
        public bool Gratuito { get; private set; }

        [Display(Name = "Será online?")]
        public bool Online { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Moeda em formato inválido")]
        public decimal Valor { get; set; }

        [Display(Name = "Empresa / Grupo Organizador")]
        public string NomeDaEmpresa { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        public Guid OrganizadorId { get; set; }

        // Endereço

        [Key]
        public Guid EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }
}
