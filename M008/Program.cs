namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Lebewesen lw = new Lebewesen("Test");
		lw.WasBinIch(); //Normale Klasse, keine Besonderheiten
		
		Mensch m = new Mensch("Max", 34);
		//m.Name = "Max"; //Mensch hat Name und WasBinIch geerbt
		m.WasBinIch();
		
		lw.GetHashCode(); //Jede Klasse in C# erbt von Object, und hat dadurch GetHashCode, Equals, GetType, ToString
	}
}

/// <summary>
/// Diese Klasse stellt die Basisklasse dar. Sie gibt ihre Inhalte (Felder, Properties und Funktionen) an die Unterklassen weiter.
/// </summary>
public class Lebewesen
{
	/// <summary>
	/// Name wird nach unten weitervererbt
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Dieser Konstruktor muss in der Unterklasse implementiert und mithilfe von base verkettet werden
	/// </summary>
	/// <param name="name"></param>
	public Lebewesen(string name)
	{
		Name = name;
	}

	/// <summary>
	/// WasBinIch wird auch nach unten vererbt
	/// virtual: Diese Methode kann in der Unterklasse überschrieben werden, muss aber nicht
	/// </summary>
	public virtual void WasBinIch()
	{
        Console.Write("Ich bin ein Lebewesen");
    }
}

public sealed class Mensch : Lebewesen // : <Typ>: Vererbung herstellen
{
	/// <summary>
	/// Alter würde nach unten weitervererbt werden
	/// </summary>
	public int Alter { get; set; }

	/// <summary>
	/// Konstruktor mit Strg + . auf den Klassennamen erzeugen
	/// Konstruktor kann hier unten nochmal bearbeitet werden
	/// </summary>
	public Mensch(string name, int alter) : base(name) //base: Greife etwas in der Oberklasse an (effektiv this im Vererbungskontext)
	{
		Alter = alter;
	}

	/// <summary>
	/// sealed: Verhindert das Überschreiben der Methode oder das Vererben von einer Klasse
	/// </summary>
	public override sealed void WasBinIch()
	{
		base.WasBinIch(); //Führe hier die Implementation in der Lebewesen aus
        Console.WriteLine($", genauer gesagt ein Mensch und bin {Alter} Jahre alt");
    }
}

public class Katze : Lebewesen
{
	public string Farbe { get; set; }

	public Katze(string name, string farbe) : base(name)
	{
		Farbe = farbe;
	}
}