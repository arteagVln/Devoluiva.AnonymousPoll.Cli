using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.Library.Interfaces.Providers
{
    public interface IInputProvider
    {
        Survey GetSurvey();
    }
}