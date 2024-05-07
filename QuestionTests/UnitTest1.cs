namespace QuestionTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestCreateNewQuestion()
    {
        Dictionary<int, Question> expecteddict = new Dictionary<int, Question>();
        expecteddict.Add(1, new Question("What is Peters favorite food?", new List<string>{"Pizza", "Spaghetti", "Ice cream"}));   

        Dictionary<int, Question> questiondict = new Dictionary<int, Question>();
        questiondict.Add(questiondict.Count()+1,Program.CreateNewQuestion("What is Peters favorite food? \"Pizza\" \"Spaghetti\" \"Ice cream\""));

        CollectionAssert.AreEqual(expecteddict, questiondict);
    }
}