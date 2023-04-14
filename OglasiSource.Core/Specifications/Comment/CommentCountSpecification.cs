using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Specifications.Comment
{
    public class CommentCountSpecification : BaseSpecification<Entities.Comment>
    {
        public CommentCountSpecification(CommentSpecParams commentSpecParams) : base(x =>
            (!commentSpecParams.UserId.HasValue )
        )
        {

        }
    }
}
