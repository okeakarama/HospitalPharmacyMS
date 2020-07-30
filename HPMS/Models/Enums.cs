using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HPMS.Models
{
    public class Enums
    {

        public enum PageType
        {
            [Description("Single")]
            Single = 1,
            [Description("List")]
            List = 2,
            [Description("Mother")]
            Mother = 10
        }

        public enum DrugType
        {

            [Description("Normal")]
            Normal = 1

        }

    }
}