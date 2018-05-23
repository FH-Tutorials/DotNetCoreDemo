# .Net Core Socket Demo using docker

Shows a simple example how a .net core application may be executed/compiled on Linux running inside docker container.

When running the container an application is started which opens a socket on port 9000. It is possible to connect over a telnet client to that port using the IP address of the docker machine and sending ACII  characters. When finally sending *shift + q* the whole concatenated text is echoed back to client and right after the server is shutted down.

The docker example illustrates a development environment. Thus when transitioning to a productive business application the process of building and running the container needs to be changed.

## Required Installations

  * docker
  * git (including git-bash on windows)
  * Visual Studio 17 (or the dotnet CLI-Tool)
  
## Building the docker container

Before running the container it is necessary to execute

```bash
./build.sh
```

When that script is executed it is build the visual studio solution using the "dotnet" command. Afterwards the docker container is provisioned in order to host the application.

## Running the Application

When the previous build has been execute successfully it is possible to run the application by starting

```bash
./run.sh
```

The script starts the docker container and exposes the port 9000. The folder of the application (located on the host system) is shared into the docker-container. 