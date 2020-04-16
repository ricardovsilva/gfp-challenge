FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY ./src /app/backend
WORKDIR /app/backend
RUN dotnet restore
RUN dotnet test

EXPOSE 5000

CMD dotnet run --project api/api.csproj http://0.0.0.0:5000

