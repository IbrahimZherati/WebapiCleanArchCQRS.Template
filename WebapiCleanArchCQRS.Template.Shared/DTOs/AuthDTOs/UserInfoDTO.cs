using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebapiCleanArchCQRS.Template.Application.DTOs.AuthDTOs
{
    public class UserInfoDTO
    {
        public bool IsAuthenticated { get; set; }
        public string? UserName { get; set; }

        public string? Json { get; set; }
        public List<KeyValuePair<string, string>>? ExposedClaims { get; set; } // Work Without Json Error
    }
}
