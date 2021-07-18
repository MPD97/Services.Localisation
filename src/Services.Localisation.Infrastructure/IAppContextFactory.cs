using Services.Localisation.Application;

namespace Services.Localisation.Infrastructure
{
    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}