﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDriver
    {
        public static DataTable GetAllDrivers()
        {
            return clsDriversDataAccess.GetAllDrivers();
        }

        public static int GetDriverID(int PersonID)
        {
            return clsDriversDataAccess.GetDriverByPersonID(PersonID);
        }

        public static int CreateDriver (int PersonID, int CreatedByUserID)
        {
            return clsDriversDataAccess.CreateDriver(PersonID, CreatedByUserID);
        }

        
    }
}
