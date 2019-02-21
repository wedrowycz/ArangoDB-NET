2019-02-17

Views - added first simple support for links management via ChangeProperties 

2019-02-14

Added first simple implementation for arango search views - module AView
- create view
- check for view existence

2019-01-09
Collection creation faild for edge collection -
"This is due to the Json msg passed where the value of parameter "type" is "Edge" instead of 3." as stated user berry4u 
<br/>

**This branch is compatible with ArangoDB 3.x. For more information about incompatible changes with previous branches read [release notes](https://docs.arangodb.com/devel/Manual/ReleaseNotes/UpgradingChanges30.html). For ArangoDB 2.x compatible driver checkout [this](https://github.com/yojimbo87/ArangoDB-NET/tree/2.x) branch.**

# ArangoDB-NET

ArangoDB-NET is a C# driver for [ArangoDB](https://www.arangodb.com/) NoSQL multi-model database. Driver implements and communicates with database backend through its [HTTP API](https://docs.arangodb.com/3.0/HTTP/index.html) interface and runs on Microsoft .NET and mono framework.

## Installation

There are following ways to install the driver:

- download and install [nuget package](https://www.nuget.org/packages/ArangoDB-NET/)
- clone ArangoDB-NET [repository](https://github.com/yojimbo87/ArangoDB-NET) and build [master branch](https://github.com/yojimbo87/ArangoDB-NET/tree/master) to have latest stable version

## Docs contents

- [Basic usage](docs/BasicUsage.md)
  - [Connection management](docs/BasicUsage.md#connection-management)
  - [Checking and removing existing connections](docs/BasicUsage.md#checking-and-removing-existing-connections)
  - [Database context](docs/BasicUsage.md#database-context)
  - [AResult object](docs/BasicUsage.md#aresult-object)
  - [AError object](docs/BasicUsage.md#aerror-object)
  - [JSON representation](docs/BasicUsage.md#json-representation)
  - [Serialization options](docs/BasicUsage.md#serialization-options)
  - [Document ID, key and revision](docs/BasicUsage.md#document-id-key-and-revision)
  - [Fluent API](docs/BasicUsage.md#fluent-api)
- [Database operations](docs/DatabaseOperations.md)
  - [Create database](docs/DatabaseOperations.md#create-database)
  - [Retrieve current database](docs/DatabaseOperations.md#retrieve-current-database)
  - [Retrieve accessible databases](docs/DatabaseOperations.md#retrieve-accessible-databases)
  - [Retrieve all databases](docs/DatabaseOperations.md#retrieve-all-databases)
  - [Retrieve database collections](docs/DatabaseOperations.md#retrieve-database-collections)
  - [Delete database](docs/DatabaseOperations.md#delete-database)
  - [More examples](docs/DatabaseOperations.md#more-examples)
- [Collection operations](docs/CollectionOperations.md)
  - [Create collection](docs/CollectionOperations.md#create-collection)
  - [Retrieve collection](docs/CollectionOperations.md#retrieve-collection)
  - [Retrieve collection properties](docs/CollectionOperations.md#retrieve-collection-properties)
  - [Retrieve collection count](docs/CollectionOperations.md#retrieve-collection-count)
  - [Retrieve collection figures](docs/CollectionOperations.md#retrieve-collection-figures)
  - [Retrieve collection revision](docs/CollectionOperations.md#retrieve-collection-revision)
  - [Retrieve collection checksum](docs/CollectionOperations.md#retrieve-collection-checksum)
  - [Retrieve all indexes](docs/CollectionOperations.md#retrieve-all-indexes)
  - [Truncate collection](docs/CollectionOperations.md#truncate-collection)
  - [Load collection](docs/CollectionOperations.md#load-collection)
  - [Unload collection](docs/CollectionOperations.md#unload-collection)
  - [Change collection properties](docs/CollectionOperations.md#change-collection-properties)
  - [Rename collection](docs/CollectionOperations.md#rename-collection)
  - [Rotate collection journal](docs/CollectionOperations.md#rotate-collection-journal)
  - [Delete collection](docs/CollectionOperations.md#delete-collection)
  - [More examples](docs/CollectionOperations.md#more-examples)
- [Document and edge operations](docs/DocumentAndEdgeOperations.md)
  - [Create document](docs/DocumentAndEdgeOperations.md#create-document)
  - [Create document with user defined key](docs/DocumentAndEdgeOperations.md#create-document-with-user-defined-key)
  - [Create edge](docs/DocumentAndEdgeOperations.md#create-edge)
  - [Check document existence](docs/DocumentAndEdgeOperations.md#check-document-existence)
  - [Retrieve document](docs/DocumentAndEdgeOperations.md#retrieve-document)
  - [Retrieve vertex edges](docs/DocumentAndEdgeOperations.md#retrieve-vertex-edges)
  - [Update document](docs/DocumentAndEdgeOperations.md#update-document)
  - [Replace document](docs/DocumentAndEdgeOperations.md#replace-document)
  - [Replace edge](docs/DocumentAndEdgeOperations.md#replace-edge)
  - [Delete document](docs/DocumentAndEdgeOperations.md#delete-document)
  - [More examples](docs/DocumentAndEdgeOperations.md#more-examples)
- [AQL query operations](docs/QueryOperations.md)
  - [Query operation parameters](docs/QueryOperations.md#query-operation-parameters)
  - [Executing simple query](docs/QueryOperations.md#executing-simple-query)
  - [Executing query with bind variables](docs/QueryOperations.md#executing-query-with-bind-variables)
  - [Executing non-query operation](docs/QueryOperations.md#executing-non-query-operation)
  - [Result format options](docs/QueryOperations.md#result-format-options)
  - [Parse query](docs/QueryOperations.md#parse-query)
  - [Minify query](docs/QueryOperations.md#minify-query)
  - [Delete cursor](docs/QueryOperations.md#delete-cursor)
  - [More examples](docs/QueryOperations.md#more-examples)
- [AQL user functions management](docs/FunctionOperations.md)
  - [Register function](docs/FunctionOperations.md#register-function)
  - [Retrieve function list](docs/FunctionOperations.md#retrieve-function-list)
  - [Unregister function](docs/FunctionOperations.md#unregister-function)
  - [More examples](docs/FunctionOperations.md#more-examples)
- [Transaction operations](docs/TransactionOperations.md)
  - [Execute transaction](docs/TransactionOperations.md#execute-transaction)
- [Index operations](docs/IndexOperations.md)
  - [Create index](docs/IndexOperations.md#create-index)
  - [Retrieve index](docs/IndexOperations.md#retrieve-index)
  - [Delete index](docs/IndexOperations.md#delete-index)
  - [More examples](docs/IndexOperations.md#more-examples)
- [Foxx operations](docs/FoxxOperations.md)
  - [Get request](docs/FoxxOperations.md#get-request)
  - [Post request](docs/FoxxOperations.md#post-request)
  - [Put request](docs/FoxxOperations.md#put-request)
  - [Patch request](docs/FoxxOperations.md#patch-request)
  - [Delete request](docs/FoxxOperations.md#delete-request)
- [Views operations](docs/Views.md)
