using DAL.Entities;

namespace FitFinderProject.PL.Models
{
    public class OwnerDashboardViewModel
    {
        public int TotalGyms { get; set; }
        public int TotalMembers { get; set; }
        public int TotalSubscriptions { get; set; }

        public decimal MonthlyRevenue { get; set; } // Average revenue per month
        public decimal TotalRevenue { get; set; } // Total revenue generated from all subscriptions

        public decimal ThisMonthRevenue { get; set; } // Revenue generated in the current month

        public string MostPopularGym { get; set; } // Name of the gym with the most members

        public string TopPlan { get; set; } // Name of the most popular subscription plan

        public List<GymViewModel> Gyms { get; set; } = new List<GymViewModel>();

        public List<PlanViewModel> Plans { get; set; } = new List<PlanViewModel>();

        public List<MemberViewModel> RecentMembers { get; set; } = new List<MemberViewModel>();

    }
}
