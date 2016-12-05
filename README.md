# EnerBank
Questa è un'applicazione DotNet Core che prende in input due file csv
- primo agromento nome file csv di accrediti
- secondo argomento nome file csv di orari per le estrazione degli accrediti

## Prerequisiti 
L'applicazione ha bisogno dei tool di SDK DotNet/AspNet Core

### Installazione su Windows
Se non presente l'SDK .Net Core, occorre esequire le istruzioni riportate dalla documentazione ufficiale microsoft qui riportata
https://www.microsoft.com/net/core#windows

### Installazione su Mac
Se non presente l'SDK .Net Core, occorre esequire le istruzioni riportate dalla documentazione ufficiale microsoft qui riportata
https://www.microsoft.com/net/core#macos

### Installazione su Ubuntu
Se non presente l'SDK .Net Core, occorre esequire le istruzioni riportate dalla documentazione ufficiale microsoft qui riportata
https://www.microsoft.com/net/core#ubuntu

In particolare, per Ubuntu 16.04
1) Eseguire i comandi di configurazione per rendere accessibile il pacchetto
```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
sudo apt-get update
```
2) installare .NET Core SDK
```
	sudo apt-get install dotnet-dev-1.0.0-preview2-003131
```

## EnerBank.Console
L'applicazione console, prende in input due parametri come output genera un file di risultati in formato csv.

### Run
Eseguire lo script di installazione `deploy.sh`: la procedura genera una directory "deploy" dentro al quale saranno riportati i compilati
Eseguire lo script EnerBank.Run con in input i nomi dei file come parametri, se presenti nella directory corrente, altrimenti il path assoluto.

## EnerBank.UI.Web
Questa è un'applicazione AspNet Core che prende in input due file csv
- primo agromento nome file csv di accrediti
- secondo argomento nome file csv di orari per le estrazione degli accrediti

Come output genera un report tabellare nella pagina.

### Run
Eseguire lo script `dotnet run` avvia un server web che risponde all'indirizzo `http://localhost:5000/`
La pagina che risponde alla home offre un form dove è possibile caricare due file csv:
- file csv di accrediti
- file csv di orari per le estrazione degli accrediti
Una volta caricati è possibile premere un pulsante **Upload Data** per caricare i dati e visualizzare i dati elaborati.

