namespace T9 {
	internal class Program {
		static void Main(string[] args) {
			T9 t9 = new();
			Console.WriteLine(t9.ToNumber('q'));
			Console.WriteLine(t9.ToNumber('w'));
			Console.WriteLine(t9.ToNumber('A'));
			Console.WriteLine(t9.ToNumber('ö'));

			Console.WriteLine(t9.KeyIndex(1));
			Console.WriteLine(t9.KeyIndex(2));
			Console.WriteLine(t9.KeyIndex(3));
			Console.WriteLine(t9.KeyIndex(4));
			Console.WriteLine(t9.KeyIndex(5));

			Console.WriteLine(t9.WordToNumbers("Hello"));
		}
	}
}
