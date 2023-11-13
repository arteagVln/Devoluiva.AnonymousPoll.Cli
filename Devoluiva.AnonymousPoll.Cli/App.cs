using Devoluiva.AnonymousPoll.Library.Interfaces.Formatters;
using Devoluiva.AnonymousPoll.Library.Interfaces.Processor;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;

namespace Devoluiva.AnonymousPoll.Cli;

public class App
{
    private readonly IInputProvider _inputProvider;
    private readonly ISurveyProcesor _surveyProcesor;
    private readonly IOutputFormatter _outputFormatter;

    public App(IInputProvider inputProvider, ISurveyProcesor surveyProcesor, IOutputFormatter outputFormatter)
    {
        _inputProvider = inputProvider;
        _surveyProcesor = surveyProcesor;
        _outputFormatter = outputFormatter;
    }

    public void Run() 
    {
        var survey = _inputProvider.GetSurvey();
        var result = _surveyProcesor.ProcessSurvey(survey);

        foreach (var item in result)
            Console.WriteLine(_outputFormatter.Format(item));

        Console.ReadLine();
    }
}
