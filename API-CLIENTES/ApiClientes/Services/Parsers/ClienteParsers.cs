using System;
using ApiClientes.Database.Models;
using ApiClientes.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Services.Parsers
{
    public class ClienteParsers
    {
        public static TbCliente ToTbCliente(
            CriarClienteDTO dto)
        {
            TbCliente novoCliente = new();
            novoCliente.Nome = dto.Nome;
            novoCliente.Telefone = dto.Telefone;
            novoCliente.Documento = dto.Documento;
            novoCliente.Tipodoc = dto.Tipodoc;
            novoCliente.Criadoem = DateTime.Now.ToUniversalTime();
            novoCliente.Alteradoem = novoCliente.Criadoem;

            return novoCliente;
        }

        public static ClienteDTO ToClienteDTO(TbCliente cliente)
        {

            ClienteDTO Response = new();
            Response.Id = cliente.Id;
            Response.Nome = cliente.Nome;
            Response.Criadoem = cliente.Criadoem;
            Response.Alteradoem = cliente.Alteradoem;
            Response.Telefone = cliente.Telefone;
            Response.Documento = cliente.Documento;
            Response.Nascimento = cliente.Nascimento;
            Response.Tipodoc = cliente.Tipodoc;

            return Response;
        }
    }
}
