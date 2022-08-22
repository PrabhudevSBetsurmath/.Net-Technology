using System;
namespace AssetManagementSystem
{
   public class AssetProperties
    {
        private int serialNumberAsset;
        private string nameAsset; 
        public int serialNumber
        {
            set
            {
                if(value<=0)
                {
                    Console.WriteLine("WRITE THE NON NEGATIVE NUMBER GREATER THAN ZERO");
                }
                else
                {
                    serialNumberAsset = value;
                }
            }
            get
            {
                return serialNumberAsset;
            }
        }
        public string name 
        {
            set
            {
                if (value ==string.Empty)
                {
                    Console.WriteLine("NAME ASSET MUST NOT BE EMPTY");
                }
                else
                {
                    nameAsset = value;
                }
            }
            get
            {
                return nameAsset;
            }
        }
    }

       
 }


