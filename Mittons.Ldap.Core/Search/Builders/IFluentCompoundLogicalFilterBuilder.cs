using System.Collections.Generic;
using Mittons.Ldap.Core.Search.Attributes;
using Mittons.Ldap.Core.Search.Filters;
using Mittons.Ldap.Core.Search.Operators;
using Mittons.Ldap.Core.Search.Values;

namespace Mittons.Ldap.Core.Search.Builders
{
    public interface IFluentOrFilterBuilder
    {
        IFluentOrFilterPendingConditionBuilder Attribute(string attribute);
        IFluentOrFilterPendingNextFilterBuilder Has(IFilter filter);
    }

    public interface IFluentAndFilterBuilder
    {
        IFluentAndFilterPendingConditionBuilder Attribute(string attribute);
        IFluentAndFilterPendingNextFilterBuilder Has(IFilter filter);
    }

    public interface IFluentCompoundLogicalFilterBuilder
        : IFluentOrFilterBuilder,
          IFluentAndFilterBuilder
    {
        IFilter Build();
    }

    public interface IFluentOrFilterPendingConditionBuilder
    {
        IFluentOrFilterPendingIsValueBuilder Is { get; }
        IFluentOrFilterPendingDoesValueBuilder Does { get; }
    }

    public interface IFluentAndFilterPendingConditionBuilder
    {
        IFluentAndFilterPendingIsValueBuilder Is { get; }
        IFluentAndFilterPendingDoesValueBuilder Does { get; }
    }

    public interface IFluentCompoundLogicalFilterPendingConditionBuilder
        : IFluentOrFilterPendingConditionBuilder,
          IFluentAndFilterPendingConditionBuilder
    { }

    public interface IFluentOrFilterPendingIsValueBuilder
        : IFluentOrFilterPendingValueBuilder
    {
        IFluentOrFilterPendingIsValueBuilder Not { get; }
    }

    public interface IFluentAndFilterPendingIsValueBuilder
        : IFluentAndFilterPendingValueBuilder
    {
        IFluentAndFilterPendingIsValueBuilder Not { get; }
    }

    public interface IFluentCompoundLogicalFilterPendingIsValueBuilder
        : IFluentOrFilterPendingIsValueBuilder,
          IFluentAndFilterPendingIsValueBuilder
    { }

