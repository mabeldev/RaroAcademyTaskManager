namespace Testes;

[TestClass]
public class UnitTest1
{
    private readonly ServiceCollection ServiceColletion = new ServiceCollection();
    private ServiceProvider ServiceProvider;
    private IResponsavelNegocio ResponsavelNegocio;
    private IResponsavelRepositorio ResponsavelRepositorio;
    private ITarefaNegocio TarefaNegocio;
    private ITarefaRepositorio TarefaRepositorio;

    [TestInitialize]
    public void Init()
    {
        ServiceColletion.AddSingleton<IResponsavelNegocio, ResponsavelNegocio>();
        ServiceColletion.AddSingleton<IResponsavelRepositorio, ResponsavelRepositorio>();
        ServiceColletion.AddSingleton<ITarefaNegocio, TarefaNegocio>();
        ServiceColletion.AddSingleton<ITarefaRepositorio, TarefaRepositorio>();
    }    

}