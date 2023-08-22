namespace M002
{
	internal class Program
	{
		/// <summary>
		/// Die Main Methode
		/// </summary>
		/// <param name="args">Die Programmargumente</param>
		static void Main(string[] args)
		{
			#region Variablen
			//Variable: Container der einen Wert halten kann
			//Besteht aus Typ und Name
			int zahl;
			zahl = 5;

            Console.WriteLine(zahl);

            Console.WriteLine(zahl * 2);

			string wort = "Hallo";
            Console.WriteLine(wort);

			char buchstabe = 'A';
            Console.WriteLine(buchstabe);

			//Kommazahl: float, double, decimal
			double kommazahl = 38924.328954723;
			float floatZahl = 325.239058230f; //Kommazahlen sind standardmäßig double, mit F zu float konvertieren
			decimal decimalZahl = 24981.23589923845m; //Kommazahlen sind standardmäßig double, mit M zu decimal konvertieren

			long longZahl = 2849921384902385290;

			//bool
			bool b = false;
			b = true;
			#endregion

			#region Strings
			string kombi = "Das Wort ist " + wort;
            Console.WriteLine(kombi);

			string kombination = "Das Wort ist: " + wort + ", die Zahl ist: " + zahl + ", der boolean ist: " + b; //Anstrengend
            Console.WriteLine(kombination);

			//String Interpolation: Code in Strings einbauen
			string interpolation = $"Das Wort ist: {wort}, die Zahl ist: {zahl}, der boolean ist: {b}";
            Console.WriteLine(interpolation);

            //Escape-Sequenzen: Sonderzeichen in den String einbauen (z.B. Umbrüche, Tabs)
            //https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
            Console.WriteLine("Text\t\n\"Text");
			char einzeln = '\'';
			char leer = '\0';

			//Verbatim String: String der Escape-Sequenzen ignoriert
			string verbatim = @"\n";
			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_08_22";
			#endregion

			#region Eingabe
			//string eingabe = Console.ReadLine(); //Warte auf die Eingabe vom Benutzer
   //         Console.WriteLine($"Du hast {eingabe} eingegeben");

			////Parse: Konvertiert einen String in einen bestimmten Typen
			//string inputZahl = Console.ReadLine();
			//int x = int.Parse(inputZahl); //Konvertierung muss gemacht werden
   //         Console.WriteLine(x * 5);

			//double.Parse(inputZahl); //Eingabe vom Benutzer in eine Kommazahl konvertieren
			#endregion

			#region Konvertierungen
			//String -> anderer Typ: Parse
			//anderer Typ -> String: ToString()
			//anderer Typ -> anderer Typ: Cast, Typecast, Casting

			double d = 39254.2358249358;
			int i = (int) d; //Nicht kompatibel, durch Cast Konvertierung erzwingen
			short s = (short) i; //i wird gesenkt auf 65536 falls notwendig

			d = i; //Implizite Konvertierung (passt direkt ohne Erzwingung)
			#endregion

			#region Arithmetik
			int z1 = 5;
			int z2 = 8;

            Console.WriteLine(z1 + z2); //Summe wird berechnet, originale Zahlen werden nicht verändert

			z1 = z1 + z2; //z1 wird zu z1 + z2
			z1 += z2; //Addiere auf z1, z2

			z1 %= z2; //Schreibe den Rest der Division in z1

			z1++; //z1 += 1
			z2--; //z2 -= 1

			double d2 = 23814.32598239852390458;
			//Rundungsfunktionen: Floor, Ceiling, Round
			double f = Math.Floor(d2); //abrunden, originale Zahl wird nicht verändert
			double c = Math.Ceiling(d2); //aufrunden
			Math.Round(d2, 2); //Runde d2 auf 2 Kommazahlen
			Math.Round(4.5); //4, bei .5 die nächste gerade Zahl
			Math.Round(5.5); //6

            Console.WriteLine(8 / 5); //Int-Division: da zwei Int als Argumente (Ergebnis 1 statt 1.6)
            Console.WriteLine(8 / 5d); //Kommadivision erzwingen, wenn eine der beiden Zahlen eine Kommazahl ist
            Console.WriteLine(8 / 5.0);
            Console.WriteLine(8f / 5);
            Console.WriteLine((double) z1 / z2); //z1 temporär zu einem double konvertieren
            #endregion
        }
	}
}