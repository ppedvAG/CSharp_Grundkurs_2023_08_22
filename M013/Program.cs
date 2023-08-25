namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		//Unerwartete Feler abfangen mittels try-catch
		//Normalerweise stürzt das Programm ab wenn ein Fehler auftritt und nicht behandelt wird
		//Try-Catch
		//Im try Block steht der Code bei dem die Fehler behandelt werden sollen
		//In den Catch Blöchen die Fehler behandeln die auftreten können. Jeder Catch Block sollte eine bestimmte Exception behandeln.

		//Event: Statischer Punkt an den eine Funktion angehängt werden kann
		//Wenn das Event ausgelöst wird, wird die Funktion an dem Event ausgeführt
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

		//throw new Exception("Das ist ein Test");

		try //Codeblock markieren -> Rechtsklick -> Surround With -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> IOException, OutOfMemoryException, ArgumentOutOfRangeException
			int x = int.Parse(eingabe); //ArgumentNullException, OverflowException, FormatException
			if (x == 0)
				throw new TestException("Die Zahl ist 0", "Fehler"); //Mittels throw können beliebige Exceptions geworfen werden
		}
		catch (FormatException) //Hier wird die FormatException behandelt
		{
            Console.WriteLine("Keine Zahl eingegeben");
        }
		catch (OverflowException e) //Hier wird die OverflowException behandelt
		{
            Console.WriteLine("Zahl ist zu groß/klein");
            Console.WriteLine(e.Message); //Die C# interne Nachricht (Value was either too large or too small for an Int32.)
			Console.WriteLine(e.StackTrace); //Informationen zu dem Punkt wo die Exception aufgetreten ist (von unten nach oben lesen)
        }
		catch (TestException e)
		{
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Status);
        }
		catch (Exception) //Alle anderen Fehler fangen
		{
            Console.WriteLine("Anderer Fehler"); //Wird nur ausgeführt, wenn ein oberes Catch nicht ausgeführt wird (FormatException und OverflowException)

			//throw ohne Exception funktioniert in catch Blöcken und wirft die Exception weiter
			//Lässt das Programm trotz Fehlerbehandlung abstürzen
			//Bei fatalen Fehlern
			throw;
		}
		finally //Wird immer ausgeführt, egal ob ein Fehler passiert oder nicht
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		//Logging-Code
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Exception.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception
{
	public string Status { get; set; }

	public TestException(string? message, string status) : base(message)
	{
		Status = status;
	}
}