using TaskControl.Modelos;
using TaskControl.Interfaces;

namespace TaskControl.Negocio
{
    public class TarefaNegocio : ITarefaNegocio
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaNegocio(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        public void ValidarTarefa(Tarefa tarefa)
        {
            if (tarefa == null)
            {
                throw new Exception("Invalid Tarefa");
            }
            if (tarefa.Nome == null || tarefa.Nome.Length < 2 )
            {
                throw new Exception("Invalid Nome");
            }
            if (tarefa.Descricao == null || tarefa.Descricao.Length < 10 )
            {
                throw new Exception("Invalid Descricao");
            }
            if  (tarefa.Responsavel == 0)
            {
                throw new Exception("Invalid Responsavel");
            }

            _tarefaRepositorio.Registrar(tarefa);
            Console.WriteLine("Tarefa Cadastrada com Sucesso!");

        }
        public Tarefa ProcurarTarefa(int TarefaId)
        {
            var TarefaEncontrada = _tarefaRepositorio.VerTarefa(TarefaId);
            if(TarefaEncontrada.Id == 0)
            {
                throw new Exception("Tarefa não encontrado");
            }
            return TarefaEncontrada;
        }

        
    }
}