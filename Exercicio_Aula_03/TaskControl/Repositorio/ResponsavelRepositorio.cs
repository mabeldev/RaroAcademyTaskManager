using TaskControl.Modelos;
using TaskControl.Interfaces;

namespace TaskControl.Repositorio
{
    public class ResponsavelRepositorio : IResponsavelRepositorio
    {   
        public List<Responsavel> Responsaveis = new List<Responsavel>();
        public ResponsavelRepositorio()
        {
            Responsaveis.Add(new Responsavel{Id = 1, Nome = "Joao",});
            Responsaveis.Add(new Responsavel{Id = 2, Nome = "Maria",});
            Responsaveis.Add(new Responsavel{Id = 3, Nome = "Eduardo",});
        }
         public void AdicionarResponsavel (Responsavel responsavel)
        {
            Responsaveis.Add(responsavel);
        }
        public Responsavel ProcurarResponsavel (int ResponsavelId)
        {
           var ResponsavelEncontrado =  Responsaveis.Where(responsavel => responsavel.Id == ResponsavelId).FirstOrDefault();
           return ResponsavelEncontrado;
        }
    }
    
   

}