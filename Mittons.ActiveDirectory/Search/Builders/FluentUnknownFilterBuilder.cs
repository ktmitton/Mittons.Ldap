using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Filters;
using Mittons.ActiveDirectory.Search.Operators;
using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Builders
{
    public interface IFluentUnknownFilterPendingAttributeBuilder
    {
        IFluentUnknownFilterPendingConditionBuilder Attribute(string attribute);
    }

    public interface IFluentUnknownFilterPendingConditionBuilder
    {
        IFluentUnknownFilterPendingIsValueBuilder Is { get; }
        IFluentUnknownFilterPendingDoesValueBuilder Does { get; }
    }

    public interface IFluentUnknownFilterPendingIsValueBuilder
        : IFluentUnknownFilterPendingValueBuilder
    {
        IFluentUnknownFilterPendingValueBuilder Not { get; }
    }

    public interface IFluentUnknownFilterPendingValueBuilder
    {
        IFluentUnknownFilterPendingNextFilterBuilder EqualTo(string value);
        IFluentUnknownFilterPendingNextFilterBuilder GreaterThan(int value);
        IFluentUnknownFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value);
        IFluentUnknownFilterPendingNextFilterBuilder LessThan(int value);
        IFluentUnknownFilterPendingNextFilterBuilder LessThanOrEqualTo(string value);
        IFluentUnknownFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false);
    }

    public interface IFluentUnknownFilterPendingDoesValueBuilder
    {
        IFluentUnknownFilterPendingDoesValueBuilder Not { get; }
        IFluentUnknownFilterPendingNextFilterBuilder Exist();
        IFluentUnknownFilterPendingNextFilterBuilder StartWith(string value);
    }

    public interface IFluentUnknownFilterPendingNextFilterBuilder
    {
        IFluentOrFilterBuilder Or { get; }
        IFluentAndFilterBuilder And { get; }
        IFilter Build();
    }

    public class FluentUnknownFilterBuilder
        : IFluentUnknownFilterPendingAttributeBuilder,
          IFluentUnknownFilterPendingConditionBuilder,
          IFluentUnknownFilterPendingIsValueBuilder,
          IFluentUnknownFilterPendingValueBuilder,
          IFluentUnknownFilterPendingDoesValueBuilder,
          IFluentUnknownFilterPendingNextFilterBuilder
    {
        private string _attribute = string.Empty;
        private bool _negate = false;
        private IFilter? _filter = null;

        public IFluentUnknownFilterPendingIsValueBuilder Is
            => this;

        public IFluentUnknownFilterPendingDoesValueBuilder Does
            => this;

        IFluentUnknownFilterPendingValueBuilder IFluentUnknownFilterPendingIsValueBuilder.Not
            => Negate();

        IFluentUnknownFilterPendingDoesValueBuilder IFluentUnknownFilterPendingDoesValueBuilder.Not
            => Negate();

        public IFluentOrFilterBuilder Or
            => new FluentCompoundLogicalFilterBuilder(
                _filter ?? throw new System.InvalidOperationException("No filter has been built."),
                LogicalOperator.Or
            );

        public IFluentAndFilterBuilder And
            => new FluentCompoundLogicalFilterBuilder(
                _filter ?? throw new System.InvalidOperationException("No filter has been built."),
                LogicalOperator.And
            );

        private FluentUnknownFilterBuilder Negate()
        {
            _negate = true;

            return this;
        }

        public IFluentUnknownFilterPendingConditionBuilder Attribute(string attribute)
        {
            _attribute = attribute;

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder EqualTo(string value)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.Equality, new SimpleValue(value));

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder Exist()
        {
            throw new System.NotImplementedException();
        }

        public IFluentUnknownFilterPendingNextFilterBuilder GreaterThan(int value)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue((value + 1).ToString()));

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue(value));

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder LessThan(int value)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue((value - 1).ToString()));

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder LessThanOrEqualTo(string value)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue(value));

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new WildcardValue(value, hasLeadingWildcard, hasTrailingWildcard));

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder StartWith(string value)
        {
            _filter = new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new SimpleValue(value));

            return this;
        }

        public IFilter Build()
            => _filter ?? throw new System.InvalidOperationException("No filter has been built.");
    }

    public class FluentUnknownFilterPendingAttributeBuilder
    {
        public FluentUnknownFilterPendingConditionBuilder Attribute(string attribute)
        {
            throw new System.NotImplementedException();
        }
    }

    public class FluentUnknownFilterPendingConditionBuilder
    {
        private readonly string _attribute;

        public FluentUnknownFilterPendingConditionBuilder(string attribute)
        {
            _attribute = attribute;
        }

        public FluentUnknownFilterPendingNextFilterBuilder Exists
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new PresentItemFilter(new SimpleAttribute(_attribute))
            );

        public FluentUnknownFilterPendingIsNotValueBuilder IsNot
            => new FluentUnknownFilterPendingIsNotValueBuilder(_attribute);
        public FluentUnknownFilterPendingDoesNotValueBuilder DoesNot
            => new FluentUnknownFilterPendingDoesNotValueBuilder(_attribute);

        public FluentUnknownFilterPendingNextFilterBuilder IsEqualTo(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.Equality, new SimpleValue(value))
            );

        public FluentUnknownFilterPendingNextFilterBuilder IsGreaterThan(int value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue((value + 1).ToString()))
            );

        public FluentUnknownFilterPendingNextFilterBuilder IsGreaterThanOrEqualTo(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue(value))
            );

        public FluentUnknownFilterPendingNextFilterBuilder IsLessThan(int value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue((value - 1).ToString()))
            );

        public FluentUnknownFilterPendingNextFilterBuilder IsLessThanOrEqualTo(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue(value))
            );

        public FluentUnknownFilterPendingNextFilterBuilder StartsWith(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new SimpleValue(value))
            );

        public FluentUnknownFilterPendingNextFilterBuilder IsLike(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new WildcardValue(value, hasLeadingWildcard, hasTrailingWildcard))
            );
    }

    public class FluentUnknownFilterPendingIsNotValueBuilder
    {
        private readonly string _attribute;

        public FluentUnknownFilterPendingIsNotValueBuilder(string attribute)
        {
            _attribute = attribute;
        }

        public FluentUnknownFilterPendingNextFilterBuilder EqualTo(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.Equality, new SimpleValue(value))
                )
            );

        public FluentUnknownFilterPendingNextFilterBuilder GreaterThan(int value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue((value + 1).ToString()))
                )
            );

        public FluentUnknownFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue(value))
                )
            );

        public FluentUnknownFilterPendingNextFilterBuilder LessThan(int value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue((value - 1).ToString()))
                )
            );

        public FluentUnknownFilterPendingNextFilterBuilder LessThanOrEqualTo(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue(value))
                )
            );

        public FluentUnknownFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new WildcardValue(value, hasLeadingWildcard, hasTrailingWildcard))
                )
            );
    }

    public class FluentUnknownFilterPendingDoesNotValueBuilder
    {
        private readonly string _attribute;

        public FluentUnknownFilterPendingDoesNotValueBuilder(string attribute)
        {
            _attribute = attribute;
        }

        public FluentUnknownFilterPendingNextFilterBuilder StartsWith(string value)
            => new FluentUnknownFilterPendingNextFilterBuilder(
                new SimpleLogicalFilter(
                    LogicalOperator.Not,
                    new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new SimpleValue(value))
                )
            );
    }

    public class FluentUnknownFilterPendingNextFilterBuilder
    {
        private readonly IFilter _filter;

        public FluentUnknownFilterPendingNextFilterBuilder(IFilter filter)
        {
            _filter = filter;
        }

        public IFluentAndFilterBuilder And
            => new FluentCompoundLogicalFilterBuilder(_filter, LogicalOperator.And);

        public IFluentOrFilterBuilder Or
            => new FluentCompoundLogicalFilterBuilder(_filter, LogicalOperator.Or);

        public IFilter Build() => _filter;
    }
}