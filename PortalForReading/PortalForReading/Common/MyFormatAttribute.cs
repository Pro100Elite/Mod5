using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalForReading.Common
{
    public class MyFormatAttribute : ValidationAttribute
    {
        private static string[] myFormat;

        public MyFormatAttribute(string[] Formats)
        {
            myFormat = Formats;
        }

        public override bool IsValid(object value)
        {
            HttpPostedFileBase f = value as HttpPostedFileBase;

            if (f != null)
            {
                string strval = f.ContentType;
                for (int i = 0; i < myFormat.Length; i++)
                {
                    if (strval == myFormat[i])
                        return true;
                }
            }

            return false;
        }
    }
}