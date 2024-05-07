public class Question
{
	public String question;
	public List<string> answers;
	
	public Question(String inputq, List<string> inputa)
	{
		int maxLength = 255;

		question = inputq;

		answers = inputa;
		for (int i = answers.Count - 1; i >= 0; i--)
		{
			if(answers[i].Length>maxLength)
				answers[i] = answers[i].Substring(0, 255); //ensures the answers aren't longer than 255 chars and in case shortens them
		}
	}
}