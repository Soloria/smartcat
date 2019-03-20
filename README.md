# Run tests 🦉

1. [Install .NET Core SDK 2.1 +](https://www.microsoft.com/net/download/dotnet-core/2.1)
2. Check file `сonfig.json` in the project directory
2. Execute command `dotnet build` in the project directory
3. Execute command `dotnet test -v normal --no-build` in the project directory


# config.json

### transport_types
Available transport types - `Самолет`, `Поезд`, `Электричка`, `Автобус`
### departure_date
Date format is week day or day number + month, example - `23 марта` or `Суббота`
