using AutoMapper;
using MediatR;
using Portfolio.CommandsQueries;
using Portfolio.Dtos;
using Portfolio.Exceptions;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Handlers
{
    public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand, Unit>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(request.Id);

            if (blogPost == null)
            {
                throw new NotFoundException(nameof(BlogPost), request.Id);
            }

            await _blogPostRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }

}