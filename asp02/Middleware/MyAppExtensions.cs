using Microsoft.AspNetCore.Builder;

namespace asp02 {
    public static class MyAppExtensions
    {
        // Mở rộng cho IApplicationBuilder phương thức UseCheckAccess
         public static IApplicationBuilder useFirstMiddleWare(this IApplicationBuilder builder)
         {
             return builder.UseMiddleware<FirstMiddleware>();
         }
    }
}