# Readme

## RFC Specification

- [x] [filter](Mittons.Ldap.Core/Search/Filters/Filter.cs) `"(" filtercomp ")"`

- [x] [filtercomp](Mittons.Ldap.Core/Search/Filters/IFilterComponent.cs) `and / or / not / item`

- [x] [and](Mittons.Ldap.Core/Search/Filters/CompoundFilter.cs) `"&" filterlist`

- [x] [or](Mittons.Ldap.Core/Search/Filters/CompoundFilter.cs) `"|" filterlist`

- [x] [not](Mittons.Ldap.Core/Search/Filters/SimpleFilter.cs) `"!" filter`

- [x] [filterlist](Mittons.Ldap.Core/Search/Filters/CompoundFilter.cs) `1*filter`

- [x] [item](Mittons.Ldap.Core/Search/Items/IItem.cs) `simple / present / substring / extensible`

- [x] [simple](Mittons.Ldap.Core/Search/Items/SimpleItem.cs) `attr filtertype value`

- [x] [filtertype](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `equal / approx / greater / less`

- [x] [equal](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `"="`

- [x] [approx](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `"~="`

- [x] [greater](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `">="`

- [x] [less](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `"<="`

- [ ] [extensible]() `attr [":dn"] [":" matchingrule] ":=" value / [":dn"] ":" matchingrule ":=" value`

- [x] [present](Mittons.Ldap.Core/Search/Items/PresentItem.cs.cs) `attr "=*"`

- [x] [substring](Mittons.Ldap.Core/Search/Items/SubstringItem.cs) `attr "=" [initial] any [final]`

- [x] [initial](Mittons.Ldap.Core/Search/Items/SubstringItem.cs) `value`

- [x] [any](Mittons.Ldap.Core/Search/Values/WildcardValue.cs) `"*" *(value "*")`

- [x] [final](Mittons.Ldap.Core/Search/Items/SubstringItem.cs) `value`

- [x] [attr](Mittons.Ldap.Core/Search/Attributes/Attribute.cs) `AttributeDescription from Section 4.1.5`

- [ ] [matchingrule]() `MatchingRuleId from Section 4.1.9`

- [x] [value](Mittons.Ldap.Core/Search/Values/SimpleValue.cs) `AttributeValue from Section 4.1.6`