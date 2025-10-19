# Readme

## RFC Specification

- [x] [filter](Mittons.ActiveDirectory/Search/Filters/Filter.cs) `"(" filtercomp ")"`

- [x] [filtercomp](Mittons.ActiveDirectory/Search/Filters/IFilterComponent.cs) `and / or / not / item`

- [x] [and](Mittons.ActiveDirectory/Search/Filters/CompoundFilter.cs) `"&" filterlist`

- [x] [or](Mittons.ActiveDirectory/Search/Filters/CompoundFilter.cs) `"|" filterlist`

- [x] [not](Mittons.ActiveDirectory/Search/Filters/SimpleFilter.cs) `"!" filter`

- [x] [filterlist](Mittons.ActiveDirectory/Search/Filters/CompoundFilter.cs) `1*filter`

- [x] [item](Mittons.ActiveDirectory/Search/Items/IItem.cs) `simple / present / substring / extensible`

- [x] [simple](Mittons.ActiveDirectory/Search/Items/SimpleItem.cs) `attr filtertype value`

- [x] [filtertype](Mittons.ActiveDirectory/Search/ComparisonOperator.cs) `equal / approx / greater / less`

- [x] [equal](Mittons.ActiveDirectory/Search/ComparisonOperator.cs) `"="`

- [x] [approx](Mittons.ActiveDirectory/Search/ComparisonOperator.cs) `"~="`

- [x] [greater](Mittons.ActiveDirectory/Search/ComparisonOperator.cs) `">="`

- [x] [less](Mittons.ActiveDirectory/Search/ComparisonOperator.cs) `"<="`

- [ ] [extensible]() `attr [":dn"] [":" matchingrule] ":=" value / [":dn"] ":" matchingrule ":=" value`

- [x] [present](Mittons.ActiveDirectory/Search/Items/PresentItem.cs.cs) `attr "=*"`

- [x] [substring](Mittons.ActiveDirectory/Search/Items/SubstringItem.cs) `attr "=" [initial] any [final]`

- [x] [initial](Mittons.ActiveDirectory/Search/Items/SubstringItem.cs) `value`

- [x] [any](Mittons.ActiveDirectory/Search/Values/WildcardValue.cs) `"*" *(value "*")`

- [x] [final](Mittons.ActiveDirectory/Search/Items/SubstringItem.cs) `value`

- [x] [attr](Mittons.ActiveDirectory/Search/Attribute.cs) `AttributeDescription from Section 4.1.5`

- [ ] [matchingrule]() `MatchingRuleId from Section 4.1.9`

- [x] [value](Mittons.ActiveDirectory/Search/Values/SimpleValue.cs) `AttributeValue from Section 4.1.6`