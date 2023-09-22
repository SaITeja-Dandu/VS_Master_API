namespace VS_Master_API.Models
{
    public class VS_Schedule
    {
        public VS_Schedule()
        {
        }

        //  public VS_Schedule() { }

        //public VS_Schedule(VS_Schedule vS_Schedule)
        //{
        //    vSSchedule1 = vS_Schedule;
        //}


        #region VS_Schedule_Declaration

        //public string? VesselId { get; set; } = null;

        public int? Internal_ID { get; set; } = null;
        public string vesselId { get; set; } = null;
        public string vesselName { get; set; } = null;
        public string voyageNumber { get; set; } = null;
        public string SCN { get; set; } = null;
        public string ETA { get; set; } = null;
        public string ETD { get; set; } = null;
        public string portOfArrival { get; set; } = null;
        public string location { get; set; } = null;
        public string txnDateTime { get; set; } = null;
        public string currentDateTime { get; set; } = null;
        public string messageType { get; set; } = null;
        public int? messageType_Category { get; set; } = null;
        public string Rec_Insert_Date { get; set; }
        public string errorMsg { get; set; } = null;

        #endregion

        public class GetSCNNumber
        {
            public GetSCNNumber() { }
            public string SCN { get; set; }
            public string errorMsg { get; set; } = null;
        }

        public class GetvesselName
        {
            public GetvesselName() { }
            public string vesselName { get; set; }
            public string errorMsg { get; set; } = null;
        }
        public class GetvoyageNumber
        {
            public GetvoyageNumber() { }
            public string voyageNumber { get; set; }
            public string errorMsg { get; set; } = null;
        }
        public class GetvesselId
        {
            public GetvesselId() { }
            public string vesselId { get; set; }
            public string errorMsg { get; set; } = null;
        }
    }

}
