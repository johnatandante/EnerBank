﻿using System;
using EnerBank.Interfaces;
using Environment.Injector;

namespace Enerbank.Model.Test
{
	class DataUtils
	{

		internal static string[] AccreditiMocked = new string[] {
@"Janet,362.36,2016-11-04T07:40Z,20 "		 ,
@"Anna,433.03,2016-11-04T09:29Z,84"			 ,
@"Ronald,122.28,2016-11-04T14:47Z,85 "		 ,
@"Gerald,690.70,2016-11-04T02:33Z,44"			 ,
@"Jesse,793.97,2016-11-04T13:39Z,62"			 ,
@"Laura,533.97,2016-11-04T22:18Z,42"			 ,
@"Julia,772.88,2016-11-04T01:46Z,22 "			 ,
@"Sarah,253.45,2016-11-04T03:04Z,77 "		 ,
@"Eric,553.54,2016-11-04T20:53Z,50 "			 ,
@"Virginia,116.47,2016-11-04T20:16Z,96 "		 ,
@"Ann,315.05,2016-11-04T23:54Z,20"			 ,
@"Stephen,755.88,2016-11-04T12:15Z,43"			 ,
@"Ruby,955.98,2016-11-04T22:14Z,29 "			 ,
@"Jack,585.77,2016-11-04T12:41Z,3"				 ,
@"Jessica,859.72,2016-11-04T02:41Z,25 "			 ,
@"Heather,555.41,2016-11-04T01:38Z,4"		 ,
@"Clarence,237.51,2016-11-04T07:05Z,50"		 ,
@"Anne,363.07,2016-11-04T13:09Z,14 "			 ,
@"Amanda,745.19,2016-11-04T22:54Z,4"			 ,
@"Paula,229.22,2016-11-04T23:17Z,50"			 ,
@"Jane,676.93,2016-11-04T22:50Z,92 "			 ,
@"Bobby,584.75,2016-11-04T16:11Z,64"			 ,
@"Diana,373.07,2016-11-04T19:09Z,45"			 ,
@"Lawrence,948.56,2016-11-04T23:24Z,32 "		 ,
@"Craig,833.05,2016-11-04T15:01Z,45"			 ,
@"Shawn,727.33,2016-11-04T13:07Z,37"			 ,
@"Robert,508.41,2016-11-04T04:08Z,33"		 ,
@"Eugene,796.79,2016-11-04T12:02Z,71 "			 ,
@"William,950.59,2016-11-04T19:29Z,57"		 ,
@"David,698.42,2016-11-04T05:15Z,87 "		 ,
@"Betty,775.49,2016-11-04T07:37Z,43 "		 ,
@"Edward,244.91,2016-11-04T14:05Z,87 "			 ,
@"Sandra,632.14,2016-11-04T17:21Z,44 "		 ,
@"Mark,946.84,2016-11-04T10:11Z,29 "			 ,
@"Brenda,459.80,2016-11-04T08:35Z,41"			 ,
@"Howard,500.28,2016-11-04T11:23Z,34 "		 ,
@"Lisa,696.08,2016-11-04T21:56Z,100"			 ,
@"Steven,533.07,2016-11-04T23:22Z,93 "		 ,
@"Benjamin,291.66,2016-11-04T17:41Z,38 "		 ,
@"Brian,546.32,2016-11-04T21:36Z,69"			 ,
@"Brandon,677.45,2016-11-04T13:50Z,56"		 ,
@"William,329.53,2016-11-04T19:24Z,94"		 ,
@"Louis,316.32,2016-11-04T07:52Z,94 "		 ,
@"Elizabeth,599.00,2016-11-04T21:22Z,43"		 ,
@"Beverly,906.31,2016-11-04T21:40Z,41"		  ,
@"Kelly,723.23,2016-11-04T02:06Z,42 "		  ,
@"Brian,581.35,2016-11-04T11:03Z,49"			  ,
@"Earl,687.36,2016-11-04T02:27Z,62"			  ,
@"Randy,589.45,2016-11-04T15:35Z,83"			  ,
@"John,429.41,2016-11-04T16:46Z,89 "			  ,
@"Dennis,942.30,2016-11-04T09:21Z,50"		  ,
@"Ernest,447.25,2016-11-04T10:53Z,80 "		  ,
@"George,747.78,2016-11-04T23:46Z,36 "			  ,
@"Frank,383.15,2016-11-04T20:51Z,48"			  ,
@"Johnny,501.72,2016-11-04T07:49Z,92"			  ,
@"Sandra,671.73,2016-11-04T18:34Z,84 "			  ,
@"Ashley,470.34,2016-11-04T13:32Z,4"			  ,
@"Andrew,652.13,2016-11-04T08:08Z,84"		  ,
@"Eugene,910.14,2016-11-04T21:23Z,48 "		  ,
@"Aaron,498.51,2016-11-04T05:27Z,99 "		  ,
@"Patrick,119.45,2016-11-04T05:22Z,63 "		  ,
@"Jesse,771.72,2016-11-04T02:38Z,3"				  ,
@"Jason,286.79,2016-11-04T23:28Z,74"			  ,
@"Jessica,409.73,2016-11-04T20:32Z,67"			  ,
@"Jesse,438.41,2016-11-04T13:01Z,7 "			  ,
@"Mary,968.84,2016-11-04T17:07Z,12 "			  ,
@"Ryan,306.07,2016-11-04T04:10Z,6 "			  ,
@"Heather,724.76,2016-11-04T06:55Z,84 "			  ,
@"Kevin,774.80,2016-11-04T02:38Z,39 "			  ,
@"Ashley,401.18,2016-11-04T03:15Z,28"		  ,
@"Roger,546.09,2016-11-04T19:24Z,57"			  ,
@"Janice,365.26,2016-11-04T15:13Z,15 "		  ,
@"Kathy,693.41,2016-11-04T03:00Z,38 "		  ,
@"Daniel,699.31,2016-11-04T06:02Z,9 "		  ,
@"Justin,668.42,2016-11-04T19:32Z,35 "		  ,
@"Sharon,997.82,2016-11-04T22:40Z,38 "			  ,
@"Doris,976.13,2016-11-04T12:00Z,21"			  ,
@"Timothy,755.84,2016-11-04T21:03Z,25"			  ,
@"Timothy,860.44,2016-11-04T09:47Z,4"		  ,
@"Stephen,722.74,2016-11-04T21:40Z,85"			  ,
@"Irene,934.27,2016-11-04T14:35Z,42"			  ,
@"Lisa,781.88,2016-11-04T11:33Z,79 "			  ,
@"Albert,765.15,2016-11-04T23:49Z,80 "		  ,
@"Stephen,867.86,2016-11-04T04:59Z,64 "			  ,
@"Doris,401.46,2016-11-04T04:41Z,79 "		  ,
@"Albert,438.60,2016-11-04T01:58Z,50"			  ,
@"Amanda,820.23,2016-11-04T12:34Z,79 "		  ,
@"Raymond,910.54,2016-11-04T17:04Z,37"		  ,
@"Evelyn,227.77,2016-11-04T23:48Z,55 "			  ,
@"Diane,202.79,2016-11-04T21:26Z,86"			  ,
@"Irene,211.57,2016-11-04T15:28Z,57"			  ,
@"Deborah,738.07,2016-11-04T07:45Z,86 "		  ,
@"Peter,523.99,2016-11-04T18:23Z,77"			  ,
@"Carlos,575.01,2016-11-04T20:08Z,51 "		  ,
@"David,424.67,2016-11-04T17:53Z,43"			  ,
@"Fred,375.32,2016-11-04T15:16Z,67 "			  ,
@"Judy,523.88,2016-11-04T03:06Z,74"				  ,
@"Phyllis,408.54,2016-11-04T09:34Z,65 "		  ,
@"Doris,869.38,2016-11-04T10:03Z,13",
@"Albert,297.14,2016-11-04T01:33Z,22",
		};

