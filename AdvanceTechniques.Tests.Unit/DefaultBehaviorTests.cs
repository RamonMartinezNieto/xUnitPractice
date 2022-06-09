using Xunit.Abstractions;

namespace AdvanceTechniques.Tests.Unit;

/// <summary>
/// NOTES: Default Behavior is that each test is executed one after another. 
/// And then, each test is indepndent to the othres ones. And each GUID is different
/// 
/// Note: Moving one test to another class, the tests in different classes are running in 
/// parallel. But only one test. The behavior is the same, but we can create tests in 
/// separate clases to parallelize a little bit this are default behavior. 
/// </summary>
public class DefaultBehaviorTests
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly ITestOutputHelper _testOutputHelper;

    public DefaultBehaviorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }


    [Fact]
    public async Task ExampleTest2() 
    {
        _testOutputHelper.WriteLine(_id.ToString());
        await Task.Delay(2000);
    }

    [Fact]
    public async Task ExampleTest3() 
    {
        _testOutputHelper.WriteLine(_id.ToString());
        await Task.Delay(2000);
    }
}

public class DefaultBehaviorTests2
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly ITestOutputHelper _testOutputHelper;

    public DefaultBehaviorTests2(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }


    [Fact]
    public async Task ExampleTest3() 
    {
        _testOutputHelper.WriteLine(_id.ToString());
        await Task.Delay(2000);
    }
}