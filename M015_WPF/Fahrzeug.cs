using System;

namespace Fahrzeugpark;

public abstract class Fahrzeug
{
	public string Name { get; set; }

	public int Preis { get; set; }

	public int MaxGeschwindigkeit { get; set; }

	public abstract string Info();

	public static Fahrzeug GeneriereFahrzeug()
	{
		Random r = new Random();
		switch (r.Next(0, 3))
		{
			case 0: return new PKW("Audi", 30000, 300, 4);
			case 1: return new Schiff("Titanic", 10_000_000, 100, "Diesel");
			default: return new Flugzeug("Boeing 747", 5_000_000, 1000, 10000);
		}
	}

	public Fahrzeug(string name, int preis, int maxGeschwindigkeit)
	{
		Name = name;
		Preis = preis;
		MaxGeschwindigkeit = maxGeschwindigkeit;
	}
}

public class PKW : Fahrzeug
{
	public int AnzahlSitzplaetze { get; set; }

	public override string Info()
	{
		return $"Dieser PKW kostet {Preis}€ und könnte maximal {MaxGeschwindigkeit}km/h fahren. " +
			$"Es hat {AnzahlSitzplaetze} Sitzplätze.";
	}

	public PKW(string name, int preis, int maxGeschwindigkeit, int anzSitze) : base(name, preis, maxGeschwindigkeit)
	{
		AnzahlSitzplaetze = anzSitze;
	}
}

public class Schiff : Fahrzeug
{
	public string Treibstoff { get; set; }

	public override string Info()
	{
		return $"Dieses Schiff kostet {Preis}€ und könnte maximal {MaxGeschwindigkeit}km/h fahren. " +
			$"Es fährt mit {Treibstoff}.";
	}

	public Schiff(string name, int preis, int maxGeschwindigkeit, string treibstoff) : base(name, preis, maxGeschwindigkeit)
	{
		Treibstoff = treibstoff;
	}
}

public class Flugzeug : Fahrzeug
{
	public int Flughoehe { get; set; }

	public override string Info()
	{
		return $"Dieses Flugzeug kostet {Preis}€ und könnte maximal {MaxGeschwindigkeit}km/h schnell fliegen. " +
			$"Es kann maximal auf {Flughoehe}m aufsteigen.";
	}

	public Flugzeug(string name, int preis, int maxGeschwindigkeit, int flughoehe) : base(name, preis, maxGeschwindigkeit)
	{
		Flughoehe = flughoehe;
	}
}