namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 5; i++)
			{
				Person p = new Person();
			}
			
			GC.Collect();
			GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren
			#endregion

			#region Static
			//Statische Member sind "global"
			//Können immer und von überall aufgerufen/angegriffen werden
			//Nicht-statische Member sind vom Objekt abhängig
			Person p2 = new Person();
            Console.WriteLine(p2.VollerName); //VollerName hängt auf dem Objekt daran

			//Console con = new Console(); //Nicht möglich
			Console.WriteLine(); //Direkter Zugriff über Klassenname ("global")

			Person.PrintEtwas(); //Eigene statische Funktion
								 //p2.PrintEtwas(); //Funktion ist auf der Klasse, nicht auf dem Objekt
			#endregion

			#region Arbeiten mit Datumswerten
			DateTime now = DateTime.Now; //Die jetzt Zeit
            Console.WriteLine(now.Hour);
            Console.WriteLine(now.Minute); //Einzelne Teile aus der Zeit entnehmen
            Console.WriteLine(now.ToLongDateString() + " " + now.ToLongTimeString()); //Schöne Repräsentationen der gegebenen Zeit

			now = now.AddHours(24);
            Console.WriteLine(now); //Stunden addieren, kann auch Überschläge

			now += TimeSpan.FromDays(3); //Auch mit TimeSpan möglich
			now -= TimeSpan.FromDays(3);

			now += new TimeSpan(4, 10, 20); //Beliebige Zeiten addieren
            Console.WriteLine(now);
			#endregion

			#region Werte- und Referenztypen
			//Wertetyp
			//struct
			//Bei Zuweisungen werden die Inhalte kopiert
			//Bei Vergleichen werden die Inhalte verglichen
			int original = 5;
			int x = original;
			original = 10;

			//Referenztyp
			//class
			//Bei Zuweisungen werden die Inhalte referenziert
			//Bei Vergleichen werden die Speicheradressen verglichen
			Person p3 = new Person();
			Person p4 = p3;
			p3.Alter = 100;

            Console.WriteLine(p3.GetHashCode());
            Console.WriteLine(p4.GetHashCode());
			// if (p3.GetHashCode() == p4.GetHashCode()) -> if (p3 == p4)

			Test(p3);
			Test(original);
			#endregion

			#region Null
			//Null: Leerer Wert/kein Wert, keine Referenz
			int zahl; //Structs können nicht null sein
			Person p5; //Klassen können null sein

			p5 = new Person(); //p5 wird mit einem Objekt befüllt
			p5 = null; //Verbindung trennen, GC sammelt jetzt das Objekt ein

			//p5.Nachname = ""; //NullReferenceException: p5 existiert nicht, daher kann auch auf Nachname nicht zugegriffen werden

			if (p5 == null)
			{
				p5 = new Person();
			}

			if (p5 != null)
			{
				p5.Nachname = "";
			}
			#endregion
		}

		public static void Test(Person p)
		{
			p.Alter = 200;
		}

		public static void Test(int x)
		{
			x = 200;
		}
	}
}