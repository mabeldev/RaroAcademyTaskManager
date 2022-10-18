using TaskControl.Modelos;
using TaskControl.Interfaces;

namespace TaskControl.Negocio
{
    public class ResponsavelNegocio : IResponsavelNegocio
    {
        private readonly IResponsavelRepositorio _ResponsavelRepositorio;

        public ResponsavelNegocio(IResponsavelRepositorio ResponsavelRepositorio)
        {
            _ResponsavelRepositorio = ResponsavelRepositorio;
        }
        
        public void ValidarResponsavel(Responsavel Responsavel)
        {
            if (Responsavel == null)
            {
                throw new Exception("Invalid Responsavel");
            }
            if (Responsavel.Id == null)
            {
                throw new Exception("Invalid ResponsavelId");
            }
            if (Responsavel.Nome == null || Responsavel.Nome.Length < 2)
            {
                throw new Exception("Invalid ResponsavelNome");
            }
            _ResponsavelRepositorio.AdicionarResponsavel(Responsavel);
        }
        public Responsavel ProcurarResponsavel(int ResponsavelId)
        {
            var ResponsavelEncontrado = _ResponsavelRepositorio.ProcurarResponsavel(ResponsavelId);
            if (ResponsavelEncontrado.Id == null)
            {
                return null;
            }
            return ResponsavelEncontrado;
        }
    }
}