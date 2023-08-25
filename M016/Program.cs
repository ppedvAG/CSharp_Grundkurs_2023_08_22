using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		//Dateimanagement Klassen
		//File, Directory, Path

		//Environment-Klasse: Gibt Informationen zu der Umgebung
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Spezielle Folder holen

		string folderPath = Path.Combine(desktop, "Test"); //Path.Combine: Pfade zusammebauen (erstellt keine Dateien/Ordner)

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//StreamWriter sw = new StreamWriter(filePath);
		//sw.WriteLine("Test1");
		//sw.WriteLine("Test2");
		//sw.WriteLine("Test3");
		//sw.Flush();
		//sw.Close(); //Streams müssen geschlossen werden, weil Dateien die offen bleiben können nicht bearbeitet/gelöscht werden

		//using: Schließt den Stream am Ende des Blocks automatisch
		//Funktioniert generell bei allen Objekten die Daten aus der Applikation laden/schreiben
		//using (StreamWriter sw = new StreamWriter(filePath))
		//{
		//	sw.WriteLine("Test1");
		//	sw.WriteLine("Test2");
		//	sw.WriteLine("Test3");
		//} //Hier am Ende wird Dispose() ausgeführt

		//using (StreamReader sr = new StreamReader(filePath))
		//{
		//	string text = sr.ReadToEnd(); //Einzelner string mit \r\n für Umbrüche
		//	//string[] zeilen = sr.ReadToEnd().Split(Environment.NewLine);

		//	sr.BaseStream.Position = 0; //Stream Position an den Anfang setzen

		//	List<string> zeilen = new();
		//	while (!sr.EndOfStream)
		//		zeilen.Add(sr.ReadLine());
		//}

		////using-Statement: Schließt den Stream am Ende der Funktion automatisch (statt am Ende des Blocks)
		////using StreamWriter sw2 = new(filePath);

		////Schnelle Methoden
		//string text2 = File.ReadAllText(filePath);
		//string[] lines = File.ReadAllLines(filePath);

		//File.WriteAllText(filePath, "Text10\nText20");
		//File.WriteAllLines(filePath, lines);

		//File.AppendAllText(filePath, "Text10\nText20");
		//File.AppendAllLines(filePath, lines);



		//NuGet-Packages: Externe Pakete die auf einer per Projektbasis installiert werden können
		//Funktionalität des Projekts durch verschiedene Pakete erweitern
		//Tools -> NuGet Package Manager -> Manage NuGet Packages

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

		//System.Text.Json
		//string json = JsonSerializer.Serialize(fahrzeuge);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson);

		//Newtonsoft.Json
		//string json = JsonConvert.SerializeObject(fahrzeuge);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson);

		//Xml
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new(filePath))
		{
			xml.Serialize(sw, fahrzeuge);
		}

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> readXml = xml.Deserialize(sr) as List<Fahrzeug>;
		}
	}
}

public class Fahrzeug
{
	[JsonIgnore]
	[XmlAttribute]
	public int MaxGeschwindigkeit { get; set; }

	//[XmlIgnore]
	[XmlAttribute]
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

	public Fahrzeug()
	{

	}
}


public enum FahrzeugMarke { Audi, BMW, VW }