DELETE FROM [SpaceFeed] WHERE SpaceIdentifier = 'javascript';
DELETE FROM [Space] WHERE Identifier = 'javascript';

INSERT INTO [Space]
VALUES('javascript', 'JavaScript', 'All of the JavaScript resources')

INSERT INTO [SpaceFeed]
VALUES('javascript', 'Reddit', 'JavaScript', 'javascript'),

INSERT INTO [SpaceFeed]
VALUES('javascript', 'DevTo', 'JavaScript', 'javascript'),
feed