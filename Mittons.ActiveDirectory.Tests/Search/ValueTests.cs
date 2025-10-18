using Mittons.ActiveDirectory.Search;

namespace Mittons.ActiveDirectory.Tests.Search;

public class ValueTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [Matrix(
            "1",
            "John",
            "John Smith",
            @"John\Smith",
            "John*Smith",
            "(John) Smith"
        )] string contents
    )
    {
        // Arrange
        // Act
        Value value = new(contents);

        // Assert
        await Assert.That(value.Contents).IsEqualTo(contents);
    }

    [Test]
    [Arguments("1", "1")]
    [Arguments("John", "John")]
    [Arguments(@"John\Smith", @"John\Smith")]
    [Arguments("John*Smith", @"John*Smith")]
    [Arguments("(John) Smith", @"(John) Smith")]
    [Arguments("John\0Smith", "John\0Smith")]
    public async Task ToString_WhenCalled_ExpectTheContentsToBeReturned(
        string contents,
        string expectedResult
    )
    {
        // Arrange
        Value value = new(contents);

        // Act
        string actualResult = value.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [Arguments("1", "1")]
    [Arguments("John", "John")]
    [Arguments(@"John\Smith", @"John\\Smith")]
    [Arguments("John*Smith", @"John\*Smith")]
    [Arguments("(John) Smith", @"\(John\) Smith")]
    [Arguments("John\0Smith", "John\0Smith")]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheSpecialCharactersToBeStringEscaped(
        string contents,
        string expectedResult
    )
    {
        // Arrange
        Value value = new(contents);

        // Act
        string actualResult = value.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [Arguments("1", "1")]
    [Arguments("John", "John")]
    [Arguments(@"John\Smith", @"John\5cSmith")]
    [Arguments("John*Smith", @"John\2aSmith")]
    [Arguments("(John) Smith", @"\28John\29 Smith")]
    [Arguments("John\0Smith", @"John\00Smith")]
    public async Task ToLdapString_WhenCalled_ExpectSpecialCharactersToBeHexEncoded(
        string contents,
        string expectedResult
    )
    {
        // Arrange
        Value value = new(contents);

        // Act
        string actualResult = value.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    // [Test]
    // [MethodDataSource(nameof(EscapedStringsDatasource))]
    // public async Task ToLdapEscapedString_WhenCalledWithAttributesThatNeedEscaped_ExpectAValidLdapEscapedString(
    //     string unescapedAttribute,
    //     string escapedAttribute
    // )
    // {
    //     // Arrange
    //     PresentItem item = new(unescapedAttribute);
    //     string expectedResult = $"({escapedAttribute}=*)";

    //     // Act
    //     string actualResult = item.ToLdapEscapedString();

    //     // Assert
    //     await Assert.That(actualResult).IsEqualTo(expectedResult);
    // }

    // public static IEnumerable<(string unescaped, string escaped)> EscapedStringsDatasource()
    // {
    //     (string unescaped, string escaped)[] SpecialCharacters = [
    //         (@"\*", @"\2a"),
    //         (@"\(", @"\28"),
    //         (@"\)", @"\29"),
    //         (@"\\", @"\5c"),
    //     ];

    //     foreach (var (unescaped, escaped) in SpecialCharacters)
    //     {
    //         yield return ($"{unescaped}test", $"{escaped}test");
    //         yield return ($"test{unescaped}", $"test{escaped}");
    //         yield return ($"te{unescaped}st", $"te{escaped}st");
    //     }
    // }
}
