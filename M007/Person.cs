namespace M007
{
	internal class Person
	{
		#region Variable
		private string vorname; //Feld ist privat, damit der Benutzer der Klasse keinen Unsinn in das Feld schreiben kann

		/// <summary>
		/// Gibt den Vornamen der Person zurück.</br>
		/// Get-Methoden geben das Feld dahinter zurück, und haben generell keine Parameter.
		/// </summary>
		/// <returns>Der Vorname der Person</returns>
		public string GetVorname()
		{
			return vorname;
		}

		/// <summary>
		/// Setzt den neuen Vornamen für diese Person.</br>
		/// Set-Methoden sind generell void und haben einen Parameter.</br>
		/// Über die Set-Methode kann ein neuer Wert in das Feld geschrieben werden, und zusätzlich kann davor eine Überprüfung gemacht werden.
		/// </summary>
		/// <param name="neuerVorname">Der neue Vorname der Person</param>
		public void SetVorname(string neuerVorname)
		{
			if (neuerVorname.All(char.IsLetter) && neuerVorname.Length >= 2 && neuerVorname.Length <= 15)
				vorname = neuerVorname;
			else
                Console.WriteLine("Neuer Vorname ist ungültig");
        }
		#endregion

		#region Property
		private string nachname;

		/// <summary>
		/// Dieses Property (Eigenschaft) repräsentiert die Get- und Set-Methoden von oben (Vorname).
		/// </summary>
		public string Nachname
		{
			get //äquivalent zu getvorname()
			{
				return nachname;
			}
			set //Äquivalent zu SetVorname(string)
			{
				//value: Der Parameter der Set-Methode
				if (value.All(char.IsLetter) && value.Length >= 2 && value.Length <= 15)
					nachname = value;
				else
					Console.WriteLine("Neuer Nachname ist ungültig");
			}
		}

		/// <summary>
		/// Get-Only Property: Kann nicht gesetzt werden
		/// </summary>
		public string VollerName
		{
			get
			{
				return vorname + " " + nachname;
			}
			//set weglassen, macht keinen Sinn für einen vollen Namen (weil zusammengesetzt aus Vor- und Nachname)
		}

		public string VollerName2
		{
			get => vorname + " " + nachname; //Kürzere Form von oben, return fällt weg
		}

		public string VollerName3 => vorname + " " + nachname; //Kürzeste Form von oben, get und return fallen weg

		public int Alter { get; set; } //Auto-Property -> Kein Unterschied zu: public int Alter;

		public decimal Gehalt { get; private set; } //Gehalt soll nur von hier innerhalb der Klasse gesetzt werden können

		//prop
		//propa
		//propfull

		private Rolle rolle = Rolle.Teilnehmer;

		public Rolle Rolle
		{
			get => rolle;
			private set
			{
				rolle = value;
			}
		}
        #endregion

        #region Konstruktor

        public Person()
		{
            Console.WriteLine("Person wurde erstellt");
        }

        /// <summary>
        /// Konstruktor: Code der bei Erstellung des Objekts ausgeführt wird</br>
        /// Hier sollten Standardwerte gesetzt werden (über Parameter)</br>
        /// </summary>
        public Person(string vorname, string nachname) : this()
		{
			this.vorname = vorname; //this: Greife aus der Methode/dem Konstruktor heraus (nach oben)
			this.nachname = nachname;
		}

		/// <summary>
		/// Konstruktoren verketten (this): Bei Verwendung dieses Konstruktors wird auch der obere Konstruktor verwendet
		/// </summary>
		public Person(string vorname, string nachname, int alter, decimal gehalt) : this(vorname, nachname)
		{
			Alter = alter;
			Gehalt = gehalt;
		}

		public Person(string vorname, string nachname, int alter, decimal gehalt, Rolle rolle) : this(vorname, nachname, alter, gehalt)
		{
			Rolle = rolle;
		}
		#endregion

		/// <summary>
		/// Destruktor: Wird aufgerufen, wenn das Objekt vom GC eingesammelt wird
		/// </summary>
		~Person()
		{
			//GetHashCode(): Gibt die Speicheradresse des Objekts zurück, wird für Vergleiche verwendet
            Console.WriteLine($"Person wurde eingesammelt {GetHashCode()}");
        }

		public static void PrintEtwas()
		{
            //Console.WriteLine(vorname); //Hier auch kein Zugriff auf Vorname möglich
            Console.WriteLine("Etwas");
        }
	}

	enum Rolle { Trainer, Teilnehmer, Organisator }
}
