#!/bin/bash
DIR="$(pwd)"
SCRIPT=${1:-"bash"}

#get os
unameOut="$(uname -s)"
case "${unameOut}" in
    Linux*)     machine=Linux;;
    Darwin*)    machine=Mac;;
    CYGWIN*)    machine=Win;;
    MINGW*)     machine=Win;;
    *)          machine="UNKNOWN:${unameOut}"
esac

#before execution get rid of executing container
docker rm coreconsole_active 2>/dev/null

#fix path for windows
if [ "$machine" == "Win" ]
then
  #fix path
  WINDIR="${DIR//\//\\}"
  WINDIR="${WINDIR/\\c/C:}"
 
  #export to fix path mangling bug
  export MSYS_NO_PATHCONV=1
  winpty docker run -h myhost -v "$WINDIR:/app" -p 9000:9000 --name coreconsole_active -it coreconsole bash
  export MSYS_NO_PATHCONV=0
else
  docker run -h myhost -v "$DIR:/app" -p 9000:9000 --name coreconsole_active -it coreconsole bash
fi
