using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.Library.Interfaces.Processor
{
    public interface ISurveyProcesor
    {
        SurveyProcessResult[] ProcessSurvey(Survey survey);
    }
}