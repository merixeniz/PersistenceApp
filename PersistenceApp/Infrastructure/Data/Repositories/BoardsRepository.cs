using Application.Interfaces.DataAccess;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class BoardsRepository : EfRepository<Board>, IBoardsRepository
    {
        private readonly IMapper _mapper;

        public BoardsRepository(PersistenceDbContext dbContext,
                                IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<GetBoardsDto>> GetBoardsAsync(CancellationToken token)
        {
            List<GetBoardsDto> boards = new List<GetBoardsDto>();

            var boardNames = await _dbContext.Boards
                                       .Select(x => x.Name)
                                       .Distinct()
                                       .ToListAsync(token);

            foreach (var boardName in boardNames)
            {
                var tmpList = _dbContext.Boards
                                .Where(x => x.Name == boardName)
                                .OrderByDescending(x => x.Version)
                                .Take(2)
                                .ProjectTo<GetBoardsDto>(_mapper.ConfigurationProvider);

                boards.AddRange(tmpList);
            }
            return boards;
        }

        public async Task<List<GetBoardsDto>> GetBoardsByNameAsync(string boardName, CancellationToken token)
        {
            return await _dbContext.Boards
                            .Where(x => x.Name == boardName)
                            .OrderByDescending(x => x.Version)
                            .ProjectTo<GetBoardsDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(token);
        }
    }
}
