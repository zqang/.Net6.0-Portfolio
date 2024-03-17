using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.Data.Repositories.Author;
using PortfolioAPI.Data.Repositories.User;
using PortfolioAPI.Models;

namespace PortfolioAPI.Handlers.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserRepository _userRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IUserRepository userRepository)
        {
            _authorRepository = authorRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Models.Author(request.Id,request.UserID,request.Name,request.Bio);

            var user = await _userRepository.GetByIdAsync(request.UserID);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            author.Email = user.Email;
            author.RegistrationDate = DateTime.Now;
            author.Status = user.Status;
            author.User = user;

            await _authorRepository.AddAsync(author);

            return author.AuthorID;
        }
    }
}
