using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
  public  class BatchNoList
    {
        public string ShipVia { get; set; }

        public int PickingTicketNo { get; set; }

        public int Line_No { get; set; }

        public string CustomerID { get; set; }

        public string PickItem { get; set; }

        public int BaleNo { get; set; }

        public int PickUpBatchNo { get; set; }
        public string SKU { get; set; }

        public string PickingLocation { get; set; }

        public string Floor { get; set; }

        public string Row { get; set; }

        public string ItemID { get; set; }

        public int IDX { get; set; }

        public string CustomerPO { get; set; }

        public string WarehouseID { get; set; }

        public string Itemtype { get; set; }

        public String PickUpDate { get; set; }

        public DateTime LabelPrintedDate { get; set; }
    }
}
