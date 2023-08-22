namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b)
			{
				Console.WriteLine($"while: {a}");
				a++;
			} //Nach jedem Durchlauf wird geprüft, ob die Bedingung noch wahr ist

			int c = 00;
			int d = 10;
			do //Diese Schleife wird mindestens einmal ausgeführt, egal ob die Bedingung von Anfang true ist oder nicht
			{
				Console.WriteLine($"do-while: {c}");
				c++;
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			c = 0;

			while (true) //do-while mit while (true) darstellen
			{
				c++;
				if (c == 5)
					continue; //continue: Springe zum Kopf zurück, führe den Code danach nicht aus
				Console.WriteLine($"while-true: {c}");

				if (c >= d) //break sollte mit if/else kombiniert werden
					break; //Beendet die Schleife
			}

			//for + Tab + Tab
			//Drei Teile: Laufvariable, Bedingung(en), Inkrement
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"for: {i}");
			}

			//Beliebig viele Zähler, Bedingungen und Inkremente möglich
			for (int i = 0, j = 1; i < 31; i++, j *= 2)
			{
				Console.WriteLine($"2^{i}={j}");
			}

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine($"forr: {i}");
			}

			//Array durchgehen
			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			for (int i = 0; i < zahlen.Length; i++) //Array mit Schleife durchgehen
			{
				Console.WriteLine($"zahlen[{i}] = {zahlen[i]}"); //Fehleranfällig, weil der Index daneben greifen kann
			}

			//foreach + Tab + Tab
			foreach (int item in zahlen) //Array durchgehen aber kann nicht daneben greifen, weil kein Index
			{
				Console.WriteLine(item);
			}

			foreach (int item in zahlen) //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
				Console.WriteLine(item);
			#endregion

			#region Enums
			//Enum: Eigener Typ gefüllt mit fixen Zuständen

			//if (Console.ReadKey().Key == ConsoleKey.K)

			Wochentag tag = Wochentag.Di; //Nur fixe Zustände möglich

			if (tag == Wochentag.Sa) //Nur fixe Zustände möglich
			{

			}

			//Jeder Enum Wert hat einen Int Dahinter (Mo = 0, Di = 1, ...)
			int x = 2;
			Wochentag castTag = (Wochentag) x; //Direkte Umwandlung
			int y = (int) castTag; //Tag von oben wieder zurück konvertieren

			Console.WriteLine(Wochentag.Mi + 1);

			//String zu Enum
			Wochentag parseTag = Enum.Parse<Wochentag>("Do");
			Wochentag parseTagZahl = Enum.Parse<Wochentag>("3"); //Enum.Parse kann auch Zahlen konvertieren

			foreach (Wochentag wt in Enum.GetValues<Wochentag>())
			{
				Console.WriteLine(wt);
			}
			#endregion

			#region Switch
			string stringTag = "Mo";
			if (stringTag == "Mo") //If-ElseIf Baum (unschön)
				Console.WriteLine("Wochenanfang");
			else if (stringTag == "Di" || stringTag == "Mi" || stringTag == "Do" || stringTag == "Fr")
				Console.WriteLine("Wochentag");
			else if (stringTag == "Sa" || stringTag == "So")
				Console.WriteLine("Wochenende");
			else
				Console.WriteLine("Fehler");

			//Strg + .: Schnellaktionen unter dem Cursor anzeigen
			switch (stringTag) //Schaue die Variable an
			{
				case "Mo": //Wenn Mo
					Console.WriteLine("Wochenanfang");
					break; //Am Ende von jedem Case muss ein break existieren
				case "Di":
				case "Mi":
				case "Do":
				case "Fr": //Di bis Fr wurden kombiniert
					Console.WriteLine("Wochentag");
					break;
				case "Sa":
				case "So": //Sa und So wurden auch kombiniert
					Console.WriteLine("Wochenende");
					break;
				default: //effektiv else
					Console.WriteLine("Fehler");
					break;
			}

			int z = 0;
			switch (z)
			{
				case 0:
					Console.WriteLine("Null");
					break;
				case 1:
					Console.WriteLine("Eins");
					break;
				case 2:
					Console.WriteLine("Zwei");
					break;
				default:
					Console.WriteLine("Andere Zahl");
					break;
			}

			//Switch mit boolescher Logik
			switch (tag)
			{
				case >= Wochentag.Mo and <= Wochentag.Fr: //Hier muss and und or verwendet werden
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
			}

			#endregion

			//Strg + .: Schnellaktionen unter dem Cursor anzeigen
			//Strg + Leertaste: Vorschläge öffnen
			//Strg + K, Strg + D: Code formatieren
			//Strg + K, Strg + C: Codeblock auskommentieren
			//Strg + K, Strg + U: Codeblock einkommentieren
			//Alt + Pfeiltaste: Derzeitige Zeile verschieben
		}
	}

	public enum Wochentag
	{
		Mo = 1, Di, Mi, Do = 10, Fr, Sa, So
	}
}