using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bootstrap.AspNetCore.Mvc.TagHelpers.Extensions
{
    public static class TagHelperContextExtensions
    {
        public static ButtonGroupContext GetButtonGroupContext(this TagHelperContext context)
        {
            return context.GetContext<ButtonGroupContext>();
        }
        public static DropdownContext GetDropdownContext(this TagHelperContext context)
        {
            return context.GetContext<DropdownContext>();
        }

        public static void InsertContext<TContext>(this TagHelperContext context, TContext contextToInsert)
            where TContext : class
        {
            context.Items.Add(typeof(TContext), contextToInsert);
        }

        private static TContext GetContext<TContext>(this TagHelperContext context)
            where TContext : class
        {
            if (context.Items.ContainsKey(typeof(TContext)))
            {
                return context.Items[typeof(TContext)] as TContext;
            }

            return default(TContext);
        }
    }
}