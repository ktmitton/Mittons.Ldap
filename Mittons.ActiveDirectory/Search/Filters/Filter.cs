using System;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class Filter : IFilter
    {
        public IFilterComponent FilterComponent { get; }

        public Filter(IFilterComponent filterComponent)
        {
            if (filterComponent is null)
            {
                throw new ArgumentNullException(nameof(filterComponent));
            }

            new ArgumentOutOfRangeException(nameof(filterComponent), "A Filter cannot be created with a null FilterComponent.");

            FilterComponent = filterComponent;
        }

        public override string ToString() => $"({FilterComponent})";
        public string ToDirectoryServicesString() => $"({FilterComponent.ToDirectoryServicesString()})";
        public string ToLdapString() => $"({FilterComponent.ToLdapString()})";
    }
}
