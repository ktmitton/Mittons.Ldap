using Mittons.ActiveDirectory.Search;
using Mittons.ActiveDirectory.Search.Values;

using Attribute = Mittons.ActiveDirectory.Search.Attribute;

namespace Mittons.ActiveDirectory.Tests.Data;

public record ComponentData<T>(T Component, string DefaultString, string DirectoryServicesString, string LdapString);

public class ComponentDataDatasource
{
    public static IEnumerable<ComponentData<Attribute>> AttributesDatasource()
    {
        yield return new ComponentData<Attribute>(new Attribute("name"), "name", "name", "name");
        yield return new ComponentData<Attribute>(new Attribute("id"), "id", "id", "id");
    }

    public static IEnumerable<ComponentData<ComparisonOperator>> ComparisonOperatorsDatasource()
    {
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.Equality, "=", "=", "=");
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.ApproximateMatch, "~=", "~=", "~=");
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.GreaterThanOrEqual, ">=", ">=", ">=");
        yield return new ComponentData<ComparisonOperator>(ComparisonOperator.LessThanOrEqual, "<=", "<=", "<=");
    }

    public static IEnumerable<ComponentData<SimpleValue>> SimpleValuesDatasource()
    {
        yield return new ComponentData<SimpleValue>(new SimpleValue("1"), "1", "1", "1");
        yield return new ComponentData<SimpleValue>(new SimpleValue("John"), "John", "John", "John");
        yield return new ComponentData<SimpleValue>(new SimpleValue(@"John\Smith"), @"John\Smith", @"John\\Smith", @"John\5cSmith");
        yield return new ComponentData<SimpleValue>(new SimpleValue("John*Smith"), "John*Smith", @"John\*Smith", @"John\2aSmith");
        yield return new ComponentData<SimpleValue>(new SimpleValue("(John) Smith"), "(John) Smith", @"\(John\) Smith", @"\28John\29 Smith");
        yield return new ComponentData<SimpleValue>(new SimpleValue("John\0Smith"), "John\0Smith", "John\0Smith", @"John\00Smith");
    }

    public static IEnumerable<ComponentData<WildcardValue>> WildcardValuesDatasource()
    {
        yield return new ComponentData<WildcardValue>(new WildcardValue("1", false, false), "1", "1", "1");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John", false, false), "John", "John", "John");
        yield return new ComponentData<WildcardValue>(new WildcardValue(@"John\Smith", false, false), @"John\Smith", @"John\\Smith", @"John\5cSmith");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John*Smith", false, false), "John*Smith", @"John\*Smith", @"John\2aSmith");
        yield return new ComponentData<WildcardValue>(new WildcardValue("(John) Smith", false, false), "(John) Smith", @"\(John\) Smith", @"\28John\29 Smith");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John\0Smith", false, false), "John\0Smith", "John\0Smith", @"John\00Smith");

        yield return new ComponentData<WildcardValue>(new WildcardValue("1", true, false), "*1", "*1", "*1");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John", true, false), "*John", "*John", "*John");
        yield return new ComponentData<WildcardValue>(new WildcardValue(@"John\Smith", true, false), @"*John\Smith", @"*John\\Smith", @"*John\5cSmith");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John*Smith", true, false), "*John*Smith", @"*John\*Smith", @"*John\2aSmith");
        yield return new ComponentData<WildcardValue>(new WildcardValue("(John) Smith", true, false), "*(John) Smith", @"*\(John\) Smith", @"*\28John\29 Smith");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John\0Smith", true, false), "*John\0Smith", "*John\0Smith", @"*John\00Smith");

        yield return new ComponentData<WildcardValue>(new WildcardValue("1", false, true), "1*", "1*", "1*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John", false, true), "John*", "John*", "John*");
        yield return new ComponentData<WildcardValue>(new WildcardValue(@"John\Smith", false, true), @"John\Smith*", @"John\\Smith*", @"John\5cSmith*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John*Smith", false, true), "John*Smith*", @"John\*Smith*", @"John\2aSmith*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("(John) Smith", false, true), "(John) Smith*", @"\(John\) Smith*", @"\28John\29 Smith*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John\0Smith", false, true), "John\0Smith*", "John\0Smith*", @"John\00Smith*");

        yield return new ComponentData<WildcardValue>(new WildcardValue("1", true, true), "*1*", "*1*", "*1*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John", true, true), "*John*", "*John*", "*John*");
        yield return new ComponentData<WildcardValue>(new WildcardValue(@"John\Smith", true, true), @"*John\Smith*", @"*John\\Smith*", @"*John\5cSmith*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John*Smith", true, true), "*John*Smith*", @"*John\*Smith*", @"*John\2aSmith*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("(John) Smith", true, true), "*(John) Smith*", @"*\(John\) Smith*", @"*\28John\29 Smith*");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John\0Smith", true, true), "*John\0Smith*", "*John\0Smith*", @"*John\00Smith*");
    }

    public static IEnumerable<ComponentData<SimpleValue>> SimpleValuesSmallDatasource()
    {
        yield return new ComponentData<SimpleValue>(new SimpleValue("1"), "1", "1", "1");
        yield return new ComponentData<SimpleValue>(new SimpleValue("John"), "John", "John", "John");
    }

    public static IEnumerable<ComponentData<WildcardValue>> WildcardValuesSmallDatasource()
    {
        yield return new ComponentData<WildcardValue>(new WildcardValue("1", false, false), "1", "1", "1");
        yield return new ComponentData<WildcardValue>(new WildcardValue("John", false, false), "John", "John", "John");
    }
}