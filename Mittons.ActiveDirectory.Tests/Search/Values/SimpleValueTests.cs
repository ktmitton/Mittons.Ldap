using Mittons.ActiveDirectory.Search.Values;
using Mittons.ActiveDirectory.Tests.Data;

namespace Mittons.ActiveDirectory.Tests.Search.Values;

public class SimpleValueTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [Matrix("1", "John")] string contents
    )
    {
        // Arrange
        // Act
        SimpleValue value = new(contents);

        // Assert
        await Assert.That(value.Contents).IsEqualTo(contents);
    }

    [Test]
    [MatrixDataSource]
    public async Task DefaultString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
