// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Strg + .: Schnellaktionen unter dem Cursor anzeigen
//Strg + Leertaste: Vorschläge öffnen
//Strg + K, Strg + D: Code formatieren
//Strg + K, Strg + C: Codeblock auskommentieren
//Strg + K, Strg + U: Codeblock einkommentieren
//Alt + Pfeiltaste: Derzeitige Zeile verschieben
//Strg + R + R: Feld umbenennen, wird überall umbenannt
//F12: Zu dem Member unter dem Cursor springen
//Strg + D: Derzeitige Zeile kopieren

new Queue<Fahrzeug>(new Fahrzeug[10].Select(e => Fahrzeug.GenFahrzeug())
	.Zip(new Stack<Fahrzeug>(new Fahrzeug[10].Select(e => Fahrzeug.GenFahrzeug())
	.Where(e => e is IBeladbar)
	.ToList()
	.ToDictionary(e => e.First, e => e.Second);
Console.WriteLine();

public class Fahrzeug
{
	public static Fahrzeug GenFahrzeug() => Random.Shared.Next(0, 3) switch { 1 => new PKW(), 2 => new Schiff(), _ => new Flugzeug() };
}

public class PKW : Fahrzeug { }

public class Schiff : Fahrzeug, IBeladbar
{
	public Fahrzeug Ladung { get; set; }

	public void Belade(Fahrzeug f)
	{
		Ladung = f;
	}
}

public class Flugzeug : Fahrzeug { }

public interface IBeladbar 
{
	void Belade(Fahrzeug f);
}