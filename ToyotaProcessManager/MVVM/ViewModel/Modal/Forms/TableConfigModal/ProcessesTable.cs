using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
public partial class TableConfigModalViewModel
{
    [ObservableProperty]
    private string _searchProcessText;

    public List<ToyotaProcess> ProcessList { get; set; } = [];
    public ObservableCollection<ToyotaProcess> FiltredProcessList { get; set; } = [];
    public List<ToyotaProcess> HiddenProcessList { get; set; } = [];

    partial void OnSearchProcessTextChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            FiltredProcessList.Clear();
            foreach (var item in ProcessList)
                FiltredProcessList.Add(item);
            return;
        }

        var filtered = ProcessList
            .Where(x => x.Title.StartsWith(value, StringComparison.OrdinalIgnoreCase))
            .ToList();

        FiltredProcessList.Clear();
        foreach (var item in filtered)
            FiltredProcessList.Add(item);
    }
}