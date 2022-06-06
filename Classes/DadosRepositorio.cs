using FinalWork.EducationalSoftware.Interfaces;
using FinalWork.EducationalSoftware.Series;

namespace FinalWork.EducationalSoftware
{
    public class DadosRepositorio : IRepositorio<Dado>
	{
        private List<Dado> listaDados = new List<Dado>();
		
		public void Atualiza(int id, Dado objeto)
		{
			listaDados[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaDados[id].Excluir();
		}

		public void Insere(Dado objeto)
		{
			listaDados.Add(objeto);
		}

		public List<Dado> Lista()
		{
			return listaDados;
		}

		public int ProximoId()
		{
			return listaDados.Count;
		}

		public Dado RetornaPorId(int id)
		{
			return listaDados[id];
		}
	}
}