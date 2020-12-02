using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Reflection;

namespace Spdx
{
    public static class Spdx
    {
        static readonly Lazy<License[]> licenses = new Lazy<License[]>(() => Load<LicensesData>("Spdx.licenses.json").Licenses);
        public static IReadOnlyCollection<License> Licenses => licenses.Value;
        public static IReadOnlyCollection<LicenseException> Exceptions => exceptions.Value;

        static readonly Lazy<LicenseException[]> exceptions = new Lazy<LicenseException[]>(() => Load<LicensesData>("Spdx.exceptions.json").Exceptions);


        public static LicenseExpression Parse(string spdx)
        {
            throw new NotImplementedException();
        }

        internal static T Load<T>(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var yes = assembly.GetManifestResourceNames();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
