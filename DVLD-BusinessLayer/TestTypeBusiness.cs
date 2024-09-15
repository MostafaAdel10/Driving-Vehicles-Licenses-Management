﻿using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestTypeBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestTypeBusiness.enTestType ID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public float Fees { set; get; }
        public clsTestTypeBusiness()

        {
            this.ID = clsTestTypeBusiness.enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;

            Mode = enMode.AddNew;
        }
        public clsTestTypeBusiness(clsTestTypeBusiness.enTestType ID, string TestTypeTitel,
            string Description, float TestTypeFees)

        {
            this.ID = ID;
            this.Title = TestTypeTitel;
            this.Description = Description;

            this.Fees = TestTypeFees;
            Mode = enMode.Update;
        }
        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.ID = (clsTestTypeBusiness.enTestType)clsTestTypeData.AddNewTestType(this.Title, 
                this.Description, this.Fees);

            return (this.Title != "");
        }
        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypeData.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }
        public static clsTestTypeBusiness Find(clsTestTypeBusiness.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;

            if (clsTestTypeData.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))

                return new clsTestTypeBusiness(TestTypeID, Title, Description, Fees);
            else
                return null;

        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
    }
}
