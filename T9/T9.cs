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

		/// <summary>
		/// The root <see cref="Node"/> to all possible inputted words.
		/// </summary>
		private Node words = new();

		/// <summary>
		/// Constructor for <see cref="T9"/>. Reads all words from the inputted file and adds it into the <see cref="words"/> <see cref="Array"/>.
		/// </summary>
		/// <param name="filepath">The file path to the dictionary file as a <see cref="string"/>.</param>
		public T9(string filepath) {
			//Read all words from the dictionary and add all words
			using(StreamReader reader = new StreamReader(filepath)) {
				string line;

				//Read each line (word) from the file and add it to the trie
				while((line = reader.ReadLine()) != null)
					AddWord(line);
			}

		}

		/// <summary>
		/// Add a word into the <see cref="words"/> <see cref="Node"/> <see cref="Array"/>.
		/// </summary>
		/// <param name="word">The word that should be added.</param>
		private void AddWord(string word) {
			Node pointer = words;

			//Check each character of the word
			foreach(char c in word) {
				//Get the index of the character
				int index = (int)CharToNumber(c);
				
				//Check if there are no next character array and add a new
				if(pointer.Next[index] == null)
					pointer.Next[index] = new();

				//Go to the next characters 
				pointer = pointer.Next[index];
			}
			//Mark the node as an end of a word
			pointer.Word = true;
		}

		/// <summary>
		/// Check if a word exist in the inputted <see cref="words"/> <see cref="Node"/> <see cref="Array"/>.
		/// </summary>
		/// <param name="word">The word look for.</param>
		/// <returns><see cref="bool"/> if the word exist or not.</returns>
		public bool CheckWord(string word) {
			Node pointer = words;

			//Check each character of the word
			foreach(char c in word) {
				int index = (int)CharToNumber(c);

				//Go forward if the character exists
				if(pointer.Next[index] != null)
					pointer = pointer.Next[index];
				else
					return false;
			}
			//Return if a word is found
			return pointer.Word;
		}

		/// <summary>
		/// Convert a inputted key <see cref="char"/> 1-9 into <see cref="int"/>.
		/// </summary>
		/// <param name="character">The <see cref="char"/> to convert into an <see cref="int"/>.</param>
		/// <returns>The <paramref name="character"/> as an <see cref="int"/>.</returns>
		public int KeyToNumber(char character) {
			if(character > '0' &&  character <= '9')
				return character - 49;

			return -1;
		}

		/// <summary>
		/// Convert the inputted <paramref name="character"/> into a <see cref="int"/>.
		/// Works with both upper and lowercase chars.
		/// </summary>
		/// <param name="character">The <see cref="char"/> to convert to <see cref="int"/>.</param>
		/// <returns><see cref="int"/> value of the inputted <paramref name="character"/>.</returns>
		public int? CharToNumber(char character) {
			//Make sure the inputted character is uppercase
			character = char.ToLower(character);

			//Get the position in the array of the char
			if(character.CompareTo('p') <= 0)
				return character - 97;
			//Get special positions for chars after Q
			if(character.CompareTo('v') <= 0)
				return character - 98;
			//Get special positions for chars after W
			if(character.CompareTo('z') <= 0)
				return character - 99;
			if(character.CompareTo('å') == 0)
				return 24;
			if(character.CompareTo('ä') == 0)
				return 25;
			if(character.CompareTo('ö') == 0)
				return 26;

			//If not found return null
			return null;
			}

		/// <summary>
		/// Convert a number between 0 to 26 into a lowercase <see cref="char"/>.
		/// </summary>
		/// <param name="number">The number to convert into a <see cref="char"/>.</param>
		/// <returns>The <see cref="char"/> of the given <paramref name="number"/>.</returns>
		public char? NumberToChar(int number) {
			if(number < 0 || number >= 27)
				return null;

			//Get the position in the array of the char
			if(number <= 15)
				return (char?)((char?)number + 97);
			//Get special positions for chars after Q
			if(number <= 20)
				return (char?)((char?)number + 98);
			//Get special positions for chars after W
			if(number <= 23)
				return (char?)((char?)number + 99);
			if(number == 24)
				return 'å';
			if(number == 25)
				return 'ä';
			if(number == 26)
				return 'ö';

			//If not found return null
			return null;
		}

		public int WordToNumbers(string word) {
			string number = "";
			foreach(char c in word)
				number += (CharToNumber(c) / 3) + 1;
			
			return int.Parse(number);
		}

	}
}
