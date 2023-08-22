namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(1, 2);
			PrintAddiere(3, 4);
			PrintAddiere(5, 6);

			int summe = Addiere(8, 9); //Ergebnis der Funktion herausnehmen und in die Summe Variable schreiben
            Console.WriteLine("Die Summe ist: " + summe);

			double summeDouble = Addiere(8, 3d); //Double Overload erzwingen durch einen double Parameter
			Addiere(1, 2, 3);

			Summiere(3, 4);
			Summiere(1, 2, 3, 4);
			Summiere(1, 2, 3, 4, 5, 6, 7, 8, 9);
			Summiere(); //Keine Parameter sind auch beliebig viele Parameter

			Subtrahiere(3, 4);
			Subtrahiere(3, 4, 5);

			SubtrahiereOderAddiere(4, 5);
			SubtrahiereOderAddiere(4, 5);
			SubtrahiereOderAddiere(4, 5);
			SubtrahiereOderAddiere(4, 5);
			SubtrahiereOderAddiere(4, 5);
			SubtrahiereOderAddiere(4, 5, false); //Funktion über bool Parameter anpassen

			int differenz;
			AddiereUndSubtrahiere(6, 8, out differenz); //Funktion mit mehreren Rückgabewerten machen

			int result = 0;
			bool parsenFunktioniert = int.TryParse("123", out result);
			if (parsenFunktioniert)
			{
                Console.WriteLine(result);
            }
			else
			{
                Console.WriteLine("Parsen hat nicht funktioniert");
            }

            Console.WriteLine(int.TryParse("123", out result) ? result : "Parsen hat nicht funktioniert");
        }

		static void PrintAddiere(int x, int y)
		{
			Console.WriteLine(x + y);
		}

		/// <summary>
		/// Aufbau:
		/// Modifier (public, static, async, ref, readonly, extern, ...)
		/// Rückgabetyp, Ergebnis der Funktion
		/// Namen der Funktion
		/// Parameterliste
		/// </summary>
		static int Addiere(int x, int y)
		{
			return x + y; //return: Wirf das Ergebnis der Funktion an den Benutzer zurück
		}

		/// <summary>
		/// Überladung: Methode mit demselben Namen wie einer andere Methode, aber mit anderen Parametern
		/// </summary>
		static double Addiere(double x, double y)
		{
			return x + y;
		}

		static int Addiere(int x, int y, int z)
		{
			return x + y + z;
		}

		static int Summiere(params int[] zahlen)
		{
			return zahlen.Sum();
		}

		static int Subtrahiere(int x, int y, int z = 0)
		{
			return x - y - z;
		}

		static int SubtrahiereOderAddiere(int x, int y, bool sub = true)
		{
			return sub ? x - y : x + y;
		}

		static int AddiereUndSubtrahiere(int x, int y, out int diff)
		{
			diff = x - y;
			return x + y;
		}

		static void PrintZahl(int z)
		{
            Console.WriteLine(z);
			return; //Aus Funktion herausspringen / Funktion beenden (häufig mit einer if)
            Console.WriteLine(z);
        }
	}
}