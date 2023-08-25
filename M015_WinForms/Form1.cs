namespace M015_WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Size = new Size(Random.Shared.Next(300, 600), Random.Shared.Next(300, 600));
		}
	}
}