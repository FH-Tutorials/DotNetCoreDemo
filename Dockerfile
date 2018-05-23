# use docker mono container from hub
#FROM mono
FROM microsoft/dotnet
# TODO
# compile

RUN apt-get update
RUN apt-get install -y telnet net-tools

EXPOSE 9000

# run
#ENTRYPOINT ["mono", "/app/DotNetCoreDemo/bin/Release/netcoreapp2.0/DotNetCoreDemo.dll"]