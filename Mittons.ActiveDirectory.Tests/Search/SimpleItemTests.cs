using Mittons.ActiveDirectory.Search;
using Attribute = Mittons.ActiveDirectory.Search.Attribute;

namespace Mittons.ActiveDirectory.Tests.Search;

public class SimpleItemTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<SimpleItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ValuesDatasource))] ComponentData<Value> valueComponent
    )
    {
        // Arrange
        // Act
        SimpleItem item = new(attributeComponent.Component, comparisonOperatorComponent.Component, valueComponent.Component);

        // Assert
        await Assert.That(item.Attribute).IsEqualTo(attributeComponent.Component);
        await Assert.That(item.ComparisonOperator).IsEqualTo(comparisonOperatorComponent.Component);
        await Assert.That(item.Value).IsEqualTo(valueComponent.Component);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<SimpleItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ValuesDatasource))] ComponentData<Value> valueComponent
    )
    {
        // Arrange
        SimpleItem item = new(attributeComponent.Component, comparisonOperatorComponent.Component, valueComponent.Component);
        string expectedResult = $"({attributeComponent.DefaultString}{comparisonOperatorComponent.DefaultString}{valueComponent.DefaultString})";

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<SimpleItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ValuesDatasource))] ComponentData<Value> valueComponent
    )
    {
        // Arrange
        SimpleItem item = new(attributeComponent.Component, comparisonOperatorComponent.Component, valueComponent.Component);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}{comparisonOperatorComponent.DirectoryServicesString}{valueComponent.DirectoryServicesString})";

        // Act
        string actualResult = item.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<SimpleItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<SimpleItemTests>(nameof(ValuesDatasource))] ComponentData<Value> valueComponent
    )
    {
        // Arrange
        SimpleItem item = new(attributeComponent.Component, comparisonOperatorComponent.Component, valueComponent.Component);
        string expectedResult = $"({attributeComponent.LdapString}{comparisonOperatorComponent.LdapString}{valueComponent.LdapString})";

        // Act
        string actualResult = item.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    public record ComponentData<T>(T Component, string DefaultString, string DirectoryServicesString, string LdapString);

    private static IEnumerable<ComponentData<Attribute>> AttributesDatasource()
    {
        yield return new ComponentData<Attribute>(new Attribute("name"), "name", "name", "name");
        yield return new ComponentData<Attribute>(new Attribute("id"), "id", "id", "id");
    }

    private static IEnumerable<ComponentData<ComparisonOperator>> ComparisonOperatorsDatasource()
    {
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.Equality, "=", "=", "=");
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.ApproximateMatch, "~=", "~=", "~=");
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.GreaterThanOrEqual, ">=", ">=", ">=");
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.LessThanOrEqual, "<=", "<=", "<=");
    }

    private static IEnumerable<ComponentData<Value>> ValuesDatasource()
    {
        yield return new ComponentData<Value>(new Value("1"), "1", "1", "1");
        yield return new ComponentData<Value>(new Value("John"), "John", "John", "John");
        yield return new ComponentData<Value>(new Value(@"John\Smith"), @"John\Smith", @"John\\Smith", @"John\5cSmith");
        yield return new ComponentData<Value>(new Value("John*Smith"), "John*Smith", @"John\*Smith", @"John\2aSmith");
        yield return new ComponentData<Value>(new Value("(John) Smith"), "(John) Smith", @"\(John\) Smith", @"\28John\29 Smith");
        yield return new ComponentData<Value>(new Value("John\0Smith"), "John\0Smith", "John\0Smith", @"John\00Smith");
    }
}
