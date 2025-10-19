using Mittons.Ldap.Core.Search;
using Mittons.Ldap.Core.Search.Filters;
using Mittons.Ldap.Core.Search.Operators;
using Mittons.Ldap.Core.Tests.Data;
using Moq;

namespace Mittons.Ldap.Core.Tests.Search.Filters;

public class CompoundFilterTests
{
    [Test]
    [MatrixDataSource]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.CompoundLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent,
        [MatrixMethod<CompoundFilterTests>(nameof(RandomFiltersDatasource))] (Mock<IFilter> filter, string defaultString, string directoryServicesString, string ldapString)[] filters
    )
    {
        // Arrange
        // Act
        CompoundLogicalFilter compoundFilter = new(logicalOperatorComponent.Component, filters.Select(f => f.filter.Object));

        // Assert
        await Assert.That(compoundFilter.LogicalOperator).IsEqualTo(logicalOperatorComponent.Component);
        await Assert.That(compoundFilter.Filters).IsEquivalentTo(filters.Select(f => f.filter.Object));
    }

    [Test]
    [MatrixDataSource]
    public void Ctor_WhenCreatedWithASimpleOperator_ExpectException(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.SimpleLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent
    )
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new CompoundLogicalFilter(logicalOperatorComponent.Component, [Mock.Of<IFilter>()]));
    }

    [Test]
    [MatrixDataSource]
    public async Task DefaultString_WhenCalled_ExpectTheDefaultStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.CompoundLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent,
        [MatrixMethod<CompoundFilterTests>(nameof(RandomFiltersDatasource))] (Mock<IFilter> filter, string defaultString, string directoryServicesString, string ldapString)[] filters
    )
    {
        // Arrange
        CompoundLogicalFilter compoundFilter = new(logicalOperatorComponent.Component, filters.Select(f => f.filter.Object));
        string expectedResults = $"({logicalOperatorComponent.Component.DefaultString}{string.Join(string.Empty, filters.Select(f => f.defaultString))})";

        // Act
        string actualResult = compoundFilter.DefaultString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    [MatrixDataSource]
    public async Task DirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.CompoundLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent,
        [MatrixMethod<CompoundFilterTests>(nameof(RandomFiltersDatasource))] (Mock<IFilter> filter, string defaultString, string directoryServicesString, string ldapString)[] filters
    )
    {
        // Arrange
        CompoundLogicalFilter compoundFilter = new(logicalOperatorComponent.Component, filters.Select(f => f.filter.Object));
        string expectedResults = $"({logicalOperatorComponent.Component.DirectoryServicesString}{string.Join(string.Empty, filters.Select(f => f.directoryServicesString))})";

        // Act
        string actualResult = compoundFilter.DirectoryServicesString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    [MatrixDataSource]
    public async Task LdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned(
        [MatrixMethod<ComponentDataDatasource>(nameof(ComponentDataDatasource.CompoundLogicalOperatorsDatasource))] ComponentData<LogicalOperator> logicalOperatorComponent,
        [MatrixMethod<CompoundFilterTests>(nameof(RandomFiltersDatasource))] (Mock<IFilter> filter, string defaultString, string directoryServicesString, string ldapString)[] filters
    )
    {
        // Arrange
        CompoundLogicalFilter compoundFilter = new(logicalOperatorComponent.Component, filters.Select(f => f.filter.Object));
        string expectedResults = $"({logicalOperatorComponent.Component.LdapString}{string.Join(string.Empty, filters.Select(f => f.ldapString))})";

        // Act
        string actualResult = compoundFilter.LdapString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    public static IEnumerable<(Mock<IFilter> filter, string defaultString, string directoryServicesString, string ldapString)[]> RandomFiltersDatasource()
    {
        for (int i = 1; i <= 5; i++)
        {
            yield return [.. Enumerable.Range(0, i).Select(_ =>
            {
                string defaultString = Guid.NewGuid().ToString();
                string directoryServicesString = Guid.NewGuid().ToString();
                string ldapString = Guid.NewGuid().ToString();

                Mock<IFilter> filterMock = new();
                filterMock.Setup(f => f.DefaultString).Returns(defaultString);
                filterMock.Setup(f => f.DirectoryServicesString).Returns(directoryServicesString);
                filterMock.Setup(f => f.LdapString).Returns(ldapString);

                return (filterMock, defaultString, directoryServicesString, ldapString);
            })];
        }
    }
}
