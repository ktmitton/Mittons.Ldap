using Mittons.ActiveDirectory.Search;

namespace Mittons.ActiveDirectory.Tests.Search;

public class PresentItemTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [Matrix("id", "name")] string attribute
    )
    {
        // Arrange
        // Act
        PresentItem item = new(attribute);

        // Assert
        await Assert.That(item.Attribute).IsEqualTo(attribute);
    }

    [Test]
    [MatrixDataSource]
    public void Ctor_WhenCreatedWithInvalidAttributes_ExpectException(
        [Matrix(null, "", " ")] string attribute
    )
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new PresentItem(attribute));
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalled_ExpectAValidLdapItemString(
        [Matrix("id", "name")]string attribute
    )
    {
        // Arrange
        string expectedResult = $"({attribute}=*)";
        PresentItem item = new(attribute);

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
        PresentItem item = new(unescapedAttribute);
        string expectedResult = $"({escapedAttribute}=*)";

        // Act
        string actualResult = item.ToLdapEscapedString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
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