		internal static string[] AccreditiMockedWithImportoTotale100AndTrasazioniTotale10At15_00_Mocked = new string[] {
@"Jessica,409.73,2016-11-04T20:32Z,67" ,
@"Jesse,438.41,2016-11-04T13:01Z,7 ",
@"Mary,968.84,2016-11-04T17:07Z,12 "   ,
@"Ryan,306.07,2016-11-04T04:10Z,6 " ,
	@"Take 1 - 15,2.00,2016-11-04T15:00Z,1" ,
@"Kevin,774.80,2016-11-04T02:38Z,39 "    ,
@"Ashley,401.18,2016-11-04T03:15Z,28" ,
@"Roger,546.09,2016-11-04T19:24Z,57"  ,
@"Janice,365.26,2016-11-04T15:13Z,15 ",
@"Kathy,693.41,2016-11-04T03:00Z,38 " ,
@"Daniel,699.31,2016-11-04T06:02Z,9 " ,
	@"Take 2 - 15,8.56,2016-11-04T15:00Z,5",
@"Sharon,997.82,2016-11-04T22:40Z,38 " ,
@"Doris,976.13,2016-11-04T12:00Z,21",
@"Timothy,755.84,2016-11-04T21:03Z,25" ,
	@"Take 3 - 15,88.43,2016-11-04T15:00Z,3",
		@"Take TZ,1.01,2016-11-04T15:00+00:00,1"   ,
@"Irene,934.27,2016-11-04T14:35Z,42"  ,
@"Lisa,781.88,2016-11-04T11:33Z,79 "     ,
@"Albert,765.15,2016-11-04T23:49Z,80 ",
@"Stephen,867.86,2016-11-04T04:59Z,64 "  ,
@"Doris,401.46,2016-11-04T04:41Z,79 " ,
		};

