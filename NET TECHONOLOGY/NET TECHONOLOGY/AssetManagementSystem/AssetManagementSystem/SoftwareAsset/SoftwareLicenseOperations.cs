using System;
using System.Collections.Generic;
namespace AssetManagementSystem
{
  public  class SoftwareLicenseAsset
    {
        
         List<SoftwareLicenseProperties> softwareLicenseList = new List<SoftwareLicenseProperties>(4);
        public void AddingSoftwareLicense()
        {
           
            Console.WriteLine("ENTER THE NUMBER OF SOFTWARE LICENSE TO BE ADDED");
            int addSoftwareLicense = int.Parse(Console.ReadLine());
            for (int i = 0; i < addSoftwareLicense; i++)
            {
                SoftwareLicenseProperties softwareLicenseComp = new SoftwareLicenseProperties();
                Console.WriteLine("ENTER THE SERIAL NUMBER OF THE SOFTWARE LICENSE");
                softwareLicenseComp.serialNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("ENTER THE NAME OF THE SOFTWARE LICENSE");
                softwareLicenseComp.name = (Console.ReadLine());
                Console.WriteLine("ENTER THE DATE OF EXPIRY OF THE SOFTWARE LICENSE");
                softwareLicenseComp.dateOfExpiry = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("ENTER THE DATE OF PUBLISH OF THE SOFTWARE LICENSE");
                softwareLicenseComp.dateOfPublish = Convert.ToDateTime(Console.ReadLine());
                softwareLicenseList.Add(softwareLicenseComp);
            }
            Console.WriteLine("\t\t\t\t ADDED SUCCESFULLY!!");
        }
        public void DisplaytheSoftwareLicense()
        {
            if (softwareLicenseList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool testSerialNumber = false;
                for (int i = 0; i < softwareLicenseList.Count; i++)
                {
                    if (softwareLicenseList[i].serialNumber == 0 || softwareLicenseList[i].name == string.Empty)
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
                    Console.WriteLine("Serial Number \t \t Name \t \t Date Of Expiry \t \t Date Of publish");
                    foreach (SoftwareLicenseProperties obj in softwareLicenseList)
                    {
                        Console.WriteLine(obj.serialNumber + "\t \t \t" + obj.name + "\t \t \t" + obj.dateOfExpiry.ToString("dd/MM/yyyy") + "\t \t \t" + obj.dateOfPublish.ToString("dd/MM/yyyy"));

                    }
                }

            }
        }

