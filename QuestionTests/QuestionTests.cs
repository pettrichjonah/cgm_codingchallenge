namespace QuestionTests;

[TestClass]
public class QuestionTests
{
    private static Question expectedQuestion = new("What is Peters favorite food?", new List<string> { "Pizza", "Spaghetti", "Ice cream" });

    [TestMethod]
    public void TestCreateNewQuestion()
    {
        var question = Program.CreateNewQuestion("What is Peters favorite food? \"Pizza\" \"Spaghetti\" \"Ice cream\"");

        AssertQuestions(expectedQuestion, question);
    }

    [TestMethod]
    public void TestSearchQuestion()
    {
        const string q = "What is Peters favorite food?";

        Program.questionList.Add(new Question(q, new List<string> { "Pizza", "Spaghetti", "Ice cream" }));
        var question = Program.SearchQuestion(q);

        AssertQuestions(expectedQuestion, question!);
    }

    [TestMethod]
    public void TestGetAnswers()
    {
        var expectedOutput = "- Pizza\n- Spaghetti\n- Ice cream\n";
        var actualOutput = Program.GetAnswers(expectedQuestion);

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    private void AssertQuestions(Question q1, Question q2)
    {
        Assert.AreEqual(q1.question, q2.question);
        for (int i = 0; i < q1.answers.Count; i++)
        {
            Assert.AreEqual(q1.answers[i], q2.answers[i]);
        }
    }
}