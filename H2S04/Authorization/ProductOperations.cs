using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace H2S04.Authorization
{
    public static class ProductOperations
    {
        public static OperationAuthorizationRequirement Create =
          new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
    }

    public static class Constants
    {
        public static readonly string CreateOperationName = "Create";

        public static readonly string ReadOperationName = "Read";

        public static readonly string UpdateOperationName = "Update";

        public static readonly string DeleteOperationName = "Delete";

        public static readonly string ProductAdministratorsRole = "ProductAdministrators";

        public static readonly string ProductManagersRole = "ProductManagers";
    }

}
