namespace FitFinderProject.PL.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Gender { get; set; }
        public string Address { get; set; }
        public string GymName { get; set; }
        public string PlanName { get; set; }

        public int SubscriptionId { get; set; }
    }
}
