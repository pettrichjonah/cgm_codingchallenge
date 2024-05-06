using System.Formats.Asn1;
using System.Text.RegularExpressions;

Dictionary<int, Question> questiondict = new Dictionary<int, Question>();

while(true)
{
	Console.WriteLine("Do you want to ask an existing question (1) or add a new one (2)?"); 

	switch(Convert.ToInt32(Console.ReadLine()))
	{
		case 1:
			Console.WriteLine("Alright, ask me a question!");
			int question_id = SearchQuestion(Convert.ToString(Console.ReadLine()));

			if(question_id!=0)
			{
				DisplayQuestion(question_id);
				Console.WriteLine(); //spacing
			}
			else
				Console.WriteLine("the answer to life, universe and everything is 42\n");

			continue;

		case 2:
			Console.WriteLine("I'm excited! Please enter the question you want to add!");
			Console.WriteLine("Input format: <question>? \"<answer1>\" \"<answer2>\" \"<answerx>\"");
			AddNewQuestion();
			continue; 

		default:
			break;
	}
}

void AddNewQuestion() 
{
	string input = Convert.ToString(Console.ReadLine());
	string[] splitinput = input.Split('?');

	string question = splitinput[0].Trim();

	string tempanswerspace = splitinput[1].Trim(); //holds: "Pizza" "Spaghetti" "Ice cream"
	string pattern = "\"(.*?)\"";
	List<string> answers = Regex.Split(tempanswerspace, pattern).ToList<string>();

	//removing the whitespace list items; backwards because List can't be changed while iterating
	for (int i = answers.Count - 1; i >= 0; i--)
    {
        if(string.IsNullOrWhiteSpace(answers[i]))
        {
            answers.RemoveAt(i);
        }
    }

	Question q = new Question(question + "?", answers); //adds question mark back to question for exact comparison
	questiondict.Add(questiondict.Count()+1,q);
}

int SearchQuestion(String inputq) //if this method returns 0, question has not been found
{
	foreach(KeyValuePair<int, Question> q in questiondict)
	{
		if(inputq == q.Value.question)
			return q.Key;
	}
	return 0;
}

void DisplayQuestion(int qkey)
{
	Question foundq = questiondict[qkey];
	foreach(String answer in foundq.answers)
	{
		Console.WriteLine("- " + answer);
	}
}