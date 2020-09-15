DELETE FROM [SpaceFeed] WHERE SpaceIdentifier = 'csharp';
DELETE FROM [Space] WHERE Identifier = 'csharp';

INSERT INTO [Space]
VALUES('csharp', 'C#', 'Everything C# and .NET related')

INSERT INTO [SpaceFeed]
VALUES('csharp', 'Reddit', '.NET', 'dotnet'),
      ('csharp', 'Reddit', 'C#', 'csharp')

INSERT INTO [SpaceFeed]
VALUES('csharp', 'DevTo', '.NET', 'dotnet'),
      ('csharp', 'DevTo', 'C#', 'csharp')