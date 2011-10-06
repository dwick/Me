namespace Me.Web.Mvc.Infrastructure.Mapping.Resolvers
{
    #region using

    using System;

    #endregion

    public static class GuidResolver
    {
        public static Guid Resolve(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid guidValue;

                Guid.TryParse(id, out guidValue);

                if(guidValue != Guid.Empty)
                {
                    return guidValue;
                }
            }
            throw new Exception();
        }
    }
}
