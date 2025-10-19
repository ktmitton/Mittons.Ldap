using Mittons.Ldap.Core.Search.Values;
using Mittons.Ldap.Core.Tests.Data;

namespace Mittons.Ldap.Core.Tests.Search.Values;

public class WildcardValueTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [Matrix("1", "John")] string contents,
        [Matrix(true, false)] bool includeStartWildcard,
        [Matrix(true, false)] bool includeEndWildcard
    )
    {
        // Arrange
        // Act
        WildcardValue value = new(contents, includeStartWildcard, includeEndWildcard);

        // Assert
        await Assert.That(value.Contents).IsEqualTo(contents);
        await Assert.That(value.IncludeStartWildcard).IsEqualTo(includeStartWildcard);
        await Assert.That(value.IncludeEndWildcard).IsEqualTo(includeEndWildcard);
    }

    [Test]
    [MatrixDataSource]
    public async Task DefaultString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesDatasource))] ComponentData<WildcardValue> valueComponent
    )
    {
        // Arrange
        string expectedResult = valueComponent.DefaultString;

        // Act
        string actualResult = valueComponent.Component.DefaultString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task DirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesDatasource))] ComponentData<WildcardValue> valueComponent
    )
    {
        // Arrange
        string expectedResult = valueComponent.DirectoryServicesString;

        // Act
        string actualResult = valueComponent.Component.DirectoryServicesString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task LdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesDatasource))] ComponentData<WildcardValue> valueComponent
    )
    {
        // Arrange
        string expectedResult = valueComponent.LdapString;

        // Act
        string actualResult = valueComponent.Component.LdapString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }
}