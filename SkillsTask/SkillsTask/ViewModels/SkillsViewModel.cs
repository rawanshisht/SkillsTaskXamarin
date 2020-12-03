using SkillsTask.Models;
using SkillsTask.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SkillsTask.ViewModels
{
    public class SkillsViewModel : ViewModelBase
    {
        public ICommand OutputNameCommand { get; private set; }
        
        public string SelectedItemText { get; private set; }

        private ObservableCollection<Skill> _list;

        public ObservableCollection<Skill> SkillsList
        {
            get
            {

                return _list;
            }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(_list));
            }
        }

        private Skill _selectedSkill;

        public SkillsViewModel()
        {
            //SkillsList = new ObservableCollection<Skill>() { new Skill() { Name = "test", Descritpion = "desc", Level = 20 } };
            OutputNameCommand = new Command<Skill>(OutputName);
            SkillsList = App.Database.GetSkillsAsync();
            // _selectedSkill = new Skill();
        }

        private ICommand _updateCommand;
        public ICommand UpdateCommand => _updateCommand ?? (_updateCommand = new Command((obj)=> {
            
            handleUpdate();
        }, e=> true));

        async void handleUpdate()
        {
            // App.Database.UpdateSkill(SelectedSkill);
            //Application.Current.MainPage.Navigation.PushAsync(new SkillsListView());
            Debug.WriteLine("Updateeeee");
        }
        void OutputName(Skill skill)
        {
           // Application.Current.MainPage.Navigation.PushAsync(new SkillsDetailView());

            SelectedItemText = string.Format("{0}", skill.Name);
            OnPropertyChanged("SelectedItemText");
            var vm = new SkillsDetailsViewModel();
            vm.x = SelectedItemText;
        }
        public Skill SelectedSkill
        {
            get
            {
                return _selectedSkill;
            }
            set
            {
                _selectedSkill = value;
                OnPropertyChanged(nameof(_selectedSkill));
                //HandleSelectItem();

            }

        }
        private void HandleSelectItem()
        {
           // var vm = new SkillsDetailsViewModel();
            //vm.SelectedSkill = SelectedSkill;
        }

        //public List<Skill> GetSkills()
        //{
        //    return SkillsList;
        //}
        //private void Add()
        //{
        //    var skills = App.Database.GetSkillsAsync().Result;
        //    foreach (var skill in skills)
        //    {
        //        SkillsList.Add(skill);
        //    }
        //}

    }
}
