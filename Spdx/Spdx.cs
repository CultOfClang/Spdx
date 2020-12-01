using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Text.Json;
using System.IO;
using System.Reflection;

namespace Spdx
{
    public static class Spdx
    {
        public static IReadOnlyCollection<License> Licenses
        {
            get
            {
                return Load().Licenses;
            }
        }
        public static LicensesData Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Spdx.licenses.json";


            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<LicensesData>(json);
            }
        }
    }
}
