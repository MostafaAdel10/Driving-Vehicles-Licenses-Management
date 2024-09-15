using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountryBusiness
    {
        public int ID { set; get; }
        public string CountryName { set; get; }

        public clsCountryBusiness()

        {
            this.ID = -1;
            this.CountryName = "";

        }

        private clsCountryBusiness(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static clsCountryBusiness Find(int ID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryInfoByID(ID, ref CountryName))

                return new clsCountryBusiness(ID, CountryName);
            else
                return null;

        }

        public static clsCountryBusiness Find(string CountryName)
        {

            int ID = -1;

            if (clsCountryData.GetCountryInfoByName(CountryName, ref ID))

                return new clsCountryBusiness(ID, CountryName);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();

        }

    }
}
