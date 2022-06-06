namespace FinalWork.EducationalSoftware.Series
{
    public class Dado : EntidadeBase
    {
        // Atributos
		private SelecioneTipoDado Tipo { get; set; }
		private string Nome { get; set; }
		private string Email { get; set; }
		private int Telefone { get; set; }
        private bool Excluido { get; set; }

        // Métodos
		public Dado(int id, SelecioneTipoDado tipo, string nome, string email, int telefone)
		{
			this.Id = id;
			this.Tipo = tipo;
			this.Nome = nome;
			this.Email = email;
			this.Telefone = telefone;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            
			retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "E-mail: " + this.Email + Environment.NewLine;
            retorno += "Telefone: " + this.Telefone + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}

        public bool retornaExcluido()
		{
			return this.Excluido;	
		}

        public void Excluir() {
            this.Excluido = true;
        }
    }
}