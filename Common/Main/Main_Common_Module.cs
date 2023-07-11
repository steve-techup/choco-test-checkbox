using System;
using System.Drawing;
using System.IO;
using Caretag_Class.My;
using Microsoft.VisualBasic;

namespace Caretag_Class;

public static class Function_Module
{
    // ****************************************************************************************************************************
    public static short Programs_Security_Level = 1;
    public static string Program_User = "";
    public static string Program_Name = "Surgical_Admin";
    public static int The_Log_ID = 0;
    public static int GlobalPersonID = 0;
    public static string Language_Choosen = "";
    public static string The_Cost_Item = "";
    public static string Cost_Extra_Text = "";

    public static short Max_Instruments = 80;

    // ****************************************************************************************************************************
    public static string passPhrase = "FeivelInTheSky";
    public static string saltValue = "KnowledgeHub";
    public static int passwordIterations = 2;
    public static string initVector = "@1B2c3D4e5F6g7H8";
    public static int keySize = 256;
    
    // ****************************************************************************************************************************
    public static string DeskTopReader_Name = "Caretag_Device";
    public static string The_Reader_Name = "";
    public static int The_Reader_ID = 0;
    public static string The_IP_Address = "";
    public static int The_Compamy_ID = 0;
    public static int The_Department_ID = 0;
    public static string The_EPC = "";

    public static string The_Product_Code = "";

    // *****************************************************************************************************************************
    public static string The_Tray_EPC = "";
    public static int The_Tray_ID = 0;
    public static string Edit_Tray_ID;
    public static int The_Tray_Descrip_ID = 0;

    public static DateTime The_Tray_Time_Start;

    // *****************************************************************************************************************************
    public static Image picture = null;
    public static bool I_Agree = false;
    
    // *****************************************************************************************************************************
    public static string SQL_ConnectionString = "";
    public static string TableNameEdit = "";

    public static string DataBaseString = "";

    // Public ConfigFileName As String = "C:\PGR_CONFIG\" & My.Application.Info.AssemblyName
    public static string BackUp_FilePath = Path.Combine(MyProject.Computer.FileSystem.SpecialDirectories.MyDocuments,
        "BackUp_" + DateAndTime.Now.ToFileTime() + ".csv");
    // ****************************************************************************************************************************
}