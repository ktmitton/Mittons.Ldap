using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Filters;
using Mittons.ActiveDirectory.Search.Operators;
using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Builders
{
    public interface IFluentUnknownFilterPendingAttributeBuilder
    {
        IFluentUnknownFilterPendingConditionBuilder Attribute(string attribute);
        IFluentUnknownFilterPendingNextFilterBuilder Has(IFilter filter);
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

        private FluentUnknownFilterBuilder Negate()
        {
            _negate = true;

            return this;
        }

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

        private FluentUnknownFilterBuilder SetFilter(IFilter filter)
        {
            _filter = _negate ? new SimpleLogicalFilter(LogicalOperator.Not, filter) : filter;

            return this;
        }

        public IFluentUnknownFilterPendingConditionBuilder Attribute(string attribute)
        {
            _attribute = attribute;

            return this;
        }

        public IFluentUnknownFilterPendingNextFilterBuilder Has(IFilter filter)
        {
            return SetFilter(filter);
        }

        public IFluentUnknownFilterPendingNextFilterBuilder EqualTo(string value)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.Equality, new SimpleValue(value))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder Exist()
            => SetFilter(
                new PresentItemFilter(new SimpleAttribute(_attribute))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder GreaterThan(int value)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue((value + 1).ToString()))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue(value))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder LessThan(int value)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue((value - 1).ToString()))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder LessThanOrEqualTo(string value)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue(value))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new WildcardValue(value, hasLeadingWildcard, hasTrailingWildcard))
            );

        public IFluentUnknownFilterPendingNextFilterBuilder StartWith(string value)
            => SetFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new SimpleValue(value))
            );

        public IFilter Build()
            => _filter ?? throw new System.InvalidOperationException("No filter has been built.");
    }
}