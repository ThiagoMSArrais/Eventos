using System;
using System.Collections.Generic;
using TMSA.Eventos.Domain.Core.Models;
using TMSA.Eventos.Domain.Eventos;

namespace TMSA.Eventos.Domain.Organizadores
{
    public class Organizador : Entity<Organizador>
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public Organizador(Guid id, string nome, string cpf, string email)
        {
            OrganizadorID = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        // EF Construtor
        public Guid OrganizadorID { get; private set; }
        protected Organizador() { }

        // EF Propriedade de Navegação
        public virtual ICollection<Evento> Eventos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}