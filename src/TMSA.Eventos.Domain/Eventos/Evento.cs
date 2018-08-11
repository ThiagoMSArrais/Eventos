using FluentValidation;
using System;
using TMSA.Eventos.Domain.Core.Models;
using TMSA.Eventos.Domain.Organizadores;

namespace TMSA.Eventos.Domain.Eventos
{
    public class Evento : Entity<Evento>
    {
        public Evento(
            string nome,
            string descricaoCurta,
            string descricaoLonga,
            DateTime dataInicioDoEvento,
            DateTime dataFimDoEvento,
            bool onLine,
            bool gratuito,
            decimal valor,
            string nomeDaEmpresa)
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicioDoEvento = dataInicioDoEvento;
            DataFimDoEvento = dataFimDoEvento;
            Online = onLine;
            Gratuito = gratuito;
            Valor = valor;
            NomeDaEmpresa = nomeDaEmpresa;
        }

        //EF Construtor
        protected Evento() { }

        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicioDoEvento { get; private set; }
        public DateTime DataFimDoEvento { get; private set; }
        public bool Online { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public string NomeDaEmpresa { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid? OrganizadorId { get; private set; }

        //EF Propriedade de Navegação
        public virtual Endereco Endereco { get; private set; }
        public virtual Organizador Organizador { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarDescricaoCurta();
            ValidarDescricaoLonga();
            ValidarData();
            ValidarLocal();
            ValidarValor();
            ValidarNomeDaEmpresa();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Preencha o nome do evento.")
                .Length(2, 150).WithMessage("O nome do evento deve ter entre dois à 150 caracteres.");
        }

        private void ValidarData()
        {
            RuleFor(c => c.DataInicioDoEvento)
                .LessThan(c => c.DataFimDoEvento).WithMessage("A data de início deve ser maior que a data do final do evento.");

            RuleFor(c => c.DataInicioDoEvento)
                .GreaterThan(DateTime.Now).WithMessage("A data de início não deve ser menor que a data atual.");
        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(c => c.Endereco)
                    .Null().When(c => c.Online).WithMessage("O evento não deve ter endereço quando for on-line.");

            if (!Online)
                RuleFor(c => c.Online)
                    .NotNull().When(c => c.Online == false).WithMessage("O evento deve ter um endereço.");
        }

        private void ValidarValor()
        {
            if (Gratuito)
                RuleFor(c => c.Valor)
                    .Equal(0).When(c => c.Gratuito)
                    .WithMessage("O valor não deverá ser diferente de 0 quando o evento for gratuito.");

            if (!Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(1, 50000)
                    .WithMessage("O valor deve estar entre 1.0 a 50.000");
        }

        private void ValidarNomeDaEmpresa()
        {
            RuleFor(c => c.NomeDaEmpresa)
                .NotEmpty().WithMessage("Preencha o nome da empresa.")
                .Length(2, 150).WithMessage("O nome da empresa pode ser preenchido entre 2 à 150 caracteres.");
        }

        private void ValidarDescricaoCurta()
        {
            RuleFor(c => c.DescricaoCurta)
                .NotEmpty().WithMessage("Preencha a descrição curta.")
                .Length(10, 150).WithMessage("A descrição curta deve ter entre 10 à 150 caracteres."); 
        }

        private void ValidarDescricaoLonga()
        {
            RuleFor(c => c.DescricaoLonga)
                .NotEmpty().WithMessage("Preencha a descrição longa.")
                .Length(10, 240).WithMessage("A descrição longa deve ter entre 10 à 240 caracteres.");
        }
        #endregion
    }
}