using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.Library.Interfaces.Formatters
{
    public interface IOutputFormatter
    {
        string Format(SurveyProcessResult surveyProcessItem);
    }
}