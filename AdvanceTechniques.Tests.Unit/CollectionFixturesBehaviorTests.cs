namespace AdvanceTechniques.Tests.Unit;

/// <summary>
/// To shared the same objet to different clases its necesary to use the 
/// attribute Collection indicating the name of the CollectionDefinition
/// that implement the Fixture. 
/// 
/// IMPORTANT NOTE: When we shared a fixture to different classes these 
/// tests will be run not in parallel, because are sharing the same 
/// fixture. 
/// 
/// To run in parallel we need to change to the implmentation of : IClassFixture<T>
/// 
/// However, we can further customize
/// </summary>
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
