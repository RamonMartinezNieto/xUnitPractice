namespace AdvanceTechniques.Tests.Unit;

public class MyClassFixture  : IDisposable
{
    public Guid Id { get; } = Guid.NewGuid();

    public MyClassFixture()
    {
        //This will runs once before any test in the class that implement it
        //remember that the constructor in the class tests is running before each test
    }

    public void Dispose()
    {
        //This will runs once at the end of all tests
        //remember that the dispose in the class tests is running after each test
    }
}
