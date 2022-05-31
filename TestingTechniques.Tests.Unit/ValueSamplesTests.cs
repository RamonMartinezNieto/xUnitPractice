namespace TestingTechniques.Tests.Unit;

public class ValueSamplesTests
{
    private ValueSamples _sut = new(); //system under tests

    [Fact]
    public void String_ShouldBeTheSameString()
    {
        var result = _sut.FullName; 
        var expected = "Ramón Martínez";

        result.Should().Be(expected);
        result.Should().NotBe("Ramon Martinez");
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().StartWith("Ramón");
        result.Should().EndWith("Martínez");
    }

    [Fact]
    public void Int_ShouldBeTheSameInt()
    {
        var result = _sut.Age; 
        var expected = 33;

        result.Should().Be(expected);
        result.Should().NotBe(22);
        result.Should().BePositive(); 
        result.Should().NotBeNull();    
    } 
    
    [Fact]
    public void Date_ShouldBeTheSameDate_Example()
    {
        DateOnly result = _sut.DataofBirthday;

        result.Should().Be(new(1988, 10, 27));
        //result.Should().BeInRange(new(1980, 10, 27), new(1990, 10, 27)); //preguntar
        //result.Should().BeGreatherThan(new(1988, 10, 1)); //preguntar
    }
    
    [Fact]
    public void UserExample_ShouldBeTheSameUser()
    {
        var result = _sut.AppUser;

        var expected = new User()
        {
            FullName = "Ramon Martinez",
            Age = 33,
            DateOfBirthday = new(1988, 10, 27)
        };

        //Assert.Equal(expected, result); //this fails because is checkin the references of the object
        //result.Should().Be(expected); //this fails because is checkin the references of the object

        //this runs because is checking all properties in execution time to check each individual property
        result.Should().BeEquivalentTo(expected); 
    }
        
    [Fact]
    public void EnumerableObjectExample()
    {
        var expected = new User()
        {
            FullName = "Ramon Martinez",
            Age = 33,
            DateOfBirthday = new(1988, 10, 27)
        };

        var users = _sut.Users.As<User[]>();

        //users.Should().Contain(expected); //fail because is checking the reference
        users.Should().ContainEquivalentOf(expected); // same as BeEquivalentTo
        users.Should().HaveCount(3);
        users.Should().Contain(x => x.FullName.StartsWith("Ramon"));
        users.Should().HaveCountLessThan(10); 
    }


    [Fact]
    public void Example_EnumerableInt()
    {
        var numbers = _sut.Numbers.As<int[]>();

        numbers.Should().HaveCount(4);
        numbers.Should().Contain(5);
        numbers.Should().NotHaveCount(10);
    }

}