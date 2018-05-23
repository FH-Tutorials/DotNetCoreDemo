#!/bin/bash
echo "building application..."
dotnet build .

echo "building docker container..."
docker build -t coreconsole .
