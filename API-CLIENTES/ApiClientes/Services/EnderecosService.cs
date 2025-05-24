using System.Collections.Generic;
using System.Linq;
using ApiClientes.Database.Models;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using ApiClientes.Services.Parsers;

namespace ApiClientes.Services
{
    public class EnderecosService
    {
        private readonly ClientesContext _dbcontext;

        public EnderecosService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public EnderecoDTO Criar(CriarEnderecoDTO dto)
        {
            // Verificar se o cliente existe
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == dto.Clienteid);
            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            var endereco = EnderecoParsers.ToTbEndereco(dto);

            _dbcontext.TbEnderecos.Add(endereco);
            _dbcontext.SaveChanges();

            return EnderecoParsers.ToEnderecoDTO(endereco);
        }

        public List<EnderecoDTO> ListarTodos()
        {
            var enderecos = _dbcontext.TbEnderecos.ToList();
            return enderecos.Select(e => EnderecoParsers.ToEnderecoDTO(e)).ToList();
        }

        public EnderecoDTO ListarPorId(int id)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new BadRequestException("Endereço não encontrado");

            return EnderecoParsers.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO Atualizar(int id, AtualizarEnderecoDTO dto)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new BadRequestException("Endereço não encontrado");

            endereco.Logradouro = dto.Logradouro;
            endereco.Numero = dto.Numero;
            endereco.Complemento = dto.Complemento;
            endereco.Bairro = dto.Bairro;
            endereco.Cidade = dto.Cidade;
            endereco.Uf = dto.Uf;
            endereco.Cep = dto.Cep;
            endereco.Status = dto.Status;

            _dbcontext.SaveChanges();

            return EnderecoParsers.ToEnderecoDTO(endereco);
        }

        public void Deletar(int id)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new BadRequestException("Endereço não encontrado");

            _dbcontext.TbEnderecos.Remove(endereco);
            _dbcontext.SaveChanges();
        }
    }
}
