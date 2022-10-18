using TaskControl.Modelos;

namespace TaskControl.Interfaces
{
    public interface ITarefaRepositorio
    {
        public void Registrar (Tarefa tarefa);
        public Tarefa VerTarefa (int TarefaId);
        public void MudarResponsavel (int ResponsavelId, int TarefaId);
        public void MudarSituacao (int TarefaId, Status situacao);

    }
}