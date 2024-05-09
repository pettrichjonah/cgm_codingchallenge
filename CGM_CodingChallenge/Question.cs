public class Question
{
	public string question;
	public List<string> answers;

	private int maxLength = 255;
	
	public Question(string inputq, List<string> inputa)
	{
		question = inputq;

		answers = inputa;
		for (int i = 0; i < answers.Count; i++)
		{
			 if(answers[i].Length>maxLength)
			 	answers[i] = answers[i].Substring(0, 255); //ensures the answers aren't longer than 255 chars and in case shortens them
		}
	}
}