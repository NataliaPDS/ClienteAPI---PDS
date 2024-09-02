using ClienteAPI___01.Dtos;
using ClienteAPI___01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI___01.Salvar
{
    public class ClienteSalvar

    {
      
            private const string linkCam = "C:\\Users\\Master\\Documents\\TarefaTxt\\Cliente.txt";

            public static List<Cliente> Lista()
            {
                var clientes = new List<Cliente>();

                if (!File.Exists(linkCam))
                    return clientes;

                foreach (var line in File.ReadAllLines(linkCam))
                {
                    var linha = line.Split('|');
                    clientes.Add(new Cliente
                    {
                        Id = int.Parse(linha[0]),
                        Nome = linha[1],
                        DataNasc = linha[2],
                        Sexo = linha[3],
                        Rg = linha[4],
                        Cpf = linha[5],
                        Endereco = linha[6],
                        Cidade = linha[7],
                        Estado = linha[8],
                        Telefone = linha[9],
                        Email = linha[10]
                    });
                }

                return clientes;
            }

            public static Cliente GetById(int id)
            {
                return Lista().FirstOrDefault(c => c.Id == id);
            }

            public static Cliente GetByCPF(string cpf)
            {
                return Lista().FirstOrDefault(c => c.Cpf == cpf);
            }

            public static Cliente Criar(ClienteDTO clienteDto)
            {
                if (!ValidaCPF(clienteDto.Cpf))
                {
                    throw new ArgumentException("CPF inválido.");
                }

                var clientes = Lista();
                var criarCliente = new Cliente
                {
                    Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1,
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

                clientes.Add(criarCliente);
                Salvar(clientes);
                return criarCliente;
            }

            public static Cliente Atualizar(int id, ClienteDTO clienteDto)
            {
                if (!ValidaCPF(clienteDto.Cpf))
                {
                    throw new ArgumentException("CPF inválido.");
                }

                var clientes = Lista();
                var cliente = clientes.FirstOrDefault(c => c.Id == id);

                if (cliente == null) return null;

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

                Salvar(clientes);
                return cliente;
            }

            public static bool Deletar(int id)
            {
                var clientes = Lista();
                var cliente = clientes.FirstOrDefault(c => c.Id == id);

                if (cliente == null) return false;

                clientes.Remove(cliente);
                Salvar(clientes);
                return true;
            }

            private static void Salvar(List<Cliente> clientes)
            {
                // Verifica se o diretório existe e o cria se necessário
                string diretorio = Path.GetDirectoryName(linkCam);
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                var linhas = clientes.Select(c =>
                    $"{c.Id}|{c.Nome}|{c.DataNasc}|{c.Sexo}|{c.Rg}|{c.Cpf}|{c.Endereco}|{c.Cidade}|{c.Estado}|{c.Telefone}|{c.Email}");
                File.WriteAllLines(linkCam, linhas);
            }

        public static bool ValidaCPF(string cpf)
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

