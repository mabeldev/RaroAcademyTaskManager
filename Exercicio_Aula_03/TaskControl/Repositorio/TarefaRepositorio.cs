using TaskControl.Modelos;
using TaskControl.Interfaces;

namespace TaskControl.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        public List<Tarefa> Tarefas = new List<Tarefa>();

        public TarefaRepositorio()
        {
            Tarefas.Add(new Tarefa{Id = 1, Nome = "Tarefa1", Descricao = "Descricao1", Responsavel = 1, Situacao = Status.Pendente});
            Tarefas.Add(new Tarefa{Id = 2, Nome = "Tarefa2", Descricao = "Descricao2", Responsavel = 2, Situacao = Status.Concluida});
            Tarefas.Add(new Tarefa{Id = 3, Nome = "Tarefa3", Descricao = "Descricao3", Responsavel = 3, Situacao = Status.Cancelada});
        }
        public void Registrar (Tarefa tarefa)
        {
        Tarefas.Add(tarefa);
        }

        public Tarefa VerTarefa (int TarefaId)
        {
            return Tarefas.Where(tarefa => tarefa.Id == TarefaId).FirstOrDefault();
        }

        public void MudarResponsavel (int ResponsavelId, int TarefaId)
        {
            VerTarefa(TarefaId).Responsavel = ResponsavelId;
        }

        public void MudarSituacao (int TarefaId, Status situacao)
        {
            VerTarefa(TarefaId).Situacao = situacao;
        }

        public List<Tarefa> VerResponsavelTarefa(int ResponsavelId)
        {
        return Tarefas.Where(tarefa => tarefa.Responsavel == ResponsavelId).ToList();
        }

    }
}