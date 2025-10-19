using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Filters;
using Mittons.ActiveDirectory.Tests.Data;

namespace Mittons.ActiveDirectory.Tests.Search.Filters;

public class PresentItemFilterTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        // Act
        PresentItemFilter item = new(attributeComponent.Component);

        // Assert
        await Assert.That(item.Attribute).IsEqualTo(attributeComponent.Component);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        PresentItemFilter item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.DefaultString}=*)";

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        PresentItemFilter item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}=*)";

        // Act
        string actualResult = item.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        PresentItemFilter item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.LdapString}=*)";

        // Act
        string actualResult = item.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }
}