		static DateTime Orario12 = new DateTime(2016,11,04,12,0,0);
		static DateTime OrarioBefore12 = new DateTime(2016,11,04,11,59,59);
		static DateTime OrarioOver12 = new DateTime(2016,11,04,12,0,1);
		//static DateTime Orario15 = new DateTime(2016,11,04,15,0,0);
		
		internal static IAccredito[] AccreditiCollectionWithSingleOrarioOver12;

		internal static IAccredito[] AccreditiCollectionWithSingleOrario12;

		internal static IAccredito[] AccreditiCollectionWithSingleOrarioBefore12;

		internal static IEstrazione EstrazioneWithOrario12;

		internal static IResultEstrazione RisultatoEstrazioneItem15_00;

		static DataUtils(){
			ModelService evn = GetNewDataEnvironment();

			AccreditiCollectionWithSingleOrarioOver12 = new IAccredito[] {
				evn.GetNew<IAccredito>(1.00M, 1, OrarioOver12, "Orario Over 12")
			};

			AccreditiCollectionWithSingleOrario12= new IAccredito[] {
				evn.GetNew<IAccredito>(1.00M, 1, Orario12 , "Orario 12")
			};

			AccreditiCollectionWithSingleOrarioBefore12= new IAccredito[] {
				evn.GetNew<IAccredito>(1.00M, 1,OrarioBefore12 , "Orario Before 12")
			};

			EstrazioneWithOrario12 = evn.GetNew<IEstrazione>(Orario12);
			
			RisultatoEstrazioneItem15_00 = evn.GetNew<IResultEstrazione>(100.00M, 10); 

		}

		private static ModelService Init(ModelService env) {
			return env.Map<IAccredito, Accredito>()
				.Map<IEstrazione, Estrazione>()
				.Map<IResultEstrazione, RisultatoEstrazione>();
			
		}

		internal static ModelService GetNewDataEnvironment(){
			return Init((ModelService)Activator.CreateInstance(typeof(ModelService)));
		}

		internal static string[] FiltroEstrazioniMocked = new string[] {
			"2016-11-04T03:15:00Z",
			"2016-11-04T20:36:00Z",
			"2016-11-04T05:02:00Z",
			"2016-11-04T06:50:00Z",
			"2016-11-04T09:49:00Z",
			"2016-11-04T05:01:00Z",
			"2016-11-04T08:58:00Z",
			"2016-11-04T13:17:00Z",
			"2016-11-04T10:04:00Z",
			"2016-11-04T15:36:00Z",
		};

		static string ThreeOClockPM = "2016-11-04T15:00:00+00:00";

		internal static string[] FiltroEstrazioniSingleItem15_00Mocked= new string[] {
			ThreeOClockPM,
		};

	}

	public class Estrazione : IEstrazione
	{
		public Estrazione(){ }

		public Estrazione(DateTime ora) {
			Orario = ora;
		}

		public DateTime Orario
		{
			get; set;
		}
	}

	public class Accredito : IAccredito
	{
		public Accredito(){ }

		public Accredito(decimal importo, int numero, DateTime orario, string descrizione){
			Descrizione = descrizione;
			Importo = importo;
			NumeroTransazioni = numero;
			Orario = orario;

		}

		public string Descrizione
		{
			get; set;
		}

		public decimal Importo
		{
			get; set;
		}

		public int NumeroTransazioni
		{
			get; set;
		}

		public DateTime Orario
		{
			get; set;
		}
	}

	public class RisultatoEstrazione : IResultEstrazione
	{
		public RisultatoEstrazione() { }

		public RisultatoEstrazione(decimal importo, int numero){
			ImportoTotale = importo;
			TransazioniTotale = numero;
			Data = DateTime.Now;
		}

		public decimal ImportoTotale
		{
			get; set;
		}

		public int TransazioniTotale
		{
			get; set;
		}
		
		public DateTime Data
		{
			get; set;
		}
	}
}
