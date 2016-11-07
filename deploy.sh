#!/bin/bash
dotnet restore
cd EnerBank.Console
dotnet build
dotnet publish -f netcoreapp1.0 -c release
mv ./bin/release/netcoreapp1.0/publish ./../deploy
