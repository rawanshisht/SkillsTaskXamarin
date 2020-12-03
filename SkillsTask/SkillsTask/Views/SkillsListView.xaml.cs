using SkillsTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkillsTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillsListView : ContentPage
    {
        public SkillsListView()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedSkill = e.Item as Skill;
            var newPage = new SkillsDetailView(selectedSkill.ID, selectedSkill.Name, selectedSkill.Level, selectedSkill.Descritpion);
            newPage.BindingContext = selectedSkill;
            await Application.Current.MainPage.Navigation.PushAsync(newPage);
        }
    }
}