namespace M006.Data
{
	internal class Kurs
	{
		public Person[] Teilnehmer;

		public Standort Ort;

		public Kurs(Standort ort, params Person[] tn)
		{
			Ort = ort;
			Teilnehmer = new Person[tn.Length];
			for (int i = 0; i < tn.Length; i++)
			{
				Teilnehmer[i] = tn[i];
			}
		}
	}

	public enum Standort
	{
		Präsenz,
		Virtuell,
		Gemischt
	}
}
