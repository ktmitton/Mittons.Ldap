using Mittons.ActiveDirectory.Search;
using Attribute = Mittons.ActiveDirectory.Search.Attribute;

namespace Mittons.ActiveDirectory.Tests.Search;

public class PresentItemTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<PresentItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent
    )
    {
        // Arrange
        // Act
        PresentItem item = new(attributeComponent.Component);

        // Assert
        await Assert.That(item.Attribute).IsEqualTo(attributeComponent.Component);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<PresentItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent
    )
    {
        // Arrange
        PresentItem item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.DefaultString}=*)";

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<PresentItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent
    )
    {
        // Arrange
        PresentItem item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}=*)";

        // Act
        string actualResult = item.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<PresentItemTests>(nameof(AttributesDatasource))] ComponentData<Attribute> attributeComponent
    )
    {
        // Arrange
        PresentItem item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.LdapString}=*)";

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
}
