using System;
using System.Collections.Generic;
using System.Linq;
using ApiClientes.Database.Models;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using ApiClientes.Services.Parsers;
using ApiClientes.Services.Validations;

namespace ApiClientes.Services
{
    public class ClientesService
    {
        private readonly ClientesContext _dbcontext;

        public ClientesService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ClienteDTO Criar(CriarClienteDTO dto)
        {
            ClienteValidations.ValidouCriarCliente(dto);

            TbCliente novoCliente = ClienteParsers.ToTbCliente(dto);

            _dbcontext.TbClientes.Add(novoCliente);
            _dbcontext.SaveChanges();

            return ClienteParsers.ToClienteDTO(novoCliente);
        }

        public List<ClienteDTO> ListarTodos()
        {
            var clientes = _dbcontext.TbClientes.ToList();
            return clientes.Select(c => ClienteParsers.ToClienteDTO(c)).ToList();
        }

        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new BadRequestException($"Cliente com ID {id} não encontrado.");
            }

            return ClienteParsers.ToClienteDTO(cliente);
        }

        public ClienteDTO Atualizar(int id, AtualizarClienteDTO dto)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new BadRequestException($"Cliente com ID {id} não encontrado.");
            }

            // Validar dados
            if (string.IsNullOrEmpty(dto.Nome))
                throw new BadRequestException("Nome é obrigatório");
            if (string.IsNullOrEmpty(dto.Documento))
                throw new BadRequestException("Documento é obrigatório");
            if (!new[] { 0, 1, 2, 3, 99 }.Contains(dto.Tipodoc))
                throw new BadRequestException("Tipo de documento não suportado");

            // Atualizar campos
            cliente.Nome = dto.Nome;
            cliente.Nascimento = dto.Nascimento;
            cliente.Telefone = dto.Telefone;
            cliente.Documento = dto.Documento;
            cliente.Tipodoc = dto.Tipodoc;
            cliente.Alteradoem = DateTime.UtcNow;

            _dbcontext.SaveChanges();

            return ClienteParsers.ToClienteDTO(cliente);
        }

        public void Deletar(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new BadRequestException($"Cliente com ID {id} não encontrado.");
            }

            _dbcontext.TbClientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }

    }
}
