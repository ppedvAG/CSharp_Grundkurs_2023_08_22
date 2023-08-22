using System.Net.Http.Headers;
using System.Net.WebSockets;

namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Eine Variable, die mehrere Werte halten kann (statt einem)
			int[] zahlen; //Arrayvariable deklariert mithilfe von []
			zahlen = new int[10]; //new: Erstelle ein neues Objekt -> hier ein int[] mit 10 Stellen
			zahlen[0] = 5; //Nullbasierter Index: Größe 10, Indizes 0-9
			Console.WriteLine(zahlen[3]); //Wert von Stelle 3 auslesen -> 0

            Console.WriteLine(zahlen.Length); //Anzahl der Elemente (10)
            Console.WriteLine(zahlen.Contains(5)); //Enthält das Array den Wert 5? -> true
            Console.WriteLine(zahlen.Contains(20)); //false

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung (schreibt die Werte von Anfang an in das Array), Länge 5, Indizes 0-4
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Kürzeste Schreibweise

			//Mehrdimensionale Arrays: Arrays mit mehreren Koordination (X, Y, Z, ...)
			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), Deklaration mit Komma in der Klammer
			zweiDArray[1, 1] = 8;
			Console.WriteLine(zweiDArray[1, 1]);

			zweiDArray = new int[,]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

            Console.WriteLine(zweiDArray.Length); //Summe der Elemente 3x3 = 9
            Console.WriteLine(zweiDArray.Rank); //Anzahl der Dimensionen (2)
            Console.WriteLine(zweiDArray.GetLength(0)); //Länge einer einzelnen Dimension (3)
            Console.WriteLine(zweiDArray.GetLength(1)); //Länge einer einzelnen Dimension (3)
			#endregion

			#region Bedingungen
			//Vergleichsoperatoren
			//==, !=, <=, >=, <, >
			//2 Werte vergleichen

			//Logische Operatoren
			//&&, ||, !, ^
			//2 Bedingungen verknüpfen

			if (zahlen.Contains(5) ^ zahlen.Contains(20)) //Wenn die Bedingungen unterschiedlich sind
			{
				//Wenn zahlen 5 enthält aber nicht 20 oder zahlen 20 enthält aber nicht 5
			}
			else
			{

			}

			//Ternary Operator (Fragezeichen Operator)
			//Bedingungen kürzen
			//Dieser Operator hat immer ein Ergebnis
			//Hat immer if und else
			string s = "";
			if (zahlen.Contains(5)) //Bei einzeiligen ifs können die Klammern weggelassen werden
				s = "Zahlen enthält 5";
			else
				s = "Zahlen enthält nicht 5";
            Console.WriteLine(s);

			s = zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5"; //Wenn Zahlen 5 enthält, dann links, sonst rechts
            Console.WriteLine(s);

            Console.WriteLine(zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5");

            Console.WriteLine(zweiDArray.Rank == 2 ? "Hat 2 Dimensionen" : "Hat nicht 2 Dimensionen");
			#endregion
        }
	}
}