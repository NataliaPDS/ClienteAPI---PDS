using ClienteAPI___01.Dtos;
using ClienteAPI___01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI___01.Controllers
{
    [Route("/")]
    [ApiController]

        public class ClienteController : ControllerBase
        {
      
        private static List<Cliente> listaClientes = new List<Cliente>();

        public ClienteController()
        {
            if (!listaClientes.Any())
            {
                listaClientes.Add(new Cliente
                {
                    Id = 1,
                    Nome = "Natalia",
                    DataNasc = "01/01/2000",
                    Sexo = "Feminino",
                    Rg = "1111111",
                    Cpf = "000.000.000-00",
                    Endereco = "Rua Vital",
                    Cidade = "Sao Luis",
                    Estado = "Acre",
                    Telefone = "69 9999 9999",
                    Email = "email@gmail.com",
                });

                listaClientes.Add(new Cliente
                {
                    Id = 2,
                    Nome = "Sthefany",
                    DataNasc = "02/02/2000",
                    Sexo = "Feminino",
                    Rg = "2222222",
                    Cpf = "111.111.111-11",
                    Endereco = "Rua Flores",
                    Cidade = "Ji-Parana",
                    Estado = "Rondonia",
                    Telefone = "69 9999 9999",
                    Email = "emaill@gmail.com",
                });
            }
        }

        // Retorna todos os clientes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaClientes);
        }

        // Retorna um cliente por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = listaClientes.FirstOrDefault(item => item.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // Retorna um cliente por CPF
        [HttpGet("GetCPF")]
        public IActionResult GetByCPF(string cpf)
        {
            if (!ValidaCPF(cpf))
            {
                return BadRequest("CPF inválido.");
            }

            var cliente = listaClientes.FirstOrDefault(c => c.Cpf == cpf);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // Adiciona um novo cliente à lista
        [HttpPost("AdicionaCliente")]
        public IActionResult Post([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("Cliente não pode ser vazio.");
            }
            if (!ValidaCPF(clienteDto.Cpf))
            {
                return BadRequest("CPF inválido.");
            }

            var cliente = new Cliente
            {
                Id = listaClientes.Count + 1,
                Nome = clienteDto.Nome,
                DataNasc = clienteDto.DataNasc,
                Sexo = clienteDto.Sexo,
                Rg = clienteDto.Rg,
                Cpf = clienteDto.Cpf,
                Endereco = clienteDto.Endereco,
                Cidade = clienteDto.Cidade,
                Estado = clienteDto.Estado,
                Telefone = clienteDto.Telefone,
                Email = clienteDto.Email
            };

            listaClientes.Add(cliente);
            return StatusCode(StatusCodes.Status201Created, cliente);
        }

        // Atualiza um cliente existente
        [HttpPut("AtualizaCliente")]
        public IActionResult Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("Cliente não pode ser vazio.");
            }
            if (!ValidaCPF(clienteDto.Cpf))
            {
                return BadRequest("CPF inválido.");
            }
            
            var cliente = listaClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nome = clienteDto.Nome;
            cliente.DataNasc = clienteDto.DataNasc;
            cliente.Sexo = clienteDto.Sexo;
            cliente.Rg = clienteDto.Rg;
            cliente.Cpf = clienteDto.Cpf;
            cliente.Endereco = clienteDto.Endereco;
            cliente.Cidade = clienteDto.Cidade;
            cliente.Estado = clienteDto.Estado;
            cliente.Telefone = clienteDto.Telefone;
            cliente.Email = clienteDto.Email;

            return Ok(cliente);
        }

        // Deleta um cliente da lista
        [HttpDelete("DeletaCliente")]
        public IActionResult Delete(int id)
        {
            var cliente = listaClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            listaClientes.Remove(cliente);
            return Ok(cliente);
        }

        // Validação de CPF
        private static bool ValidaCPF(string cpf)
        {

            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");



            int cont1 = 11;
            int soma1 = 0;

            if (cpf.Length == 11)
            {

                for (int i = 0; i < cpf.Length - 1; i++)
                {
                    soma1 = Convert.ToInt32(cpf[i].ToString()) * cont1;

                    cont1 = cont1 - 1;
                }
                int rest1 = soma1 % 11;

                if (rest1 < 2)
                {
                    rest1 = 0;
                }
                else
                {
                    rest1 = 11 - rest1;
                }

                if (Convert.ToInt32(cpf[10].ToString()) != rest1)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }


        }
    }


    
}
