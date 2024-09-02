namespace ClienteAPI___01.Models
{
    public class Cliente
    {
        /*Nome, Data Nascimento, Sexo, RG, CPF, Endereço, Cidade, Estado, telefone, Email.
* Todos os campos devem ser obrigatório e a API deve validar o CPF.*/

        public int Id { get; set; }
        public string Nome { get; set; }

        public string DataNasc { get; set; }

        public string Sexo { get; set; }

        public string Rg {get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }  
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; } 
        


    }
}
