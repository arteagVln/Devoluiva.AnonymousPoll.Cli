namespace Devoluiva.AnonymousPoll.Library.Models;

public class SurveyProcessResult
{
    public int CaseNumber { get; }
    public string[] StudentNames { get; }

    public SurveyProcessResult(int caseNumber, string[] studentNames)
    {
        CaseNumber = caseNumber;
        StudentNames = studentNames;
    }
}
