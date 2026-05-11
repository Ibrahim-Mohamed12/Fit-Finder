using DAL.Entities;
using DAL.Entities.Enums;

namespace FitFinderProject.PL.Models
{
    public class PlanViewModel
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public billing_cycle billing_Cycle { get; set; }

        public string Description { get; set; }
        public string? GymId { get; set; }
    }

    public static class PlanViewModelExtensions
    {
        public static PlanViewModel ToViewModel(this Plan plan)
        {
            return new PlanViewModel
            {
                Id = plan.Id,
                Price = plan.Price,
                billing_Cycle = plan.billing_Cycle,
                Description = plan.Description,
                GymId = plan.GymId
            };
        }

        public static Plan ToPlan(this PlanViewModel viewModel)
        {
            return new Plan
            {
                Id = viewModel.Id,
                Price = viewModel.Price,
                billing_Cycle = viewModel.billing_Cycle,
                Description = viewModel.Description,
                GymId = viewModel.GymId
            };
        }
    }
}
