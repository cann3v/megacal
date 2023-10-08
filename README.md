# Build
```
dotnet restore megacal.csproj
dotnet build
dotnet run
```
or
```
docker build -f Dockerfile -t megacal .
docker run --name megacal -p 80:80 megacal:latest
```

# Usage
`curl -X POST -H "Content-Type: application/json" -d "{\"a\": 15, \"b\": 5}" http://localhost:5258/api/multiply`

Expected output:
`{"result":75}`
