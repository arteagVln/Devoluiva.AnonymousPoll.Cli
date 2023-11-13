using Devoluiva.AnonymousPoll.Library.Interfaces.Processor;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.Cli.Processor;

public class SurveyProcesor : ISurveyProcesor
{
    private readonly IStudentProvider _studentProvider;

    public SurveyProcesor(IStudentProvider studentProvider)
    {
        _studentProvider = studentProvider;
    }

    public SurveyProcessResult[] ProcessSurvey(Survey survey)
    {
        var students = _studentProvider.GetStudents();
        var result = new SurveyProcessResult[survey.Responses.Length];

        for (int i = 0; i < survey.Responses.Length; i++)
        {
            result[i] = new SurveyProcessResult(i + 1, Match(survey.Responses[i], students));
        }

        return result;
    }

    public static string[] Match(SurveyResponse surveyResponse, Student[] students)
    {
        return students.Where(x => x.Gender == surveyResponse.Gender && x.Age == surveyResponse.Age
                             && x.Education == surveyResponse.Education && x.AcademicYear == surveyResponse.AcademicYear)
                       .Select(s => s.Name)
                       .ToArray();
    }
}
