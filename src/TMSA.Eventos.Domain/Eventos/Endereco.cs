using FluentValidation;
using System;
using TMSA.Eventos.Domain.Core.Models;

namespace TMSA.Eventos.Domain.Eventos
{
    public class Endereco : Entity<Endereco>
    {

        public Endereco(
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cep,
            string cidade,
            string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
        }

        //EF Construtor
        protected Endereco() { }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid? EventoId { get; private set; }

        //EF Propriedade de Navegação
        public virtual Evento Evento { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarLogradouro();
            ValidarNumero();
            ValidarBairro();
            ValidarCEP();
            ValidarCidade();
            ValidarEstado();
            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("Preencha o logradouro.")
                .Length(2, 150).WithMessage("O logradouro deve ter entre 2 à 150 caracteres.");
        }

        private void ValidarNumero()
        {
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Preencha o número.");
        }

        private void ValidarBairro()
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Preencha o bairro.")
                .Length(2, 150).WithMessage("O bairro deve ter entre 2 à 150 caracteres.");
        }

        private void ValidarCEP()
        {
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("Preencha o cep.")
                .Length(8).WithMessage("Preencha o cep com oito digitos.");
        }

        private void ValidarCidade()
        {
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Preencha a cidade")
                .Length(2, 150).WithMessage("A cidade deve ter entre 2 à 150 caracteres");
        }

        private void ValidarEstado()
        {
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Preencha o estado.")
                .Length(2, 150).WithMessage("O estado deve ter entre 2 à 150 caracteres.");
        }
        #endregion
    }
}