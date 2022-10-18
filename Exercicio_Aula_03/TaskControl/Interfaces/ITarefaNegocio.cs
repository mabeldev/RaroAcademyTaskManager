using TaskControl.Modelos;

namespace TaskControl.Interfaces
{
    public interface ITarefaNegocio
    {
        public void ValidarTarefa (Tarefa tarefa);
        public Tarefa ProcurarTarefa(int TarefaId);
    }
}