using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PleaseWorkDamnIt.Models
{
    public enum Safety
    {
        Catastrophic=5,
        Critical=4,
        Serious=3,
        Minor=2,
        Negligible=1
    }
    public enum Function
    {
        LifeSupport=5,
        Diagnostic=4,
        TherapyAnalysis=3,
        Monitoring=2,
        Micekkes=1
    }
    public enum Area
    {
        OR=5,
        EmergencyICU=4,
        RadiologyLabs=3,
        InternalUnits=2,
        Other=1
    }
    public enum Detection
    {
        NoChance=5,
        LowChance=4,
        ModerateChance=3,
        HighChance=2,
        EasyToDetect=1,
    }
    public class Device
    {
        public int ID { get; set; }

        [MinLength(1)]
        public string Name { get; set; }


        [MinLength(1)]
        public string Brand { get; set; }


        [MinLength(1)]
        public string Model { get; set; }

        [Display(Name = "Type of Service")]
        public string TypeOfService { get; set; }


        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}"), 
            Display(Name = "Purchase Date")]
        public DateTime PurchasingDate { get; set; }



        [Display(Name = "Number Of Working Days")]
        public int NumberOfWorkingDays { get; set; }
        public int UtilizationRate()
        {
            if ((NumberOfWorkingDays / 365f) * 100 >= 80) return 5;
            else if ((NumberOfWorkingDays / 365f) * 100 < 80 && (NumberOfWorkingDays / 365f) * 100 >= 65) return 4;
            else if ((NumberOfWorkingDays / 365f) * 100 < 65 && (NumberOfWorkingDays / 365f) * 100 >= 50) return 3;
            else if ((NumberOfWorkingDays / 365f) * 100 < 50 && (NumberOfWorkingDays / 365f) * 100 >= 30) return 2;
            else if ((NumberOfWorkingDays / 365f) * 100 < 30) return 1;
            else return 1;
        }
        public string UtilizationRateString()
        {
            if (UtilizationRate()==5) return "Excessive";
            if (UtilizationRate() == 4) return "Above Average";
            if (UtilizationRate() == 3) return "Average";
            if (UtilizationRate() == 2) return "Below Average";
            if (UtilizationRate() == 1) return "Limited";
            else return "Not Calculated";
        }


        [Display(Name = "Number of Failures")]
        public int NumberOfFailures { get; set; }
        [Display(Name = "Down Time")]
        public int DownTime { get; set; }
        public int Unavailability()
        {
            if ((DownTime / 365f) * 100 >= 50) return 5;
            else if ((DownTime / 365f) * 100 < 50 && (DownTime / 365f) * 100 >= 40) return 4;
            else if ((DownTime / 365f) * 100 < 40 && (DownTime / 365f) * 100 >= 30) return 3;
            else if ((DownTime / 365f) * 100 < 30 && (DownTime / 365f) * 100 >= 20) return 2;
            else if ((DownTime / 365f) * 100 < 20 && (DownTime / 365f) * 100 >= 10) return 1;
            else return 1;
        }
        public string UnavailabilityString()
        {
            if (Unavailability() == 5) return "Very High";
            if (Unavailability() == 4) return "High";
            if (Unavailability() == 3) return "Moderate";
            if (Unavailability() == 2) return "Low";
            if (Unavailability() == 1) return "Very Low";
            else return "Not Calculated";
        }

        public Safety? Safety { get; set; }

        public Function? Function { get; set; }

        public Area? Area { get; set; }


        [Display(Name = "Service Cost"), DataType(DataType.Currency)]
        public float ServiceCost { get; set; }

        [Display(Name = "Operation Cost"), DataType(DataType.Currency)]
        public float OperationCost { get; set; }

        [Display(Name = "Purchasing Cost"), DataType(DataType.Currency), Column(TypeName = "decimal (18,2)")]
        public float PurchasingCost { get; set; }

        public int FinancialScore()
        {
            if ((ServiceCost / PurchasingCost) >= 0.5) return 3;
            if ((ServiceCost / PurchasingCost) >= 0.3 && (ServiceCost / PurchasingCost)<0.5) return 2;
            else return 1;
        }

        public Detection? Detection { get; set; }

        
        public int AgeFactor()
        {
            if (DateTime.Now.Year - PurchasingDate.Year >= 10) return 5;
            if (DateTime.Now.Year - PurchasingDate.Year >= 8 && DateTime.Now.Year - PurchasingDate.Year < 10) return 4;
            if (DateTime.Now.Year - PurchasingDate.Year >= 6 && DateTime.Now.Year - PurchasingDate.Year < 8) return 3;
            if (DateTime.Now.Year - PurchasingDate.Year >= 5 && DateTime.Now.Year - PurchasingDate.Year < 6) return 2;
            else return 1;
        }
        //public int RPN() 
        //{
        //    double Importance = Math.Ceiling(((double)Function + (double)Area) / 2);
        //    return (UtilizationRate() + Unavailability()+ AgeFactor()) * ((int)Safety + (int)Importance + FinancialScore()) * (int)Detection;
        //}
        public int DeviceScore { get; set; }
    }
}
