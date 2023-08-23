using System.Net.Security;

namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		//Polymorphismus (Vielgestaltigkeit)
		//Welche Typen passen mit welchen anderen Typen zusammen (Typkompatiblität)

		Mensch m = new Mensch(); //Variablentyp Mensch, Laufzeittyp Mensch -> kann alle Objekte halten vom Typ Mensch oder einer Unterklasse vom Typ Mensch

		//Lebewesen lw = new Lebewesen(); //Variablentyp Lebewesen, Laufzeittyp Lebewesen -> kann alle Objekte halten vom Typ Lebewesen oder einer Unterklasse vom Typ Lebewesen
		Lebewesen lw2 = m; //Mensch ist kompatibel mit Lebewesen

		//m = (Mensch) lw; //Möglich, aber nur durch Cast (kann kompatibel sein)
		//lw = m; //Immer möglich (ohne Cast)

		object o = new object(); //Variablentyp Object -> kann alle Objekte halten
		o = m;
		o = 123;
		o = true;
		o = "Text";

		//Typ
		//Beschreibung die jedes Objekt hat
		//.GetType(): Kann aus einer Variable/Object der Type Object herausgeholt werden
		//typeof(<Typname>): Kann aus einem Typnnamen ein Type Object herausgeholt
		Type mt = m.GetType();
		Type lt = typeof(Lebewesen);

		#region Typvergleiche
		//Genauer Typvergleich
		if (m.GetType() == typeof(Mensch))
		{
            //Ist der Inhalt von m genau ein Mensch
            Console.WriteLine("m ist ein Mensch");
        }

		if (m.GetType() == typeof(Lebewesen))
		{
			//Ist der Inhalt von m genau ein Lebewesen
			Console.WriteLine("m ist ein Lebewesen");
		}

		if (m.GetType() == typeof(object))
		{
			//Ist der Inhalt von m genau ein Object
			Console.WriteLine("m ist ein Object");
		}

		//Vererbungshierarchie Typvergleich
		if (m is Mensch)
		{
			//Ist der Inhalt von m ein Mensch
			Console.WriteLine("m ist Mensch");
		}

		if (m is Lebewesen)
		{
			//Ist der Inhalt von m ein Lebewesen
			Console.WriteLine("m ist Lebewesen");
		}

		if (m is object)
		{
			//Ist der Inhalt von m ein Object
			Console.WriteLine("m ist Object");
		}
		#endregion

		//Praktisches Beispiel
		Lebewesen[] lebewesen = new Lebewesen[3];
		lebewesen[0] = new Mensch();
		lebewesen[1] = new Katze();
		lebewesen[2] = new Mensch();

		foreach (Lebewesen l in lebewesen)
		{
			l.WasBinIch(); //Alle Unterklassen müssen diese Methode haben, daher kann diese hier aufgerufen werden

			if (l is Mensch)
			{
				Mensch mensch = (Mensch) l;
				mensch.Sprechen();
			}

			if (l is Katze katze) //Schneller Cast
				katze.Springen();
		}

		long x = 3825729358923458;
		int y = (int) x;
		double z = y;

		Test(lebewesen[0]);
		Test(lebewesen[1]);
		Test(lebewesen[2]);
		Test(m);
		Test(lw2);
	}

	public static void Test(Lebewesen l) //Alle Lebewesen können hier übergeben werden
	{

	}

	public static void Test(object o) //Alles kann hier übergeben werden
	{

	}
}




/// <summary>
/// abstract: Strukturklasse, gibt eine Struktur vor die Unterklassen befolgen müssen
/// Es kann von dieser Klasse kein Objekt mehr erstellt werden
/// Abstrakte Klassen können nur vererbt werden
/// </summary>
public abstract class Lebewesen
{
	public string Name { get; set; }

    public Lebewesen()
    {
        
    }

    public Lebewesen(string name)
	{
		Name = name;
	}

	/// <summary>
	/// Hier wird nurnoch die Struktur der Methode vorgegeben, die Unterklassen müssen jetzt selbst eine Implementation bereitstellen
	/// </summary>
	public abstract void WasBinIch();
}

public sealed class Mensch : Lebewesen // : <Typ>: Vererbung herstellen
{
	/// <summary>
	/// Alter würde nach unten weitervererbt werden
	/// </summary>
	public int Alter { get; set; }

    public Mensch() : base()
    {
        
    }

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
		//base.WasBinIch(); //Führe hier die Implementation in der Lebewesen aus
		Console.WriteLine($"Ich bin ein Mensch und bin {Alter} Jahre alt");
	}

	public void Sprechen()
	{

	}
}

public class Katze : Lebewesen
{
	public string Farbe { get; set; }

    public Katze() : base()
    {
        
    }

    public Katze(string name, string farbe) : base(name)
	{
		Farbe = farbe;
	}

	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin eine Katze");
    }

	public void Springen()
	{

	}
}