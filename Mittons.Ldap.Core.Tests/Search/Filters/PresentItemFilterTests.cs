using Mittons.Ldap.Core.Search.Attributes;
using Mittons.Ldap.Core.Search.Filters;
using Mittons.Ldap.Core.Tests.Data;

namespace Mittons.Ldap.Core.Tests.Search.Filters;

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
    public async Task DefaultString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        PresentItemFilter item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.DefaultString}=*)";

        // Act
        string actualResult = item.DefaultString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task DirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        PresentItemFilter item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}=*)";

        // Act
        string actualResult = item.DirectoryServicesString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task LdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent
    )
    {
        // Arrange
        PresentItemFilter item = new(attributeComponent.Component);
        string expectedResult = $"({attributeComponent.LdapString}=*)";

        // Act
        string actualResult = item.LdapString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }
}
