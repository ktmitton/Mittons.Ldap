using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Items;
using Mittons.ActiveDirectory.Search.Values;
using Mittons.ActiveDirectory.Tests.Data;

namespace Mittons.ActiveDirectory.Tests.Search.Items;

public class SubstringItemTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        // Act
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, endValueComponent.Component);

        // Assert
        await Assert.That(item.Attribute).IsEqualTo(attributeComponent.Component);
        await Assert.That(item.StartValue).IsEqualTo(startValueComponent.Component);
        await Assert.That(item.Value).IsEqualTo(anyComponent.Component);
        await Assert.That(item.EndValue).IsEqualTo(endValueComponent.Component);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, endValueComponent.Component);
        string expectedResult = $"({attributeComponent.DefaultString}={startValueComponent.DefaultString}{anyComponent.DefaultString}{endValueComponent.DefaultString})";

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, endValueComponent.Component);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}={startValueComponent.DirectoryServicesString}{anyComponent.DirectoryServicesString}{endValueComponent.DirectoryServicesString})";

        // Act
        string actualResult = item.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, endValueComponent.Component);
        string expectedResult = $"({attributeComponent.LdapString}={startValueComponent.LdapString}{anyComponent.LdapString}{endValueComponent.LdapString})";

        // Act
        string actualResult = item.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalledWithNoStartWildcard_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, null, anyComponent.Component, endValueComponent.Component);
        string expectedResult = $"({attributeComponent.DefaultString}={anyComponent.DefaultString}{endValueComponent.DefaultString})";

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalledWithNoStartWildcard_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, null, anyComponent.Component, endValueComponent.Component);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}={anyComponent.DirectoryServicesString}{endValueComponent.DirectoryServicesString})";

        // Act
        string actualResult = item.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalledWithNoStartWildcard_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> endValueComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, null, anyComponent.Component, endValueComponent.Component);
        string expectedResult = $"({attributeComponent.LdapString}={anyComponent.LdapString}{endValueComponent.LdapString})";

        // Act
        string actualResult = item.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalledWithNoEndWildcard_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, null);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}={startValueComponent.DirectoryServicesString}{anyComponent.DirectoryServicesString})";

        // Act
        string actualResult = item.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalledWithNoEndWildcard_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, null);
        string expectedResult = $"({attributeComponent.DirectoryServicesString}={startValueComponent.DirectoryServicesString}{anyComponent.DirectoryServicesString})";

        // Act
        string actualResult = item.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalledWithNoEndWildcard_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesSmallDatasource))] ComponentData<SimpleValue> startValueComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.WildcardValuesSmallDatasource))] ComponentData<WildcardValue> anyComponent
    )
    {
        // Arrange
        SubstringItem item = new(attributeComponent.Component, startValueComponent.Component, anyComponent.Component, null);
        string expectedResult = $"({attributeComponent.LdapString}={startValueComponent.LdapString}{anyComponent.LdapString})";

        // Act
        string actualResult = item.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }
}
