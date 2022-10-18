using TaskControl.Modelos;

namespace TaskControl.Interfaces
{
    public interface IResponsavelNegocio
    {
        public void ValidarResponsavel(Responsavel Responsavel);
        public Responsavel ProcurarResponsavel(int ResponsavelId);

    }
}