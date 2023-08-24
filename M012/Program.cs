using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Linq: Ermöglicht das einfache Filtern von Listen
		//-> Alle Klassen die von IEnumerable erben
		//Alle Linq Funktionen enthalten eine Schleife um ihre Ergebnisse zu liefern
		
		List<int> list = Enumerable.Range(1, 20).ToList();
        Console.WriteLine(list.Average());
        Console.WriteLine(list.Sum());
        Console.WriteLine(list.Min());
        Console.WriteLine(list.Max());

        Console.WriteLine(list.First()); //Erstes Element, Fehler wenn kein Element gefunden
        Console.WriteLine(list.Last());

        Console.WriteLine(list.FirstOrDefault()); //Erstes Element, default wenn kein Element gefunden
		Console.WriteLine(list.LastOrDefault());

        //Bei First/Last können Bedingungen angegeben werden
        //Console.WriteLine(list.First(e => e % 50 == 0)); //Fehler
        Console.WriteLine(list.FirstOrDefault(e => e % 50 == 0)); //0

		//Lambda-Expression (e => ...): Gibt die Bedingung oder den Selektor an den die Funktion verwenden soll
		//e => wird in Linq Funktion generell benötigt
		//e kann ein beliebiger Name sein
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq-Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Objektliste
		//Alle Fahrzeuge finden mit mindestens 200km/h
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs finden mit mindestens 200km/h
		fahrzeuge.Where(e => e.MaxV >= 200 && e.Marke == FahrzeugMarke.VW);

		//Alle Fahrzeuge nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Wichtig: OrderBy erzeugt eine neue Liste
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV).ToList(); //Sekundäre Sortierung
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV).ToList(); //Absteigende Sortierung

		//Select: Wandelt die Liste in eine neue Form um
		//In der Funktion kann ein Term angegeben werden, und jedes Element wird dann konvertiert in diese Form
		//2 Beispiele
		//1. Fall (häufigster Anwendungsfall): Einzelnes Feld aus der Liste extrahieren
		fahrzeuge.Select(e => e.MaxV).Average(); //Nur die Geschwindigkeiten von den Fahrzeugen nehmen und Durchschnitt berechnen
		fahrzeuge.Select(e => e.Marke).Distinct(); //Marken nehmen und einzigartig machen

		//2. Fall: Liste transformieren
		fahrzeuge.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV}km/h fahren.");

		//2. Beispiel
		string[] pfade = Directory.GetFiles(@"C:\Windows\System32"); //Alle Dateien ohne Pfad und ohne Endung holen
		List<string> p = new();
		foreach (string pfad in pfade)
			p.Add(Path.GetFileNameWithoutExtension(pfad));

		List<string> p2 = Directory.GetFiles(@"C:\Windows\System32").Select(e => Path.GetFileNameWithoutExtension(e)).ToList();

        Console.WriteLine(p.SequenceEqual(p2));

		//Wieviele BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW); //4
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).Count(); //Benötigt 16 Listenzugriffe statt 12

		//All & Any
		//Fahren alle Fahrzeuge schneller als 200km/h?
		fahrzeuge.All(e => e.MaxV > 200); //false
		if (fahrzeuge.All(e => e.MaxV > 200))
		{

		}

		fahrzeuge.Any(e => e.MaxV > 200); //Mindestens ein Element -> true
		if (fahrzeuge.Any(e => e.MaxV > 200))
		{

		}

		fahrzeuge.Any(); //Hat die Liste Elemente? fahrzeuge.Count > 0

		//Min, Max, MinBy, MaxBy
		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit

		//Skip & Take
		//Nehmen einen int und überspringen/nehmen soviele Elemente
		//Die 3 schnellsten Fahrzeuge
		fahrzeuge
			.OrderByDescending(e => e.MaxV)
			.Take(3);

		//Sum, Average
		fahrzeuge.Sum(e => e.MaxV); //fahrzeuge.Select(e => e.MaxV).Sum();
		fahrzeuge.Average(e => e.MaxV); //fahrzeuge.Select(e => e.MaxV).Average();
		#endregion

		#region Erweiterungsmethoden
		//Erweiterungsmethode: Funktion, die an einen beliebigen Typen angehängt werden können
		int x = 482973;
		x.Quersumme();
        Console.WriteLine(382572395.Quersumme());

		fahrzeuge.Shuffle();

		int[] zahlen = { 1, 2, 3, 4, 5 };
		zahlen.Shuffle();

		Dictionary<string, int> dict = new();
		dict.Shuffle();
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}