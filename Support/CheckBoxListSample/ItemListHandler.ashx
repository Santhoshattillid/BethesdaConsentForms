<%@ WebHandler Language="C#" Class="ItemListHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

public class ItemListHandler : IHttpHandler {
    
public void ProcessRequest (HttpContext context) {
    context.Response.ContentType = "text/plain";
    String strMethodName = String.Empty;
    String strSelectedText = String.Empty;
    String strSelectedValue = String.Empty;
    if (!String.IsNullOrEmpty(context.Request.Form["StrSelectedValue"]))
    {
        strSelectedValue = Convert.ToString(context.Request.Form["StrSelectedValue"]);
    }
    if (!String.IsNullOrEmpty(context.Request.Form["StrSelectedText"]))
    {
        strSelectedText = Convert.ToString(context.Request.Form["StrSelectedText"]);
    }
    if (!String.IsNullOrEmpty(context.Request.QueryString["StrMethodName"]))
    {
        strMethodName = Convert.ToString(context.Request.QueryString["StrMethodName"]);
    }
    if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("GETCOUNTRIES"))
    {
        context.Response.Write(CreateCountrySelectOptions(GetCountries()));
    }
    else if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("GETCOUNTRIES2"))
    {
        context.Response.Write(CreateCountrySelectList(GetCountries()));
    }
    else if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("SHOWDATA"))
    {
        context.Response.Write("<table><tr><td>Selected Text: </td><td><textarea cols=\"20\" rows = \"10\">" + strSelectedText + "</textarea></td></tr><tr><td>" + "Selected Value: </td><td><textarea cols=\"20\" rows = \"10\">" + strSelectedValue + "</textarea></td></tr></table>");
    }
    else
    {
        context.Response.Write("-2");
    }
}
 
    public bool IsReusable {
        get {
            return false;
        }
    }


    private List<Country> GetCountries()
    {
        List<Country> countries = new List<Country>();
        for (int iCtr = 0; iCtr < 200; iCtr++)
        {
            countries.Add(new Country(iCtr, "Country" + iCtr));
        }
        return countries;
    }

    private String CreateCountrySelectOptions(List<Country> PrmCountry)
    {
        System.Text.StringBuilder strBldOptions = new System.Text.StringBuilder();
        foreach (Country country in PrmCountry)
        {
            strBldOptions.Append("<li><input type=\"checkbox\" id=\"chk_" + country.I32Id + "\" value=\"" + country.I32Id + "\" text=\"" + country.StrName + "\">" + country.StrName + "</li>");
        }
        return strBldOptions.ToString();
    }

    private String CreateCountrySelectList(List<Country> PrmCountry)
    {
        System.Text.StringBuilder strBldOptions = new System.Text.StringBuilder("<ol id=\"LstCountries2\">");
        foreach (Country country in PrmCountry)
        {
            strBldOptions.Append("<li><input type=\"checkbox\" id=\"chk_" + country.I32Id + "\" value=\"" + country.I32Id + "\" text=\"" + country.StrName + "\">" + country.StrName + "</li>");
        }
        strBldOptions.Append("</ol>");
        return strBldOptions.ToString();
    }

}