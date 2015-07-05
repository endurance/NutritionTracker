using System;
using FoodTracker.ViewModel;
using Caliburn.Micro;
namespace FoodTracker.Model
{
    public class FoodItem : PropertyChangedBase 
    {
        public FoodItem()
        {
            Id = Guid.NewGuid();
            Name = "";
            ImperialServing = new ImperialServing();
            MetricServing = new MetricServing();
            FoodMacros = new Macronutrient();
        }

        public override string ToString()
        {
            return Name + " " + ImperialServing + " " + MetricServing + " " + FoodMacros;
        }

        #region Properties

        public Guid Id {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            } 
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public ImperialServing ImperialServing
        {
            get { return _impServing; }
            set
            {
                _impServing = value;
                NotifyOfPropertyChange(() => ImperialServing);
            }
        }

        public MetricServing MetricServing
        {
            get { return _metricServing; }
            set
            {
                _metricServing = value;
                NotifyOfPropertyChange(() => MetricServing);
            }
        }

        public Macronutrient FoodMacros
        {
            get { return _foodMacros; }
            set
            {
                _foodMacros = value;
                NotifyOfPropertyChange(() => FoodMacros);
            }
        }

        #endregion

        private Guid _id;
        private string _name;
        private ImperialServing _impServing;
        private MetricServing _metricServing;
        private Macronutrient _foodMacros;

    }
}