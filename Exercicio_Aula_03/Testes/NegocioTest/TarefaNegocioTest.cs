using Moq;

namespace Testes;

[TestClass]
public class TarefaNegocioTest
{
    private readonly ServiceCollection ServiceColletion = new ServiceCollection();
    private ServiceProvider ServiceProvider;
    private ITarefaNegocio _tarefaNegocio;
    private ITarefaRepositorio _tarefaRepositorio;

    [TestInitialize]
    public void Init()
    {
        ServiceColletion.AddSingleton<ITarefaNegocio, TarefaNegocio>();
        ServiceColletion.AddSingleton<ITarefaRepositorio, TarefaRepositorio>();
        ServiceProvider = ServiceColletion.BuildServiceProvider();
        _tarefaNegocio = ServiceProvider.GetService<ITarefaNegocio>();
    }    
 // ID NOME DESCRICAO RESPONSAVEL SITUACAO
    [TestMethod]
    public void TesteValidaTarefaSemNome()
    {
        Tarefa NTarefa = new Tarefa()
        {
            Id = 4,
            Nome = null,
            Descricao = "Descricao4",
            Responsavel = 1,
            Situacao = Status.Concluida
        };
         
        var excepction = Assert.ThrowsException<Exception>(() => _tarefaNegocio.ValidarTarefa(NTarefa));
        Assert.AreEqual("Invalid Nome", excepction.Message);
    }
    [TestMethod]
    public void TesteValidaTarefaSemDescricao()
    {
        Tarefa NTarefa = new Tarefa()
        {
            Id = 4,
            Nome = "Tarefa4",
            Descricao = null,
            Responsavel = 1,
            Situacao = Status.Concluida
        };
         
        var excepction = Assert.ThrowsException<Exception>(() => _tarefaNegocio.ValidarTarefa(NTarefa));
        Assert.AreEqual("Invalid Descricao", excepction.Message);
    }
    [TestMethod]
    public void TesteValidaTarefaSemResponsavel()
    {
        Tarefa NTarefa = new Tarefa()
        {
            Id = 4,
            Nome = "Tarefa4",
            Descricao = "Descricao4",
            Responsavel = 0,
            Situacao = Status.Concluida
        };
         
        var excepction = Assert.ThrowsException<Exception>(() => _tarefaNegocio.ValidarTarefa(NTarefa));
        Assert.AreEqual("Invalid Responsavel", excepction.Message);
    }
    [TestMethod]
    public void TesteSeCadastraTarefaValida()
    {
        var mock = new Mock<ITarefaRepositorio>();
        Tarefa NTarefa = new Tarefa()
        {
            Id = 4,
            Nome = "Tarefa4",
            Descricao = "Descricao4",
            Responsavel = 2,
            Situacao = Status.Concluida
        };
        
        mock.Setup(Rep => Rep.Registrar(NTarefa));
        mock.Setup(Rep2 => Rep2.VerTarefa(4)).Returns(NTarefa);
        
        _tarefaNegocio = new TarefaNegocio(mock.Object);

        Tarefa tarefa4 = _tarefaNegocio.ProcurarTarefa(4);
        Assert.AreEqual(NTarefa, tarefa4);
    }
}