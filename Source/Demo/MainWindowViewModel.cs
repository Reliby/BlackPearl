using BlackPearl.Controls.Contract;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BlackPearl.Controls.Demo
{
  public class MainWindowViewModel: BindableBase
  {
    private List<Person> FSelectedItems;
    public MainWindowViewModel()
    {
      Source = new List<Person>(PersonDataProvider.GetDummyData());
      FSelectedItems = new List<Person>() { Source.FirstOrDefault() };
      SelectedItems2 = new List<Person>();
      ShowSelectedItemCommand = new DelegateCommand<IList<Person>>(ShowSelectedItemCommandAction);
      AdvanceLookUpContract = new AdvanceLookUpContract();
      AddItemCommand = new DelegateCommand<IList<Person>>(AddItemCommandAction);
    }

    public List<Person> Source { get; set; }
    public List<Person> SelectedItems { get => FSelectedItems; set => SetSelectedItems(value); }
    public List<Person> SelectedItems2 { get; set; }
    public ICommand ShowSelectedItemCommand { get; set; }
    public ILookUpContract AdvanceLookUpContract { get; }
    public ICommand AddItemCommand { get; set; }

    private void ShowSelectedItemCommandAction(IList<Person> data)
    {
      var stringBuilder = new StringBuilder();

      foreach (Person p in data)
      {
        stringBuilder.AppendLine(p.Name);
      }

      MessageBox.Show(stringBuilder.ToString(), "Selected items");
    }

    private void AddItemCommandAction(IList<Person> data)
    {
      //data.Add(Source.FirstOrDefault());
      //SelectedItems = (List<Person>)data;
      List<Person> Pepe = new List<Person>() { Source.FirstOrDefault() };
      SelectedItems = Pepe;
    }

    private void SetSelectedItems(List<Person> value)
    {
      FSelectedItems = value;
      RaisePropertyChanged("SelectedItems");
    }

  }
}
