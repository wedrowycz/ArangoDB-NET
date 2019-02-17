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

<b> Create View </b>

Fluent api properties :
  - Type(AViewType value) - determines default view typ - arangosearch (1) at this moment (ArangoDB 3.4.2-1)

```csharp
var db = new ADatabase("myDatabaseAlias");

// creates new View
var createViewResult = db.View
    .Type(AViewType.arangosearch)    
    .Create("MyView");
    
if(createViewResult.Success)   
{
  foreach (var entity in createViewResult.Value)
  {
   .... process result
  }
}
```   

<b> Delete View <b>
  
```csharp
var db = new ADatabase("myDatabaseAlias");

// deletes View
var deleteViewResult = db.View   
    .Delete("MyView");
 if(deleteViewResult.Success)  
 {
    ....and process result
 }
```      

  
<b> List  Views</b>
```csharp
var db = new ADatabase("myDatabaseAlias");

// list all Views
var listViewResult = db.View   
    .GetList();
    
if(createViewResult.Success)   
{
  foreach (var entity in listViewResult.Value)
  {
   .... process result
  }
}    
```
<b>Add link <b>
Link is added with most default values : default all fields,analyzers - identity,includeAllFields- true, empty field list  ...
View support links to Document and Edge Collections  
  
```csharp
var db = new ADatabase("myDatabaseAlias");

var addLink = db.View
  .ChangeProperties("MyView","MyCollection1");
var addLink = db.View
  .ChangeProperties("MyView","MyEdgeCollection2");
```

After adding link's (make sure succesfully) you may query (AQL) and retrieve data from added collections

```sql
for item in MyView
  return item
```
