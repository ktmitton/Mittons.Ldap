using System;

namespace Mittons.Ldap.Core.Search.Filters
{
    public class Filter : IFilter
    {
        public IFilterComponent FilterComponent { get; }

        public string DefaultString
            => $"({FilterComponent.DefaultString})";

        public string DirectoryServicesString
            => $"({FilterComponent.DirectoryServicesString})";

        public string LdapString
            => $"({FilterComponent.LdapString})";

        public Filter(IFilterComponent filterComponent)
        {
            if (filterComponent is null)
            {
                throw new ArgumentNullException(nameof(filterComponent));
            }

            new ArgumentOutOfRangeException(nameof(filterComponent), "A Filter cannot be created with a null FilterComponent.");

            FilterComponent = filterComponent;
        }
    }
}
