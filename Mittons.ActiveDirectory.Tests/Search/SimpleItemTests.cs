using Mittons.ActiveDirectory.Search;

namespace Mittons.ActiveDirectory.Tests.Search;

public class SimpleItemTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [Matrix("id", "name")] string attribute,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperators))] ComparisonOperator comparisonOperator,
        [Matrix("1", "John")] string value
    )
    {
        // Arrange
        // Act
        SimpleItem item = new(attribute, comparisonOperator, value);

        // Assert
        await Assert.That(item.Attribute).IsEqualTo(attribute);
        await Assert.That(item.ComparisonOperator).IsEqualTo(comparisonOperator);
        await Assert.That(item.Value).IsEqualTo(value);
    }

    [Test]
    [MatrixDataSource]
    public void Ctor_WhenCreatedWithInvalidAttributes_ExpectException(
        [Matrix(null, "", " ")] string attribute,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperators))] ComparisonOperator comparisonOperator,
        [Matrix("1", "John")] string value
    )
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new SimpleItem(attribute, comparisonOperator, value));
    }

    [Test]
    [MatrixDataSource]
    public void Ctor_WhenCreatedWithInvalidValues_ExpectException(
        [Matrix("id", "name")] string attribute,
        [MatrixMethod<SimpleItemTests>(nameof(ComparisonOperators))] ComparisonOperator comparisonOperator,
        [Matrix(null, "", " ")] string value
    )
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new SimpleItem(attribute, comparisonOperator, value));
    }

    [Test]
    [MethodDataSource(nameof(BasicToStringDatasource))]
    public async Task ToString_WhenCalled_ExpectAValidLdapItemString(
        string attribute,
        ComparisonOperator comparisonOperator,
        string value,
        string expectedResult
    )
    {
        // Arrange
        SimpleItem item = new(attribute, comparisonOperator, value);

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MethodDataSource(nameof(EscapedStringsDatasource))]
    public async Task ToLdapEscapedString_WhenCalledWithAttributesThatNeedEscaped_ExpectAValidLdapEscapedString(
        string unescapedAttribute,
        string escapedAttribute
    )
    {
        // Arrange
        SimpleItem item = new(unescapedAttribute, ComparisonOperator.Equality, "John");
        string expectedResult = $"({escapedAttribute}=John)";

        // Act
        string actualResult = item.ToLdapEscapedString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MethodDataSource(nameof(EscapedStringsDatasource))]
    public async Task ToLdapEscapedString_WhenCalledWithValuesThatNeedEscaped_ExpectAValidLdapEscapedString(
        string unescapedValue,
        string escapedValue
    )
    {
        // Arrange
        SimpleItem item = new("name", ComparisonOperator.Equality, unescapedValue);
        string expectedResult = $"(name={escapedValue})";

        // Act
        string actualResult = item.ToLdapEscapedString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    private static IEnumerable<ComparisonOperator> ComparisonOperators()
    {
        yield return ComparisonOperator.Equality;
        yield return ComparisonOperator.ApproximateMatch;
        yield return ComparisonOperator.GreaterThanOrEqual;
        yield return ComparisonOperator.LessThanOrEqual;
    }

    public static IEnumerable<(string attribute, ComparisonOperator comparisonOperator, string value, string expectedResult)> BasicToStringDatasource()
    {
        yield return ("name", ComparisonOperator.Equality, "John", "(name=John)");
        yield return ("name", ComparisonOperator.ApproximateMatch, "Smith", "(name~=Smith)");
        yield return ("id", ComparisonOperator.GreaterThanOrEqual, "1", "(id>=1)");
        yield return ("id", ComparisonOperator.LessThanOrEqual, "2", "(id<=2)");
    }

    public static IEnumerable<(string unescaped, string escaped)> EscapedStringsDatasource()
    {
        (string unescaped, string escaped)[] SpecialCharacters = [
            (@"\*", @"\2a"),
            (@"\(", @"\28"),
            (@"\)", @"\29"),
            (@"\\", @"\5c"),
        ];

        foreach (var (unescaped, escaped) in SpecialCharacters)
        {
            yield return ($"{unescaped}test", $"{escaped}test");
            yield return ($"test{unescaped}", $"test{escaped}");
            yield return ($"te{unescaped}st", $"te{escaped}st");
        }
    }
}
