using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaTableGroup 
{
    public List<ToyotaProcessTable> TableGroup { get; set; }
    public string CreationDate { get; set; } 
    public int HiddenProcessCount { get; set; } 
    public int HiddenEmployersCount { get; set; } 
    public int TotalTables { get; set; }
    public int TotalProcess { get; set; }
    public int TotalEmployers { get; set; }
    public int MediaEmployersPerProcess { get; set; }

    public ToyotaTableGroup(
        string CreationDate,
        List<ToyotaProcessTable> TableGroup, 
        int TotalTables,
        int TotalEmployers,
        int MediaEmployersPerProcess,
        int HiddenProcessCount,
        int HiddenEmployersCount)
    {
        this.TableGroup = TableGroup;
        this.CreationDate = CreationDate;
        this.HiddenProcessCount = HiddenProcessCount;
        this.HiddenEmployersCount = HiddenEmployersCount;

        this.TotalTables = TotalTables;
        TotalProcess = TotalTables;
        this.TotalEmployers = TotalEmployers;
        this.MediaEmployersPerProcess = MediaEmployersPerProcess;
    }
}
