using System;
using System.IO;
using System.Security.Claims;
using Microsoft.Graph;

namespace myhealthhub.web.Services.Graph
{
    // Helper methods to access Graph user data stored in the claims principal
    public static class GraphClaimsPrincipalExtensions
    {
        public static string GetUserGraphDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.DisplayName);
        }

        public static string GetUserGraphGivenName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.GivenName);
        }

        public static string GetUserGraphEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.Email);
        }

        public static string GetUserGraphPhoto(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.Photo);
        }

        public static string GetUserGraphTimeZone(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.TimeZone);
        }

        public static string GetUserGraphTimeFormat(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.TimeFormat);
        }

        public static string GetUserJobTitle(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.JobTitle);
        }

        public static string GetUserPhone(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.Phone);
        }

        public static string GetUserOfficeLocation(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(GraphClaimTypes.OfficeLocation);
        }

        public static void AddUserGraphInfo(this ClaimsPrincipal claimsPrincipal, User user)
        {
            var identity = claimsPrincipal.Identity as ClaimsIdentity;

            identity.AddClaim(new Claim(GraphClaimTypes.DisplayName, user.DisplayName));
            identity.AddClaim(new Claim(GraphClaimTypes.GivenName, user.GivenName));
            identity.AddClaim(new Claim(GraphClaimTypes.Email, user.Mail ?? user.UserPrincipalName));
            // identity.AddClaim(new Claim(GraphClaimTypes.TimeZone, user.MailboxSettings.TimeZone));
            // identity.AddClaim(new Claim(GraphClaimTypes.TimeFormat, user.MailboxSettings.TimeFormat));
            identity.AddClaim(new Claim(GraphClaimTypes.JobTitle, user.JobTitle));
            // identity.AddClaim(new Claim(GraphClaimTypes.Phone, user.MobilePhone));
            // identity.AddClaim(new Claim(GraphClaimTypes.OfficeLocation, user.OfficeLocation));
        }

        public static void AddUserGraphPhoto(this ClaimsPrincipal claimsPrincipal, Stream photoStream)
        {
            var identity = claimsPrincipal.Identity as ClaimsIdentity;

            if (photoStream == null)
            {
                // Add the default profile photo
                identity.AddClaim(new Claim(GraphClaimTypes.Photo, "/img/no-profile-pic-icon-12.png"));
                return;
            }

            // Copy the photo stream to a memory stream
            // to get the bytes out of it
            var memoryStream = new MemoryStream();
            photoStream.CopyTo(memoryStream);
            var photoBytes = memoryStream.ToArray();

            // Generate a date URI for the photo
            var photoUrl = $"data:image/png;base64,{Convert.ToBase64String(photoBytes)}";

            identity.AddClaim(new Claim(GraphClaimTypes.Photo, photoUrl));
        }
    }
}