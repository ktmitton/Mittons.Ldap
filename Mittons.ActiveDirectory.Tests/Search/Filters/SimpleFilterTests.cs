using Mittons.ActiveDirectory.Search;
using Mittons.ActiveDirectory.Search.Filters;
using Mittons.ActiveDirectory.Search.Operators;
using Mittons.ActiveDirectory.Tests.Data;
using Moq;

namespace Mittons.ActiveDirectory.Tests.Search.Filters;

public class SimpleFilterTests
{
    private readonly string _filterDefaultString = Guid.NewGuid().ToString();
    private readonly string _filterDirectoryServicesString = Guid.NewGuid().ToString();
    private readonly string _filterLdapString = Guid.NewGuid().ToString();
    private readonly Mock<IFilter> _filterMock = new();

    public SimpleFilterTests()
    {
        _filterMock.Setup(f => f.ToString()).Returns(_filterDefaultString);
        _filterMock.Setup(f => f.ToDirectoryServicesString()).Returns(_filterDirectoryServicesString);
        _filterMock.Setup(f => f.ToLdapString()).Returns(_filterLdapString);
    }

    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        // Act
        SimpleFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);

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
        Assert.Throws<ArgumentException>(() => new SimpleFilter(logicalOperatorComponent.Component, _filterMock.Object));
    }

    [Test]
    [MatrixDataSource]
    public async Task ToString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        SimpleFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);
        string expectedResults = $"({logicalOperatorComponent.Component}{_filterDefaultString})";

        // Act
        string actualResult = simpleFilter.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        SimpleFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);
        string expectedResults = $"({logicalOperatorComponent.Component}{_filterDirectoryServicesString})";

        // Act
        string actualResult = simpleFilter.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    [MatrixDataSource]
    public async Task ToLdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        SimpleFilter simpleFilter = new(logicalOperatorComponent.Component, _filterMock.Object);
        string expectedResults = $"({logicalOperatorComponent.Component}{_filterLdapString})";

        // Act
        string actualResult = simpleFilter.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }
}
