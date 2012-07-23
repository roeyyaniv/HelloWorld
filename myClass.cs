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
}