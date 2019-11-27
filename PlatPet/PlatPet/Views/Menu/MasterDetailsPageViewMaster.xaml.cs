using PlatPet.Views.Cadastros;
using PlatPet.Views.Visualizacao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailsPageViewMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailsPageViewMenuItem[] OpcoesMenu
        {
            get;
            set;
        }

        public MasterDetailsPageViewMaster()
        {
            InitializeComponent();
            OpcoesMenu = new[] 
            {
                new MasterDetailsPageViewMenuItem {Id = 0, Title = "Menu",
                    TargetType = typeof(TabbedPageViewTelaInicial)}

                ,                

                new MasterDetailsPageViewMenuItem {Id = 0, Title = "Lista Pets",
                    TargetType = typeof(ContentListViewPet),
                    IconSource = "pata.png",}

                ,

                new MasterDetailsPageViewMenuItem {Id = 0, Title = "Agenda de Consultas",
                    TargetType = typeof(ContentPageViewAgendarConsulta),
                    IconSource = "calendario.png",}
                ,

                new MasterDetailsPageViewMenuItem {Id = 0, Title = "Forma Pagamento",
                    TargetType = typeof(ContentPageCadastroFormaPagamentoView),
                    IconSource = "cartao.png"
                ,}

        };
            ListView = MenuItemsListView;
            BindingContext = this;
        }

        class MasterDetailsPageViewMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailsPageViewMenuItem> MenuItems { get; set; }
            
            public MasterDetailsPageViewMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailsPageViewMenuItem>(new[]
                {
                    new MasterDetailsPageViewMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailsPageViewMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailsPageViewMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailsPageViewMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailsPageViewMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}