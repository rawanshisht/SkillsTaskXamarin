
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkillsTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillsDetailView : ContentPage
    {
        public SkillsDetailView(int id, string name, int level, string desc)
        {
            InitializeComponent();
            this.FindByName<Entry>("myNameEntry").Text = name;
            this.FindByName<Entry>("myLevelEntry").Text = level.ToString();
            this.FindByName<Editor>("myDescEntry").Text = desc;
        }
        
    }
}