using DAL.Entities;

namespace FitFinderProject.PL.Models
{
    public class GymViewModel
    {
        public string Location { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CoverImageUrl { get; set; } = null!;

        public TimeOnly OpenTime { get; set; }

        public TimeOnly CloseTime { get; set; }

        public string? OwnerId { get; set; }

    }

    public static class GymViewModelExtensions
    {
        public static GymViewModel ToViewModel(this Gym gym)
        {
            return new GymViewModel
            {
                Location = gym.Location,
                Description = gym.Description,
                CoverImageUrl = gym.CoverImageUrl,
                OpenTime = gym.OpenTime,
                CloseTime = gym.CloseTime,
                OwnerId = gym.OwnerId
            };
        }

        public static Gym ToGym(this GymViewModel viewModel)
        {
            return new Gym
            {
                Location = viewModel.Location,
                Description = viewModel.Description,
                CoverImageUrl = viewModel.CoverImageUrl,
                OpenTime = viewModel.OpenTime,
                CloseTime = viewModel.CloseTime,
                OwnerId = viewModel.OwnerId
            };
        }
    }
}
