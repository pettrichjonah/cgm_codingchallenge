using System.Text.RegularExpressions;

public class Program {
	public static Dictionary<int, Question> questiondict = new Dictionary<int, Question>();

	static void Main() 
	{
		while(true)
		{
			Console.WriteLine("Do you want to ask an existing question (1) or add a new one (2)?"); 

			switch(GetInput())
			{
				case "1":
					Console.WriteLine("\nAlright, ask me a question!");
					int question_id = SearchQuestion(GetInput());

					if(question_id!=0)
					{
						Console.WriteLine(GetAnswers(question_id)); //outputs question
					}
					else
						Console.WriteLine("- the answer to life, universe and everything is 42\n");

					continue;

				case "2":
					Console.WriteLine("\nI'm excited! Please enter the question you want to add!");
					Console.WriteLine("Input format: <question>? \"<answer1>\" \"<answer2>\" \"<answerx>\""); //escape characters because of extensive double quote usage
					questiondict.Add(questiondict.Count()+1,CreateNewQuestion(GetInput()));

					continue; 

				default:
					Console.WriteLine("Enter a valid option!");

					continue;
			}
		}
	}

	private static string GetInput() //prevents user from entering nothing
	{
		string input = "";
		
		do {
			input = Console.ReadLine();
			if (string.IsNullOrEmpty(input)) {
				Console.WriteLine("Your input can't be empty!");
			}
		} while (string.IsNullOrEmpty(input));

		return input;
	}

	public static Question CreateNewQuestion(string input) 
	{
		string[] splitinput = input.Split('?');

		string question = splitinput[0].Trim();
		if(question.Length>255)
		{
			Console.WriteLine("Question can't be longer than 255 chars! Please try again! "); //warns user that question is too long and returns to program start
		}

		string tempanswerspace = splitinput[1].Trim(); //holds: "Pizza" "Spaghetti" "Ice cream"
		string pattern = "\"(.*?)\"";
		List<string> answers = Regex.Split(tempanswerspace, pattern).ToList<string>();

		//removing the whitespace list items; backwards because List can't be changed while iterating
		for (int i = answers.Count - 1; i >= 0; i--)
		{
			if(string.IsNullOrWhiteSpace(answers[i]))
				answers.RemoveAt(i);
		}

		Question q = new Question(question + "?", answers); //adds question mark back to question for exact comparison
		return q;
	}

	public static int SearchQuestion(String inputq) //if this method returns 0, question has not been found
	{
		foreach(KeyValuePair<int, Question> q in questiondict)
		{
			if(inputq == q.Value.question)
				return q.Key;
		}
		return 0;
	}

	public static string GetAnswers(int qkey)
	{
		string answeroutput = "";
		Question foundq = questiondict[qkey];

		foreach(String answer in foundq.answers)
		{
			answeroutput += "- " + answer + "\n";
		}

		return answeroutput;
	}
}