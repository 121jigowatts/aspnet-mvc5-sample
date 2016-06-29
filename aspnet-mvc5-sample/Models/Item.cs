using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Models
{
    public class Item
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime? Deadline { get; set; }
        public bool Completed { get; set; }


        public bool IsExpiration(DateTime? now = null)
        {
            //期限が存在しない場合、falseを返す
            if (this.Deadline == null)
            {
                return false;
            }

            //完了済みの場合、falseを返す
            if (this.Completed)
            {
                return false;
            }

            if (now == null)
            {
                now = DateTime.Now;
            }

            if (now < this.Deadline)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }

    }
    
}
