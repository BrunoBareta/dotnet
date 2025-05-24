using System;

namespace ApiClientes.Services.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public DateTime Criadoem { get; internal set; }
        public DateTime Alteradoem { get; internal set; }
        public string Telefone { get; internal set; }
        public string Documento { get; internal set; }
        public DateTime? Nascimento { get; internal set; }
        public int Tipodoc { get; internal set; }
    }
    public class CriarClienteDTO
    {
        public string Nome { get; set; }

        public DateTime? Nascimento { get; set; }

        public string Telefone { get; set; }

        public string Documento { get; set; }

        public int Tipodoc { get; set; }
    }

    public class AtualizarClienteDTO
    {
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public int Tipodoc { get; set; }
    }
}