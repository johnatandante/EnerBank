#!/bin/bash
dotnet run ../EnerBank.UI/Resources/accrediti.txt ../EnerBank.UI/Resources/estrazioni.txt
cat result.csv