        public void DeletetheSoftwareLicense()
        {
            if (softwareLicenseList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                Console.WriteLine("ENTER THE SOFTWARE LICENSE SERIAL NUMBER TO BE DELETED");
                int softwareLicenseToBeDeleted =int.Parse(Console.ReadLine());
                bool checkForSoftwareLicenseDelete = false;
                
                for (int i = 0; i < softwareLicenseList.Count; i++)
                {
                    if (softwareLicenseToBeDeleted == softwareLicenseList[i].serialNumber)
                    {
                        softwareLicenseList.RemoveAt(i);
                        checkForSoftwareLicenseDelete = true;
                    }
                    
                }
                if (checkForSoftwareLicenseDelete == true)
                {
                    Console.WriteLine("THE SOFTWARE LICENSE YOU HAVE ENTERED IS DELETED SUCESSFULLY");
                }
                else 
                {
                    Console.WriteLine("THE SOFTWARE LICENSE  WHICH  YOU HAVE ENTERED IS NOT PRESENT IN THE LIST ASSET ");
                }
            }

        }
        public void SearchSoftwareLicense()
        {
            if (softwareLicenseList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool softwareLicenseAvailable = false;

                Console.WriteLine("ENTER THE SOFTWARE LICENSE NAME TO BE SEARCHED");
                string softwareToBeSearched = Console.ReadLine();
                for (int i = 0; i < softwareLicenseList.Count; i++)
                {
                    if (softwareToBeSearched == softwareLicenseList[i].name)
                    {
                        Console.WriteLine("Serial Number \t \t Name \t \t Date Of Expiry \t \t Date of publish");
                        Console.WriteLine(softwareLicenseList[i].serialNumber + "\t \t \t" + softwareLicenseList[i].name + "\t \t \t" + softwareLicenseList[i].dateOfExpiry.ToString("dd/MM/yyyy") + "\t \t \t" + softwareLicenseList[i].dateOfPublish.ToString("dd/MM/yyyy"));
                        softwareLicenseAvailable = true;
                    }
                }
                if(softwareLicenseAvailable == false)
                {
                   
                    Console.WriteLine("THE SOFTWARE LICENSE NAME WHICH YOU HAVE ENETERED IS NOT PRESENT TO SEARCH");
                }
               
            }

        }
        public void UpdateSoftwareLicense()
        {
            if (softwareLicenseList.Count == 0)
            {
                Console.WriteLine("PLEASE ADD THE ASSET AS OPTION 1 SHOWN ABOVE");
            }
            else
            {
                bool test = false;
                DisplaytheSoftwareLicense();
                Console.WriteLine("Enter THE NAME FROM OBSERVING ABOVE LIST TO BE UPDATED");
                string softwareLicenseName = (Console.ReadLine());
                for (int i = 0; i < softwareLicenseList.Count; i++)
                {
                    if ((softwareLicenseList[i].name == softwareLicenseName))
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
                    Console.WriteLine($"DO YOU WANT UPDATE ATLEAST ONE ITEM IN \"{softwareLicenseName}\"ENTER 1  OR TO EXIT PRESS 2");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice==1)
                    {
                        Console.WriteLine("1.DO YOU WANT TO UPDATE SERIAL NUMBER?");
                        Console.WriteLine("2 DO YOU WANT TO UPDATE NAME?");
                        Console.WriteLine("3 DO YOU WANT TO UPDATE DATE OF EXPIRY?");
                        Console.WriteLine("4 DO YOU WANT UPDATE DATE OF PUBLISH?");
                        Console.WriteLine("5 DO YOU WANT UPDATE WHOLE LIST?");
                        int choiceForSoftwareLicense = int.Parse(Console.ReadLine());
                        for (int i = 0; i < softwareLicenseList.Count; i++)
                        {
                            switch (choiceForSoftwareLicense)
                            {
                                case 1:
                                    if (softwareLicenseList[i].name == softwareLicenseName)
                                    {
                                        Console.WriteLine(" ENTER THE SERIAL NUMBER TO BE UPDATED");
                                        softwareLicenseList[i].serialNumber = int.Parse(Console.ReadLine());
                                        DisplaytheSoftwareLicense();
                                    }
                                    break;
                                case 2:
                                    if (softwareLicenseList[i].name == softwareLicenseName)
                                    {
                                        Console.WriteLine(" ENTER THE NAME TO BE UPDATED");
                                        softwareLicenseList[i].name = Console.ReadLine();
                                        DisplaytheSoftwareLicense();
                                    }
                                    break;
                                case 3:
                                    if (softwareLicenseList[i].name == softwareLicenseName)
                                    {
                                        Console.WriteLine(" ENTER THE DATE OF EXPIRY TO BE UPDATED");
                                        softwareLicenseList[i].dateOfExpiry = Convert.ToDateTime(Console.ReadLine());
                                        DisplaytheSoftwareLicense();
                                    }
                                    break;
                                case 4:
                                    if (softwareLicenseList[i].name == softwareLicenseName)
                                    {
                                        Console.WriteLine(" ENTER THE DATE OF PUBLISH TO BE UPDATED");
                                        softwareLicenseList[i].dateOfPublish = Convert.ToDateTime(Console.ReadLine());
                                        DisplaytheSoftwareLicense();
                                    }
                                    break;
                                case 5:
                                    if (softwareLicenseList[i].name == softwareLicenseName)
                                    {
                                        Console.WriteLine("ENTER THE NAME WHICH YOU WANT UPDATE");
                                        softwareLicenseList[i].name = Console.ReadLine();
                                        Console.WriteLine("ENTER THE SERIAL NUMBER WHICH YOU WANT UPDATE");
                                        softwareLicenseList[i].serialNumber = int.Parse(Console.ReadLine());
                                        Console.WriteLine("ENTER THE  DATE OF EXPIRY WHICH YOU WANT UPDATE");
                                        softwareLicenseList[i].dateOfExpiry = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("ENTER THE DATE OF PUBLISH WHICH YOU WANT UPDATE");
                                        softwareLicenseList[i].dateOfPublish = Convert.ToDateTime(Console.ReadLine());
                                        DisplaytheSoftwareLicense();
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
                        ChooseoptionForSoftwareLicenseAsset();
                    }

                }

            }
        }
        public void ChooseoptionForSoftwareLicenseAsset()
        {
            Console.WriteLine("1 Add an SoftwareLicense");
            Console.WriteLine("2 Search an SoftwareLicense");
            Console.WriteLine("3 Update an SoftwareLicense");
            Console.WriteLine("4 Delete an SoftwareLicense");
            Console.WriteLine("5 List of all available SoftwareLicense");
            Console.WriteLine("6 Exit");
            Console.WriteLine("####################################################");
            Console.WriteLine("ENTER YOUR CHOICE:");
            int chooseOfOperation = int.Parse(Console.ReadLine());
            if (chooseOfOperation == 1)
            {

                AddingSoftwareLicense();
                ChooseoptionForSoftwareLicenseAsset();
            }
            else if (chooseOfOperation == 2)
            {
                SearchSoftwareLicense();
                ChooseoptionForSoftwareLicenseAsset();
            }
            else if (chooseOfOperation == 3)
            {
                UpdateSoftwareLicense();
                ChooseoptionForSoftwareLicenseAsset();
            }
            else if (chooseOfOperation == 4)
            {
                DeletetheSoftwareLicense();
                ChooseoptionForSoftwareLicenseAsset();
            }
            else if (chooseOfOperation == 5)
            {
                DisplaytheSoftwareLicense();
                ChooseoptionForSoftwareLicenseAsset();
            }
            else if (chooseOfOperation == 6)
            {
                Program.ChooseAsset();

            }
        }

   }
 }
