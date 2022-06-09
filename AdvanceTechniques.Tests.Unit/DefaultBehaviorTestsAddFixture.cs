using Xunit.Abstractions;

namespace AdvanceTechniques.Tests.Unit;

/// <summary>
/// NOTES: A fixture is the way to shared a component (or some  else) 
/// to all tests.
/// We ned implement IClassFixture<T> and iject it 
/// 
/// All tests will be have the same GUID as ID 
/// </summary>
public class DefaultBehaviorTestsAddFixture : IClassFixture<MyClassFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly MyClassFixture _classFixture;

    public DefaultBehaviorTestsAddFixture(ITestOutputHelper testOutputHelper, 
        MyClassFixture classFixture)
    {
        _testOutputHelper = testOutputHelper;
        _classFixture = classFixture;
    }


    [Fact]
    public async Task ExampleTest2() 
    {
        _testOutputHelper.WriteLine($"{_classFixture.Id}");
        await Task.Delay(2000);
    }

    [Fact]
    public async Task ExampleTest3() 
    {
        _testOutputHelper.WriteLine($"{_classFixture.Id}");
        await Task.Delay(2000);
    }
}