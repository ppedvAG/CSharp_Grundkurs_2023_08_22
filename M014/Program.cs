namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		//Action, Func: Benötigen anonyme Methoden, diese beginnen mit e =>
		//Falls irgendwo Action, Func, Predicate, ... fängt dieser Parameter mit e =>
		//List<int> ints;
		//ints.Where(e => ...);
		//ints.ForEach(e => ...);
		//ints.Find(e => ...);

		//Event: Statischer Punkt an den eine Funktion angehängt werden kann
		//Wenn das Event ausgelöst wird, wird die Funktion an dem Event ausgeführt
		Component comp = new Component(); //Zweigeteilter Aufbau: Entwickler der Komponente legt Schnittstellen fest, die der Benutzer selbst mit Funktionen ausstatten kann
		comp.StartProcess += Comp_StartProcess; //Hier kann der Endnutzer ein eigenes Verhalten für das Event definieren
		comp.Progress += Comp_Progress;
		comp.Run();
	}

	private static void Comp_StartProcess()
	{
		//Hier kann der Entwickler der die Komponente verwendet selbst festlegen was diese tut
        Console.WriteLine("Komponente gestartet");
    }

	private static void Comp_Progress()
	{
        Console.WriteLine("Fortschritt");
    }
}

public class Component
{
	public event Action StartProcess;

	public event Action Progress;

	public void Run()
	{
		StartProcess?.Invoke();
		for (int i = 0; i < 10; i++)
		{
			Progress?.Invoke();
			Thread.Sleep(200);
		}
	}
}