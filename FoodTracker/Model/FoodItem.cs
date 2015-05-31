using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
   public class FoodItem
   {
      private long id;
      private string m_name;
      private ImperialServing impServing;
      private MetricServing metServing;
      private CalorieSet foodMacros;

      public FoodItem()
      {
         id = -1;
         m_name = "";
         impServing = new ImperialServing();
         metServing = new MetricServing();
         foodMacros = new CalorieSet();
      }

      public override String ToString()
      {
         return Name + " " + ImperialServing + " " + MetricServing + " " + FoodMacros;
      }

      #region Properties
      public long Id
      {
         get { return id; }
         set { id = value; }
      }
      public string Name
      {
         get { return m_name; }
         set { m_name = value; }
      }

      public ImperialServing ImperialServing
      {
         get { return impServing; }
         set { impServing = value; }
      }

      public MetricServing MetricServing
      {
         get { return metServing; }
         set { metServing = value; }
      }

      public CalorieSet FoodMacros
      {
         get { return foodMacros; }
         set { foodMacros = value; }
      }
      #endregion
   }
}
