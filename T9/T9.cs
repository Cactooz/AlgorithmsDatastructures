namespace T9 {
	internal class T9 {
		private class Node {
			private Node[] next;
			private bool word;

			public Node() {
				next = new Node[27];
				word = false;
			}

			public Node[] Next { get => next; set => next = value; }
			public bool Word { get => word; set => word = value; }

		}

		private char[] chars = new char[27];

		/// <summary>
		/// Constructor for <see cref="T9"/>. Puts A-Ö excluding Q and W into <see cref="chars"/> array.
		/// </summary>
		public T9() {
			int j = 0;
			//Fill the chars array with all the characters
			for(int i = 0; i < 24; i++) {
				//Skip Q and W
				if(i == 16 || i == 21)
					j++;

				chars[i] = (char)(97 + j++);
			}
			chars[24] = 'å';
			chars[25] = 'ä';
			chars[26] = 'ö';

		}

		/// <summary>
		/// Convert the inputted <paramref name="character"/> into a <see cref="int"/>.
		/// Works with both upper and lowercase chars.
		/// </summary>
		/// <param name="character">The <see cref="char"/> to convert to <see cref="int"/>.</param>
		/// <returns><see cref="int"/> value of the inputted <paramref name="character"/>.</returns>
		public int? ToNumber(char character) {
			//Make sure the inputted character is uppercase
			character = char.ToLower(character);

			int pos;

			//Get the position in the array of the char
			if(character.CompareTo('p') <= 0)
				pos = character - 97;
			//Get special positions for chars after Q
			else if(character.CompareTo('v') <= 0)
				pos = character - 98;
			//Get special positions for chars after W
			else if(character.CompareTo('z') <= 0)
				pos = character - 99;
			else
				//Move position into end of array for ÅÄÖ
				pos = 24;

			//Loop through and find the correct index of the char
			for(int i = pos; i < 27; i++) {
				if(chars[i].Equals(character))
					return i;
			}

			//If not found return null
			return null;
		} 

		public int WordToNumbers(string word) {
			string number = "";
			foreach(char c in word)
				number += (ToNumber(c) / 3) + 1;

			return int.Parse(number);
		}

	}
}
