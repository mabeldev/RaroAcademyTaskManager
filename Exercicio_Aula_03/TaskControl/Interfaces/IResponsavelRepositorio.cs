using TaskControl.Modelos;

namespace TaskControl.Interfaces
{
    public interface IResponsavelRepositorio
    {
        public void AdicionarResponsavel (Responsavel responsavel);
        public Responsavel ProcurarResponsavel (int ResponsavelId);
    }
}