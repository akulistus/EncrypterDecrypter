using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterDecrypter.Services
{
    public class EncrypterDecrypterService
    {
        private static char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь',
                                                'Э', 'Ю', 'Я',};

        private static int N = characters.Length;

        public string DecryptData(string input, string keyword)
        {

            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                if (characters.Contains(symbol))
                {
                    int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                    result += characters[p];

                    keyword_index++;

                    if (keyword_index == keyword.Length)
                        keyword_index = 0;
                }
                else
                {
                    result += symbol;
                }
            }

            return result;
        }

        public string EncryptData(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                if (characters.Contains(symbol))
                {
                    int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                    result += characters[c];

                    keyword_index++;

                    if (keyword_index == keyword.Length)
                        keyword_index = 0;
                }
                else
                {
                    result += symbol;
                }

            }

            return result;
        }
    }
}
