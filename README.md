# .Net Core Socket Demo using docker

Show a simple example on how .net core application may be executed/compiled on Linux running inside docker container.

When running the container an application is started which opens a socket on port 9000. It is possible to connect over a telnet client to that port using the IP address of the docker machine and send different characters. When sending *shift + q* then the hole concatenated text is echoed back to client.

## Required Installations

  * docker
  * git (including git-bash on windows)
  * Visual Studio 17 (or the dotnet CLI-Tool)
  
## Building the docker container

Before running the container it is necessary to execute

```bash
./build.sh
```

When that script is executed the application is build using the "dotnet" command. Afterwards the docker container is provisioned in order to host the application.

## Running the Application

When the previous build has been execute successfully it is possible to run the application by starting

```bash
./run.sh
```

The script starts the docker container and exposes the port 9000. The folder of the application (located on the host system) is shared into the docker-container. 