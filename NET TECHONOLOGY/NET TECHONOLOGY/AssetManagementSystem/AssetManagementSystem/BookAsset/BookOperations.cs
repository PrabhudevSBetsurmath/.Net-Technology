using System;
using System.Collections.Generic;
namespace AssetManagementSystem
{
    public class BookAsset
    {
                List<BookProperties> bookList = new List<BookProperties>(4);
        public void AddingBook()
        {
            Console.WriteLine("ENTER THE NUMBER OF BOOK TO BE ADDED");
            int addBook = int.Parse(Console.ReadLine());
            for (int i = 0; i < addBook; i++)
            {
                BookProperties bookComp = new BookProperties();
                Console.WriteLine("ENTER THE SERIAL NUMBER OF THE BOOK");
                bookComp.serialNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("ENTER THE NAME OF THE BOOK");
                bookComp.name = (Console.ReadLine());
                Console.WriteLine("ENTER THE AUTHOR OF THE BOOK");
                bookComp.author = (Console.ReadLine());
                Console.WriteLine("ENTER THE DATE OF PUBLISH OF THE BOOK");
                bookComp.dateOfPublish =Convert.ToDateTime(Console.ReadLine());
                bookList.Add(bookComp);
            }
            Console.WriteLine("\t\t\t\t ADDED SUCCESFULLY!!");
        }
        public void DisplayTheBook()
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool testSerialNumber = false;
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].serialNumber == 0 || bookList[i].name==string.Empty||bookList[i].author==string.Empty)
                    {
                        testSerialNumber = true;
                    }
                }
                if (testSerialNumber)
                {
                    Console.WriteLine("\t\t\t\t\t\t PLEASE ENTER SERIAL NUMBER GREATER THEN ZERO AND DO NOT LEAVE THE OTHER FIELDS EMPTY");
                }
                else
                {
                    Console.WriteLine("Serial Number \t \t Name \t \t Author \t \t Date of publish");
                    foreach (BookProperties obj in bookList)
                    {
                        Console.WriteLine(obj.serialNumber + "\t \t \t" + obj.name + "\t \t \t" + obj.author + "\t \t \t" + obj.dateOfPublish.ToString("dd/MM/yyyy"));
                    }
                }
            }
        }
        public void DeleteTheBook()
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                Console.WriteLine("ENTER THE SERIAL NUMBER OF THE BOOK TO BE DELETED");
                int bookToBeDeleted = int.Parse(Console.ReadLine());
                bool checkForBookDelete = false;
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookToBeDeleted == bookList[i].serialNumber)
                    {
                        bookList.RemoveAt(i);
                        checkForBookDelete = true;
                    }

                }
                if (checkForBookDelete == true)
                {
                    Console.WriteLine("THE SERIAL NUMBER YOU HAVE ENTERED IS DELETED SUCESSFULLY");
                }
                else
                {
                    Console.WriteLine("THE SERIAL NUMBER YOU HAVE ENTERED IS NOT PRESENT IN THE LIST ASSET ");
                }
            }

        }

        public void SearchBook()
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool bookAvailable = false;
                Console.WriteLine("ENTER THE BOOK TO BE SEARCHED");
                string bookToBeSearched = Console.ReadLine();
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookToBeSearched == bookList[i].name)
                    {
                        Console.WriteLine("Serial Number \t \t Name \t \t Author \t \t Date of publish");
                        Console.WriteLine(bookList[i].serialNumber + "\t \t \t" + bookList[i].name + "\t \t \t" + bookList[i].author + "\t \t \t" + bookList[i].dateOfPublish.ToString("dd/MM/yyyy"));
                        bookAvailable = true;
                    }
                }
                if (bookAvailable == false)
                {
                    Console.WriteLine("THE BOOK NAME WHICH YOU HAVE ENETERED IS NOT PRESENT TO SEARCH");

                }
            }
        }
        public void UpdateBook()
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool test=false;
                DisplayTheBook();
                Console.WriteLine("Enter THE NAME FROM OBSERVING ABOVE LIST TO BE UPDATED");
                string bookName = (Console.ReadLine());
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].name == bookName)
                    {
                        test = true;
                    }
                }
                if (test==false)
                {
                    Console.WriteLine("BOOK NOT FOUND");
                    Console.WriteLine();
                }
                while (test==true)
                {
                    Console.WriteLine($"DO YOU WANT UPDATE ATLEAST ONE ITEM IN \"{bookName}\"ENTER 1  OR TO EXIT PRESS 2");
                    int choice = int.Parse(Console.ReadLine());
                    if(choice == 1)
                    {
                        Console.WriteLine("1 DO YOU WANT TO SERIAL NUMBER?");
                        Console.WriteLine("2 DO YOU WANT TO UPDATE NAME?");
                        Console.WriteLine("3 DO YOU WANT TO UPDATE AUTHOR?");
                        Console.WriteLine("4 DO YOU WANT TO UPDATE DATE OF PUBLISH?");
                        Console.WriteLine("5 DO YOU WANT TO UPDATE WHOLE LIST?");
                        int choiceForBook = int.Parse(Console.ReadLine());
                        for (int i = 0; i < bookList.Count; i++)
                        {
                            switch (choiceForBook)
                            {
                                case 1:
                                    if (bookList[i].name == bookName)
                                    {
                                        Console.WriteLine(" ENTER THE SERIAL NUMBER TO BE UPDATED");
                                        bookList[i].serialNumber = int.Parse(Console.ReadLine());
                                        DisplayTheBook();
                                    }
                                    break;
                                case 2:
                                    if (bookList[i].name == bookName)
                                    {
                                        Console.WriteLine(" ENTER THE NAME TO BE UPDATED");
                                        bookList[i].name = Console.ReadLine();
                                        DisplayTheBook();
                                    }
                                    break;
                                case 3:
                                    if (bookList[i].name == bookName)
                                    {
                                        Console.WriteLine(" ENTER THE AUTHOR TO BE UPDATED");
                                        bookList[i].author = Console.ReadLine();
                                        DisplayTheBook();
                                    }
                                    break;
                                case 4:
                                    if (bookList[i].name == bookName)
                                    {
                                        Console.WriteLine(" ENTER THE DATE OF PUBLISH TO BE UPDATED");
                                        bookList[i].dateOfPublish =Convert.ToDateTime( Console.ReadLine());
                                        DisplayTheBook();
                                    }
                                    break;
                                case 5:
                                    if (bookList[i].name == bookName)
                                    {
                                        Console.WriteLine("ENTER THE NAME WHICH YOU WANT UPDATE");
                                        bookList[i].name = Console.ReadLine();
                                        Console.WriteLine("ENTER THE SERIAL NUMBER WHICH YOU WANT UPDATE");
                                        bookList[i].serialNumber = int.Parse(Console.ReadLine());
                                        Console.WriteLine("ENTER THE  DATE OF EXPIRY WHICH YOU WANT UPDATE");
                                        bookList[i].author = Console.ReadLine();
                                        Console.WriteLine("ENTER THE DATE OF PUBLISH WHICH YOU WANT UPDATE");
                                        bookList[i].dateOfPublish =Convert.ToDateTime( Console.ReadLine());
                                        DisplayTheBook();
                                    }
                                    break;

                                default:
                                    Console.WriteLine("CHOOSE CORRECT OPTION");
                                    break;

                            }
                        }

                    }else if (choice==2)
                    {
                        ChooseoptionForBookAsset();
                    }

                }

            }
        }

            public void ChooseoptionForBookAsset()
            {
                Console.WriteLine("1 Add an Book");
                Console.WriteLine("2 Search an Book");
                Console.WriteLine("3 Update an Book");
                Console.WriteLine("4 Delete an Book");
                Console.WriteLine("5 List of all available Books");
                Console.WriteLine("6 Exit");
                Console.WriteLine("####################################################");
                Console.WriteLine("ENTER YOUR CHOICE:");
                int chooseOfOperation = int.Parse(Console.ReadLine());
                if (chooseOfOperation == 1)
                {

                    AddingBook();
                    ChooseoptionForBookAsset();
                }
                else if (chooseOfOperation == 2)
                {
                    SearchBook();
                    ChooseoptionForBookAsset();
                }
                else if (chooseOfOperation == 3)
                {
                    UpdateBook();
                    ChooseoptionForBookAsset();
                }
                else if (chooseOfOperation == 4)
                {
                    DeleteTheBook();
                    ChooseoptionForBookAsset();
                }
                else if (chooseOfOperation == 5)
                {
                    DisplayTheBook();
                    ChooseoptionForBookAsset();
                }
                else if (chooseOfOperation == 6)
                {
                    Program.ChooseAsset();

                }
            }

        
    }
}
