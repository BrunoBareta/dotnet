using ApiClientes.Database.Models;
using ApiClientes.Services.DTOs;
using System;

namespace ApiClientes.Services.Parsers
{
    public class EnderecoParsers
    {
        public static TbEndereco ToTbEndereco(CriarEnderecoDTO dto)
        {
            return new TbEndereco
            {
                Clienteid = dto.Clienteid,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Cep = dto.Cep,
                Status = 1 // ativo por padrão
            };
        }

        public static EnderecoDTO ToEnderecoDTO(TbEndereco endereco)
        {
            return new EnderecoDTO
            {
                Id = endereco.Id,
                Clienteid = endereco.Clienteid,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Uf = endereco.Uf,
                Cep = endereco.Cep,
                Status = endereco.Status
            };
        }
    }
}
