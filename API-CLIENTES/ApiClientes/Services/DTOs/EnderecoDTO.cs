using System;

namespace ApiClientes.Services.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; internal set; }
        public int Clienteid { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Numero { get; internal set; }
        public string Complemento { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public string Uf { get; internal set; }
        public string Cep { get; internal set; }
        public int Status { get; internal set; }
    }

    public class CriarEnderecoDTO
    {
        public int Clienteid { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
    }

    public class AtualizarEnderecoDTO
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public int Status { get; set; }
    }
}
