using System.Linq;

namespace M006.Data
{
	internal class Kurs
	{
		public string Kursname { get; private set; }

		public Standort Ort { get; set; }

		public Person[] Teilnehmer;

		public Kurs(string kursname, Standort ort, params Person[] tn)
		{
			Kursname = kursname;
			Ort = ort;
			Teilnehmer = new Person[tn.Length];
			for (int i = 0; i < tn.Length; i++)
			{
				Teilnehmer[i] = tn[i];
			}
		}

		public void TeilnehmerHinzufuegen(params Person[] tn)
		{
			Teilnehmer = Teilnehmer.Concat(tn).ToArray();
		}
	}

	public enum Standort { Präsenz, Virtuell, Gemischt }
}
