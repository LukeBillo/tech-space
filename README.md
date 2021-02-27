# Tech Space

This is an application I've used as an excuse to play further with React and also collate all of the different developer websites I look at. I tend to look at places like Reddit and dev.to to find information on upcoming technology, but I figured it would be nice to see all of those posts in one place- and so this is the aim of this project. In the future, I also hope to add more sources and even some more basic news sources like RSS feeds.

## Getting Started

### Prerequisites

1. You'll need .NET5.0 and npm to run this project.
2. The backend server requires some kind of SQL storage; it has only been tested with Microsoft SQL Server 2019.

### Database Migrations

There are migrations found in the TechSpace.Data.Migrations project. If you are on Windows, it should be as simple as running the powershell script in that project `MigrateUp.ps1` (which, at the time of writing, actually just executes `dotnet run --`).

You may want to insert some data into the generated tables to link the web app to some Reddit or Dev.to articles. In the migrations project, there is some test data which can be inserted for C# and JavaScript feeds (or, "spaces" as I've called them).

### Running the Web Application

1. In the TechSpace.Web project, find the `client-app` directory and run `npm install` to restore dependencies.
2. Run `dotnet run` in the TechSpace.Web project.
3. Navigate to the default hosting URL, which should be http://localhost:5000/
4. [Optional] The project is also hosted over HTTPS if you have developer certificates enabled, and will be served at https://localhost:5001.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
