

namespace MyProject.Models
{
    public class Inventory : BindableBase
    {
        private int _id { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        private string _name { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private Condition _Condition { get; set; }
        public Condition Condition
        {
            get => _Condition;
            set
            {
                _Condition = value;
                RaisePropertyChanged(nameof(Condition));
            }
        }

    }


}
