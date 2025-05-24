    using System.Linq;
    using ApiClientes.Services.DTOs;
    using ApiClientes.Services.Exceptions;

    namespace ApiClientes.Services.Validations
    {
        public class ClienteValidations
        {
            public static bool ValidouCriarCliente(
                CriarClienteDTO criarClienteDTO)

            {
                if (string.IsNullOrEmpty(criarClienteDTO.Nome))
            
                    throw new BadRequestException(
                        "Nome é obrigatório");
            

                if (string.IsNullOrEmpty(criarClienteDTO.Documento))
                    throw new BadRequestException(
                        "Documento é obrigatório");


                if (new[] { 0, 1, 2, 3, 99 }.Contains(
                    criarClienteDTO.Tipodoc))
                    throw new BadRequestException(
                        "Tipo de documento não suportado");


                return true;

            }

        }
    }
