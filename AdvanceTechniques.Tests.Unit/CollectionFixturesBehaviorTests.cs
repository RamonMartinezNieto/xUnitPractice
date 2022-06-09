namespace AdvanceTechniques.Tests.Unit;


[Collection("MyCollectionFixture")]
public class CollectionFixturesBehaviorTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly MyClassFixture _classFixture;

    public CollectionFixturesBehaviorTests(ITestOutputHelper testOutputHelper, 
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

[Collection("MyCollectionFixture")]
public class CollectionFixturesBehaviorTests2
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly MyClassFixture _classFixture;

    public CollectionFixturesBehaviorTests2(ITestOutputHelper testOutputHelper, 
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
