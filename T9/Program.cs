namespace T9 {
	internal class Program {
		static void Main(string[] args) {
			T9 t9 = new();
			Console.WriteLine(t9.ToNumber('q'));
			Console.WriteLine(t9.ToNumber('w'));
			Console.WriteLine(t9.ToNumber('A'));
			Console.WriteLine(t9.ToNumber('ö'));
		}
	}
}
