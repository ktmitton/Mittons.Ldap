using Mittons.ActiveDirectory.Search.Filters;
using Moq;

namespace Mittons.ActiveDirectory.Tests.Search.Filters;

public class FilterTests
{
    private readonly string _filterDefaultString = Guid.NewGuid().ToString();
    private readonly string _filterDirectoryServicesString = Guid.NewGuid().ToString();
    private readonly string _filterLdapString = Guid.NewGuid().ToString();
    private readonly Mock<IFilterComponent> _filterComponentMock = new();

    public FilterTests()
    {
        _filterComponentMock.Setup(f => f.DefaultString).Returns(_filterDefaultString);
        _filterComponentMock.Setup(f => f.DirectoryServicesString).Returns(_filterDirectoryServicesString);
        _filterComponentMock.Setup(f => f.LdapString).Returns(_filterLdapString);
    }

    [Test]
    public async Task Ctor_WhenCreated_ExpectPropertiesToBeSet()
    {
        // Arrange
        // Act
        Filter filter = new(_filterComponentMock.Object);

        // Assert
        await Assert.That(filter.FilterComponent).IsEqualTo(_filterComponentMock.Object);
    }

    [Test]
    public void Ctor_WhenCreatedWithACompoundOperator_ExpectException()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Filter(null!));
    }

    [Test]
    public async Task DefaultString_WhenCalled_ExpectTheDefaultStringToBeReturned()
    {
        // Arrange
        Filter filter = new(_filterComponentMock.Object);
        string expectedResults = $"({_filterDefaultString})";

        // Act
        string actualResult = filter.DefaultString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    public async Task DirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned()
    {
        // Arrange
        Filter filter = new(_filterComponentMock.Object);
        string expectedResults = $"({_filterDirectoryServicesString})";

        // Act
        string actualResult = filter.DirectoryServicesString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    public async Task LdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned()
    {
        // Arrange
        Filter filter = new(_filterComponentMock.Object);
        string expectedResults = $"({_filterLdapString})";

        // Act
        string actualResult = filter.LdapString;

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }
}
