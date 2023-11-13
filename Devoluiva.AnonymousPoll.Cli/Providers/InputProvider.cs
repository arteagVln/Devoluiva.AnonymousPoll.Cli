using Devoluiva.AnonymousPoll.Cli.Helpers;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.Cli.Providers;

public class InputProvider : IInputProvider
{
    public Survey GetSurvey()
    {
        var testCasesNumber = Parsers.ParseInteger(Console.ReadLine()!);
        var survey = new Survey
        {
            Responses = new SurveyResponse[testCasesNumber]
        };

        for (int i = 0; i < testCasesNumber; i++)
        {
            var line = Console.ReadLine()!.Split(',');

            survey.Responses[i] = new SurveyResponse
            {
                Gender = line[0],
                Age = Parsers.ParseInteger(line[1]),
                Education = line[2],
                AcademicYear = Parsers.ParseInteger(line[3])
            };
        }

        return survey;
    }
}
