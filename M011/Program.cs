namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generisches Typargument (Generic): Gibt die Möglichkeit den Typen für das Objekt dynamisch vorzugeben
		//Überall in der Klasse wo ein T verwendet wird, wird dieses T durch den gegebenen Typen ersetzt
		//<int> -> T -> int: Add(int), Remove(int), ...

		//List: Flexibles Array, passt die Größe automatisch auf die Elemente an. Es können später weitere Elemente hinzugefügt werden
		//Hat viele Gemeinsamkeiten mit dem Array
		List<int> list = new List<int>();
		list.Add(1); //T wird durch int ersetzt

		List<string> strList = new();
		strList.Add("1"); //T wird durch string ersetzt

        Console.WriteLine(list.Count); //effektiv array.Length, nicht Count() benutzen
		list[0] = 5; //Elemente beschreiben wie beim Array
		Console.WriteLine(list[0]); //Elemente auslesen wie beim Array

		foreach (int i in list)
		{
			Console.WriteLine(i);
		}

		list.Sort();

		//////////////////////////////////////////////////////////////////

		Stack<int> stack = new(); //Target-Typed New: Ergänzt den Typnamen von Links (Gegenstück zu var)
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);
		stack.Push(4);
		stack.Push(5); //Element oben auflegen

		stack.Peek(); //Oberstes Element anschauen

		stack.Pop(); //Oberstes Element anschauen und entfernen (5)

		Queue<int> queue = new();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);
		queue.Enqueue(5); //Element in die Reihe stellen

		queue.Peek(); //Vorderstes Element anschauen

		queue.Dequeue(); //Vorderstes Element anschauen und entfernen (1)

		//////////////////////////////////////////////////////////////////

		//Dictionary: Liste von Key-Value Paaren, wird für Zuordnungen verwendet
		//Schlüssel muss eindeutig sein
		//Hat 2 Generics (Schlüssel, Wert)
		Dictionary<string, int> einwohnerzahlen = new();
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //ArgumentException

		if (einwohnerzahlen.ContainsKey("Wien")) //Schauen ob der Schlüssel existiert
			Console.WriteLine(einwohnerzahlen["Wien"]); //Den Wert des Schlüssels holen

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var: Compiler ergänzt den Typen automatisch, Strg + . kann den Typen ergänzen
		{
            Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
        }

		einwohnerzahlen.Keys.ToList(); //Nur die Schlüssel holen
		einwohnerzahlen.Values.ToList(); //Nur die Werte holen
	}
}