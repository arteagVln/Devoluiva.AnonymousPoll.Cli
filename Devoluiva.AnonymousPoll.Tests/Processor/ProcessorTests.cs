using Devoluiva.AnonymousPoll.Cli.Processor;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Devoluiva.AnonymousPoll.Library.Models;
using Moq;

namespace Devoluiva.AnonymousPoll.Tests.Processor;

public class ProcessorTests
{
    private readonly SurveyProcesor _sut;
    private readonly Mock<IStudentProvider> _studentProviderMock;

    private readonly Survey survey = new()
    {
        Responses = new SurveyResponse[] 
        {
            new SurveyResponse { Gender = "M", Age = 21, Education = "Carpenter", AcademicYear = 2 }
        }
    };

    public ProcessorTests()
    {
        _studentProviderMock = new Mock<IStudentProvider>();
        _sut = new SurveyProcesor(_studentProviderMock.Object);
    }

    [Fact]
    public void ProcessSurves_ActionExecutes_ReturnsSurveyProccessResultArray()
    {
        var result = _sut.ProcessSurvey(survey);
        Assert.IsType<SurveyProcessResult[]>(result);
    }

    [Fact]
    public void ProcessSurveys_ActionExecutes_ReturnsAProccessResultPerSurveyResponse()
    {
        var result = _sut.ProcessSurvey(survey);
        Assert.Equal(survey.Responses.Count(), result.Length);
    }

    [Fact]
    public void GetTeams_ActionExecutes_MatchShouldFindCorrectAmountOfStudents()
    {
        _studentProviderMock.Setup(provider => provider.GetStudents())
            .Returns(new Student[] 
            { 
                new Student{ Name = "Fabio Ayala", Gender = "M", Age = 21, Education = "Carpenter", AcademicYear = 2},
                new Student{ Name = "Amed Morales", Gender = "M", Age = 21, Education = "Carpenter", AcademicYear = 2}
            });

        var result = _sut.ProcessSurvey(survey);
        Assert.Equal(2, result[0].StudentNames.Length);
    }
}
