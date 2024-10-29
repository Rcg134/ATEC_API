using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATEC_API.GeneralModels.MESATECModels.StagingResponse
{
    public class MaterialStagingResponse
    {
		public bool? isSuccessful {  get; set; }
        public bool? isThawed { get; set; }
        public string? SID { get; set; }
        public string? sidDesc { get; set; }
        public string? batchId { get; set; }
        public string? serial { get; set; }
        public string? thawingIn { get; set; }
        public string? thawingOut { get; set; }
        public string? workLifeEnd { get; set; }
        public string? expirationDate { get; set; }
        public bool? isLotExist { get; set; }
        public bool? isEpoxyAssigned { get; set; }
        public bool? isMachineExist { get; set; }
        public string? msg { get; set; }
        public string? customerCode { get; set; }
        public string? customerId { get; set;}
    }
}
