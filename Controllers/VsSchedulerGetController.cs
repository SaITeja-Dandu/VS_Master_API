using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using VS_Master_API.Models;
using System.Data;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VS_Master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class VsSchedulerGetController : ControllerBase
    {
        private DbConnectionClass GetDbConnection = new DbConnectionClass();
        private GetNumbers GetNumbers = new GetNumbers();

        List<VS_Schedule> GetvS_Schedules = new List<VS_Schedule>();
        [HttpGet("{scnNo}")]
        public List<VS_Schedule> GetOne(string scnNo)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select [Internal_ID], [vesselId], [vesselName], [voyageNumber], [SCN], [ETA], [ETD], [portOfArrival], [location], [txnDateTime], [currentDateTime], [messageType], [messageType_Category], [Rec_Insert_Date], [Rec_LastModify_Date], [Rec_Modify_By]  From [dbo].[Vessel_Voyage_Schedule] where (SCN like '%" + scnNo + "%')", 0);
            GetvS_Schedules.Clear();
            bool CheckingMasterDataFinall = true;//GetNumbers.CheckMasterData(Convert.ToInt16(MasterCode), Convert.ToInt16(UserID));
            if (ChecJobID.Length != 0 && CheckingMasterDataFinall == true)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule> clsMovementCompletes = new List<VS_Schedule>();
                try
                {

                    SqlConnection conn = new(Connstr);
                    string Query = "select [Internal_ID], [vesselId], [vesselName], [voyageNumber], [SCN], [ETA], [ETD], [portOfArrival], [location], [txnDateTime], [currentDateTime], [messageType], [messageType_Category], [Rec_Insert_Date], [Rec_LastModify_Date], [Rec_Modify_By]  From [dbo].[Vessel_Voyage_Schedule] where (SCN like '%" + scnNo + "%')";


                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule k = new VS_Schedule();
                        if (dr1["Internal_ID"] != System.DBNull.Value)
                        {
                            k.Internal_ID = (int)dr1["Internal_ID"];
                        }

                        if (dr1["vesselId"] != System.DBNull.Value)
                        {
                            k.vesselId = dr1["vesselId"].ToString();
                        }
                        if (dr1["vesselName"] != System.DBNull.Value)
                        {
                            k.vesselName = dr1["vesselName"].ToString();
                        }
                        if (dr1["voyageNumber"] != System.DBNull.Value)
                        {
                            k.voyageNumber = dr1["voyageNumber"].ToString();
                        }
                        if (dr1["SCN"] != System.DBNull.Value)
                        {
                            k.SCN = dr1["SCN"].ToString();
                        }
                        if (dr1["ETA"] != System.DBNull.Value)
                        {
                            k.ETA = DateTime.Parse(dr1["ETA"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        if (dr1["ETD"] != System.DBNull.Value)
                        {
                            k.ETD = DateTime.Parse(dr1["ETD"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        if (dr1["portOfArrival"] != System.DBNull.Value)
                        {
                            k.portOfArrival = dr1["portOfArrival"].ToString();
                        }

                        if (dr1["location"] != System.DBNull.Value)
                        {
                            k.location = dr1["location"].ToString();
                        }

                        if (dr1["txnDateTime"] != System.DBNull.Value)
                        {
                            k.txnDateTime = DateTime.Parse(dr1["txnDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }

                        if (dr1["currentDateTime"] != System.DBNull.Value)
                        {
                            k.currentDateTime = DateTime.Parse(dr1["currentDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }

                        if (dr1["messageType"] != System.DBNull.Value)
                        {
                            k.messageType = dr1["messageType"].ToString();
                        }

                        if (dr1["messageType_Category"] != System.DBNull.Value)
                        {
                            k.messageType_Category = (short)dr1["messageType_Category"];
                        }

                        if (dr1["Rec_Insert_Date"] != System.DBNull.Value)
                        {
                            k.Rec_Insert_Date = DateTime.Parse(dr1["Rec_Insert_Date"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        k.errorMsg = "";


                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    VS_Schedule l = new VS_Schedule();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                    //throw;
                }
                return clsMovementCompletes;

            }
            else
            {
                List<VS_Schedule> clsMovementCompletes = new List<VS_Schedule>();
                VS_Schedule k = new VS_Schedule();
                k.errorMsg = "VesselId  or vesselName   or SCN  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }
        }

        [HttpGet("{scnNo}/{vesselName}")]
        public List<VS_Schedule> GetOne(string scnNo, string vesselName)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select [Internal_ID], [vesselId], [vesselName], [voyageNumber], [SCN], [ETA], [ETD], [portOfArrival], [location], [txnDateTime], [currentDateTime], [messageType], [messageType_Category], [Rec_Insert_Date], [Rec_LastModify_Date], [Rec_Modify_By]  From [dbo].[Vessel_Voyage_Schedule] where(vesselName like '%" + vesselName + "%' or SCN like '%" + scnNo + "%')", 0);
            GetvS_Schedules.Clear();
            bool CheckingMasterDataFinall = true;//GetNumbers.CheckMasterData(Convert.ToInt16(MasterCode), Convert.ToInt16(UserID));
            if (ChecJobID.Length != 0 && CheckingMasterDataFinall == true)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule> clsMovementCompletes = new List<VS_Schedule>();
                try
                {


                    SqlConnection conn = new(Connstr);

                    string Query = "select [Internal_ID], [vesselId], [vesselName], [voyageNumber], [SCN], [ETA], [ETD], [portOfArrival], [location], [txnDateTime], [currentDateTime], [messageType], [messageType_Category], [Rec_Insert_Date], [Rec_LastModify_Date], [Rec_Modify_By]  From [dbo].[Vessel_Voyage_Schedule] where(vesselName like '%" + vesselName + "%' or SCN like '%" + scnNo + "%')";

                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule k = new VS_Schedule();
                        if (dr1["Internal_ID"] != System.DBNull.Value)
                        {
                            k.Internal_ID = (int)dr1["Internal_ID"];
                        }

                        if (dr1["vesselId"] != System.DBNull.Value)
                        {
                            k.vesselId = dr1["vesselId"].ToString();
                        }
                        if (dr1["vesselName"] != System.DBNull.Value)
                        {
                            k.vesselName = dr1["vesselName"].ToString();
                        }
                        if (dr1["voyageNumber"] != System.DBNull.Value)
                        {
                            k.voyageNumber = dr1["voyageNumber"].ToString();
                        }
                        if (dr1["SCN"] != System.DBNull.Value)
                        {
                            k.SCN = dr1["SCN"].ToString();
                        }
                        if (dr1["ETA"] != System.DBNull.Value)
                        {
                            k.ETA = DateTime.Parse(dr1["ETA"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        if (dr1["ETD"] != System.DBNull.Value)
                        {
                            k.ETD = DateTime.Parse(dr1["ETD"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        if (dr1["portOfArrival"] != System.DBNull.Value)
                        {
                            k.portOfArrival = dr1["portOfArrival"].ToString();
                        }

                        if (dr1["location"] != System.DBNull.Value)
                        {
                            k.location = dr1["location"].ToString();
                        }

                        if (dr1["txnDateTime"] != System.DBNull.Value)
                        {
                            k.txnDateTime = DateTime.Parse(dr1["txnDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }


                        if (dr1["currentDateTime"] != System.DBNull.Value)
                        {
                            k.currentDateTime = DateTime.Parse(dr1["currentDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }

                        if (dr1["messageType"] != System.DBNull.Value)
                        {
                            k.messageType = dr1["messageType"].ToString();
                        }

                        if (dr1["messageType_Category"] != System.DBNull.Value)
                        {
                            k.messageType_Category = (short)dr1["messageType_Category"];
                        }

                        if (dr1["Rec_Insert_Date"] != System.DBNull.Value)
                        {
                            k.Rec_Insert_Date = DateTime.Parse(dr1["Rec_Insert_Date"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        k.errorMsg = "";


                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    VS_Schedule l = new VS_Schedule();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                    //throw;
                }

                return clsMovementCompletes;

            }
            else
            {
                List<VS_Schedule> clsMovementCompletes = new List<VS_Schedule>();
                VS_Schedule k = new VS_Schedule();

                k.errorMsg = "VesselId  or vesselName or SCN  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }



        }

        [HttpGet("{scnNo}/{vesselName}/{voyageNumber}")]
        public List<VS_Schedule> GetOne(string scnNo, string vesselName, string voyageNumber)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select [Internal_ID], [vesselId], [vesselName], [voyageNumber], [SCN], [ETA], [ETD], [portOfArrival], [location], [txnDateTime], [currentDateTime], [messageType], [messageType_Category], [Rec_Insert_Date], [Rec_LastModify_Date], [Rec_Modify_By]  From [dbo].[Vessel_Voyage_Schedule] where(vesselName like '%" + vesselName + "%' or voyageNumber like '%" + voyageNumber + "%' or SCN like '%" + scnNo + "%')", 0);
            GetvS_Schedules.Clear();
            bool CheckingMasterDataFinall = true;//GetNumbers.CheckMasterData(Convert.ToInt16(MasterCode), Convert.ToInt16(UserID));
            if (ChecJobID.Length != 0 && CheckingMasterDataFinall == true)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule> clsMovementCompletes = new List<VS_Schedule>();
                try
                {


                    SqlConnection conn = new(Connstr);

                    string Query = "select [Internal_ID], [vesselId], [vesselName], [voyageNumber], [SCN], [ETA], [ETD], [portOfArrival], [location], [txnDateTime], [currentDateTime], [messageType], [messageType_Category], [Rec_Insert_Date], [Rec_LastModify_Date], [Rec_Modify_By]  From [dbo].[Vessel_Voyage_Schedule] where(vesselName like '%" + vesselName + "%' or voyageNumber like '%" + voyageNumber + "%' or SCN like '%" + scnNo + "%')";

                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule k = new VS_Schedule();
                        if (dr1["Internal_ID"] != System.DBNull.Value)
                        {
                            k.Internal_ID = (int)dr1["Internal_ID"];
                        }

                        if (dr1["vesselId"] != System.DBNull.Value)
                        {
                            k.vesselId = dr1["vesselId"].ToString();
                        }
                        if (dr1["vesselName"] != System.DBNull.Value)
                        {
                            k.vesselName = dr1["vesselName"].ToString();
                        }
                        if (dr1["voyageNumber"] != System.DBNull.Value)
                        {
                            k.voyageNumber = dr1["voyageNumber"].ToString();
                        }
                        if (dr1["SCN"] != System.DBNull.Value)
                        {
                            k.SCN = dr1["SCN"].ToString();
                        }
                        if (dr1["ETA"] != System.DBNull.Value)
                        {
                            k.ETA = DateTime.Parse(dr1["ETA"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        if (dr1["ETD"] != System.DBNull.Value)
                        {
                            k.ETD = DateTime.Parse(dr1["ETD"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        if (dr1["portOfArrival"] != System.DBNull.Value)
                        {
                            k.portOfArrival = dr1["portOfArrival"].ToString();
                        }

                        if (dr1["location"] != System.DBNull.Value)
                        {
                            k.location = dr1["location"].ToString();
                        }

                        if (dr1["txnDateTime"] != System.DBNull.Value)
                        {
                            k.txnDateTime = DateTime.Parse(dr1["txnDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }


                        if (dr1["currentDateTime"] != System.DBNull.Value)
                        {
                            k.currentDateTime = DateTime.Parse(dr1["currentDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }

                        if (dr1["messageType"] != System.DBNull.Value)
                        {
                            k.messageType = dr1["messageType"].ToString();
                        }

                        if (dr1["messageType_Category"] != System.DBNull.Value)
                        {
                            k.messageType_Category = (short)dr1["messageType_Category"];
                        }

                        if (dr1["Rec_Insert_Date"] != System.DBNull.Value)
                        {
                            k.Rec_Insert_Date = DateTime.Parse(dr1["Rec_Insert_Date"].ToString()).ToString("yyyy-MM-dd HH:mm");
                        }
                        k.errorMsg = "";


                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    VS_Schedule l = new VS_Schedule();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                    //throw;
                }

                return clsMovementCompletes;

            }
            else
            {
                List<VS_Schedule> clsMovementCompletes = new List<VS_Schedule>();
                VS_Schedule k = new VS_Schedule();

                k.errorMsg = "VesselId  or vesselName   or SCN  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }



        }


        [HttpGet("~/ScnNumberSearch")]
        public List<VS_Schedule.GetSCNNumber> GetSCN(string ScnNumberSearch)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select distinct SCN  From [dbo].[Vessel_Voyage_Schedule] where(SCN like '%" + ScnNumberSearch + "%') and messageType in ('JETA','ETAAmend')", 0);
            if (ChecJobID.Length != 0)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule.GetSCNNumber> clsMovementCompletes = new List<VS_Schedule.GetSCNNumber>();
                try
                {
                    SqlConnection conn = new(Connstr);
                    string Query = "select distinct SCN From [dbo].[Vessel_Voyage_Schedule] where (SCN like '%" + ScnNumberSearch + "%') and messageType in ('JETA','ETAAmend')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule.GetSCNNumber k = new VS_Schedule.GetSCNNumber();

                        if (dr1["SCN"] != System.DBNull.Value)
                        {
                            k.SCN = dr1["SCN"].ToString();
                        }

                        k.errorMsg = "";
                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    VS_Schedule.GetSCNNumber l = new VS_Schedule.GetSCNNumber();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                }

                return clsMovementCompletes;
            }
            else
            {
                List<VS_Schedule.GetSCNNumber> clsMovementCompletes = new List<VS_Schedule.GetSCNNumber>();
                VS_Schedule.GetSCNNumber k = new VS_Schedule.GetSCNNumber();
                k.errorMsg = "SCN  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }

        }


        [HttpGet("~/vesselNameSearch")]
        public List<VS_Schedule.GetvesselName> GetVesselName(string vesselName)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select distinct vesselName  From [dbo].[Vessel_Voyage_Schedule] where(vesselName like '%" + vesselName + "%') and messageType in ('JETA','ETAAmend')", 0);
            if (ChecJobID.Length != 0)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule.GetvesselName> clsMovementCompletes = new List<VS_Schedule.GetvesselName>();
                try
                {
                    SqlConnection conn = new(Connstr);
                    string Query = "select distinct vesselName From [dbo].[Vessel_Voyage_Schedule] where (vesselName like '%" + vesselName + "%') and messageType in ('JETA','ETAAmend')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule.GetvesselName k = new VS_Schedule.GetvesselName();

                        if (dr1["vesselName"] != System.DBNull.Value)
                        {
                            k.vesselName = dr1["vesselName"].ToString();
                        }

                        k.errorMsg = "";
                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    VS_Schedule.GetvesselName l = new VS_Schedule.GetvesselName();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                }

                return clsMovementCompletes;
            }
            else
            {
                List<VS_Schedule.GetvesselName> clsMovementCompletes = new List<VS_Schedule.GetvesselName>();
                VS_Schedule.GetvesselName k = new VS_Schedule.GetvesselName();
                k.errorMsg = "vesselName  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }

        }


        [HttpGet("~/voyageNumber")]
        public List<VS_Schedule.GetvoyageNumber> GetVoyageNumber(string voyageNumber)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select distinct voyageNumber  From [dbo].[Vessel_Voyage_Schedule] where(voyageNumber like '%" + voyageNumber + "%') and messageType in ('JETA','ETAAmend')", 0);
            if (ChecJobID.Length != 0)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule.GetvoyageNumber> clsMovementCompletes = new List<VS_Schedule.GetvoyageNumber>();
                try
                {
                    SqlConnection conn = new(Connstr);
                    string Query = "select distinct voyageNumber From [dbo].[Vessel_Voyage_Schedule] where (voyageNumber like '%" + voyageNumber + "%') and messageType in ('JETA','ETAAmend')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule.GetvoyageNumber k = new VS_Schedule.GetvoyageNumber();

                        if (dr1["voyageNumber"] != System.DBNull.Value)
                        {
                            k.voyageNumber = dr1["voyageNumber"].ToString();
                        }

                        k.errorMsg = "";
                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    VS_Schedule.GetvoyageNumber l = new VS_Schedule.GetvoyageNumber();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                }

                return clsMovementCompletes;
            }
            else
            {
                List<VS_Schedule.GetvoyageNumber> clsMovementCompletes = new List<VS_Schedule.GetvoyageNumber>();
                VS_Schedule.GetvoyageNumber k = new VS_Schedule.GetvoyageNumber();
                k.errorMsg = "voyageNumber  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }

        }


        [HttpGet("~/vesselIdSearch")]
        public List<VS_Schedule.GetvesselId> GetvesselId(string vesselId)
        {
            string ChecJobID = GetNumbers.RetriveParticularColumns("select distinct vesselId  From [dbo].[Vessel_Voyage_Schedule] where(vesselId like '%" + vesselId + "%') and messageType in ('JETA','ETAAmend')", 0);
            if (ChecJobID.Length != 0)
            {
                var Connstr = GetDbConnection.DbConnString();
                List<VS_Schedule.GetvesselId> clsMovementCompletes = new List<VS_Schedule.GetvesselId>();
                try
                {
                    SqlConnection conn = new(Connstr);
                    string Query = "select distinct vesselId From [dbo].[Vessel_Voyage_Schedule] where (vesselId like '%" + vesselId + "%') and messageType in ('JETA','ETAAmend')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader dr1;

                    conn.Open();
                    dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        VS_Schedule.GetvesselId k = new VS_Schedule.GetvesselId();

                        if (dr1["vesselId"] != System.DBNull.Value)
                        {
                            k.vesselId = dr1["vesselId"].ToString();
                        }

                        k.errorMsg = "";
                        clsMovementCompletes.Add(k);
                    }
                    dr1.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    VS_Schedule.GetvesselId l = new VS_Schedule.GetvesselId();

                    l.errorMsg = ex.Message.Trim();
                    clsMovementCompletes.Add(l);

                }

                return clsMovementCompletes;
            }
            else
            {
                List<VS_Schedule.GetvesselId> clsMovementCompletes = new List<VS_Schedule.GetvesselId>();
                VS_Schedule.GetvesselId k = new VS_Schedule.GetvesselId();
                k.errorMsg = "VesselID  Did not Match any so No Data..";
                clsMovementCompletes.Add(k);
                return clsMovementCompletes;
            }

        }
    }

}
