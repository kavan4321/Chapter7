
using Chapter7.Tables.Page4Table;

namespace Chapter7.Template.ActivityTemp
{
    public class ActivityTemplate : DataTemplateSelector
    {
        public DataTemplate ComplateTemplate { get; set; }
        public DataTemplate InComplateTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var Items = (ActivityTable)item;

            if (Items.IsComplete == true)
            {
                return ComplateTemplate;

            }
            else
            {
                return InComplateTemplate;
            }
        }
    }
}
