# use dotnet core with dotnet CLI-Tool
FROM microsoft/dotnet

# install some helper tools
RUN apt-get update
RUN apt-get install -y telnet net-tools

EXPOSE 9000

# execute application located in app folder
ENTRYPOINT ["dotnet", "run", "--project", "/app/DotNetCoreDemo"]