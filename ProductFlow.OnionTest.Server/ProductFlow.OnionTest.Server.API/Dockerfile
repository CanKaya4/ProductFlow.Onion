FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Proje dosyalarını kopyala
COPY ["ProductFlow.OnionTest.Server.API/ProductFlow.OnionTest.Server.API.csproj", "ProductFlow.OnionTest.Server.API/"]
COPY ["ProductFlow.OnionTest.Server.Application/ProductFlow.OnionTest.Server.Application.csproj", "ProductFlow.OnionTest.Server.Application/"]
COPY ["ProductFlow.OnionTest.Server.Domain/ProductFlow.OnionTest.Server.Domain.csproj", "ProductFlow.OnionTest.Server.Domain/"]
COPY ["ProductFlow.OnionTest.Server.Infrastructure/ProductFlow.OnionTest.Server.Infrastructure.csproj", "ProductFlow.OnionTest.Server.Infrastructure/"]

# Restore işlemi (Burada hata almamak için yolların doğruluğu kritik)
RUN dotnet restore "ProductFlow.OnionTest.Server.API/ProductFlow.OnionTest.Server.API.csproj"

# Kalan her şeyi kopyala
COPY . .

# API'yi derle
WORKDIR "/src/ProductFlow.OnionTest.Server.API"
RUN dotnet publish -c Release -o /app/publish

# Çalıştırma aşaması
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProductFlow.OnionTest.Server.API.dll"]