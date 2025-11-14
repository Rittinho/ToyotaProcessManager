using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation.Repository;
public partial class RepositoryServices
{
    public List<ToyotaTableGroup> GetAllTables()
    {
        RefreshLists();
        return _tableData;
    }
    public ToyotaTableGroup GetFirstTable()
    {
        RefreshLists();
        return _tableData.FirstOrDefault();
    }
    public ToyotaTableGroup GetLastTable()
    {
        RefreshLists();
        return _tableData.LastOrDefault();
    }
    public bool SaveNewTableGroup(ToyotaTableGroup newTableGroup)
    {
        if(newTableGroup is null)
            return false;

        RefreshLists();
        _tableData.Add(newTableGroup);
        _jsonServices.SaveTableGroupJson(_tableData);
        RefreshLists();

        return true;
    }
    public bool RemoveTableGroup(ToyotaTableGroup TableGroup)
    {
        if (TableGroup is null)
            return false;

        RefreshLists();
        _tableData.Remove(TableGroup);
        RefreshLists();

        return true;
    }
}