using M006.Data; //Person importieren über Using

namespace M006
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person p; //Variable anlegen
			p = new Person("Lukas", "Kern"); //Objekt erstellen mit new, Speicherplatz im RAM wird reserviert und die Adresse wird in p gespeichert
			p.SetVorname("Max"); //Einzelne Werte des Objekts anpassen über Methode
			p.Nachname = "Mustermann";  //Einzelne Werte des Objekts anpassen über Property

			p.Alter = 30;
            //p.Gehalt = 10000; //private set, deswegen nicht möglich
            Console.WriteLine(p.Gehalt);

			Person p2 = new Person("", ""); //Beliebig viele Objekte von demselben Bauplan möglich
			//p und p2 haben keinen Zusammenhang (außer das sie von der selben Klasse kommen)
			p2.Alter = 50;

			Person p3 = new Person("", "", 40, 5000); //Hier werden beide Konstruktoren verwendet (wegen this)

			//Namespace: Unterteilung von Typen in "Pakete" (Organisation)
			//Console, int, double, string: System
			//File, Directory, Path: System.IO
			//HttpClient: System.Net.Http

			//Referenzierung von Objekten zwischen verschiedenen Objekten
			Person lk = new Person("", "", 25, 200000, Rolle.Trainer);
			Person rs = new Person("", "", 42, 50000);
			Person ag = new Person("", "", 50, 750000);
			Person jo = new Person("", "", 30, 123456, Rolle.Organisator);

			Kurs k = new Kurs(Standort.Gemischt, lk, rs, ag, jo);
			foreach (Person tn in k.Teilnehmer)
			{
				switch (tn.Rolle)
				{
					case Rolle.Trainer:
                        Console.WriteLine($"{tn.VollerName} ist der Trainer dieses Kurses.");
                        break;
					case Rolle.Teilnehmer:
						Console.WriteLine($"{tn.VollerName} nimmt als Teilnehmer an dem Kurs teil.");
						break;
					case Rolle.Organisator:
                        Console.WriteLine($"{tn.VollerName} ist der Organistor dieses Kurses");
                        break;
				}
			}
		}
	}
}