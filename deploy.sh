#!/bin/bash
dotnet restore
cd EnerBank.Console
dotnet build -r osx.10.11-x64
dotnet publish -r osx.10.10-x64 -c release
mv ./bin/release/netcoreapp1.0/publish ./../deploy
