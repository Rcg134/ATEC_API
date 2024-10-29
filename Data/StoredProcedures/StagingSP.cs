// <copyright file="StagingSP.cs" company="ATEC">
// Copyright (c) ATEC. All rights reserved.
// </copyright>

namespace ATEC_API.Data.StoredProcedures
{
    public class StagingSP
    {
        private const string usp_S_I = "usp_Staging_IsTrackOut";
        public static string usp_Staging_IsTrackOut = usp_S_I;

        private const string usp_M_H_S_API = "usp_Magazine_History_Search_API";
        public static string usp_Magazine_History_Search_API = usp_M_H_S_API;

        // For test purposes
        public static string usp_Staging_IsTrackOut_Test = "usp_Staging_IsTrackOut_Test";
        public static string usp_Material_Details = "usp_MTL_Material_Details";
        public static string usp_Material_Customer = "usp_MTL_MaterialType_GetCustomer";
        public static string usp_Check_Param = "usp_MTL_Parameter_Check";
        public static string usp_Material_History = "usp_MTL_Material_History_Endpoint";

        // New Material Thawing Flow
        public static string usp_Material_InOut_Endpoint = "usp_MTL_Material_InOut_Endpoint";
        public static string usp_Material_LotMachine_Endpoint = "usp_MTL_Material_Lot_Machine_Usage_Endpoint";

        // Material Thawing for Panjit and Gem
        public static string usp_Material_InOut_PG = "usp_MTL_Material_InOut_Endpoint_PG";


    }
}