//https://www.tausquared.net/pages/ctf/rsa.html

char[] alphavitM = new char[35] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', ',', ' ' };

int[] openKey  = new int[2] { 341, 2021};
int[] closeKey = new int[2] {  17, 2021};

int[] openKeyT  = new int[2] {  5, 21 };
int[] closeKeyT = new int[2] { 17, 21 };

Console.Write("Входные данные:");
string text = Console.ReadLine();

//kek(alphavitM, openKeyT, closeKeyT, text);
kek(alphavitM, openKey, closeKey, text);

void kek(char[] alphavit, int[] open, int[] close, string input)
{
    List<int> crypted = new List<int>();
    foreach (char c in input)
    {
        for (int i = 0; i < alphavit.Length; i++)
        {
            if (alphavit[i] == c)
            {
                int r = 1; // Результат
                i %= open[1];
                for (int j = 1; j <= open[0]; j++)
                    r = (r * i) % open[1];
                crypted.Add(r);
                break;
            }
        }
    }

    #region Вывод шифрованного сообщения
    Console.Write("Шифрованное: ");
    foreach (int j in crypted)
    {
        Console.Write(j.ToString() + " ");
    }
    #endregion

    List<int> decryped = new List<int>();
    foreach (int c in crypted)
    {
        int r = 1; // Результат
        for (int i = 1; i <= close[0]; i++)
            r = (r * c % close[1]) % close[1];
        decryped.Add(r);
    }

    #region Вывод сырого дешифрованного сообщения
    Console.Write("\nДешифрованное: ");
    foreach (int j in decryped)
    {
        Console.Write(j.ToString() + " ");
    }
    #endregion

    string output = "";
    foreach (int c in decryped)
    {
        output += alphavit[c];
    }
    Console.WriteLine("\nДешифрованное: " + output);
}
