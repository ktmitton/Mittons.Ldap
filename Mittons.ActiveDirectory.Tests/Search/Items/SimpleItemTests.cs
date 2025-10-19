using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Items;
using Mittons.ActiveDirectory.Search.Operators;
using Mittons.ActiveDirectory.Search.Values;
using Mittons.ActiveDirectory.Tests.Data;

namespace Mittons.ActiveDirectory.Tests.Search.Items;

public class SimpleItemTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.AttributesDatasource))] ComponentData<SimpleAttribute> attributeComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.ComparisonOperatorsDatasource))] ComponentData<ComparisonOperator> comparisonOperatorComponent,
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleValuesDatasource))] ComponentData<SimpleValue> valueComponent
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
}
