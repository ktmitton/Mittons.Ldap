namespace Mittons.ActiveDirectory.Search.Builders
{
    public class FluentSearchBuilder
    {
        public FluentUnknownFilterBuilder Where => new FluentUnknownFilterBuilder();
    }

    public class TestBuilder
    {
        public void Test()
        {
            new FluentSearchBuilder()
                .Where
                .Attribute("name")
                .Does
                .Exist()
                .Build();

            new FluentSearchBuilder()
                .Where
                .Attribute("name")
                .Does
                .Exist()
                .And
                .Attribute("email")
                .Is
                .EqualTo("kdrive113@gmail.com")
                .And
                .Attribute("age")
                .Does
                .Not
                .StartWith("2")
                .And
                .Attribute("status")
                .Does
                .Not
                .Exist()
                .And
                .Attribute("age")
                .Is
                .Not
                .LessThan(21)
                .Build();

            new FluentSearchBuilder()
                .Where
                .Attribute("name")
                .Is
                .Not
                .EqualTo("John Doe")
                .Build();

            new FluentSearchBuilder()
                .Where
                .Attribute("age")
                .Is
                .GreaterThan(30)
                .Or
                .Attribute("department")
                .Does
                .StartWith("Sales")
                .Build();
        }
    }
}