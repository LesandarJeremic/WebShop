using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInterface.Models
{
    public class Transfer

    {

        public bool modeJson { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Supplier { get; set; }

        public string Producer { get; set; }
    }
    public class TransferIntern : Transfer

    {
        public bool create { get; set; }


    }
}