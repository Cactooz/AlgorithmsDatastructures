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
		private Node words = new();

		/// <summary>
		/// Constructor for <see cref="T9"/>. Puts A-Ö excluding Q and W into <see cref="chars"/> array.
		/// </summary>
		/// <param name="filepath">The file path to the dictionary file as a <see cref="string"/>.</param>
		public T9(string filepath) {
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


			//Read all words from the dictionary and add all words
			using(StreamReader reader = new StreamReader(filepath)) {
				string line;

				//Read each line (word) from the file
				while((line = reader.ReadLine()) != null)
					AddWord(line);
			}

		}

		/// <summary>
		/// Add word into the <see cref="words"/> <see cref="Node"/> <see cref="Array"/>.
		/// </summary>
		/// <param name="word">The word that should be added.</param>
		private void AddWord(string word) {
			Node pointer = words;

			//Check each character of the word
			foreach(char c in word) {
				//Get the index of the character
				int index = CharToNumber(c);
				
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
		/// Checks if a word exist in the inputted <see cref="words"/> <see cref="Node"/> <see cref="Array"/>.
		/// </summary>
		/// <param name="word">The word look for.</param>
		/// <returns><see cref="bool"/> if the word exist or not.</returns>
		public bool CheckWord(string word) {
			Node pointer = words;

			//Check each character of the word
			foreach(char c in word) {
				int index = CharToNumber(c);

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
		/// Convert the inputted <paramref name="character"/> into a <see cref="int"/>.
		/// Works with both upper and lowercase chars.
		/// </summary>
		/// <param name="character">The <see cref="char"/> to convert to <see cref="int"/>.</param>
		/// <returns><see cref="int"/> value of the inputted <paramref name="character"/>.</returns>
		public int CharToNumber(char character) {
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
			return -1;
		}

		public int WordToNumbers(string word) {
			string number = "";
			foreach(char c in word)
				number += (CharToNumber(c) / 3) + 1;
			
			return int.Parse(number);
		}

	}
}
