FROM microsoft/dotnet:2.1-sdk as builder

COPY . /source/

WORKDIR /source/

RUN dotnet publish -o ./artifacts

FROM microsoft/dotnet:2.1-sdk

COPY --from=builder /source/artifacts/. app/

ENV ASPNETCORE_URLS="http://+:5000"
ENV ASPNETCORE_ENVIRONMENT production

WORKDIR /app

ENTRYPOINT dotnet Kube.Web.dll
