//using Project.DAL.Entities;

//namespace Project.ViewModels
//{
//    public class AdminDashboardViewModel
//    {
//        public decimal TotalRevenue { get; set; }
//        public int BouquetOrdersCount { get; set; }
//        public int PendingEventsCount { get; set; }
//        public int TotalClientsCount { get; set; }

//        // قائمة الطلبات للعرض في الجدول
//        public IEnumerable<EventRequest>? RecentEventRequests { get; set; }
//    }
//}

using System.Collections.Generic;
using Project.DAL.Entities;

namespace Project.ViewModels
{
    public class AdminDashboardViewModel
    {
        public decimal TotalRevenue { get; set; }
        public int BouquetOrdersCount { get; set; }
        public int PendingEventsCount { get; set; }
        public int TotalClientsCount { get; set; }

        public IEnumerable<EventRequest>? RecentEventRequests { get; set; }
    }
}