    public interface IFluentOrFilterPendingValueBuilder
    {
        IFluentOrFilterPendingNextFilterBuilder EqualTo(string value);
        IFluentOrFilterPendingNextFilterBuilder GreaterThan(int value);
        IFluentOrFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value);
        IFluentOrFilterPendingNextFilterBuilder LessThan(int value);
        IFluentOrFilterPendingNextFilterBuilder LessThanOrEqualTo(string value);
        IFluentOrFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false);
    }

    public interface IFluentAndFilterPendingValueBuilder
    {
        IFluentAndFilterPendingNextFilterBuilder EqualTo(string value);
        IFluentAndFilterPendingNextFilterBuilder GreaterThan(int value);
        IFluentAndFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value);
        IFluentAndFilterPendingNextFilterBuilder LessThan(int value);
        IFluentAndFilterPendingNextFilterBuilder LessThanOrEqualTo(string value);
        IFluentAndFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false);
    }

    public interface IFluentCompoundLogicalFilterPendingValueBuilder
        : IFluentOrFilterPendingValueBuilder,
          IFluentAndFilterPendingValueBuilder
    { }

    public interface IFluentOrFilterPendingNextFilterBuilder
    {
        IFluentOrFilterBuilder Or { get; }
        IFilter Build();
    }

    public interface IFluentAndFilterPendingNextFilterBuilder
    {
        IFluentAndFilterBuilder And { get; }
        IFilter Build();
    }

    public interface IFluentCompoundLogicalFilterPendingNextFilterBuilder
        : IFluentOrFilterPendingNextFilterBuilder,
          IFluentAndFilterPendingNextFilterBuilder
    { }

    public interface IFluentOrFilterPendingDoesValueBuilder
    {
        IFluentOrFilterPendingDoesValueBuilder Not { get; }
        IFluentOrFilterPendingNextFilterBuilder Exist();
        IFluentOrFilterPendingNextFilterBuilder StartWith(string value);
    }

    public interface IFluentAndFilterPendingDoesValueBuilder
    {
        IFluentAndFilterPendingDoesValueBuilder Not { get; }
        IFluentAndFilterPendingNextFilterBuilder Exist();
        IFluentAndFilterPendingNextFilterBuilder StartWith(string value);
    }

    public interface IFluentCompoundLogicalFilterPendingDoesValueBuilder
        : IFluentOrFilterPendingDoesValueBuilder,
          IFluentAndFilterPendingDoesValueBuilder
    { }

    public class FluentCompoundLogicalFilterBuilder
        : IFluentCompoundLogicalFilterBuilder,
          IFluentCompoundLogicalFilterPendingConditionBuilder,
          IFluentCompoundLogicalFilterPendingIsValueBuilder,
          IFluentCompoundLogicalFilterPendingDoesValueBuilder,
          IFluentCompoundLogicalFilterPendingNextFilterBuilder
    {
        private readonly List<IFilter> _filters = new List<IFilter>();
        private readonly LogicalOperator _logicalOperator;
        private string _attribute = string.Empty;
        private bool _negate = false;

        public FluentCompoundLogicalFilterBuilder(
            IFilter filter,
            LogicalOperator logicalOperator
        )
        {
            _filters.Add(filter);
            _logicalOperator = logicalOperator;
        }

        private FluentCompoundLogicalFilterBuilder AddFilter(IFilter filter)
        {
            _filters.Add(_negate ? new SimpleLogicalFilter(LogicalOperator.Not, filter) : filter);

            return this;
        }

        IFluentOrFilterPendingIsValueBuilder IFluentOrFilterPendingConditionBuilder.Is
            => this;

        IFluentAndFilterPendingIsValueBuilder IFluentAndFilterPendingConditionBuilder.Is
            => this;

        IFluentOrFilterPendingDoesValueBuilder IFluentOrFilterPendingConditionBuilder.Does
            => this;

        IFluentAndFilterPendingDoesValueBuilder IFluentAndFilterPendingConditionBuilder.Does
            => this;

        IFluentOrFilterPendingIsValueBuilder IFluentOrFilterPendingIsValueBuilder.Not
            => Negate();

        IFluentOrFilterPendingDoesValueBuilder IFluentOrFilterPendingDoesValueBuilder.Not
            => Negate();

        IFluentAndFilterPendingIsValueBuilder IFluentAndFilterPendingIsValueBuilder.Not
            => Negate();

        IFluentAndFilterPendingDoesValueBuilder IFluentAndFilterPendingDoesValueBuilder.Not
            => Negate();

        private FluentCompoundLogicalFilterBuilder Negate()
        {
            _negate = true;

            return this;
        }

        IFluentOrFilterBuilder IFluentOrFilterPendingNextFilterBuilder.Or
            => this;

        IFluentAndFilterBuilder IFluentAndFilterPendingNextFilterBuilder.And
            => this;

        IFluentOrFilterPendingConditionBuilder IFluentOrFilterBuilder.Attribute(string attribute)
            => Attribute(attribute);

        IFluentAndFilterPendingConditionBuilder IFluentAndFilterBuilder.Attribute(string attribute)
            => Attribute(attribute);

        private IFluentCompoundLogicalFilterPendingConditionBuilder Attribute(string attribute)
        {
            _attribute = attribute;

            return this;
        }

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterBuilder.Has(IFilter filter)
            => Has(filter);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterBuilder.Has(IFilter filter)
            => Has(filter);

        private FluentCompoundLogicalFilterBuilder Has(IFilter filter)
        {
            _filters.Add(filter);

            return this;
        }

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingValueBuilder.EqualTo(string value)
            => EqualTo(value);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingValueBuilder.EqualTo(string value)
            => EqualTo(value);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder EqualTo(string value)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.Equality, new SimpleValue(value))
            );

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingValueBuilder.GreaterThan(int value)
            => GreaterThan(value);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingValueBuilder.GreaterThan(int value)
            => GreaterThan(value);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder GreaterThan(int value)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue((value + 1).ToString()))
            );

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingValueBuilder.GreaterThanOrEqualTo(string value)
            => GreaterThanOrEqualTo(value);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingValueBuilder.GreaterThanOrEqualTo(string value)
            => GreaterThanOrEqualTo(value);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder GreaterThanOrEqualTo(string value)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.GreaterThanOrEqual, new SimpleValue(value))
            );

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingValueBuilder.LessThan(int value)
            => LessThan(value);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingValueBuilder.LessThan(int value)
            => LessThan(value);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder LessThan(int value)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue((value - 1).ToString()))
            );

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingValueBuilder.LessThanOrEqualTo(string value)
            => LessThanOrEqualTo(value);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingValueBuilder.LessThanOrEqualTo(string value)
            => LessThanOrEqualTo(value);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder LessThanOrEqualTo(string value)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.LessThanOrEqual, new SimpleValue(value))
            );

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingValueBuilder.Like(string value, bool hasLeadingWildcard, bool hasTrailingWildcard)
            => Like(value, hasLeadingWildcard, hasTrailingWildcard);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingValueBuilder.Like(string value, bool hasLeadingWildcard, bool hasTrailingWildcard)
            => Like(value, hasLeadingWildcard, hasTrailingWildcard);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder Like(string value, bool hasLeadingWildcard = false, bool hasTrailingWildcard = false)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new WildcardValue(value, hasLeadingWildcard, hasTrailingWildcard))
            );

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingDoesValueBuilder.Exist()
            => Exist();

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingDoesValueBuilder.Exist()
            => Exist();

        private FluentCompoundLogicalFilterBuilder Exist()
        {
            _filters.Add(
                new PresentItemFilter(new SimpleAttribute(_attribute))
            );

            return this;
        }

        IFluentOrFilterPendingNextFilterBuilder IFluentOrFilterPendingDoesValueBuilder.StartWith(string value)
            => StartWith(value);

        IFluentAndFilterPendingNextFilterBuilder IFluentAndFilterPendingDoesValueBuilder.StartWith(string value)
            => StartWith(value);

        private IFluentCompoundLogicalFilterPendingNextFilterBuilder StartWith(string value)
            => AddFilter(
                new SimpleItemFilter(new SimpleAttribute(_attribute), ComparisonOperator.ApproximateMatch, new SimpleValue(value))
            );

        public IFilter Build() => new CompoundLogicalFilter(
            _logicalOperator,
            _filters
        );
    }
}