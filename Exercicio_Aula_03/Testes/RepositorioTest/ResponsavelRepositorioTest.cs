using Moq;

namespace Testes
{
    [TestClass]
    public class ResponsavelRepositorioTest
    {
        private readonly ServiceCollection ServiceColletion = new ServiceCollection();
        private ServiceProvider ServiceProvider;
        private IResponsavelRepositorio _responsavelRepositorio;
        
        [TestInitialize]
        public void Init()
        {
        ServiceColletion.AddSingleton<IResponsavelRepositorio, ResponsavelRepositorio>();
        ServiceProvider = ServiceColletion.BuildServiceProvider();
        _responsavelRepositorio = ServiceProvider.GetService<IResponsavelRepositorio>();
        }

        [TestMethod]
        public void TesteSeAdicionaAoRepositorio()
        {
            Responsavel NResponsavel = new Responsavel{Id = 4, Nome = "Joao"};
            _responsavelRepositorio.AdicionarResponsavel(NResponsavel);
            var RespTest = _responsavelRepositorio.ProcurarResponsavel(4);
            Assert.AreEqual(NResponsavel, RespTest);
        }
        [TestMethod]
        public void TesteSeEncontraResponsavel()
        {
            var RespTest = _responsavelRepositorio.ProcurarResponsavel(1);
            Console.WriteLine(RespTest);
            Assert.IsNotNull(RespTest);
        }

    }
}