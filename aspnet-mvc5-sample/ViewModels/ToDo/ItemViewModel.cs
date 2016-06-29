using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.ViewModels.ToDo
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Deadline { get; set; }
        public bool Completed { get; set; }
        public String Expiration { get; set; }

        public void SetFromModel(Item model)
        {
            this.ID = model.ID;
            this.Title = model.Title;
            this.Description = model.Description;
            this.Deadline = model.Deadline.ToString();
            this.Completed = model.Completed;
            this.Expiration = model.IsExpiration() ? "期限切れ" : string.Empty;
        }

        public Item ConvertToModel()
        {
            var model = new Item();
            model.ID = this.ID;
            model.Title = this.Title;
            model.Description = this.Description;
            model.Deadline = String.IsNullOrEmpty(this.Deadline) ?
                new Nullable<DateTime>() : DateTime.Parse(this.Deadline);


            model.Completed = this.Completed;

            return model;
        }
    }
}
