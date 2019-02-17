2019-02-17
<h2><strong>ArangDB View (arangosearch) usage</strong></h2>

Arango views is special construction intended to join multiple collections into one-dimensional search structure.
It's usage with AQL queries is same as querying collections ittself, bud due to lack of AQL-DDL
programmer have to deal with views within Arango manager or using HTTP api.

This (view) part of ARANGODB-net makes usage of View api 

View operations

- Create View
- Delete View (aka drop view)
- Add link (collection as part of view)
- list views
- acquire properties of a view
