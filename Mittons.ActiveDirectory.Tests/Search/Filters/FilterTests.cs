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
        _filterComponentMock.Setup(f => f.ToString()).Returns(_filterDefaultString);
        _filterComponentMock.Setup(f => f.ToDirectoryServicesString()).Returns(_filterDirectoryServicesString);
        _filterComponentMock.Setup(f => f.ToLdapString()).Returns(_filterLdapString);
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
    public async Task ToString_WhenCalled_ExpectTheDefaultStringToBeReturned()
    {
        // Arrange
        Filter filter = new(_filterComponentMock.Object);
        string expectedResults = $"({_filterDefaultString})";

        // Act
        string actualResult = filter.ToString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    public async Task ToDirectoryServicesString_WhenCalled_ExpectTheDirectoryServicesEncodedStringToBeReturned()
    {
        // Arrange
        Filter filter = new(_filterComponentMock.Object);
        string expectedResults = $"({_filterDirectoryServicesString})";

        // Act
        string actualResult = filter.ToDirectoryServicesString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }

    [Test]
    public async Task ToLdapString_WhenCalled_ExpectTheLdapEncodedStringToBeReturned()
    {
        // Arrange
        Filter filter = new(_filterComponentMock.Object);
        string expectedResults = $"({_filterLdapString})";

        // Act
        string actualResult = filter.ToLdapString();

        // Assert
        await Assert.That(actualResult).IsEqualTo(expectedResults);
    }
}
