using System;

namespace UI_MVC.Validators.Rules
{
    public static class CustomRules
    {
        public static bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}