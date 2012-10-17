using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Country
/// </summary>
public class Country
{
    private Int32 i32Id;
    public Int32 I32Id { get { return i32Id; } }
    private String strName;
    public String StrName { get{ return strName;} }
	public Country(Int32 PrmI32Id, String PrmStrName)
	{
        i32Id = PrmI32Id;
        strName = PrmStrName;
	}
}
