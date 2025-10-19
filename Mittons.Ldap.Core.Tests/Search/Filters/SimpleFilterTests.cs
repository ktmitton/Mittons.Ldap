using Mittons.Ldap.Core.Search;
using Mittons.Ldap.Core.Search.Filters;
using Mittons.Ldap.Core.Search.Operators;
using Mittons.Ldap.Core.Tests.Data;
using Moq;

namespace Mittons.Ldap.Core.Tests.Search.Filters;

public class SimpleFilterTests
{
    private readonly string _filterDefaultString = Guid.NewGuid().ToString();
    private readonly string _filterDirectoryServicesString = Guid.NewGuid().ToString();
    private readonly string _filterLdapString = Guid.NewGuid().ToString();
    private readonly Mock<IFilter> _filterMock = new();

    public SimpleFilterTests()
    {
        _filterMock.Setup(f => f.DefaultString).Returns(_filterDefaultString);
        _filterMock.Setup(f => f.DirectoryServicesString).Returns(_filterDirectoryServicesString);
        _filterMock.Setup(f => f.LdapString).Returns(_filterLdapString);
    }

    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        // Act
        SimpleLogicalFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);

        // Assert
        await Assert.That(simpleFilter.LogicalOperator).IsEqualTo(logicalOperatorComponent.Component);
        await Assert.That(simpleFilter.Filter).IsEqualTo(_filterMock.Object);
    }

    [Test]
    [MatrixDataSource]
    public void Ctor_WhenCreatedWithACompoundOperator_ExpectException(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.CompoundLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new SimpleLogicalFilter(logicalOperatorComponent.Component, _filterMock.Object));
    }

    [Test]
    [MatrixDataSource]
    public async Task DefaultString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        SimpleLogicalFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);
        string expectedResults = $"({logicalOperatorComponent.Component.DefaultString}{_filterDefaultString})";

        // Act
        string actualResult = simpleFilter.DefaultString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    [MatrixDataSource]
    public async Task DirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        SimpleLogicalFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);
        string expectedResults = $"({logicalOperatorComponent.Component.DirectoryServicesString}{_filterDirectoryServicesString})";

        // Act
        string actualResult = simpleFilter.DirectoryServicesString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    [MatrixDataSource]
    public async Task LdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        SimpleLogicalFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);
        string expectedResults = $"({logicalOperatorComponent.Component.LdapString}{_filterLdapString})";

        // Act
        string actualResult = simpleFilter.LdapString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }
}
