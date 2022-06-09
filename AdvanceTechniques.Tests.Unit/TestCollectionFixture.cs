namespace AdvanceTechniques.Tests.Unit;

/// <summary>
/// Note: This class is only to "configure" the behavior, because
/// we pretend to share to multiple clases the same object (fixture) 
/// 
/// To do that we implement ICollectionFixture<T> and implement the 
/// concrete fixture. 
/// 
/// The attribute CollectionDefinition mark the class with a name that 
/// we will use in the clases that we want to implement this fixture. 
/// 
/// This is the first step, see the CollectionFixtureBehaviorTest to 
/// see more.
/// 
/// We can disable parallelization in the collection
/// </summary>
[CollectionDefinition("MyCollectionFixture", DisableParallelization = true)]
public class TestCollectionFixture : ICollectionFixture<MyClassFixture>
{
}
