using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Views
{

    public class MasterDetailsPageViewMenuItem
    {
        /*public MasterDetailsPageViewMenuItem()
        {
            TargetType = typeof(MasterDetailsPageViewDetail);
        }*/
        public int Id { get; set; }
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}