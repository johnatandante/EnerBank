# Descrizione
Questa è un'applicazione DotNet Core che prende in input due file csv
- primo agromento nome file csv di accrediti
- secondo argomento nome file csv di orari per le estrazione degli accrediti

Come output genera un file dal nome result.csv nella directory corrente.

# Installazione
Se non presente l'SDK .Net Core, occorre esequire le istruzioni riportate dalla documentazione ufficiale microsoft qui riportata
https://www.microsoft.com/net/core#ubuntu

In particolare, per Ubuntu 16.04
1. Eseguire i comandi di configurazione per rendere accessibile il pacchetto
```
	sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
	sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
	sudo apt-get update
```    
2) installare .NET Core SDK
```
	sudo apt-get install dotnet-dev-1.0.0-preview2-003131
```

Eseguire lo script di installazione `deploy.sh`
La procedura genera una directory "deploy" dentro al quale saranno riportati i compilati

# Run
Eseguire lo script `EnerBank.Run` con in input i nomi dei file come parametri, se presenti nella directory corrente, altrimenti il path assoluto.
L'eseguibile sovrascrive l'eventuale file `result.csv` presente nella directory corrente.
