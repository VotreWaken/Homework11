using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserMenu UserMenu = new UserMenu();
            while (true)
            {
                Console.WriteLine("1. Add Word");
                Console.WriteLine("2. Delete Word");
                Console.WriteLine("3. Delete Translate");
                Console.WriteLine("4. Change Word");
                Console.WriteLine("5. Change Translate");
                Console.WriteLine("6. Search Translate Word");
                Console.WriteLine("7. Exit");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        UserMenu.AddWord();
                        break;
                    case 2:
                        UserMenu.DeleteWord();

                        break;
                    case 3:
                        UserMenu.DeleteTranslate();

                        break;
                    case 4:
                        UserMenu.ChangeWord();

                        break;
                    case 5:
                        UserMenu.ChangeTranslate();

                        break;
                    case 6:
                        UserMenu.SearchWord();

                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
                Console.WriteLine();
            }
        }

        class UserMenu
        {
            Translator translator = new Translator();

            public void AddWord()
            {
                Console.Write("Enter English Word: ");
                string englishWord = Console.ReadLine();
                Console.Write("Enter Translate Options Splitting By ' ' : ");
                string translationsInput = Console.ReadLine();
                List<string> translations = translationsInput.Split(' ').Select(t => t.Trim()).ToList();
                translator.AddWord(englishWord, translations);
            }

            public void DeleteWord()
            {
                Console.Write("Enter English Word To Delete: ");
                string wordToRemove = Console.ReadLine();
                translator.RemoveWord(wordToRemove);
            }

            public void DeleteTranslate()
            {
                Console.Write("Enter English Word: ");
                string wordForTranslationRemoval = Console.ReadLine();
                Console.Write("Enter Translate Word To Delete: ");
                string translationToRemove = Console.ReadLine();
                translator.RemoveTranslation(wordForTranslationRemoval, translationToRemove);
            }

            public void ChangeWord()
            {
                Console.Write("Enter English Word To Change: ");
                string wordToUpdate = Console.ReadLine();
                Console.Write("Enter New English Word: ");
                string newWord = Console.ReadLine();
                translator.UpdateWord(wordToUpdate, newWord);
            }

            public void ChangeTranslate()
            {
                Console.Write("Enter English Word: ");
                string wordForTranslationUpdate = Console.ReadLine();
                Console.Write("Enter Old Translate Word: ");
                string oldTranslation = Console.ReadLine();
                Console.Write("Enter New Translate Word: ");
                string newTranslation = Console.ReadLine();
                translator.UpdateTranslation(wordForTranslationUpdate, oldTranslation, newTranslation);
            }
            public void SearchWord()
            {
                Console.Write("Enter English Word To Search: ");
                string wordToSearch = Console.ReadLine();
                translator.SearchTranslation(wordToSearch);
            }
        }
        class Translator
        {
            private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            public void AddWord(string englishWord, List<string> frenchTranslations)
            {
                if (!dictionary.ContainsKey(englishWord))
                {
                    dictionary[englishWord] = frenchTranslations;
                }
                else
                {
                    Console.WriteLine("Word has Already");
                }
            }
            public void RemoveWord(string englishWord)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    dictionary.Remove(englishWord);
                }
                else
                {
                    Console.WriteLine("Word Not Found");
                }
            }
            public void RemoveTranslation(string englishWord, string frenchTranslation)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    if (dictionary[englishWord].Contains(frenchTranslation))
                    {
                        dictionary[englishWord].Remove(frenchTranslation);
                    }
                    else
                    {
                        Console.WriteLine("Word Translate Not Found");
                    }
                }
                else
                {
                    Console.WriteLine("Word Not Found");
                }
            }
            public void UpdateWord(string englishWord, string newEnglishWord)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    List<string> translations = dictionary[englishWord];
                    dictionary.Remove(englishWord);
                    dictionary[newEnglishWord] = translations;
                }
                else
                {
                    Console.WriteLine("Word Not Found");
                }
            }
            public void UpdateTranslation(string englishWord, string oldFrenchTranslation, string newFrenchTranslation)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    List<string> translations = dictionary[englishWord];
                    if (translations.Contains(oldFrenchTranslation))
                    {
                        translations.Remove(oldFrenchTranslation);
                        translations.Add(newFrenchTranslation);
                    }
                    else
                    {
                        Console.WriteLine("Word Translate Not Found");
                    }
                }
                else
                {
                    Console.WriteLine("Word Not Found");
                }
            }
            public void SearchTranslation(string englishWord)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    List<string> translations = dictionary[englishWord];
                    Console.WriteLine($"Translate: '{englishWord}':");
                    foreach (string translation in translations)
                    {
                        Console.WriteLine(translation);
                    }
                }
                else
                {
                    Console.WriteLine("Word Not Found");
                }
            }
        }
    }
}
