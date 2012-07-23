using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enyim.Caching;
using System.Data;
using OVFM.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{

    public static MemcachedClient MovieCache;
    public static MemcachedClient ObjectsCache;
    public static OVFM.Data.ovfmDB AdsDB;

    public static void InitCache()
    {
        MovieCache = new MemcachedClient("enyim.com/memcached");
        ObjectsCache = new MemcachedClient("enyim.com/memcached");
    }

    public static void InitDB()
    {
        AdsDB = new OVFM.Data.ovfmDB();
    }
	

	public static void DoSomething()
	{
		string s="something";
		return;
	}

	public static void WriteToLog(Exception ex, string sURL, string sUserid, string sIP, string sPageURL, cbl.Syslog.Level cllevel)
    {

        string sErrorToFile = ex.ToString() + "| " + DateTime.Now.ToString() + "| " + sUserid + "| " + sIP + "| " + sURL;

        cbl.Syslog.Client c = new cbl.Syslog.Client();
        try
        {
            string sSysLogServer = System.Configuration.ConfigurationManager.AppSettings["SysLogServer"].ToString();
            int iSysLogacility = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SysLogFacility"]);

            int isyslevel = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SysLogLevel"]);

            int level = (int)cllevel;

            if (level > isyslevel)
                return;

            c.HostIp = sSysLogServer;
            int facility = iSysLogacility;
            string text = sErrorToFile;

            c.Send(new cbl.Syslog.Message(facility, level, text));
        }
        catch (System.Exception ex1)
        {

        }
        finally
        {
            c.Close();
        }
    }
}