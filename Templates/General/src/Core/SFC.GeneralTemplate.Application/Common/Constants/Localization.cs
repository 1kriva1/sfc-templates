using System.Text;

using Microsoft.Extensions.Localization;

namespace SFC.GeneralTemplate.Application.Common.Constants;
public class Localization
{
    private static IStringLocalizer<Resources> s_localizer = default!;

    public Localization(IStringLocalizer<Resources> localizer)
    {
        s_localizer ??= localizer;
    }

    public static void Configure(IStringLocalizer<Resources> localizer)
    {
        s_localizer = localizer;
    }

    public static string SuccessResult =>
                    GetValue(s_localizer?.GetString("SuccessResult"),
                        "Success result.")!;

    public static string FailedResult =>
                       GetValue(s_localizer?.GetString("FailedResult"),
                           "Failed result.")!;

    public static string ValidationError =>
                    GetValue(s_localizer?.GetString("ValidationError"),
                        "Validation error.")!;

    public static string RequestBodyRequired =>
                        GetValue(s_localizer?.GetString("RequestBodyRequired"),
                            "Request body is required.")!;

    public static string AuthorizationError =>
                    GetValue(s_localizer?.GetString("AuthorizationError"),
                        "Authorization error.")!;

    public static string FileExtensionInvalid =>
                      GetValue(s_localizer?.GetString("FileExtensionInvalid"),
                          "Invalid file extension.")!;

    public static string MustBeUnique =>
                      GetValue(s_localizer?.GetString("MustBeUnique"),
                          "Each value from '{PropertyName}' must be unique.")!;

    public static string MustBeGreaterThan =>
                    GetValue(s_localizer?.GetString("MustBeGreaterThan"),
                        "'{0}' value must be greater than {1} value.")!;

    public static string MustBeLessThan =>
                     GetValue(s_localizer?.GetString("MustBeLessThan"),
                         "'{0}' value must be less than {1} value.")!;

    public static string DataValidator =>
                     GetValue(s_localizer?.GetString("DataValidator"),
                         "'{PropertyName}' has a range of values which does not include '{PropertyValue}'.")!;

    public static string MustBeInDataRange =>
                     GetValue(s_localizer?.GetString("MustBeInDataRange"),
                         "Each value from '{PropertyName}' must be in available data range.")!;

    public static string MustNotExceedSize =>
                      GetValue(s_localizer?.GetString("MustNotExceedSize"),
                          "The length of '{0}' must be less or equal to {1}.")!;

    public static string TimeOutError =>
                    GetValue(s_localizer?.GetString("TimeOutError"),
                        "The timeout to complete the request has expired.")!;

    public static string GeneralTemplateNotFound =>
                    GetValue(s_localizer?.GetString("GeneralTemplateNotFound"),
                        "GeneralTemplate not found.")!;

    private static string GetValue(LocalizedString? @string, string defaultValue)
    {
        return @string == null
            ? defaultValue
            : @string.ResourceNotFound
            ? defaultValue
            : @string.Value;
    }
}
