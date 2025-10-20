# Readme

## RFC Specification

- [x] [filter](Mittons.Ldap.Core/Search/Filters/Filter.cs) `"(" filtercomp ")"`

- [x] [filtercomp](Mittons.Ldap.Core/Search/Filters/IFilterComponent.cs) `and / or / not / item`

- [x] [and](Mittons.Ldap.Core/Search/Filters/CompoundLogicalFilter.cs) `"&" filterlist`

- [x] [or](Mittons.Ldap.Core/Search/Filters/CompoundLogicalFilter.cs) `"|" filterlist`

- [x] [not](Mittons.Ldap.Core/Search/Filters/SimpleLogicalFilter.cs) `"!" filter`

- [x] [filterlist](Mittons.Ldap.Core/Search/Filters/CompoundLogicalFilter.cs) `1*filter`

- [x] [item](Mittons.Ldap.Core/Search/Filters/IFilterComponent.cs) `simple / present / substring / extensible`

- [x] [simple](Mittons.Ldap.Core/Search/Filters/SimpleItemFilter.cs) `attr filtertype value`

- [x] [filtertype](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `equal / approx / greater / less`

- [x] [equal](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `"="`

- [x] [approx](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `"~="`

- [x] [greater](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `">="`

- [x] [less](Mittons.Ldap.Core/Search/Operators/ComparisonOperator.cs) `"<="`

- [ ] [extensible]() `attr [":dn"] [":" matchingrule] ":=" value / [":dn"] ":" matchingrule ":=" value`

- [x] [present](Mittons.Ldap.Core/Search/Filters/PresentItemFilter.cs) `attr "=*"`

- [x] [substring](Mittons.Ldap.Core/Search/Filters/SubstringItemFilter.cs) `attr "=" [initial] any [final]`

- [x] [initial](Mittons.Ldap.Core/Search/Filters/SubstringItemFilter.cs) `value`

- [x] [any](Mittons.Ldap.Core/Search/Values/WildcardValue.cs) `"*" *(value "*")`

- [x] [final](Mittons.Ldap.Core/Search/Filters/SubstringItemFilter.cs) `value`

- [x] [attr](Mittons.Ldap.Core/Search/Attributes/SimpleAttribute.cs) `AttributeDescription from Section 4.1.5`

- [ ] [matchingrule]() `MatchingRuleId from Section 4.1.9`

- [x] [value](Mittons.Ldap.Core/Search/Values/SimpleValue.cs) `AttributeValue from Section 4.1.6`
