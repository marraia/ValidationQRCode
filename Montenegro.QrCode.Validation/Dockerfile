#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Montenegro.QrCode.Validation/Montenegro.QrCode.Validation.csproj", "Montenegro.QrCode.Validation/"]
COPY ["Montenegro.QrCode.Validation.Core/Montenegro.QrCode.Validation.Core.csproj", "Montenegro.QrCode.Validation.Core/"]
RUN dotnet restore "Montenegro.QrCode.Validation/Montenegro.QrCode.Validation.csproj"
COPY . .
WORKDIR "/src/Montenegro.QrCode.Validation"
RUN dotnet build "Montenegro.QrCode.Validation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Montenegro.QrCode.Validation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Montenegro.QrCode.Validation.dll"]
