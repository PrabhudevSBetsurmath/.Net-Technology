using System;
namespace AssetManagementSystem
{
    public class Program
    {
        public static void ChooseAsset()
        {
            BookAsset bookOperation = new BookAsset();
            SoftwareLicenseAsset softwareOperation = new SoftwareLicenseAsset();
            HardwareAsset hardwareOperation = new HardwareAsset();
            Console.WriteLine("#################ASSEST MANGEMENT SYSTEM ###################################");
            Console.WriteLine("1.Books");
            Console.WriteLine("2.SoftwareLicense");
            Console.WriteLine("3.Hardware");
            Console.WriteLine("4 exit");
            Console.WriteLine("ENTER THE ASSET YOU WANT CHOOSE :");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                bookOperation.ChooseoptionForBookAsset();
            }
            else if (choice == 2)
            {
                softwareOperation.ChooseoptionForSoftwareLicenseAsset();
            }
            else if (choice == 3)
            {
                hardwareOperation.ChooseoptionForHardwareAsset();
            }
            else if (choice == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("YOU HAVE ENTERED WRONG CHOICE\nENTER THE CHOICE BETWEEN 1 TO 4");
                ChooseAsset();
            }
        }
        static void Main(string[] args)
        {
            Program.ChooseAsset();
        }
    }
}
