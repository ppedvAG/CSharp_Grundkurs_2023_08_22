using M013;

namespace M013_Tests;

[TestClass]
public class RechnerTests
{
	//Unit Tests: Tests die regelmäßig den Code testen
	//Bei Änderungen im Code können Tests fehlschlagen -> Bug

	//Dependencies: Referenzen zu anderen Projekten herstellen, um Code hierher zu importieren
	//Solution Explorer -> Dependencies -> Add Project Reference -> Projekt(e) auswählen (Haken setzen) -> OK

	//Test Explorer: View -> Test Explorer
	//Testing UI

	Rechner r;

	[TestInitialize]
	public void Init()
	{
		r = new();
	}

	[TestCleanup]
	public void Cleanup()
	{
		r = null;
	}

	[TestMethod]
	[TestCategory("AddiereTest")]
	public void TesteAddiere()
	{
		double x = r.Addiere(3, 4);

		//Assert-Klasse: Gibt die Möglichkeit, einen Testfall abzuschließen
		//Notwendig in Unit Testing
		Assert.AreEqual(7, x);
	}

	[TestMethod]
	[TestCategory("SubtrahiereTest")]
	public void TesteSubtrahiere()
	{
		double x = r.Subtrahiere(3, 4);

		//Assert-Klasse: Gibt die Möglichkeit, einen Testfall abzuschließen
		//Notwendig in Unit Testing
		Assert.AreEqual(-1, x);
	}
}