using Devoluiva.AnonymousPoll.Library.Interfaces.Formatters;
using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.CliV2.Formatters;

public class BarOutputFormatter : IOutputFormatter
{
    public string Format(SurveyProcessResult surveyProcessItem)
    {
        var studentNames = string.Join("| ", surveyProcessItem.StudentNames.OrderBy(x => x));

        return studentNames.Any()
            ? $"Case #{surveyProcessItem.CaseNumber}: {studentNames}"
            : $"Case #{surveyProcessItem.CaseNumber}: NONE";
    }
}
