using System;
using System.Collections.Generic;

public class Quarter
{
    public string StartDate { get; }
    public string EndDate{ get; }
    

    private static readonly List<List<string>> quarters = new List<List<string>>
    {
        new List<string> { "01-01", "31-03" },
        new List<string> { "01-04", "30-06" },
        new List<string> { "01-07", "30-09" },
        new List<string> { "01-10", "31-12" }
    };

    private Quarter(string startTime, string endTime, string year)
    {
        StartDate =  startTime + "-" + year;
        EndDate = endTime + "-" + year;
      

    }

    public static Quarter GetQuarter(string quarter, string year)
    {
        switch (quarter)
        {
            case "Q1":
                return new Quarter(quarters[0][0], quarters[0][1], year);
            case "Q2":
                return new Quarter(quarters[1][0], quarters[1][1], year);
            case "Q3":
                return new Quarter(quarters[2][0], quarters[2][1],  year);
            case "Q4":
                return new Quarter(quarters[3][0], quarters[3][1], year);
            default:
                return new Quarter("00:00", "00:00",    year);
        }
    }
}
