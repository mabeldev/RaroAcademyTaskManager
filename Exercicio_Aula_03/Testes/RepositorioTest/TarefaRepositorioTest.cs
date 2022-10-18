using Moq;
namespace Testes
{
    [TestClass]

    public class TarefaRepositorioTest
    {
        private readonly ServiceCollection ServiceColletion = new ServiceCollection();
        private ServiceProvider ServiceProvider;
        private ITarefaRepositorio _tarefaRepositorio;
        
        [TestInitialize]
        public void Init()
        {
        ServiceColletion.AddSingleton<ITarefaRepositorio, TarefaRepositorio>();
        ServiceProvider = ServiceColletion.BuildServiceProvider();
        _tarefaRepositorio = ServiceProvider.GetService<ITarefaRepositorio>();
        }
        
        [TestMethod]
        public void TestaSeAdicionaTarefa()
        {
            Tarefa NTarefa = new Tarefa()
            {
                Id = 4,
                Nome = "Tarefa4",
                Descricao = null,
                Responsavel = 1,
                Situacao = Status.Concluida
            };
            _tarefaRepositorio.Registrar(NTarefa);
            var BNTarefa = _tarefaRepositorio.VerTarefa(4);
            Assert.AreEqual(NTarefa, BNTarefa);
        }

        [TestMethod]
        public void TestaSeEncontraTarefa()
        {
            var BNTarefa = _tarefaRepositorio.VerTarefa(3);
            Console.WriteLine($"{BNTarefa}");
            Assert.IsNotNull(BNTarefa);
        }

        [TestMethod]
        public void TestaSeMudaResponsavel()
        {
            _tarefaRepositorio.MudarResponsavel(3, 1);
            Assert.AreEqual(_tarefaRepositorio.VerTarefa(1).Responsavel, 3);
        }
        [TestMethod]
        public void TestaSeMudaSituacao()
        {
            _tarefaRepositorio.MudarSituacao(1, Status.Concluida);
            Assert.AreEqual(_tarefaRepositorio.VerTarefa(1).Situacao, Status.Concluida);
        }
    }
}