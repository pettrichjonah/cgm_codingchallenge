using System.Text.RegularExpressions;

public static class Program
{
	public static List<Question> questionList = new();

	static void Main()
	{
		while (true)
		{
			Console.WriteLine("Do you want to ask an existing question (1) or add a new one (2)?");

			switch (GetInput())
			{
				case "1":
					Console.WriteLine("\nAlright, ask me a question!");
					var question = SearchQuestion(GetInput());

					if (question != null)
					{
						Console.WriteLine(GetAnswers(question)); //outputs question
					}
					else
						Console.WriteLine("- the answer to life, universe and everything is 42\n");

					break;
				case "2":
					Console.WriteLine("\nI'm excited! Please enter the question you want to add!");

					//escape characters because of extensive double quote usage
					Console.WriteLine("Input format: <question>? \"<answer1>\" \"<answer2>\" \"<answerx>\"");

					questionList.Add(CreateNewQuestion(GetInput()));

					break;
				default:
					Console.WriteLine("Enter a valid option!");

					break;
			}
		}
	}

	/// <summary>
	/// Prevents User from entering nothing by trapping inside a loop as long as input isn't given.
	/// </summary>
	private static string GetInput()
	{
		string? input;

		do
		{
			input = Console.ReadLine();

			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Your input can't be empty!");
			}
		} while (string.IsNullOrEmpty(input));

		return input;
	}

	/// <summary>
	/// Reads the input string, builds an Object of Question and returns it.
	/// </summary>
	public static Question CreateNewQuestion(string input)
	{
		var inputSplitted = input.Split('?');
		var question = inputSplitted[0].Trim();

		//warns user that question is too long and returns to program start2
		if (question.Length > 255)
		{
			Console.WriteLine("Question can't be longer than 255 chars! Please try again! ");
		}

		var answersAsString = inputSplitted[1].Trim(); //holds: "Pizza" "Spaghetti" "Ice cream"
		Console.WriteLine(answersAsString);

		var pattern = "\"(.*?)\"";
		var answers = Regex.Matches(answersAsString, pattern);

		var answerList = new List<string>();

		foreach (Match match in answers)
		{
			answerList.Add(match.Groups[1].Value);
		}

		var q = new Question(question + "?", answerList); //adds question mark at the end of the question for exact comparison

		return q;
	}

	/// <summary>
	/// If this method returns null, question has not been found.
	/// </summary>
	public static Question? SearchQuestion(string input)
	{
		foreach (var q in questionList)
		{
			if (input == q.question)
				return q;
		}

		return null;
	}

	/// <summary>
	/// This method builds a string to output the according answers for the given question.
	/// </summary>
	public static string GetAnswers(Question question)
	{
		string answerOutput = string.Empty;

		foreach (string answer in question.answers)
		{
			answerOutput += $"- {answer}\n";
		}

		return answerOutput;
	}
}