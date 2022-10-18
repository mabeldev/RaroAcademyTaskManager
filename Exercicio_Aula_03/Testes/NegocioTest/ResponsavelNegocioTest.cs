using Moq;

namespace Testes;

[TestClass]
public class ResponsavelNegocioTest
{
    private readonly ServiceCollection ServiceColletion = new ServiceCollection();
    private ServiceProvider ServiceProvider;
    private IResponsavelNegocio _responsavelNegocio;
    

    [TestInitialize]
    public void Init()
    {
        ServiceColletion.AddSingleton<IResponsavelNegocio, ResponsavelNegocio>();
        ServiceColletion.AddSingleton<IResponsavelRepositorio, ResponsavelRepositorio>();
        ServiceProvider = ServiceColletion.BuildServiceProvider();
        _responsavelNegocio = ServiceProvider.GetService<IResponsavelNegocio>();
    }    
 // ID NOME 
    [TestMethod]
    public void TesteValidaResponsavelSemId()
    {
        Responsavel NResponsavel = new Responsavel()
        {
            Id = null,
            Nome = "Alisson",
        };
         
        var excepction = Assert.ThrowsException<Exception>(() => _responsavelNegocio.ValidarResponsavel(NResponsavel));
        Assert.AreEqual("Invalid ResponsavelId", excepction.Message);
    }
    [TestMethod]
    public void TesteValidaResponsavelSemNome()
    {
        Responsavel NResponsavel = new Responsavel()
        {
            Id = 4,
            Nome = null,
        };
         
        var excepction = Assert.ThrowsException<Exception>(() => _responsavelNegocio.ValidarResponsavel(NResponsavel));
        Assert.AreEqual("Invalid ResponsavelNome", excepction.Message);
    }
    [TestMethod]
    public void TesteValidaResponsavelNomePequeno()
    {
        Responsavel NResponsavel = new Responsavel()
        {
            Id = 4,
            Nome = "a",
        };
         
        var excepction = Assert.ThrowsException<Exception>(() => _responsavelNegocio.ValidarResponsavel(NResponsavel));
        Assert.AreEqual("Invalid ResponsavelNome", excepction.Message);
    }
    [TestMethod]
    public void TesteEncontraResponsavelNaoExistente()
    {
        var ResponsavelId = 5;
        var mock = new Mock<IResponsavelRepositorio>();

        mock.Setup(Rep => Rep.ProcurarResponsavel(ResponsavelId)).Returns(new Responsavel {Id = null});
        _responsavelNegocio = new ResponsavelNegocio(mock.Object);

        var PResponsavel = _responsavelNegocio.ProcurarResponsavel(ResponsavelId);

       var excepction = Assert.ThrowsException<Exception>(() => _responsavelNegocio.ValidarResponsavel(PResponsavel));
        Assert.AreEqual("Invalid Responsavel", excepction.Message);
    }
    
    [TestMethod]
    public void TesteEncontraResponsavelExistente()
    {
        var ResponsavelId = 1;
        var mock = new Mock<IResponsavelRepositorio>();

        mock.Setup(Rep => Rep.ProcurarResponsavel(ResponsavelId)).Returns(new Responsavel {Id = 1, Nome = "Alisson" });
        _responsavelNegocio = new ResponsavelNegocio(mock.Object);

        var PResponsavel = _responsavelNegocio.ProcurarResponsavel(ResponsavelId);
        Console.WriteLine($"{PResponsavel}");

        Assert.IsNotNull(PResponsavel);
    }

}