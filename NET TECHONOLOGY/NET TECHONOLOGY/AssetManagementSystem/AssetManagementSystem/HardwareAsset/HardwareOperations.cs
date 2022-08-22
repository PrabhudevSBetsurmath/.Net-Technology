using System;
using System.Collections.Generic;

namespace AssetManagementSystem
{
 public class HardwareAsset
    {
         List<HardwareProperties> hardwareList = new List<HardwareProperties>(4);
        public  void AddingHardware()
        {
           
            Console.WriteLine("ENTER THE NUMBER OF  HARDWARE TO BE ADDED");
            int addHardware = int.Parse(Console.ReadLine());
            for (int i = 0; i < addHardware; i++)
            {
                HardwareProperties hardwareComp = new HardwareProperties();
                Console.WriteLine("ENTER THE SERIAL NUMBER OF THE  HARDWARE");
                hardwareComp.serialNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("ENTER THE NAME OF THE  HARDWARE");
                hardwareComp.name = (Console.ReadLine());
                Console.WriteLine("ENTER THE AMOUNT OF THE  HARDWARE");
                hardwareComp.amount = int.Parse(Console.ReadLine());
                Console.WriteLine("ENTER THE INSTALLATION DATE OF THE  HARDWARE");
                hardwareComp.installationDate = Convert.ToDateTime(Console.ReadLine());
                hardwareList.Add(hardwareComp);
            }
            Console.WriteLine("\t\t\t\t ADDED SUCCESFULLY!!");

        }
        public void DisplayTheHardware()
        {
            if (hardwareList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool testSerialNumber = false;
                for (int i = 0; i < hardwareList.Count; i++)
                {
                    if (hardwareList[i].serialNumber == 0 || hardwareList[i].amount == 0|| hardwareList[i].name ==string.Empty )
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
                    Console.WriteLine("Serial Number \t \t Name \t \t Installation Date \t \t Amount");
                    foreach (HardwareProperties obj in hardwareList)
                    {
                        Console.WriteLine(obj.serialNumber + "\t \t \t" + obj.name + "\t \t \t" + obj.installationDate.ToString("dd/MM/yyyy") + "\t \t \t" + obj.amount);

                    }
                }
            }

        }
        public void DeleteTheHardware()
        {
            if (hardwareList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                Console.WriteLine("ENTER THE HARDWARE NAME TO BE DELETED");
                int hardwareToBeDeleted =int.Parse(Console.ReadLine());
                bool checkForHardwareDelete = false;
                for (int i = 0; i < hardwareList.Count; i++)
                {
                    if (hardwareToBeDeleted == hardwareList[i].serialNumber)
                    {
                        hardwareList.RemoveAt(i);
                        checkForHardwareDelete = true;
                    }
                    
                }
                if (checkForHardwareDelete == true)
                {
                    Console.WriteLine("THE  HARDWARE NAME YOU HAVE ENTERED IS DELETED SUCESSFULLY");
                }
              else 
                {
                    Console.WriteLine("THE  HARDWARE NAME YOU HAVE ENTERED IS NOT PRESENT IN THE LIST ASSET ");
                }
            }

        }
        public void SearchHardware()
        {
            if (hardwareList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                 bool hardwareAvailable = false;

                Console.WriteLine("ENTER THE  HARDWARE NAME TO BE SEARCHED");
                string hardwareToBeSearched = Console.ReadLine();
                for (int i = 0; i < hardwareList.Count; i++)
                {
                    if (hardwareToBeSearched == hardwareList[i].name)
                    {
                        Console.WriteLine("Serial Number \t \t Name \t \t Installation Date \t \t Amount");
                        Console.WriteLine(hardwareList[i].serialNumber + "\t \t \t" + hardwareList[i].name + "\t \t \t" + hardwareList[i].installationDate.ToString("dd/MM/yyyy") + "\t \t \t" + hardwareList[i].amount);
                        hardwareAvailable = true;

                    }
                }
                if (hardwareAvailable == false)
                {
                    Console.WriteLine("THE HARDWARE NAME WHICH YOU HAVE ENETERED IS NOT PRESENT TO SEARCH");
                }
                
            }
        }
        public void UpdateHardware()
        {
            if ( hardwareList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool test = false;
                 DisplayTheHardware();
                Console.WriteLine("Enter THE NAME FROM OBSERVING ABOVE LIST TO BE UPDATED");
                string  hardwareName = (Console.ReadLine());
                for (int i = 0; i <  hardwareList.Count; i++)
                {
                    if (hardwareList[i].name ==  hardwareName)
                    {
                        test = true;
                    }
                }
                if (test == false)
                {
                    Console.WriteLine("SOFTWARE NOT FOUND");
                    Console.WriteLine();
                }
                while (test == true)
                {
                    Console.WriteLine($"DO YOU WANT UPDATE ATLEAST ONE ITEM IN \"{hardwareName}\"ENTER 1 OR TO EXIT PRESS 2");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("1.DO YOU WANT TO UPDATE SERIAL NUMBER?");
                        Console.WriteLine("2 DO YOU WANT TO UPDATE NAME?");
                        Console.WriteLine("3 DO YOU WANT TO UPDATE AMOUNT?");
                        Console.WriteLine("4 DO YOU WANT UPDATE INSTALLATION DATE?");
                        Console.WriteLine("5 DO YOU WANT UPDATE WHOLE LIST?");
                        int choiceForHardware = int.Parse(Console.ReadLine());
                        for (int i = 0; i <  hardwareList.Count; i++)
                        {
                            switch (choiceForHardware)
                            {
                                case 1:
                                    if ( hardwareList[i].name== hardwareName)
                                    {
                                        Console.WriteLine(" ENTER THE SERIAL NUMBER TO BE UPDATED");
                                         hardwareList[i].serialNumber = int.Parse(Console.ReadLine());
                                         DisplayTheHardware();
                                    }
                                    break;
                                case 2:
                                    if ( hardwareList[i].name == hardwareName)
                                    {
                                        Console.WriteLine(" ENTER THE NAME TO BE UPDATED");
                                         hardwareList[i].name = Console.ReadLine();
                                         DisplayTheHardware();
                                    }
                                    break;
                                case 3:
                                    if ( hardwareList[i].name ==  hardwareName)
                                    {
                                        Console.WriteLine(" ENTER THE AMOUNT TO BE UPDATED");
                                         hardwareList[i].amount =int.Parse(Console.ReadLine());
                                         DisplayTheHardware();
                                    }
                                    break;
                                case 4:
                                    if ( hardwareList[i].name ==  hardwareName)
                                    {
                                        Console.WriteLine(" ENTER THE INSTALLATION DATE TO BE UPDATED");
                                         hardwareList[i].installationDate = Convert.ToDateTime(Console.ReadLine());
                                        DisplayTheHardware();
                                    }
                                    break;
                                case 5:
                                    if (hardwareList[i].name == hardwareName)
                                    {
                                        Console.WriteLine("ENTER THE NAME WHICH YOU WANT UPDATE");
                                        hardwareList[i].name = Console.ReadLine();
                                        Console.WriteLine("ENTER THE SERIAL NUMBER WHICH YOU WANT UPDATE");
                                        hardwareList[i].serialNumber = int.Parse(Console.ReadLine());
                                        Console.WriteLine("ENTER THE INSTALLATION DATE WHICH YOU WANT UPDATE");
                                        hardwareList[i].installationDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("ENTER THE AMOUNT WHICH YOU WANT UPDATE");
                                        hardwareList[i].amount = int.Parse(Console.ReadLine());
                                        DisplayTheHardware();
                                    }
                                    break;
                                default:
                                    Console.WriteLine("CHOOSE CORRECT OPTION");
                                    break;

                            }
                        }

                    }
                    else if (choice==2)
                    {
                        ChooseoptionForHardwareAsset();
                    }

                }

            }
        }
        public void ChooseoptionForHardwareAsset()
        {
            Console.WriteLine("1 Add an Hardware");
            Console.WriteLine("2 Search an Hardware");
            Console.WriteLine("3 Update an  Hardware");
            Console.WriteLine("4 Delete an  Hardware");
            Console.WriteLine("5 List of all available  Hardware");
            Console.WriteLine("6 Exit");
            Console.WriteLine("####################################################");
            Console.WriteLine("ENTER YOUR CHOICE:");
            int chooseOfOperation = int.Parse(Console.ReadLine());
            if (chooseOfOperation == 1)
            {

                AddingHardware();
                ChooseoptionForHardwareAsset();
            }
            else if (chooseOfOperation == 2)
            {
                SearchHardware();
                ChooseoptionForHardwareAsset();
            }
            else if (chooseOfOperation == 3)
            {
                UpdateHardware();
                ChooseoptionForHardwareAsset();
            }
            else if (chooseOfOperation == 4)
            {
                DeleteTheHardware();
                ChooseoptionForHardwareAsset();
            }
            else if (chooseOfOperation == 5)
            {
                DisplayTheHardware();
                ChooseoptionForHardwareAsset();
            }
            else if (chooseOfOperation == 6)
            {
                Program.ChooseAsset();

            }
        }
    }
}

